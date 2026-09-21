using UnityEngine;

public class QuestMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform head;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        Vector3 forward = head.forward;
        Vector3 right = head.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 movement =
            forward * input.y +
            right * input.x;

        controller.Move(movement * moveSpeed * Time.deltaTime);
    }
}