using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementRogue : MonoBehaviour
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
    bool rogueAtack;
    public GameObject roguePrefab;
    private Transform armRogue;
    private Vector3 velocity = Vector3.zero;





    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rogueAtack = animator.GetBool("Atack");
        armRogue = GameObject.FindGameObjectWithTag("ArmRogue").GetComponent<Transform>();

    }


    void Update()
    {
        inputs = playerInput.actions["Move"].ReadValue<Vector2>();
        if (playerInput.actions["Jump"].WasPressedThisFrame() && IsOnGround())
        {
            Jump();
            animator.SetBool("Jump", true);
        }
        if (Input.GetKeyDown(KeyCode.F) && rogueAtack == false)
        {
            animator.SetBool("Atack", true);

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
            velocity.y = 0; // Reiniciar la velocidad vertical cuando esté en el suelo
            animator.SetBool("Jump", false);
        }
        // Aplicar la velocidad al CharacterController
        characterController.Move(velocity * Time.fixedDeltaTime);

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
            forward.y = 0;
            forward.Normalize();

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


    void OnDrawGizmos() // Dibujar el raycast en el editor para depuración visual
    {
        Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.red);
    }
    void GoAtack()
    {
        moveSpeed = 0;

    }

    void EndAtack()
    {
        moveSpeed = 20;
        animator.SetBool("Atack", false);
    }
    void InstantiateRogue()
    {
        Instantiate(roguePrefab, armRogue.transform.position, armRogue.transform.rotation);

    }
    void JumpFalse()
    {
        animator.SetBool("Jump", false);
    }
}
