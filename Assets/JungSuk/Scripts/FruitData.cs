using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FruitData", menuName = "FruitData")]
public class FruitData : ScriptableObject
{
    [SerializeField] private string fruitName; // 과일 이름
    public string FruitName { get { return fruitName; } }

    [SerializeField] private int fruitPoint; // 과일 포인트 점수 계산시 필요
    public int FruitPoint { get { return fruitPoint; } }

    [SerializeField] private LayerMask fruitMask; // 과일 레이어 마스크
    public LayerMask FruitMask { get {  return fruitMask; } }

    [SerializeField] private string fruitTag;
    public string FruitTag { get {  return fruitTag; } }

    [SerializeField] private Vector2 fruitSize; // 과일 사이즈
    public Vector2 FruitSize { get {  return fruitSize; } }

    [SerializeField] private Color fruitColor; // 과일 색깔
    public Color FruitColor { get {  return fruitColor; } }  
    




}
