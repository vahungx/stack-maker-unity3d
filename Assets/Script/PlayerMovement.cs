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

    // State của player
    public StateMove state;


    private bool isRight;
    private bool isLeft;
    private bool isForward;
    private bool isBack;

    private StateMove state; 

    private enum StateMove
    {
        None,
        Right,
        Left,
        Forward,
        Back,
    }

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
<<<<<<< HEAD
/*        Run();*/
        RunWithSwitchCase();   
=======
        Run();

        // Run fix
        RunRecommend(state);
    }

    /// <summary>
    /// Đổi thành enum
    /// Dùng Switch Case nếu có nhiều hơn 2 loại tối ưu code hơn đỡ phải khai báo nhiều bool và phải set tất cả biến bool trong khi chỉ cần set 1 biến là được
    /// Nghiên cứu cách dùng enum 
    /// </summary>
    /// Ví dụ 
    public enum StateMove
    {
        None,
        Right, 
        Left, 
        Up, 
        Down
    }
    void RunRecommend(StateMove state)
    {
        switch(state)
        {
            case StateMove.Left:
                rb.velocity = Vector3.left * movementSpeed * Time.deltaTime;
                break;
            // Tương tự 
            default: 
                break;
        }

>>>>>>> 0cf3b248173d9a0d22c43eb128c9bb53b21bfa0d
    }

    public void Run()
    {
        //4 case in this function:
        //1 is Right
        if (isRight)
        {
/*            Debug.Log("Right");*/
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
<<<<<<< HEAD
                    state = StateMove.Right;
=======

                    // chuyển thành state tương ứng tương tự các phần dưới
                    state = StateMove.Up;

>>>>>>> 0cf3b248173d9a0d22c43eb128c9bb53b21bfa0d
                }
                // 2. endPoint are in the 2sd and 3rd quadrants - rotate up = (0,0,1)
                if (Vector3.Angle(playerInput, Vector3.up) <= 45)
                {
                    isForward = true;
                    isRight = isBack = isLeft = false;
                    state = StateMove.Forward;
                }
                // 3. endPoint are in the 4th and 5th quadrants - rotate left = (-1,0,0)
                if (Vector3.Angle(playerInput, Vector3.left) < 45)
                {
                    isLeft = true;
                    isForward = isBack = isRight = false;
                    state = StateMove.Left;
                }
                // 4. endPoint are in the 6th and 7th quadrants - rotate down = (0,0,-1)
                if (Vector3.Angle(playerInput, Vector3.down) < 45)
                {
                    isBack = true;
                    isForward = isLeft = isRight = false;
                    state = StateMove.Back;
                }
                lastMousePosition = Input.mousePosition;
            }
        }
<<<<<<< HEAD
        else if (Input.GetKeyUp(KeyCode.Mouse0)) state = StateMove.None;
    }
    
    private void RunWithSwitchCase()
    {
        switch(state)
        {
            case StateMove.Right:
                rb.velocity = Vector3.right * movementSpeed * Time.deltaTime;
                break;

            case StateMove.Left:
                rb.velocity = Vector3.left * movementSpeed * Time.deltaTime;
                break;

            case StateMove.Forward:
                rb.velocity = Vector3.forward * movementSpeed * Time.deltaTime;
                break;

            case StateMove.Back:
                rb.velocity = Vector3.back * movementSpeed * Time.deltaTime;
                break;

            case StateMove.None:
                rb.velocity = Vector3.zero;
                break;
            
            default:
                break;
=======
        else
        {
            // Set lại là chưa di chuyển
            state = StateMove.None;
>>>>>>> 0cf3b248173d9a0d22c43eb128c9bb53b21bfa0d
        }
    }
}
    