using Common;
using log4net;
using Network;
using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Services
{
    class FirstTestService:Singleton<FirstTestService>
    {
        public void Init()
        {

        }
        public void Start()
        {
            MessageDistributer<NetConnection<NetSession>>.Instance.Subscribe<FirstTestRequest>(this.OnFirstTestRequest);
        }

        public void Stop() 
        { 
        
        
        }


        private void OnFirstTestRequest(NetConnection<NetSession> sender, FirstTestRequest request)
        {
            Log.InfoFormat("ttttttt{0}", request.Helloword);
        }
    }
}
