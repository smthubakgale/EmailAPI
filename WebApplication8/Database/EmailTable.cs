using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Send_Email.Database
{
    public class EmailTable
    {
        public string Idx { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string body { get; set; }

    }
}
