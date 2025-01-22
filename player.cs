
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    private Rigidbody rb;
    private int count;

    public Transform camara;
    private float movementX;
    private float movementY;
    public float speed = 10.0f;
    public float rozamiento = -1f;
   
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        rb.freezeRotation = true;
        count = 0;
       
    }
   

    void Update()
    {
        Vector3 direccion = camara.forward;
        Vector3 right = camara.right;

        Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
        Vector3 movementDirection = Vector3.ProjectOnPlane(cameraForward, Vector3.up).normalized;
        Vector3 movement = direccion * movementY * right * movementX;

        float movimiento = Input.GetAxis("Vertical"); 

        rb.MovePosition(movement * speed);
    }   

    
    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y; 
        
    }

    
    void OnFire(){
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            rb.AddForce(Vector3.up * 5.0f, ForceMode.Impulse); 
        }
    }


   void OnTriggerEnter(Collider other) 
   {
        other.gameObject.SetActive(false);
        count = count + 1;
   }


    private void FixedUpdate() 
    {
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            OnFire();
        }

        Vector3 movement = new Vector3 (movementX, 0.0f , movementY);

        
        rb.AddForce(movement*speed*rozamiento); 
    }
    

     
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
 // Rigidbody of the player.
 private Rigidbody rb; 

    public Transform camara;

 // Movement along X and Y axes.
 private float movementX;
 private float movementY;
 private int count;

 // Speed at which the player moves.
 public float speed = 0; 

 // Start is called before the first frame update.
 void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }
 
 // This function is called when a move input is detected.
 void OnMove(InputValue movementValue)
    {
 // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

 // Store the X and Y components of the movement.
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

void OnFire(){
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            rb.AddForce(Vector3.up * 5.0f, ForceMode.Impulse); 
        }
    }

void OnTriggerEnter(Collider other) 
   {
        other.gameObject.SetActive(false);
        count = count + 1;
   }
 // FixedUpdate is called once per fixed frame-rate frame.
 private void FixedUpdate() 
    {
        Vector3 direccion = camara.forward;
        Vector3 right = camara.right;

        if (Input.GetKeyDown(KeyCode.Space)) {
            OnFire();
        }
        Vector3 movement = direccion * movementY * right * movementX;


 // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed); 
    }
}