
using UnityEngine;

public class PuduMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float turnSpeed = 180f;

    [Header("Jump Settings")]
    public float jumpHeight = 2f;
    public float gravity = -20f;

    private CharacterController controller;
    private float verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.LeftArrow)) horizontal = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) horizontal = 1f;
        if (Input.GetKey(KeyCode.UpArrow)) vertical = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) vertical = -1f;

        Vector3 input = new Vector3(horizontal, 0f, vertical);

        if (input.sqrMagnitude > 0.01f)
        {
            Vector3 direction = Camera.main != null
                ? Camera.main.transform.TransformDirection(input)
                : input;

            direction.y = 0f;
            direction.Normalize();

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                turnSpeed * Time.deltaTime
            );
        }

        if (controller.isGrounded)
        {
            if (verticalVelocity < 0f)
                verticalVelocity = -2f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 movement = transform.forward * (input.sqrMagnitude > 0.01f ? moveSpeed : 0f);
        movement.y = verticalVelocity;

        controller.Move(movement * Time.deltaTime);
    }
}
