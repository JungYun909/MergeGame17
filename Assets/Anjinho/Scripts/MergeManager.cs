using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
    public int level;
    public bool isMerge;


    Rigidbody2D rigid;
    CircleCollider2D circleCollider;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            MergeManager other = collision.gameObject.GetComponent<MergeManager>();

            if (level == other.level && !isMerge && !other.isMerge && level < 4) // ���� ��ġ�� (��ġ�� ���߿� ���ԵǴ� �� ����)
            {
                // �ڽŰ� ����� ��ġ ��������
                float meX = transform.position.x;
                float meY = transform.position.y;
                float otherX = other.transform.position.x;
                float otherY = other.transform.position.y;

                // 1. ���� �Ʒ��� ���� ��
                // 2. ������ ������ ��, ���� �����ʿ� ���� ��
                if (meY < otherY || (meY == otherY && meX > otherX))
                {
                    // ������ �����
                    //other.HideFruit(transform.position);
                    // ���� ������
                    FruitLevleUp();

                }

            }
        }
    }

    private void FruitLevleUp()
    {
        isMerge = true;
        rigid.velocity = Vector2.zero;
        rigid.angularVelocity = 0;
        Debug.Log("8");
    }
    
}
