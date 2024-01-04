using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateManager : MonoBehaviour
{

    private System.Random random;
    static public RingBuffer<int> objectID = new RingBuffer<int>(10);

    public void GenerateObject()
    {
        random = new System.Random();
        int num = random.Next(1,5);
        objectID.Push(num);

    }


}
