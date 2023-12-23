using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    private Vector3 moveVector;
    private bool isDead = false;
    private float gravity = 9.8f;
    private CharacterController player;
    [SerializeField] protected float speed = 5f;
    private float verticalVelocity = 0f;
    private float animTime = 3.5f;

    private void Awake()
    {
        player = GetComponent<CharacterController>(); // ánh xạ đối tượng từ game vào code
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < animTime) 
        {
            player.Move(Vector3.forward * speed * Time.deltaTime);  //di chuyển theo trục Z
        }
        else
        {
            if (!isDead)  //khi nhân vật chưa die
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))   // nhấn phím mũi tên 
                {
                    moveVector.y = speed; 
                }
                if (player.isGrounded)              // khi va chạm mặt sàn
                {
                    verticalVelocity = -0.5f;
                }
                else                                // khi không va chạm mặt sàn
                {
                    verticalVelocity = verticalVelocity - (gravity * Time.deltaTime);
                }
                moveVector.z = Input.GetAxis("Horizontal") * 5;
                moveVector.y = verticalVelocity;
                moveVector.z = speed;
                player.Move(moveVector * Time.deltaTime);   // di chuyển tổng hợp 3 trục
            }
        }
    }
    // Hàm thay đổi tốc độ
    public void SetSpeed(float l)
    {
        speed += l;
    }
    // Hàm kiểm tra nhân vật die
    internal void Dead()
    {
        isDead = true;
    }
}
