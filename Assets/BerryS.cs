using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryS : MonoBehaviour
{
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.I.addScore(collision); 
    }*/

    private bool isProcessingCollision = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isProcessingCollision) return;

        isProcessingCollision = true;
        GameManager.I.addScore(collision);
        isProcessingCollision = false;
    }
} 