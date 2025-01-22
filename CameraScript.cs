using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float mouseSensitivity = 30f;  
    public Transform playerBody;           
    public float tope = 85f;         
    private float xRotation = 0f;
    void Start()
    {
        offset = transform.position - player.transform.position;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -tope, tope); // Limitar el ángulo vertical

        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset; 
    }
}
