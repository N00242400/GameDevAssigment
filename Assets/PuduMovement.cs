
using UnityEngine;

public class PuduMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float turnSpeed = 180f;

    private CharacterController controller;

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

            controller.SimpleMove(transform.forward * moveSpeed);
        }
        else
        {
            controller.SimpleMove(Vector3.zero);
        }
    }
}
