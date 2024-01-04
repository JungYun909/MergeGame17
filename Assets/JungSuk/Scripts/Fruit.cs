using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Fruit : MonoBehaviour
{
    public FruitData fruitData1;
    public FruitData fruitData2;
    public FruitData fruitData3;
    public FruitData fruitData4;


    public int Point;
    public int level;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
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
        anim.SetInteger("Level", level);
        switch (level)
        {
            case 1:
                SettingFruit(fruitData1);
                break;

            case 2:
                SettingFruit(fruitData2);
                break;

            case 3:
                SettingFruit(fruitData3);
                break;

            default:
                SettingFruit(fruitData4);
                break;

        }
    }
}