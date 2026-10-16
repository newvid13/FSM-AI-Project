using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;

    //Inputs
    Vector2 input;
    InputAction moveAction;

    //Orientation
    Vector3 dirRight;
    Vector3 dirForward;
    Vector3 moveDirection;

    //Speed
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        UpdateInputRelativeToCamera();
    }

    private void UpdateInputRelativeToCamera()
    {
        dirRight = Camera.main.transform.right;
        dirRight.y = 0;
        dirForward = Camera.main.transform.forward;
        dirForward.y = 0;

        dirRight.Normalize();
        dirForward.Normalize();
    }

    private void FixedUpdate()
    {
        GetInput();
        Move();
        Orientation();
    }

    private void GetInput()
    {
        input = moveAction.ReadValue<Vector2>();
    }

    private void Move()
    {
        moveDirection = dirRight * input.x + dirForward * input.y;
        rb.linearVelocity = moveDirection * moveSpeed;
    }

    private void Orientation()
    {
        if (input == Vector2.zero) 
            return;

        Quaternion endRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, endRotation, turnSpeed * Time.deltaTime);
    }
}
