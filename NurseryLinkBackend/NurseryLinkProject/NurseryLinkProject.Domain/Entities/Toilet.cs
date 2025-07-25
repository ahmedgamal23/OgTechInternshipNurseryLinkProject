using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Entities
{
    public class Toilet: Activity
    {
        public VisitType VisitType { get; set; }
    }

    public enum VisitType
    {
        ToiletVisit,
        DiaperChange,
        PottyTraining,
        Other
    }
}
