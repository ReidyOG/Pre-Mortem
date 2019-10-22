using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float camera_rotationX = 0f;
    private float currentCameraRotation = 0f;
    private Vector3 jumpForce = Vector3.zero;
    private Rigidbody rb;

    [SerializeField]
    private float camRotationLimit = 85f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move (Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(float _camera_rotationX)
    {
        camera_rotationX = _camera_rotationX;
    }

    public void ApplyJump(Vector3 _jumpForce)
    {
        jumpForce = _jumpForce;
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }

        if (jumpForce != Vector3.zero)
        {
            rb.AddForce(jumpForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            currentCameraRotation -= camera_rotationX;
            currentCameraRotation = Mathf.Clamp(currentCameraRotation, -camRotationLimit, camRotationLimit);

            cam.transform.localEulerAngles = new Vector3(currentCameraRotation, 0, 0);
        }
    }
}
