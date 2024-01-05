using System.Collections;
//using System; 
using System.Collections.Generic;
using UnityEngine;

public class BerryScript : MonoBehaviour
{
    public string Box = "Ground"; //���. 
    public Animator berryAnimator;
    public Animator appleAnimator;
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

        if (collidedTag == berryTag || collidedTag == Box) //if�� ������? 
        {
            Debug.Log("?");  
           berryAnimator.SetBool("BerryCrash", true); //�ε����� Ʈ��  
           Invoke("BAni", 1.0f); //�ִ� 1�� �� 
        }

        if (collidedTag == appleTag || collidedTag == Box) //if�� ������? 
        {
            Debug.Log("?");
            appleAnimator.SetBool("AppleCrash", true); //�ε����� Ʈ��  
            Invoke("Apni", 1.0f); //�ִ� 1�� �� 
        }
    }
    private void BAni() //�̵��Լ� 
    {
        berryAnimator.SetBool("BerryCrash", false); //������� 
    }
    private void Apni()
    {
        berryAnimator.SetBool("AppleCrash", false); //������� 
    }

    private void Start()
    {
        berryAnimator = GetComponent<Animator>(); 
    }
} 