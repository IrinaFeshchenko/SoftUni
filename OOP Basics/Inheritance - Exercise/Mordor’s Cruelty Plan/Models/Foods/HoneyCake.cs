using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mordor_s_Cruelty_Plan.Models.Foods
{
    public class HoneyCake:Food
    {
        private const int happinessPoints = 5;

        public HoneyCake() : base(happinessPoints)
        {
        }
    }
}
