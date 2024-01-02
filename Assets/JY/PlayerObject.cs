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


    // Ű���� �Է��� ������ ȣ��Ǵ� �Լ�
    void InputKey()
    {
        GetComponent<Rigidbody2D>().gravityScale = gravityScale; // �������� ����߸��� ���� �߷°� ����
        Invoke("GiveObject", 1f); // 1�ʵ� ���� ������Ʈ ������

    }

    void GiveObject()
    {
        playerObject = GenerateManager.objectID.Pop(); // ������� ������Ʈ ����

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
