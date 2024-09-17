using System;
using System.Runtime.Serialization;


namespace AjusteCSV.BL.Responses
{
    [Serializable]
    [DataContract]
    public class ResponseQuery<T>
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string Message { get; set; }        
    }
}
