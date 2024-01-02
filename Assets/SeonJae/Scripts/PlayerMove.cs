using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;     // 속도 조정
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");  // 수평 이동 - A/D

        transform.position += new Vector3(x, 0) * Time.deltaTime * speed;    //이동 구현
    }
}
