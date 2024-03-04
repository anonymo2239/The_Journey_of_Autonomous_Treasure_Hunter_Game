using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab_2._1_OtonomHazineAvcisininYolculugu_1._0
{
    abstract class Obstacle
    {
        private string summerObjectName;
        private string winterObjectName;
        private int objectSize;

        public Obstacle(string summerObjectName, string winterObjectName)
        {
            SummerObjectName = summerObjectName;
            WinterObjectName = winterObjectName;
        }

        public string SummerObjectName
        {
            get { return summerObjectName; }
            set { summerObjectName = value; }
        }

        public string WinterObjectName
        {
            get { return winterObjectName; }
            set { winterObjectName = value; }
        }

        public int ObjectSize
        {
            get { return objectSize; }
            set { objectSize = value; }
        }
    }
}
