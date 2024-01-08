using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FruitData", menuName = "FruitData")]
public class FruitData : ScriptableObject
{
    [SerializeField] private string fruitName; // ���� �̸�
    public string FruitName { get { return fruitName; } }

    [SerializeField] private int fruitPoint; // ���� ����Ʈ ���� ���� �ʿ�
    public int FruitPoint { get { return fruitPoint; } }

    [SerializeField] private LayerMask fruitMask; // ���� ���̾� ����ũ
    public LayerMask FruitMask { get {  return fruitMask; } }

    [SerializeField] private string fruitTag;
    public string FruitTag { get {  return fruitTag; } }

    [SerializeField] private Vector2 fruitSize; // ���� ������
    public Vector2 FruitSize { get {  return fruitSize; } }

    [SerializeField] private Color fruitColor; // ���� ����
    public Color FruitColor { get {  return fruitColor; } }  
    




}
