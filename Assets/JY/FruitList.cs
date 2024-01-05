using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FruitList : MonoBehaviour
{
    public GameObject fruits;
    public Sprite[] sprites = new Sprite[9];
    public int fruitsID;

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

        fruitsID = GameManager.objectID.Peek();
        fruits.GetComponent<SpriteRenderer>().sprite = sprites[fruitsID - 1];
        fruits.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);


    }

}
