using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Fruit : MonoBehaviour
{
    public FruitData[] fruitData = new FruitData[10];

    public int Point;
    public int level;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        level = GameManager.I.newFruitLevel;
        anim.SetInteger("Level", level);
    }

    private void SettingFruit(FruitData fruitData)
    {
        gameObject.name = fruitData.FruitName;

        Point = fruitData.FruitPoint;

        //gameObject.layer = LayerMask.NameToLayer("Fruit");
        transform.localScale = fruitData.FruitSize;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        //renderer.color = fruitData.FruitColor;
    }

    public void Setting()
    {
        SettingFruit(fruitData[level-1]);
       
    }
}