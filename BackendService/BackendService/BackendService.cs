using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using EasyNetQ;
using OrderModels;
using RabbitMQ.Client;

namespace BackendService
{
    public partial class BackendService : ServiceBase
    {
        public BackendService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.SubscribeToQ();
        }

        public void SubscribeToQ()
        {
            var bus = RabbitHutch.CreateBus("host=localhost;username=guest;password=guest");
            bus.Subscribe<Order>("worker1", order => Console.WriteLine("Received Order with following data: {0}, {1}, {2}, {3}", 
                order.CustomerName, order.EmailId, order.Details, order.SampleXML));
        }

        protected override void OnStop()
        {
            //do nothing
        }
    }
}
