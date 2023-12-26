using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth = 100;
    private Animator anim;
    private float time;
    private AudioSource audioSource;
    public AudioClip deadSound;        //khi chet phat ra am thanh
    public AudioClip hurtSound;        //khi bat dau phat ra am thanh
    
    //Dinh nghia delegate: thay doi phan tram suc khoe
    public event Action<float> OnHealthPrecentChanged = delegate { };

    private void Awake()
    {
        anim = GetComponent<Animator>();                //anh xa nhan vat
        audioSource = GetComponent<AudioSource>();      //anh xa am thanh
    }
    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        float currentHealthPercent = currentHealth / maxHealth;
        if (currentHealth > 10)     //co the thay 10 bang so khac
        {
            //Phat ra am thanh: bi dau
        }
        OnHealthPrecentChanged(currentHealthPercent);   //thay doi tren man hinh tich mau
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Quan ly suc khoe
        if(currentHealth <= 0)      //nhan vat die
        {
            // Xu ly am thanh
            audioSource.Pause();
            audioSource.clip = deadSound;
            audioSource.loop = false;
            // 
            audioSource.Play();
            audioSource.loop = false;
            //set trang thai die
            anim.SetInteger("Death", 1);
            GetComponent<PlayerRunning>().Dead();       //Goi ham die: nhan vat ko chay
            GetComponent<ScoreManager>().Dead();        //Goi ham die: khong cong diem
        }
        if (time > 4f)      //Thoi gian cho de sang level
        {
            Application.LoadLevel("Game Over");
        }
    }
}
