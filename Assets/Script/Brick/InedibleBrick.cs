using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InedibleBrick : Brick
{
    public override void OnTriggerExit(Collider other)
    {
        gameObject.tag = "Walkable";
    }

}
