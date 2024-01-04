using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
    public Fruit fruit;
    private int fruitLevel;
    private bool isMerge;

    Rigidbody2D rigid;
    CircleCollider2D circleCollider;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        fruit.Setting();
        fruitLevel = fruit.level;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            MergeManager other = collision.gameObject.GetComponent<MergeManager>();

            if (fruitLevel == other.fruitLevel && !isMerge && !other.isMerge && fruitLevel < 5) // 동글 합치기 (합치는 도중에 개입되는 것 방지)
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
                    other.HideFruit(transform.position);
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

        StartCoroutine(FruitLevelUpRoutine());  //애니메이션
    }

    IEnumerator FruitLevelUpRoutine()   
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetInteger("Level", fruitLevel + 1);
        yield return new WaitForSeconds(0.3f);
        fruitLevel++;
        isMerge = false;

    }

    public void HideFruit(Vector3 targetPos)
    {
        isMerge = true;
        rigid.simulated = false;
        circleCollider.enabled = false;

        StartCoroutine(HideOther(targetPos));
    }

    IEnumerator HideOther(Vector3 targetPos)
    {
        int frameCount = 0;
        while (frameCount < 20)
        {
            frameCount++;
            transform.position = Vector3.Lerp(transform.position, targetPos, 0.5f);
            yield return null;
        }
        isMerge = false;
        gameObject.SetActive(false);
        Destroy(gameObject);

    }
}