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


    public void OnDrop(InputValue button)
    {

        InputKey();
    }


    // 키보드 입력을 받으면 호출되는 함수
    public void InputKey()
    {
        GameManager.I.ObjectPop();
        playerObject = GameManager.I.newFruitLevel;
        GiveObject();
        ShowObject();
      

    } 

    void ShowObject()
    {
        switch (playerObject)
        {
            case 1:
                Debug.Log("1");

                break;

            case 2:
                Debug.Log("2");

                break;
            case 3:
                Debug.Log("3");

                break;

            default:
                Debug.Log("4");

                break;
        }
    }


    void GiveObject()
    {
       
        GameObject newObject;
        newObject = Instantiate(Fruits, SpawnPoint.position, Quaternion.identity);
        
        // 기존 오브젝트 비활성화
        //gameObject.SetActive(false);
        newObject.transform.parent = GameObject.Find("Objects").transform;


    }
}
