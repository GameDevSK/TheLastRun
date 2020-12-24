using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqaureObstacleMover : MonoBehaviour
{
    public float smoothness;

    [Tooltip("Difference between top position to bottom position")]
    public float offset;

    [Tooltip("(1,0)--East, (0, 1)--North, (-1, 0)--West, (0, -1)--South")]
    public Vector2 direction;


    float destPosZUp, destPosZDown;

    //[Tooltip("1==clockwise    -1==AntiClockwise")]
    //public int wise;
    void Start()
    {
        destPosZUp = transform.position.z + offset;
        destPosZDown = transform.position.z - offset;
    }
    /*
    int xDir = Random.Range(-1, 2);
    int yDir = Random.Range(-1, 2);
    Vector2 curDir = new Vector2(xDir, yDir); 
    */

    void Update()
    {
        if(direction==new Vector2(1,0))
        {
            MoveRight();
        }
        if (direction == new Vector2(0, 1))
        {
            MoveUp();
        }
        if (direction == new Vector2(-1, 0))
        {
            MoveLeft();
        }
        if (direction == new Vector2(0, -1))
        {
            MoveDown();
        }
    }

    private void MoveUp()
    {
        Vector3 dest = new Vector3(transform.position.x, transform.position.y, destPosZUp);
        transform.position = Vector3.Lerp(transform.position, dest, smoothness * Time.deltaTime);

        if (Vector3.Distance(transform.position, dest) == 0.0f)
        {
            direction = new Vector2(1, 0);
        }
    }

    private void MoveDown()
    {
        Vector3 dest = new Vector3(transform.position.x, transform.position.y, destPosZDown);
        transform.position = Vector3.Lerp(transform.position, dest, smoothness * Time.deltaTime);

        if (Vector3.Distance(transform.position, dest) == 0.0f)
        {
            direction = new Vector2(-1, 0);
        }
    }

    private void MoveLeft()
    {
        Vector3 dest = new Vector3(-10 + transform.localScale.x / 2, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, dest, smoothness * Time.deltaTime);

        if (transform.position == dest)
            direction = new Vector2(0, 1);
    }

    private void MoveRight()
    {
        Vector3 dest = new Vector3(10 - transform.localScale.x / 2, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, dest, smoothness * Time.deltaTime);

        if (transform.position == dest)
            direction = new Vector2(0,-1);
    }
}
