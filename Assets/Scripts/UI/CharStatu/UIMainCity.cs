using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;
using UnityEngine.UI;

public class UIMainCity : MonoBehaviour
{
    public Text avatarName;

    public Text avatarLevel;
    
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateAvatar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateAvatar()
    {
        this.avatarName.text = User.Instance.CurrentCharacter.Name+"["+User.Instance.CurrentCharacter.Id+"]";
        this.avatarLevel.text = User.Instance.CurrentCharacter.Level.ToString();
    }
}
