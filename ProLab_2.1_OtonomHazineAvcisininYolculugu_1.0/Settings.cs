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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
            if (trackBar1.Value == 1)
                label4.Visible = true;
            else
                label4.Visible = false;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 40;
            trackBar1.Value = 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.constantNumber = trackBar1.Value;
            MessageBox.Show("Değişiklikler kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public int TrackBarValue
        {
            get { return trackBar1.Value; }
        }
    }
}
