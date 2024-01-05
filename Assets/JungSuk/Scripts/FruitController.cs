using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FruitType { Charry, Strawberry, Grape, Orange}
public class FruitController : MonoBehaviour
{
    [SerializeField] private List<FruitData> fruitDatas;    
    [SerializeField] private GameObject fruitprefab;
    // Start is called before the first frame update
    /* void Start()
    {
        for(int i = 0; i < fruitDatas.Count; i++)
        {
            var fruit = SpawnFruit((FruitType)i);
        }
    }

    public Fruit SpawnFruit(FruitType type)
    {
        var newFruit = Instantiate(fruitprefab).GetComponent<Fruit>();
        newFruit.fruitData = fruitDatas[(int)type];
        newFruit.name = newFruit.fruitData.name;
        return newFruit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
