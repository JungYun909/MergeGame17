using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
    public int level;
    public bool isMerge;

    Rigidbody2D rigid;
    CircleCollider2D circleCollider;
    Animator animator;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            MergeManager other = collision.gameObject.GetComponent<MergeManager>();
            if (level == other.level && !isMerge && !other.isMerge && level < 10)
            {
                float thisX = transform.position.x;
                float thisY = transform.position.y;
                float otherX = transform.position.x;
                float otherY = transform.position.y;
                if (thisY < otherY || (thisY == otherY && thisX < otherX))
                {
                    other.HideFruit(transform.position);
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
        yield return new WaitForSeconds(0.1f);
        animator.SetInteger("Level", level + 1);
        yield return new WaitForSeconds(0.2f);
        level++;

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
    }
}
