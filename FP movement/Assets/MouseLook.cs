using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    public float MouseSensitivity = 100f;
    public Transform Player;

    private float mouseX;
    private float mouseY;

    private float xRotation = 0f;

    private void Start () {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update () {
        mouseX = Input.GetAxis ("Mouse X");
        mouseY = Input.GetAxis ("Mouse Y");

        // xRotation -= mouseY * MouseSensitivity * Time.deltaTime;
        // xRotation = Mathf.Clamp (xRotation, -90f, 90f);
        // transform.localRotation = Quaternion.Euler (xRotation, 0f, 0f);

        transform.Rotate(Vector3.left * mouseY * MouseSensitivity * Time.deltaTime);
        Player.Rotate (Vector3.up * mouseX * MouseSensitivity * Time.deltaTime);
    }
}