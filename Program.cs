/* 
 created by A.Phan @linkteams consulting 
 linkteams.com
 choa.com
*/

using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;
using System.Net;

namespace CHOA
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string msg = "Your push message here";
            PushNotifications push = new PushNotifications();
            
            // change the "device token" with the actual device token
            push.SendNotificationMessage("device token", msg, 1);  
        }

    }
}
