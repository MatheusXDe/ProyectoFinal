using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBarbarian : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerInput playerInput;
    private Animator animator;
    public new Transform camera;
    public LayerMask groundLayer;
    public float rayDistance;
    private Vector2 inputs;
    [SerializeField] private float moveSpeed = 20;
    [SerializeField] private float gravity = -0.9f;
    [SerializeField] private float fallVelocity;
    public float jumpForce;
    private Collider axeCollider;
    bool axeAtack;
    private Vector3 velocity = Vector3.zero;

    public AudioSource footstepAudioSource;
    [SerializeField] private float stepDelay = 0.5f;
    private float stepTimer;

    [Header("Attack Sound")]
    [SerializeField] private AudioClip axeSwingSound;
    [SerializeField] private AudioSource attackAudioSource;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        axeCollider = GameObject.FindGameObjectWithTag("AxeBarbarian").GetComponent<Collider>();
        axeCollider.GetComponent<Collider>().enabled = false;
        axeAtack = animator.GetBool("Atack");
    }

    void Update()
    {
        inputs = playerInput.actions["Move"].ReadValue<Vector2>();
        if (playerInput.actions["Jump"].WasPressedThisFrame() && IsOnGround())
        {
            Jump();
            animator.SetBool("Jump", true);
        }
        if (Input.GetKeyDown(KeyCode.F) && axeAtack == false)
        {
            animator.SetBool("Atack", true);

            // Reproducir sonido de ataque
            if (attackAudioSource != null && axeSwingSound != null)
            {
                attackAudioSource.PlayOneShot(axeSwingSound);
            }
        }
    }

    void FixedUpdate()
    {
        Movement();
        animator.SetBool("Atack", false);

        if (!IsOnGround())
        {
            velocity.y += gravity * Time.fixedDeltaTime;
        }
        else
        {
            velocity.y = 0;
            animator.SetBool("Jump", false);
        }

        characterController.Move(velocity * Time.fixedDeltaTime);

        if ((inputs.x != 0 || inputs.y != 0) && IsOnGround())
        {
            stepTimer += Time.fixedDeltaTime;
            if (stepTimer >= stepDelay)
            {
                footstepAudioSource.Play();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = stepDelay;
        }
    }

    void Movement()
    {
        Vector3 movement = Vector3.zero;
        float movementSpeed = 0;
        if (inputs.x != 0 || inputs.y != 0)
        {
            Vector3 forward = camera.forward;
            forward.y = 0;
            forward.Normalize();
            Vector3 right = camera.right;
            right.y = 0;
            right.Normalize();

            Vector3 direction = forward * inputs.y + right * inputs.x;
            movementSpeed = Mathf.Clamp01(direction.magnitude);
            direction.Normalize();

            movement = direction * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.3f);
        }

        characterController.Move(movement);
        animator.SetFloat("Speed", movementSpeed);
    }

    void Jump()
    {
        if (IsOnGround())
        {
            velocity.y = jumpForce;
        }
        Vector3 jumpVelocity = Vector3.up * jumpForce;
        characterController.Move(jumpVelocity * Time.fixedDeltaTime);
    }

    bool IsOnGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayDistance, groundLayer);
    }

    void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.red);
    }

    void GoAtack()
    {
        moveSpeed = 0;
    }

    void AxeContact()
    {
        axeCollider.GetComponent<Collider>().enabled = true;
    }

    void EndContact()
    {
        axeCollider.GetComponent<Collider>().enabled = false;
    }

    void EndAtack()
    {
        moveSpeed = 20;
        animator.SetBool("Atack", false);
    }

    void JumpFalse()
    {
        animator.SetBool("Jump", false);
    }

    // 🔊 Puedes llamar este método desde un evento de animación para más precisión
    public void PlayAxeSound()
    {
        if (attackAudioSource != null && axeSwingSound != null)
        {
            attackAudioSource.PlayOneShot(axeSwingSound);
        }
    }
}
