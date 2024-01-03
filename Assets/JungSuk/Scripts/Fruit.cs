using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fruit : MonoBehaviour
{
    Animator anim;
    public FruitData fruitData;
    public int Point;
    public int level;

    private void Awake()
    {
        anim = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        level = GameManager.I.newFruitLevel;
        anim.SetInteger("Level", level);
    }


}
