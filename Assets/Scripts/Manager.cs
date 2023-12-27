using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private AudioClip audio;
    [SerializeField] private string sceneName;
    [SerializeField] private Text score;

    public void LoadingScene()
    {
        SoundManager.Instance.PlaySound(audio); //bat am thanh
        Application.LoadLevel(sceneName);       //goi scene khac
        ScoreManager.score = 0f;        //reset diem
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + ((int)ScoreManager.score).ToString();
    }
}
