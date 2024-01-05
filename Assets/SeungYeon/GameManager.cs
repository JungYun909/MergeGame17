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

    public int berryScore = 1;  // 딸기끼리 부딪혔을 때.
    public int appleScore = 5;  // 사과끼리 부딪혔을 때.

    public string berryTag = "Berry"; //딸기. 
    public GameObject berryPrefab;
    public string appleTag = "Apple"; //사과. 
    public GameObject applePrefab;
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
        if (isProcessingCollision) return; // 이미 처리 중이라면 빠져나감 
        isProcessingCollision = true;

        string collidedTag = collision.gameObject.tag;
        Debug.Log(collision.gameObject.name);

        if (collidedTag == berryTag)
        {
            berryCollision(collision.gameObject);
            Debug.Log("0.1");
        }
        else if (collidedTag == appleTag)
        {
            AppleCollision(collision.gameObject);
            Debug.Log("0.2");
        }



        /*
        if (collision.gameObject.CompareTag(berryTag))
        {
            berryCollision(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag(appleTag))
        {
            AppleCollision(collision.gameObject);
        }*/

       
        isProcessingCollision = false;
    }

    private void berryCollision(GameObject berry)
    {
        isProcessingCollision = true; // 이 위치로 이동
                                      // 딸기 태그의 오브젝트가 충돌하면 사과 태그의 오브젝트 한 개를 생성하고,
                                      // 딸기 태그의 오브젝트 두 개를 파괴하며, 점수를 증가시킵니다.
                                      //Instantiate(applePrefab, berry.transform.position, Quaternion.identity); 파괴하고 생성해야하는데 사과 생성하며 파괴함 
        Destroy(berry);
        totalScore += berryScore;
        Debug.Log(berryTag);
       
        isProcessingCollision = false;
    }

    private void AppleCollision(GameObject apple)
    {
        isProcessingCollision = true; // 이 위치로 이동
        totalScore += appleScore;
        Destroy(apple); // 현재 스크립트가 연결된 오브젝트를 파괴합니다. 
        Debug.Log(appleTag);
       

        isProcessingCollision = false; // 이 위치로 이동
    }

    
    public void GenerateObject()
    {
        random = new System.Random();
        int num = random.Next(1, 10);
        objectID.Enqueue(num);

    }

    public void ObjectPop()
    {
        newFruitLevel = objectID.Dequeue();
        GenerateObject();
    }

}
