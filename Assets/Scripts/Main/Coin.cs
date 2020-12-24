using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public float rotationPerFrame;

    private GameManager gameManager;


    private void Start()
    {    
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        transform.Rotate(Vector3.up, rotationPerFrame);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name=="Player")
        {
            Destroy(this.gameObject);
        }
    }

}

