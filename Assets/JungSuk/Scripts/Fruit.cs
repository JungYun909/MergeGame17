using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fruit : MonoBehaviour
{
    public FruitData fruitData;
    public int Point;

    private void Awake()
    {
      
    }

    private void Start()
    {
        SettingFruit(fruitData);
    }

    private void SettingFruit(FruitData fruitData)
    {
        if (fruitData != null)
        {
            gameObject.name = fruitData.FruitName;

            Point = fruitData.FruitPoint;

            gameObject.layer = LayerMask.NameToLayer("Fruit");
            //gameObject.layer |= fruitData.FruitMask

            gameObject.tag = fruitData.FruitTag;
            transform.localScale = fruitData.FruitSize;

            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.color = fruitData.FruitColor;
        }
    }

}
