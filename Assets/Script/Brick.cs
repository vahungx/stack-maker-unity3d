using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool isPickUp {  get; private set; }
    public float stackRange = 0.5f;
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
            Debug.Log(player.brickList.Count + "1");
            player.playerPoint.localPosition = new Vector3(0, player.brickList.Count * stackRange, 0);
            player.playerPoint.localRotation = Quaternion.identity;
            transform.parent = player.stackPoint;
            Debug.Log(player.brickList.Count + "22");
            transform.localPosition = new Vector3(0, player.brickList.Count * stackRange, 0);
            transform.localRotation = Quaternion.identity;
            GetComponent<BoxCollider>().size = new Vector3(1, 100, 2);
        }
    }
}
