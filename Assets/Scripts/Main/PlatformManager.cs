using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] platforms;
    public float zSpawn=0;
    public float platformLength = 100;
    public int numberOfPlatform;

    public Transform playerTransform;


    private List<GameObject> activePlatforms=new List<GameObject>();
    void Start()
    {
        for(int i=0; i< numberOfPlatform; i++)
        {
            if (i == 0)
                SpawnPlatform(0);
            else
                SpawnPlatform(Random.Range(0, platforms.Length));
        }
    }

    void Update()
    {
        if(playerTransform.position.z - 150 > zSpawn - (numberOfPlatform * platformLength))
        {
            SpawnPlatform(Random.Range(0, platforms.Length));
            DeletePlatform();
        }
    }

    private void DeletePlatform()
    {
        Destroy(activePlatforms[0]);
        activePlatforms.RemoveAt(0);
    }

    public void SpawnPlatform(int platfromIndex)
    {
        GameObject go = Instantiate(platforms[platfromIndex], transform.forward * zSpawn, transform.rotation);
        //print(platfromIndex);
        activePlatforms.Add(go);
        zSpawn += platformLength;
    }

}
