using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient.Entities
{
    public class MessageData
    {
        public int ID { get; set; }
        public string MesContent { get; set; }
        public string Note { get; set; }
    }
}
