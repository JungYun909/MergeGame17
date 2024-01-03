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

            if (level == other.level && !isMerge && !other.isMerge && level < 4) // 동글 합치기 (합치는 도중에 개입되는 것 방지)
            {
                // 자신과 상대편 위치 가져오기
                float meX = transform.position.x;
                float meY = transform.position.y;
                float otherX = other.transform.position.x;
                float otherY = other.transform.position.y;

                // 1. 내가 아래에 있을 때
                // 2. 동일한 높이일 때, 내가 오른쪽에 있을 때
                if (meY < otherY || (meY == otherY && meX > otherX))
                {
                    // 상대방은 숨기기
                    //other.HideFruit(transform.position);
                    // 나는 레벨업
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
