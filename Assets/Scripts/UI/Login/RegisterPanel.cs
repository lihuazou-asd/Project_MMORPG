using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : MonoBehaviour
{
    public InputField inputZh;
    public InputField inputMm;
    public InputField inputMm2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnRegister()
    {
        if (string.IsNullOrEmpty(inputZh.text))
        {
            MessageBox.Show("请输入账号", "账号错误");
            return;
        }
        if (string.IsNullOrEmpty(inputMm.text))
        {
            MessageBox.Show("请输入密码", "密码错误");
            return;
        }
        if (string.IsNullOrEmpty(inputMm2.text))
        {
            MessageBox.Show("请输入确认密码", "确认密码错误");
            return;
        }
        if (inputMm2.text != inputMm.text)
        {
            MessageBox.Show("密码不正确", "密码错误");
            return;
        }

        UserService.Instance.SendRegister(inputZh.text, inputMm.text);
    }
}
