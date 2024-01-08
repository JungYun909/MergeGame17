using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{

    public static GameManager I;    
    public int MergePoint;
    public UIAudioManager uaManager;

    private bool isProcessingCollision = false;


    public int newFruitLevel;

    private System.Random random;
    //static public RingBuffer<int> objectID = new RingBuffer<int>(10);
    static public Queue<int> objectID = new Queue<int>();


    void Awake()
    {
        I = this;

        for (int i = 1; i <= 10; i++)
        {
            GenerateObject();
        }
        uaManager = GetComponentInChildren<UIAudioManager>();
    }

    public int totalScore = 0;

    public void addScore(Collision2D collision)
    {

       
        isProcessingCollision = false;
    }


    
    public void GenerateObject()
    {
        random = new System.Random();
        int num = random.Next(1,5);
        objectID.Enqueue(num);

    }

    public void ObjectPop()
    {
        newFruitLevel = objectID.Dequeue();
        GenerateObject();
    }

}
