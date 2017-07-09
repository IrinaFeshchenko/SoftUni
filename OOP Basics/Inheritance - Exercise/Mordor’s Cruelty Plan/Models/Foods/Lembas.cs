using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mordor_s_Cruelty_Plan.Models.Foods
{

    public class Lembas:Food
    {
        private const int happinessPoints = 3;

        public Lembas() : base(happinessPoints)
        {
        }
    }
}
