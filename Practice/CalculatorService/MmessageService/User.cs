using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization; // Needed to use [DataContract] and [DataMember]
using System.Text;
using System.Threading.Tasks;

namespace MmessageService
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Name { get; set; }
    }
}
