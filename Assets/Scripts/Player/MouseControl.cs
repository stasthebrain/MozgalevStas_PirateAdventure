using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public Transform playerBody;
    float xRotation = 0f;
    [SerializeField] float mouseSens = 100f;
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }   

    
    void Update()
    {
        float mouseX = Input.GetAxis(MouseX) * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis(MouseY) * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 85f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
