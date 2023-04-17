using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform checkPoint;
    public Transform stackPoint;
    public Transform playerPoint;
    private Rigidbody rb;
    public LayerMask whatIsTerrain;
    public List<Brick> brickList;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        brickList = new List<Brick>();
    }

    // Update is called once per frame
    void Update()
    {
        PickUp();
    }

    /*    private bool checkHand()
        {
            return 
        }*/



    private void PickUp()
    {
        foreach (Collider collider in Physics.OverlapBox(checkPoint.transform.position,checkPoint.localScale / 2, checkPoint.rotation,whatIsTerrain) )
        {
            if (collider.TryGetComponent(out Brick brick))
            {
                brick.PickUp(this);
            }
        }
    }
}
