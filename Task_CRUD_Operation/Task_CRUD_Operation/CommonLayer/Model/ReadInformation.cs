using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_CRUD_Operation.CommonLayer.Model
{
    public class ReadInformationResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<ReadInformation> readInformation { get; set; }
    }

    public class ReadInformation
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
    }
}
