using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed = 10.0F;
    public float jumpSpeed = 10.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    float rotationY = 0F;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void Update ()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        transform.Rotate(0, Input.GetAxis("Mouse X") * 15f, 0);

        rotationY += Input.GetAxis("Mouse Y") * 15f;
        rotationY = Mathf.Clamp(rotationY, -60F, 60F);
        transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
}
