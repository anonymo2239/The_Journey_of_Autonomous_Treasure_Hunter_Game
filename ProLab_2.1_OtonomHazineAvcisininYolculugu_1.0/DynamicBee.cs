using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProLab_2._1_OtonomHazineAvcisininYolculugu_1._0
{
    internal class DynamicBee : DynamicObstacle
    {
        private int howManySteps;
        private PictureBox pictureBoxBee;
        private int tickCount = 0;

        public DynamicBee(string summerObjectName, string winterObjectName, int HowManySteps, PictureBox pictureBoxBee)
            : base(summerObjectName, winterObjectName)
        {
            this.howManySteps = HowManySteps;
            this.pictureBoxBee = pictureBoxBee;
        }

        public override void Move()
        {
            Game game = new Game();
            int moveDistance = game.constantNumber;

            if (pictureBoxBee.InvokeRequired)
            {
                pictureBoxBee.Invoke(new MethodInvoker(() => Move()));
            }
            else
            {
                if (tickCount < 3)
                {
                    pictureBoxBee.Left += moveDistance;
                }
                else if (tickCount < 5)
                {
                    pictureBoxBee.Left -= moveDistance;
                }
                else
                {
                    tickCount = 0;
                }

                tickCount++;
            }
            
        }
    }

}
