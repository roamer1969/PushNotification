/* 
 created by A.Phan @linkteams consulting 
 linkteams.com
 choa.com
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;


namespace CHOA
{
    public class PushNotifications
    {
      public void SendNotificationMessage(string token, string alertText, int badge)
        {
            string key = "your urban airship app key";
            string appsecret = "your urban airship app secret";
            
            var aps = new loadobject
            {
                DeviceToken = new List<string> {token},

                APS = new loadobject.APSBody
                {
                    Badge = badge,
                    Alert = alertText
                    
                }
              
            };

            // construct json to be send to U.A. REST API
            var json = aps.ToJsonString();
             
            // communicate with urban airship push server
            var uri = new Uri("https://go.urbanairship.com/api/push/");
            var encoding = new UTF8Encoding();
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.Credentials = new NetworkCredential(key, appsecret);
            request.ContentType = "application/json";
            request.ContentLength = encoding.GetByteCount(json);

         
            using (var stream = request.GetRequestStream())
            {
                stream.Write(encoding.GetBytes(json), 0, encoding.GetByteCount(json));
                stream.Close();
                var response = request.GetResponse();
                response.Close();
            }
        }
    }
        
}

