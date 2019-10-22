using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float look_sensitivity = 3f;
    [SerializeField]
    private float jumpForce = 1000f;

    [Header("Spring Options:")]
    [SerializeField]
    private JointDriveMode jointMode = JointDriveMode.Position;
    [SerializeField]
    private float jointSpring = 20f;
    [SerializeField]
    private float jointMaxForce = 40f;

    private PlayerMotor motor;
    private ConfigurableJoint joint;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        joint = GetComponent<ConfigurableJoint>();

        JointSettings(jointSpring);
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
        float camera_rotationX = x_rotation * look_sensitivity;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);
        motor.Rotate(rotation);
        motor.RotateCamera(camera_rotationX);

        Vector3 _jumpForce = Vector3.zero;
        if (Input.GetButton("Jump"))
        {
            _jumpForce = Vector3.up * jumpForce;
            JointSettings(0f);
        }
        else
        {
            JointSettings(jointSpring);
        }

        motor.ApplyJump(_jumpForce);   
    }

    private void JointSettings(float _jointSpring)
    {
        joint.yDrive = new JointDrive {
            mode = jointMode,
            positionSpring = jointSpring,
            maximumForce = jointMaxForce
        };
    }
}
