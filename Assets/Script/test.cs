using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class test : MonoBehaviour
{
    private Vector3 lastMousePosition;
    private Vector3 targetPosition;
    private StateMove state;
    private Transform thisTransform;

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
        thisTransform = transform;
        targetPosition = thisTransform.position;
        Debug.Log(thisTransform.position);
        Debug.Log(targetPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 playerInput = -(lastMousePosition - Input.mousePosition);

            if (playerInput.magnitude > 5f)
            {
                // 4 case in this function:
                // 1. endPoint are in the 1st and 8th quadrants
                if (Vector3.Angle(playerInput, Vector3.right) < 45)
                {
                    Debug.Log("Right");
                    Raycasting(thisTransform.position, Vector3.right);
                }
            }
        }
        else { state = StateMove.None; }

        if ((thisTransform.position - targetPosition).sqrMagnitude > 0.0001f)
        {
            thisTransform.position = Vector3.MoveTowards(thisTransform.position, targetPosition, 1000 * Time.deltaTime);
        }
    }

    private void MouseInput()
    {

    }

    private void Raycasting(Vector3 origin, Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(origin, direction, out hit, 1f)) // ừ chạy rồi. clm =))
        {
            targetPosition = hit.transform.position;
            origin += direction;
            Raycasting(origin, direction);
        }
    }
}
