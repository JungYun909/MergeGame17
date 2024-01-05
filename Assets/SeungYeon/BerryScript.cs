using System.Collections;
//using System; 
using System.Collections.Generic;
using UnityEngine;

public class BerryScript : MonoBehaviour
{
    public string Box = "Ground"; //사과. 
    public Animator berryAnimator;
    public Animator appleAnimator;
    public string berryTag = "Berry"; //딸기. 
    public GameObject berryPrefab;
    public string appleTag = "Apple"; //사과. 
    public GameObject applePrefab; 


    private bool isProcessingCollision = false; 

    private void OnCollisionEnter2D(Collision2D collision) //콜라이더 충돌시 
    {
        if (isProcessingCollision) return;

        isProcessingCollision = true;
        GameManager.I.addScore(collision);
        isProcessingCollision = false;

        string collidedTag = collision.gameObject.tag; 

        if (collidedTag == berryTag || collidedTag == Box) //if문 들어오나? 
        {
            Debug.Log("?");  
           berryAnimator.SetBool("BerryCrash", true); //부딪히면 트루  
           Invoke("BAni", 1.0f); //애니 1초 후 
        }

        if (collidedTag == appleTag || collidedTag == Box) //if문 들어오나? 
        {
            Debug.Log("?");
            appleAnimator.SetBool("AppleCrash", true); //부딪히면 트루  
            Invoke("Apni", 1.0f); //애니 1초 후 
        }
    }
    private void BAni() //이동함수 
    {
        berryAnimator.SetBool("BerryCrash", false); //원래대로 
    }
    private void Apni()
    {
        berryAnimator.SetBool("AppleCrash", false); //원래대로 
    }

    private void Start()
    {
        berryAnimator = GetComponent<Animator>(); 
    }
} 