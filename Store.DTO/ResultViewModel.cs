using System;

namespace Store.DTO
{
    public class ResultViewModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
