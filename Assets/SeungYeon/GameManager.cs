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

    public int berryScore = 1;  // ���Ⳣ�� �ε����� ��.
    public int appleScore = 5;  // ������� �ε����� ��.

    public string berryTag = "Berry"; //����. 
    public GameObject berryPrefab;
    public string appleTag = "Apple"; //���. 
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
        if (isProcessingCollision) return; // �̹� ó�� ���̶�� �������� 
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
        isProcessingCollision = true; // �� ��ġ�� �̵�
                                      // ���� �±��� ������Ʈ�� �浹�ϸ� ��� �±��� ������Ʈ �� ���� �����ϰ�,
                                      // ���� �±��� ������Ʈ �� ���� �ı��ϸ�, ������ ������ŵ�ϴ�.
                                      //Instantiate(applePrefab, berry.transform.position, Quaternion.identity); �ı��ϰ� �����ؾ��ϴµ� ��� �����ϸ� �ı��� 
        Destroy(berry);
        totalScore += berryScore;
        Debug.Log(berryTag);
       
        isProcessingCollision = false;
    }

    private void AppleCollision(GameObject apple)
    {
        isProcessingCollision = true; // �� ��ġ�� �̵�
        totalScore += appleScore;
        Destroy(apple); // ���� ��ũ��Ʈ�� ����� ������Ʈ�� �ı��մϴ�. 
        Debug.Log(appleTag);
       

        isProcessingCollision = false; // �� ��ġ�� �̵�
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
