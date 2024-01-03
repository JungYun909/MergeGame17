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
        Debug.Log("8");

        StartCoroutine(FruitLevelUpRoutine());  //�ִϸ��̼�
    }

    IEnumerator FruitLevelUpRoutine()   //���Ⱑ �ݺ����ΰ� ���Ƽ� ����ȭ ��Ű�� ������...��
    {
        yield return new WaitForSeconds(0.2f);
        if (level == 1)
        {
            // ���� ������Ʈ�� ��ġ�� �����ͼ� "Fruit2"�� ��ġ�� ����
            Vector3 newPosition = transform.position;

            // ���� ������Ʈ ��Ȱ��ȭ
            gameObject.SetActive(false);

            // "Fruit2" ������Ʈ�� ã�Ƽ� Ȱ��ȭ�ϰ� ���ο� ��ġ�� ����
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
