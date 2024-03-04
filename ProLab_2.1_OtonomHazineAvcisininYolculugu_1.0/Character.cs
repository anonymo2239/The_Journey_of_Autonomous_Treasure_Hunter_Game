using ProLab_2._1_OtonomHazineAvcisininYolculugu_1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Character : Obstacle
{
    public int ID { get; set; }

    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Character(string summerObjectName, string winterObjectName, int id, string name)
        : base(summerObjectName, winterObjectName)
    {
        ID = id;
        Name = name;
    }
    //lokasyon en kısa yol algoritmaları ekle
}
