using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace BackendService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            #if (!DEBUG)

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new BackendService() 
            };
            ServiceBase.Run(ServicesToRun);
            #else
                // Debug code: this allows the process to run as a non-service.
                // It will kick off the service start point, but never kill it.
                // Shut down the debugger to exit
                BackendService service = new BackendService();
                service.SubscribeToQ();
                // Put a breakpoint on the following line to always catch
                // your service when it has finished its work
                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            #endif 


        }
    }
}
