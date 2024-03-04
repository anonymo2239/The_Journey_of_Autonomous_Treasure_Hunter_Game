using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab_2._1_OtonomHazineAvcisininYolculugu_1._0
{
    internal class StaticObstacle : Obstacle
    {
        private bool canBeBetween;
        public StaticObstacle(string summerObjectName, string winterObjectName, bool CanBeBetween)
        : base(summerObjectName, winterObjectName)
        {
            this.canBeBetween = CanBeBetween;
        }

        public bool CanBeBetween
        {
            get { return canBeBetween; }
            set { canBeBetween = value; }
        }

    }
}
