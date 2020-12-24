using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float smoothness;
    int direction;

    void Start()
    {
        do
        {
            direction = Random.Range(-1, 2);
        } while (direction == 0);
    }
    private void Update()
    {
        if(direction==1)
            MoveRight();
        if (direction == -1)
            MoveLeft();
    }

    private void MoveRight()
    {
        Vector3 dest = new Vector3(10-transform.localScale.x/2,transform.position.y,transform.position.z);
        transform.position = Vector3.Lerp(transform.position, dest, smoothness * Time.deltaTime);
        if (transform.position == dest)
            direction = -1;
    }

    private void MoveLeft()
    {
        Vector3 dest = new Vector3(-10 + transform.localScale.x / 2, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, dest, smoothness * Time.deltaTime);
        if (transform.position == dest)
            direction = 1;
    }
}
