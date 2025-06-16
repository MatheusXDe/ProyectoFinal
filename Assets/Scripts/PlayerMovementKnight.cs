using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementKnight : MonoBehaviour
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

    private Collider SwordCollider;
    bool swordAtack;
    private Vector3 velocity = Vector3.zero;

    
    public AudioSource footstepAudioSource;
    [SerializeField] private float stepDelay = 0.5f;
    private float stepTimer;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        SwordCollider = GameObject.FindGameObjectWithTag("SwordKnight").GetComponent<Collider>();
        SwordCollider.GetComponent<Collider>().enabled = false;
        swordAtack = animator.GetBool("Atack");
        stepTimer = stepDelay;
    }

    void Update()
    {
        inputs = playerInput.actions["Move"].ReadValue<Vector2>();
        if (playerInput.actions["Jump"].WasPressedThisFrame() && IsOnGround())
        {
            Jump();
            animator.SetBool("Jump", true);
        }

        if (Input.GetKeyDown(KeyCode.F) && swordAtack == false)
        {
            animator.SetBool("Atack", true);
        }
    }

    void FixedUpdate()
    {
        Movement();

        animator.SetBool("Atack", false);

        // Movimiento vertical
        if (!IsOnGround())
        {
            velocity.y += gravity * Time.fixedDeltaTime;
        }
        else
        {
            velocity.y = 0; // Reiniciar la velocidad vertical cuando esté en el suelo
            animator.SetBool("Jump", false);

        }
        // Aplicar la velocidad al CharacterController
        characterController.Move(velocity * Time.fixedDeltaTime);

        // Reproducción de pasos 
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

    public void Movement()
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

            Vector3 direction = (forward * inputs.y) + (right * inputs.x);
            movementSpeed = Mathf.Clamp01(direction.magnitude);
            direction.Normalize();

            movement = direction * moveSpeed * movementSpeed * Time.deltaTime;
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

    void SwordContact()
    {
        SwordCollider.GetComponent<Collider>().enabled = true;
    }

    void EndContact()
    {
        SwordCollider.GetComponent<Collider>().enabled = false;
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
}
