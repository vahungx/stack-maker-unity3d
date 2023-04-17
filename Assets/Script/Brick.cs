using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool isPickUp {  get; private set; }
    public float stackRange;
    private void Awake()
    {
        isPickUp = false;
    }

    public void PickUp(Player player)
    {
        if(!isPickUp)
        {
            isPickUp = true;
            //Pick Up Brick is that function
            //add bick in bricklist
            player.brickList.Add(this);
            transform.parent = player.stackPoint;
            transform.localPosition = new Vector3(0, (player.brickList.Count + 1) * stackRange, 0);
            transform.localRotation = Quaternion.identity;
            GetComponent<BoxCollider>().size = new Vector3(1, 10, 2);
        }
    }
}
