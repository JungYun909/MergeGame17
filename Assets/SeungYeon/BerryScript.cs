using System.Collections;
//using System; 
using System.Collections.Generic;
using UnityEngine;

public class BerryScript : MonoBehaviour
{
    public Animator berryAnimator;
    public string berryTag = "Berry"; //����. 
    public GameObject berryPrefab;
    public string appleTag = "Apple"; //���. 
    public GameObject applePrefab; 


    private bool isProcessingCollision = false; 

    private void OnCollisionEnter2D(Collision2D collision) //�ݶ��̴� �浹�� 
    {
        if (isProcessingCollision) return;

        isProcessingCollision = true;
        GameManager.I.addScore(collision);
        isProcessingCollision = false;

        string collidedTag = collision.gameObject.tag; 

        if (collidedTag == berryTag) //if�� ������? 
        {
           berryAnimator.SetBool("BerryCrash", true); //�ε����� Ʈ��  
           Invoke("ReturnToOriginalState", 1.0f); //�ִ� 1�� �� 
        }

    }
    private void ReturnToOriginalState()
    {
        berryAnimator.SetBool("BerryCrash", false); //������� 
    }

    private void Start()
    {
        berryAnimator = GetComponent<Animator>(); 
    }
} 