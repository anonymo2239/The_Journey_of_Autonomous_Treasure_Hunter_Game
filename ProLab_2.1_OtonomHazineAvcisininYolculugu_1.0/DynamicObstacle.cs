using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab_2._1_OtonomHazineAvcisininYolculugu_1._0
{
    internal class DynamicObstacle : Obstacle
    {
        private int howManySteps;

        public DynamicObstacle(string summerObjectName, string winterObjectName, int HowManySteps)
        : base(summerObjectName, winterObjectName)
        {
            this.howManySteps = HowManySteps;
        }

        public int HowManySteps
        {
            get { return howManySteps; }
            set { howManySteps = value; }
        }
    }
}
