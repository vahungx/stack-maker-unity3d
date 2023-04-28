using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private float threshold = 5f;
    private Vector3 lastMousePosition;
    private Vector3 targetPosition;
    private Transform thisTransform;
//    private bool canMove;

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
        thisTransform= transform;
        targetPosition = thisTransform.position;
        Debug.Log(thisTransform.position);
        Debug.Log(targetPosition);
    }

    // Update is called once per frame
    private void Update()
    {
        MouseInputToMove();
        Move();
    }

    private void MouseInputToMove()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {   
            Vector3 playerInput = -(lastMousePosition - Input.mousePosition);
            if (playerInput.magnitude > threshold)
            {
                if (Vector3.Angle(playerInput, Vector3.right) < 45)
                {
                    Raycasting(thisTransform.position, Vector3.right);
                }

                if (Vector3.Angle(playerInput, Vector3.up) < 45)
                {
                    Raycasting(thisTransform.position, Vector3.forward);
                }

                if (Vector3.Angle(playerInput, Vector3.left) <= 45)
                {
                    Raycasting(thisTransform.position, Vector3.left);
                }

                if (Vector3.Angle(playerInput, Vector3.down) <= 45)
                {
                    Raycasting(thisTransform.position, Vector3.back);
                }
                lastMousePosition = Input.mousePosition;
            }
        }
        else { state = StateMove.None; }
    }

    private void Move()
    {       
        if ((thisTransform.position - targetPosition).sqrMagnitude > 0.0001f)
            {
                thisTransform.position = Vector3.MoveTowards(thisTransform.position, targetPosition, movementSpeed * Time.deltaTime);
            }       
    }
    
    private void Raycasting (Vector3 startRay, Vector3 direction)
    {   
        RaycastHit hit;
        if (Physics.Raycast(startRay, direction, out hit, 1f))
        {
            if (hit.transform.CompareTag("Brick"))
            {
                targetPosition = hit.transform.position;
                startRay += direction;
                Raycasting(startRay, direction);
            }

        }
    }

    public void Stop()
    {
        state = StateMove.None;
    }
    private void FindTarget(StateMove stateMove)
        {
            switch (stateMove)
            {
                case StateMove.Left:
                    Raycasting(thisTransform.position, Vector3.left);
                    break;

                case StateMove.Right:
                    Raycasting(thisTransform.position, Vector3.right);
                    break;

                case StateMove.Forward:
                    Raycasting(thisTransform.position, Vector3.forward); 
                    break;

                case StateMove.Back:
                    Raycasting(thisTransform.position, Vector3.back);
                    break;
                case StateMove.None:
                    break;

                default : break;
            }
        }
}
