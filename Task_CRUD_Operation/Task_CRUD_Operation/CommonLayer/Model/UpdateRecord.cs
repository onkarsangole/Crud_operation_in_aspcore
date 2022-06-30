﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_CRUD_Operation.CommonLayer.Model
{
    public class UpdateRecordRequest
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
    }

    public class UpdateRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
