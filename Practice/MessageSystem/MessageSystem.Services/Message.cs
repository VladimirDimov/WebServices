namespace MessageSystem.Services
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class Message
    {
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public DateTime DateSend { get; set; }
    }
}
