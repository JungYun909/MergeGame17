using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FruitList : MonoBehaviour
{
    public GameObject[] fruits = new GameObject[10];
    public Sprite[] sprites = new Sprite[10];
    public int[] fruitsID = new int[10];

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
            fruitsID[i] = GameManager.objectID.buffer[i];
            fruits[i].GetComponent<SpriteRenderer>().sprite = sprites[fruitsID[i]-1];
            fruits[i].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        }
    }

}
