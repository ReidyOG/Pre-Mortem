using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        float x_move = Input.GetAxisRaw("Horizontal");
        float z_move = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * x_move;
        Vector3 moveVertical = transform.forward * z_move;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);
    }
}
