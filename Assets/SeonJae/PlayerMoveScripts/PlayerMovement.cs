using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController playerController;
    private Vector2 MoveValue = Vector2.zero;
    private Rigidbody2D rigidbody;
    [SerializeField] private Transform playerPosition;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerController.OnMoveEvent += Move;
    }
    private void Move(Vector2 value)
    {
        MoveValue = value;
    }
    private void ApplyMovement(Vector2 value)
    {
        if (playerPosition.transform.position.x > -5 && playerPosition.transform.position.x < 5)
        {
            value = value * 5;
            rigidbody.velocity = value;
        }
        else
        {
            rigidbody.velocity = Vector2.zero;
        }
    }
    private void FixedUpdate()
    {
        ApplyMovement(MoveValue);
    }
    // Update is called once per frame
    void Update()
    {
        // 범위를 벗어나면 다른 위치로 이동하도록 처리
        if (playerPosition.transform.position.x <= -5)
        {
            playerPosition.transform.position = new Vector3(-4.9f, playerPosition.transform.position.y, playerPosition.transform.position.z);
        }
        else if (playerPosition.transform.position.x >= 5)
        {
            playerPosition.transform.position = new Vector3(4.9f, playerPosition.transform.position.y, playerPosition.transform.position.z);
        }
    }
}
