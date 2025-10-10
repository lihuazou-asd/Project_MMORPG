using Common;
using GameServer.Managers;
using GameServer.Network;
using GameServer.Services;
using log4net;
using Network;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace GameServer
{
    class GameServer
    {
        NetService network;
        Thread thread;
        bool running = false;
        public bool Init()
        {
            int Port = Properties.Settings.Default.ServerPort;
            network = new NetService();
            network.Init(Port);
            DBService.Instance.Init();
            DataManager.Instance.Load();
            MapService.Instance.Init();
            UserService.Instance.Init();
            //FirstTestService.Instance.Init();
            //ItemService.Instance.Init();
            //QuestService.Instance.Init();
            //FriendService.Instance.Init();
            //TeamService.Instance.Init();
            //GuildService.Instance.Init();
            //ChatService.Instance.Init();
            thread = new Thread(new ThreadStart(this.Update));

            return true;

            //DBService.Instance.Init();
            //DBService.Instance.Entities.Users.Add(new TUser() { Username = "111", Password = "111", Player = null });
            //DBService.Instance.Entities.SaveChanges();
            //Log.Info("成功");
            //thread = new Thread(new ThreadStart(this.Update));
            //return true;


            //using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-JD6P6CNV\\MMORPG;Initial Catalog=ExtremeWorld;User Id=sa;Password=123456;MultipleActiveResultSets=true;"))
            //{
            //    try
            //    {
            //        Log.Info("Test");
            //        connection.Open();
            //        Log.Info("成功");
            //    }

            //    catch (Exception ex)
            //    {
            //        Log.Info("失败" + ex.Message);
            //    }

            //}

            //return true;

        }

        public void Start()
        {
            network.Start();
            //FirstTestService.Instance.Start();
            running = true;
            thread.Start();
        }


        public void Stop()
        {
            running = false;
            thread.Join();
            network.Stop();
        }

        public void Update()
        {
            var mapManager = MapManager.Instance;
            while (running)
            {
                Time.Tick();
                Thread.Sleep(100);
                //Console.WriteLine("{0} {1} {2} {3} {4}", Time.deltaTime, Time.frameCount, Time.ticks, Time.time, Time.realtimeSinceStartup);
                mapManager.Update();
            }
        }
    }
}
