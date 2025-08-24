using System.Collections;
using System.Collections.Generic;
using Network;
using SkillBridge.Message;
using UnityEngine;

public class Login : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NetClient.Instance.Init("127.0.0.1",8000);
        NetClient.Instance.Connect();
        
        
        NetMessage msg = new NetMessage();
        msg.Request = new NetMessageRequest();
        FirstTestRequest firstTestRequest = new FirstTestRequest();
        firstTestRequest.Helloword = "helloword";
        msg.Request.firstRequest = firstTestRequest;
        
        NetClient.Instance.SendMessage(msg);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
