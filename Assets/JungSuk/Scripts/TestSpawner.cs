using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    public GameObject[] Fruits = new GameObject[4];
    public Transform SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        GameObject spawnObject = Instantiate(Fruits[1], SpawnPoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
