using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProductClientHub.Caommunication.Responses
{
    public class ResponseErrorMessagesJson
    {
        public List<string> Errors { get; private set; }
        public ResponseErrorMessagesJson(string message)
        {
            Errors = [message];
        }

        public ResponseErrorMessagesJson(List<string> messages)
        {
            Errors = messages;
        }
    }
}
