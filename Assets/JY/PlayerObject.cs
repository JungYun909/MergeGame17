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


    // Ű���� �Է��� ������ ȣ��Ǵ� �Լ�
    void InputKey()
    {
        GetComponent<Rigidbody2D>().gravityScale = gravityScale; // �������� ����߸��� ���� �߷°� ����
        Invoke("GiveObject", 1f); // 1�ʵ� ���� ������Ʈ ����

    } 

    void GiveObject()
    {
        playerObject = GenerateManager.objectID.Pop(); // ������� ������Ʈ ����

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
