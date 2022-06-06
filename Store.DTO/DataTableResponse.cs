using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public class DataTableResponse
    {
        public DataTableResponse() { }

        public DataTableResponse(int ITotalRecords, object Data)
        {
            this.ITotalRecords = ITotalRecords;
            AaData = Data;
        }

        public int ITotalRecords { get; set; }

        public int ITotalDisplayRecords => ITotalRecords;

        public object AaData { get; set; }

        public object Data => AaData;

    }
}
