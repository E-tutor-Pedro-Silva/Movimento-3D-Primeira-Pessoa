using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float Speed = 5f;
    public float JumpHeight = 3;
    private CharacterController controller;
    private float xInput;
    private float zInput;
    private float jumpInput;

    private Vector3 velocity;
    public float Gravity = -9.81f;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;

    private void Start () {
        controller = GetComponent<CharacterController> ();
    }

    private void Update () {
        xInput = Input.GetAxis ("Horizontal");
        zInput = Input.GetAxis ("Vertical");
        jumpInput = Input.GetAxisRaw ("Jump");

        Debug.Log (IsGrounded ());

        if (IsGrounded () && velocity.y < 0) {
            velocity.y = -1f;
        }

        if(IsGrounded() && jumpInput == 1){
            Jump();
        }

        Vector3 movement = transform.right * xInput + transform.forward * zInput;

        controller.Move (movement * Speed * Time.deltaTime);

        velocity.y += Gravity * Time.deltaTime;
        controller.Move (velocity * Time.deltaTime);
    }

    private bool IsGrounded () {
        return Physics.CheckSphere (GroundCheck.position, GroundDistance, GroundMask);
    }

    private void Jump () {
        velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
    }
}