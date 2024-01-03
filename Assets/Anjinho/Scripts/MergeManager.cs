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
        Debug.Log("8");

        StartCoroutine(FruitLevelUpRoutine());  //애니메이션
    }

    IEnumerator FruitLevelUpRoutine()   //여기가 반복적인게 많아서 간략화 시키고 싶은데...흠
    {
        yield return new WaitForSeconds(0.2f);
        if (level == 1)
        {
            // 현재 오브젝트의 위치를 가져와서 "Fruit2"의 위치로 설정
            Vector3 newPosition = transform.position;

            // 기존 오브젝트 비활성화
            gameObject.SetActive(false);

            // "Fruit2" 오브젝트를 찾아서 활성화하고 새로운 위치로 설정
            GameObject fruit2 = GameObject.Find("Fruit").transform.Find("Fruit2").gameObject;
            fruit2.SetActive(true);
            fruit2.transform.position = newPosition;

        }
        if (level == 2)
        {
            Vector3 newPosition = transform.position;
            gameObject.SetActive(false);
            GameObject fruit3 = GameObject.Find("Fruit").transform.Find("Fruit3").gameObject;
            fruit3.SetActive(true);
            fruit3.transform.position = newPosition;
        }
        if (level == 3)
        {
            Vector3 newPosition = transform.position;
            gameObject.SetActive(false);
            GameObject fruit3 = GameObject.Find("Fruit").transform.Find("Fruit4").gameObject;
            fruit3.SetActive(true);
            fruit3.transform.position = newPosition;
        }
        
        isMerge = false;

    }

    public void HideFruit(Vector3 targetPos)
    {
        isMerge = true;
        rigid.simulated = false;
        circleCollider.enabled = false;
        Debug.Log("2");

        StartCoroutine(HideOther(targetPos));
    }

    IEnumerator HideOther(Vector3 targetPos)
    {
        int frameCount = 0;
        while (frameCount < 20)
        {
            Debug.Log("3");
            frameCount++;
            transform.position = Vector3.Lerp(transform.position, targetPos, 0.5f);
            yield return null;
        }
        isMerge = false;
        gameObject.SetActive(false);
        
    }
}
