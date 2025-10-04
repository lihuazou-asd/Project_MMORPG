using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour
{
    public InputField username;
    public InputField psw;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        if (string.IsNullOrEmpty(username.text))
        {
            MessageBox.Show("请输入账号", "账号");
            return;
        }
        if (string.IsNullOrEmpty(psw.text))
        {
            MessageBox.Show("请输入密码", "密码");
            return;
        }
        
        UserService.Instance.SendLogin(username.text, psw.text);
    }
}
