using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{ 

    [SerializeField] private GameObject brickPrefabs;
    [SerializeField] private Transform stackPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private GameManager gameManager;
    private List<GameObject> brickStack;

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
        brickStack = new List<GameObject> ();
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

        if (other.CompareTag("Win Block"))
        {
            //set ani
            //set ui
            gameManager.endingPanel.SetActive(true);
            
        }
    }

    private void PushToStack()
    {
        GameObject brick = Instantiate(brickPrefabs, transform.position, Quaternion.identity, stackPoint);
        brickStack.Add(brick);
        sort();
    }

    private void PopFromStack(Vector3 popPoint)
    {   
        if (brickStack.Count != 0) 
        {
            GameObject brick = brickStack[brickStack.Count - 1];
            brickStack.Remove(brick);
            brick.transform.parent = null;
            brick.transform.position = popPoint;
            player.transform.localPosition = new Vector3(0, brickStack.Count * 0.5f, 0);
        }
    }

    private void sort()
    {
        for (int i = 0;  i < brickStack.Count; i++)
        {
            brickStack[i].transform.localPosition = new Vector3(0, -0.75f + i * 0.5f, 0);

        }
        player.transform.localPosition = new Vector3(0, brickStack.Count * 0.5f, 0);
    }
}
