using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsModel
{
    public class Line
    {
        public int LineId { get; set; }
        public string LineName { get; set; }
        public string LineQiDian { get; set; }
        public string LineZhongDian { get; set; }
        public int LineOutsource { get; set; }
        public string LineHuozhu { get; set; }
        public string LinePhone { get; set; }
        public string LineDanwei { get; set; }
        public string LineRemark { get; set; }
        public DateTime LineDate { get; set; }

    }
}
