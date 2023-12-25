using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 animationOffset, startOffset, moveVector;
    private float transition = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        // Ánh xạ
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animationOffset = new Vector3(0, 5, 5);                 //Khởi tạo 
        startOffset = transform.position - player.position;     // khoảng cách giữa camera và player

    }

    // Update is called once per frame
    void Update()
    {
        moveVector = player.position + startOffset;
        moveVector.x = 0f;                                // Khong di chuyển camera khi sang trái, sang phải
        moveVector.y = Mathf.Clamp(moveVector.y, 3f, 5f); // Camera di chuyển theo trục y
        transform.position = moveVector;
        if (transition > 1f)
        {
            transform.position = moveVector;
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += 0.2f * Time.deltaTime;
            transform.LookAt(player.position);
        }
    }
}
