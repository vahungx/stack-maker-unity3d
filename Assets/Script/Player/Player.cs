using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private GameObject brickPrefabs;
    [SerializeField] private Transform stackPoint;
    [SerializeField] private Transform playerPoint;

    private Stack<GameObject> brickStack;

    #region Singleton
    public static Player Ins;
    private void Awake()
    {
        Ins = this; 
    }
    #endregion

// Start is called before the first frame update
void Start()
    {
        brickStack = new Stack<GameObject> ();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brick"))
        {
            //Push
            PushToStack();
            //set ani
        }

        if (other.CompareTag("Inedible Brick"))
        {
            //Pop
            PopFromStack(other.transform.position);
        }
    }

    private void PushToStack()
    {
        GameObject brick = Instantiate(brickPrefabs, transform.position, Quaternion.identity, stackPoint);
        brickStack.Push(brick);

        brick.transform.localPosition = new Vector3(0,(brickStack.Count - 1) /2, 0);
        playerPoint.localPosition = new Vector3(0, brickStack.Count / 2, 0);
    }

    private void PopFromStack(Vector3 popPoint)
    {
        GameObject brick = brickStack.Pop();
        brick.transform.parent = null;
        brick.transform.position = popPoint;// đoạn này đang sai này.
        playerPoint.localPosition = new Vector3(0, brickStack.Count / 2, 0);   
    }
}
