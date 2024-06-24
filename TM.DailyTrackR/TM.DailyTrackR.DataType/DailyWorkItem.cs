using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.DailyTrackR.DataType.Enums;

namespace TM.DailyTrackR.DataType
{
    public class DailyWorkItem
    {
        public int NO { get; set; }
        public string ProjectType { get; set; }
        public TaskTypeEnum TaskType { get; set; }
        public string Description { get; set; }
        public StatusEnum Status {  get; set; }
        public int id { get; set; }
        
    }
}
