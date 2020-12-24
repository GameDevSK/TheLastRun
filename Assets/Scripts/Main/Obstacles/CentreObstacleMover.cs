using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentreObstacleMover : MonoBehaviour
{
    public float smoothness;
    public int direction;
    public float offset;

    float destPosZUp, destPosZDown;
    private void Start()
    {
        destPosZUp = transform.position.z + offset;
        destPosZDown = transform.position.z - offset;
    }
    private void Update()
    {
        if (direction == 1)
        {
            MoveUp();
        }
            
        if(direction == -1)
            MoveDown();
    }

    private void MoveUp()
    {
        Vector3 dest = new Vector3(transform.position.x, transform.position.y, destPosZUp);
        transform.position = Vector3.Lerp(transform.position, dest, smoothness * Time.deltaTime);
        if (Vector3.Distance(transform.position,dest) <= 0.1f)
        {
            direction = -1;
        }
            
    }

    private void MoveDown()
    {
        Vector3 dest = new Vector3(transform.position.x, transform.position.y, destPosZDown);
        transform.position = Vector3.Lerp(transform.position, dest, smoothness * Time.deltaTime);
        if (Vector3.Distance(transform.position, dest) <= 0.1f)
        {
            direction = 1;
        }
    }
}
