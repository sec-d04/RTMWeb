using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenRTM.Core;
using OpenRTM.IIOP;
using System.Net;
using System.IO;

namespace WebToRTM
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager(args);
            manager.AddTypes(typeof(CorbaProtocolManager));
            manager.Activate();
            var comp = manager.CreateComponent<WebToRTM>();
            manager.Run();
        }
    }
}
