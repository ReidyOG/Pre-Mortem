using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float look_sensitivity = 3f;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        float x_move = Input.GetAxisRaw("Horizontal");
        float z_move = Input.GetAxisRaw("Vertical");
        float y_rotation = Input.GetAxisRaw("Mouse X");
        float x_rotation = Input.GetAxisRaw("Mouse Y");

        Vector3 moveHorizontal = transform.right * x_move;
        Vector3 moveVertical = transform.forward * z_move;
        Vector3 rotation = new Vector3(0f, y_rotation, 0f) * look_sensitivity;
        Vector3 camera_rotation = new Vector3(x_rotation, 0f, 0f) * look_sensitivity;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);
        motor.Rotate(rotation);
        motor.RotateCamera(camera_rotation);
    }
}
