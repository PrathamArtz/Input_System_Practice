using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput PlayerInput;
    private Input_System_Practice inputSystem;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PlayerInput = GetComponent<PlayerInput>(); 

        inputSystem = new Input_System_Practice();
        inputSystem.Ball.Enable();
        inputSystem.Ball.Jump.performed += Jump;
       
    }

    private void FixedUpdate()
    {

        Vector2 inputVector = inputSystem.Ball.Movement.ReadValue<Vector2>();
        float speed = 5f;
        rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);

    }

  /*  private void Movement_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        Vector2 inputVector = context.ReadValue<Vector2>();
        float speed = 5f;
        rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }
  */
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed) {
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            Debug.Log("Jumping" + context.phase);
        }
       
    }
}
