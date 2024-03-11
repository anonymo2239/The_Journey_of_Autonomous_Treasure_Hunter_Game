using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProLab_2._1_OtonomHazineAvcisininYolculugu_1._0
{
    internal class DynamicObstacle : Obstacle
    {
        private Timer timer;
        private int tickCount = 0;

        public DynamicObstacle(string summerObjectName, string winterObjectName)
            : base(summerObjectName, winterObjectName)
        {
            timer = new Timer();
            timer.Interval = 500;
            timer.Elapsed += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, ElapsedEventArgs e)
        {
            Move();
        }

        public virtual void Move()
        {
            if (tickCount < 5)
            {
                
            }
            else
            {
                tickCount = 0;
            }

            tickCount++;
        }
    }
}
