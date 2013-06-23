using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LoggingEntities;

namespace LoggingServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ILoggingService
    {

        [OperationContract]
        void SubmitLog(Log log);


    }

    [DataContract]
    public class Log
    {

        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Priority { get; set; }
        [DataMember]
        public string EventID { get; set; }
        [DataMember]
        public string Severity { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Message { get; set; }

    }


}


