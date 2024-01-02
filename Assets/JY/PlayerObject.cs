using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public GameObject[] Fruits = new GameObject[4];
    public Transform SpawnPoint;

    private int gravityScale=1;

    private GenerateManager generateManager;
    public int playerObject;
    
    // Start is called before the first frame update
    void Start()
    {
        generateManager = gameObject.AddComponent<GenerateManager>();
        generateManager.GenerateObject();
        GiveObject();
    }


    // 키보드 입력을 받으면 호출되는 함수
    void InputKey()
    {
        GetComponent<Rigidbody2D>().gravityScale = gravityScale; // 아이템을 떨어뜨리기 위해 중력값 수정
        Invoke("GiveObject", 1f); // 1초뒤 다음 오브젝트 생성

    } 

    void GiveObject()
    {
        playerObject = GenerateManager.objectID.Pop(); // 순서대로 오브젝트 반출

        GameObject newObject;

        switch (playerObject)
        {
            case 1:
                newObject = Instantiate(Fruits[1], SpawnPoint.position, Quaternion.identity);
                break;
            case 2:
                newObject = Instantiate(Fruits[2], SpawnPoint.position, Quaternion.identity);
                break;
            case 3:
                newObject = Instantiate(Fruits[3], SpawnPoint.position, Quaternion.identity);
                break;

            default:
                newObject = Instantiate(Fruits[4], SpawnPoint.position, Quaternion.identity);
                break;
        }

        newObject.transform.parent = GameObject.Find("Objects").transform;

    }
}
