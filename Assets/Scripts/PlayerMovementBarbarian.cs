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
    private float gravity = -5.0f;
    Vector3 gravityJump;
    public float jumpForce;
    private Collider axeCollider;
    bool axeAtack;


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
        ApplyGravity();
        inputs = playerInput.actions["Move"].ReadValue<Vector2>();
        if (playerInput.actions["Jump"].WasPressedThisFrame() && IsOnGround())
        {
            Jump();
            animator.SetBool("Jump", true);
        }
        if (Input.GetKeyDown(KeyCode.F) && axeAtack == false)
        {
            animator.SetBool("Atack", true);
        }
    }
    void FixedUpdate()
    {
        Movement();
        animator.SetBool("Jump", false);
        animator.SetBool("Atack", false);

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
        movement.y += gravity * Time.deltaTime;
        characterController.Move(movement);
        animator.SetFloat("Speed", movementSpeed);


    }
    void Jump()
    {
        Vector3 jumping = Vector3.up;
        jumping.y = Mathf.Sqrt(jumpForce * -5.0f * gravity * Time.deltaTime);
        characterController.Move(jumping);
    }
    bool IsOnGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayDistance, groundLayer);
    }


    void OnDrawGizmos() // Dibujar el raycast en el editor para depuración visual
    {
        Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.red);
    }
    void ApplyGravity()
    {
        // Aplicar gravedad si el jugador no está en el suelo
        if (IsOnGround() && gravity < 0)
        {
            // Mantener al jugador pegado al suelo con una pequeña fuerza hacia abajo
            gravity = -5.0f;
        }


    }
    void GoAtack()
    {
        moveSpeed = 0;
         
    }
    void AxeContact()
    {
        axeCollider.GetComponent<Collider>().enabled = true;
         
    }
    void EndAtack()
    {
        moveSpeed = 20;
        animator.SetBool("Atack", false);
        axeCollider.GetComponent<Collider>().enabled = false; 
    }
}
