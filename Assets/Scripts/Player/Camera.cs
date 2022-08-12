using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    public Transform orientation;
    private string MouseX = "Mouse X";
    private string MouseY = "Mouse Y";

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    private void Update()
    {
        float mouseX = Input.GetAxisRaw(MouseX) * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw(MouseY) * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); 
    }
}
