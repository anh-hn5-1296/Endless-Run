using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text levelText;
    //Khai bao cac bien score
    public static float score = 0f;
    private int maxLevel = 10;
    private int level = 1;
    private int scoreToNextLevel = 10;  //khoang cach giua cac level
    private bool isDead = false;        //Trang thai die

    //dinh nghia ham die
    internal void Dead()
    {
        isDead = true;
    }
    //Dinh nghia ham tang diem
    public void TangDiem(float s)
    {
        score += s;
    }
    //Dinh nghia ham tang level
    void TangLevel()
    {
        if (level == maxLevel) return;      // neu la level lon nhat
        scoreToNextLevel = scoreToNextLevel * 2;    //2 la 2 he so, co the thay doi bang so khac
        ++level;
        //thay doi toc do: tham chieu den playerRunning
        GetComponent<PlayerRunning>().SetSpeed(level);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)        //neu khong phai trang thai die 
        {
            if (score > scoreToNextLevel)       //Neu diem lon hon 10 thi tang level
            {
                TangLevel();
            }
            //cap nhat diem vao cac text
            scoreText.text = "Score: " + ((int)score).ToString();
            levelText.text = "Level: " + level;
        }
    }
}
