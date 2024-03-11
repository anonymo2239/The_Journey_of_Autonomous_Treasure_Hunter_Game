using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProLab_2._1_OtonomHazineAvcisininYolculugu_1._0
{
    internal class DynamicBird : DynamicObstacle
    {
        private int howManySteps;
        private PictureBox pictureBoxBird;
        private int tickCount = 0;

        public DynamicBird(string summerObjectName, string winterObjectName, int HowManySteps, PictureBox pictureBoxBird)
            : base(summerObjectName, winterObjectName)
        {
            this.howManySteps = HowManySteps;
            this.pictureBoxBird = pictureBoxBird;
        }

        public override void Move()
        {
            Game game = new Game();
            int moveDistance = game.constantNumber;

            if (pictureBoxBird.InvokeRequired)
            {
                pictureBoxBird.Invoke(new MethodInvoker(() => Move()));
            }
            else
            {
                if (tickCount < 5)
                {
                    pictureBoxBird.Top += moveDistance;
                }
                else if (tickCount < 9)
                {
                    pictureBoxBird.Top -= moveDistance;
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
