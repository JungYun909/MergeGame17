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

            if (fruitLevel == other.fruitLevel && !isMerge && !other.isMerge && fruitLevel < 5) // ���� ��ġ�� (��ġ�� ���߿� ���ԵǴ� �� ����)
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
                    other.HideFruit(transform.position);
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

        StartCoroutine(FruitLevelUpRoutine());  //�ִϸ��̼�
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