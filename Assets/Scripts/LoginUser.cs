using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginUser : MonoBehaviour
{
    public TMP_InputField edtUser, edtPass;
    public TMP_Text txtError;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkLogin()
    {
        var user = edtUser.text;
        var pass = edtPass.text;

        //Call api
        if (user.Equals("anhhn") && pass.Equals("123"))
        {
            SceneManager.LoadScene("StartGame");
        }
        else
        {
            txtError.text = "Login Failed";
        }
    }
}
