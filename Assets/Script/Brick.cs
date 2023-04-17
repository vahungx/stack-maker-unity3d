using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        string materiaName = collision.transform.GetComponent<MeshRenderer>().material.name;
        Debug.Log(materiaName);
    }
}
