using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    private int gravityScale=1;

    private GenerateManager generateManager = new GenerateManager();
    public int playerObject;
    
    // Start is called before the first frame update
    void Start()
    {
        generateManager.GenerateObject();
        GiveObject();
    }


    // 키보드 입력을 받으면 호출되는 함수
    void InputKey()
    {
        GetComponent<Rigidbody2D>().gravityScale = gravityScale; // 아이템을 떨어뜨리기 위해 중력값 수정
        Invoke("GiveObject", 1f); // 1초뒤 다음 오브젝트 새엇ㅇ

    }

    void GiveObject()
    {
        playerObject = GenerateManager.objectID.Pop(); // 순서대로 오브젝트 반출

        GameObject newObject;

        switch (playerObject)
        {
            case 1:
                newObject = Instantiate(object1);
                break;
            case 2:
                newObject = Instantiate(object2);
                break;
            default:
                newObject = Instantiate(object3);
                break;
        }

        newObject.transform.parent = GameObject.Find("Objects").transform;

    }
}
