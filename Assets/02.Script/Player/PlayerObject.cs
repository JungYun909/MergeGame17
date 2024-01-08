using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerObject : MonoBehaviour
{
    public GameObject Fruits;
    public Transform SpawnPoint;

    public int playerObject;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        
        ShowObject();

    }

    public void OnDrop(InputValue button)
    {

        InputKey();
        ShowObject();

    }


    // 키보드 입력을 받으면 호출되는 함수
    public void InputKey()
    {
        GiveObject();
    } 

    void ShowObject()
    {
        GameManager.I.ObjectPop();
        playerObject = GameManager.I.newFruitLevel;

        anim.SetInteger("Level", playerObject);
        
    }


    void GiveObject()
    {
       
        GameObject newObject;
        newObject = Instantiate(Fruits, SpawnPoint.position, Quaternion.identity);
        
        newObject.transform.parent = GameObject.Find("Objects").transform;


    }
}
