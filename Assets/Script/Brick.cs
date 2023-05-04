using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool isPickUp {  get; private set; }
    public bool isFinishDrop { get; private set; }
    public float stackRange = 0.5f;
    private float finishRange = 1f;
    private void Awake()
    {
        isPickUp = false;
        isFinishDrop = false;
    }

    public void PickUp(Player player)
    {
        if(!isPickUp)
        {
            isPickUp = true;
            //Pick Up Brick is that function
            //add bick in bricklist
            player.brickStackedList.Add(this);
            player.playerPoint.localPosition = new Vector3(0, player.brickStackedList.Count * stackRange,0);
            player.playerPoint.localRotation = Quaternion.identity;
            transform.parent = player.stackPoint;
            transform.localPosition = new Vector3(0, player.brickStackedList.Count * stackRange, 0);
            transform.localRotation = Quaternion.identity;
/*            GetComponent<BoxCollider>().size = new Vector3(1, 100, 2);*/
        }
    }
    public void FinishDrop(Player player)
    {
        if (!isFinishDrop)
        {
            isFinishDrop = true;
            player.brickFnishedList.Add(this);
            transform.parent = player.finishPoint;
            transform.localPosition = new Vector3(0, 0, player.brickFnishedList.Count * finishRange);
            transform.localRotation = Quaternion.identity;
            player.playerPoint.localPosition = new Vector3(0, 0.25f, player.brickFnishedList.Count * finishRange);
            player.playerPoint.localRotation = Quaternion.identity;
        }
    }
}
