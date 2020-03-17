using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.models
{
    public class TableDTO
    {
#nullable enable

        public int ComensalesNum { get; set; }
        public int? NumMesa { get; set; }

        public TableDTO(int comensalesNum, int? numMesa)
        {
            ComensalesNum = comensalesNum;
            NumMesa = numMesa;
        }

#nullable disable
    }
}
