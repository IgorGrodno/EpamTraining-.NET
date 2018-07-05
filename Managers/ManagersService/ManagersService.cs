using BLLevel.BLL;
using ManagersApp.DAL.Entities;
using ManagersApp.DAL.Repositories;
using ParsingLevel.PL;
using ParsingLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ManagersService
{
    public partial class ManagersService : ServiceBase
    {
        

        public ManagersService()
        {
            InitializeComponent();

        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            Tracker tracker = new Tracker();
        }

        
        protected override void OnStop()
        {
            
        }
    }
}
