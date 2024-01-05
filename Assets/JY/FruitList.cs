using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FruitList : MonoBehaviour
{
    private GameObject[] fruits = new GameObject[10];
    public int[] fruitsID = new int[10];
    Animator anim;

    private void Start()
    {
        FruitListSetting();
    }

    // Start is called before the first frame update
    public void OnDrop(InputValue button)
    {
        FruitListSetting();
    }
    
    void FruitListSetting()
    {
        for (int i = 0; i <= 9; i++)
        {
            fruitsID[i] = GameManager.objectID.Peek();

        }
    }

}
