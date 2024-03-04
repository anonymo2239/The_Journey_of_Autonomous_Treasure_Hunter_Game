using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProLab_2._1_OtonomHazineAvcisininYolculugu_1._0
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GirisEkrani form1 = new GirisEkrani();
            form1.ShowDialog();
            this.Hide();
        }
    }
}
