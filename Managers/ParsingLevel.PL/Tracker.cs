using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Timers;
using System.IO;
using ParsingLibrary;
using BLLevel.BLL;
using ManagersApp.DAL.Interfaces;

using ManagersApp.DAL.Repositories;
using System.Threading;

namespace ParsingLevel.PL
{
    public class Tracker
    {
        DTService dTService;

        public  Tracker()
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += this.CheckForFiles;
            timer.AutoReset = true;
            timer.Enabled = true;
            dTService = new DTService(new UnitOfWork());            
        }
       
        public void CheckForFiles(Object source, ElapsedEventArgs e)
        {
            string[] files = Directory.GetFiles(ConfigurationManager.AppSettings.Get("folderToParce"));
            List<Parser> list = new List<Parser>();
            List<Thread> listThread = new List<Thread>();

            foreach (string item in files)
            {
                list.Add(new Parser(item));
            }

            foreach(Parser item in list)
            {
               listThread.Add( new Thread(() => { item.Parse(dTService); }));              
            }

            foreach (Thread item in listThread)
            {
                item.Start();
                //item.Join();
            }
        }
    }
}
