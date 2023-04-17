using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float movementSpeed;
    private float threshhold = 5;
    private Vector3 lastMousePosition;

    private bool isRight;
    private bool isLeft;
    private bool isForward;
    private bool isBack;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isRight = isLeft = isBack = isForward = false;
    }

    // Update is called once per frame
    void Update()
    {
        StackMouseInput();
    }
    private void FixedUpdate()
    {
        Run();
    }

    public void Run()
    {
        //4 case in this function:
        //1 is Right
        if (isRight)
        {
            Debug.Log("Right");
            rb.velocity = Vector3.right * movementSpeed * Time.deltaTime;
        }
        //2 is Left
        if (isLeft)
        {
            rb.velocity = Vector3.left * movementSpeed * Time.deltaTime;
        }
        //3 is Up
        if (isForward)
        {
            rb.velocity = Vector3.forward * movementSpeed * Time.deltaTime; 
        }
        //4 is Back
        if (isBack) 
        {
            rb.velocity = Vector3.back * movementSpeed * Time.deltaTime;
        }
    }

    private void StackMouseInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            // if magnetude << is 
            Vector3 playerInput = -(lastMousePosition - Input.mousePosition);
            if (playerInput.magnitude > threshhold)
            {
                // 4 case in this function:
                // 1. endPoint are in the 1st and 8th quadrants - rotate right = (1,0,0)
                if (Vector3.Angle(playerInput, Vector3.right) <= 45) 
                {
                    isRight = true;
                    isForward = isLeft = isBack = false;
                }
                // 2. endPoint are in the 2sd and 3rd quadrants - rotate up = (0,0,1)
                if (Vector3.Angle(playerInput, Vector3.up) <= 45)
                {
                    isForward = true;
                    isRight = isBack = isLeft = false;
                }
                // 3. endPoint are in the 4th and 5th quadrants - rotate left = (-1,0,0)
                if (Vector3.Angle(playerInput, Vector3.left) < 45)
                {
                    isLeft = true;
                    isForward = isBack = isRight = false;
                }
                // 4. endPoint are in the 6th and 7th quadrants - rotate down = (0,0,-1)
                if (Vector3.Angle(playerInput, Vector3.down) < 45)
                {
                    isBack = true;
                    isForward = isLeft = isRight = false;
                }
                lastMousePosition = Input.mousePosition;
            }
        }
    }
}
    