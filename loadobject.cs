/*
 created by A.Phan @linkteams consulting 
 linkteams.com
 choa.com
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;

namespace CHOA
{
    [DataContract(Name = "loadobject")]
    public class loadobject
    {
        [DataMember(Name = "device_tokens")]
        public List<string> DeviceToken { get; set; }
        
       // optional aliases
       // [DataMember(Name = "aliases")]
      //  public List<string> Aliases { get; set; }

        [DataMember(Name = "aps")]
        public APSBody APS { get; set; }

        [DataContract(Name = "apsBody")]
        public class APSBody
        {
            [DataMember(Name = "badge")]
            public int Badge { get; set; }

            [DataMember(Name = "alert")]
            public string Alert { get; set; }

          // optional sound
          //  [DataMember(Name = "sound")]
          //  public string Sound { get; set; }
        }

        

        public string ToJsonString()
        {
            var ms = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(loadobject));
            ser.WriteObject(ms, this);
            ms.Seek(0, SeekOrigin.Begin);
            var sr = new StreamReader(ms);
            var result = sr.ReadToEnd();
            ms.Close();
            ms.Dispose();
            return result;
        }
    }

}
