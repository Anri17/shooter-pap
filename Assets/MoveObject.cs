using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    /*
    public float speed = 1.0f;
    public int horizontalDirection = 1;
    public int verticalDirection = 1;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;

    void Start()
    {
        transform.position = target4.transform.position;
    }

    void Update()
    {
        if (transform.position == target4.transform.position)
            transform.position = Vector3.Lerp(transform.position, target1.transform.position, 10f * Time.deltaTime);
        if (transform.position == target1.transform.position)
            transform.position = Vector3.Lerp(transform.position, target2.transform.position, 10f * Time.deltaTime);
        if (transform.position == target2.transform.position)
            transform.position = Vector3.Lerp(transform.position, target3.transform.position, 10f * Time.deltaTime);
        if (transform.position == target3.transform.position)
            transform.position = Vector3.Lerp(transform.position, target4.transform.position, 10f * Time.deltaTime);


        
        Vector3 direction = new Vector3(horizontalDirection, verticalDirection, 0);
        transform.position += direction * speed * Time.deltaTime;
        
    }
    */
    GameObject[] pathNode;
    public GameObject enemyObject;
    public float moveSpeed = 1f;
    float timer;
    static Vector3 currentPositionHolder;
    int currentNode;

    void Start()
    {
        pathNode = GetComponentsInChildren<GameObject>();
        CheckNode();
    }

    void CheckNode()
    {
        timer = 0;
        currentPositionHolder = pathNode[currentNode].transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime * moveSpeed;
        if (enemyObject.transform.position != currentPositionHolder)
        {
            enemyObject.transform.position = Vector3.Lerp(enemyObject.transform.position, currentPositionHolder, timer);
        }
        else
        {
            if (currentNode < pathNode.Length - 1)
            {
                currentNode++;
                CheckNode();
            }
        }
    }
}
