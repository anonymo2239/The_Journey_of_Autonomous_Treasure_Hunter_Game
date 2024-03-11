using System;
using System.Linq;
using System.Windows.Forms;

namespace ProLab_2._1_OtonomHazineAvcisininYolculugu_1._0
{
    public partial class Settings : Form
    {
        private readonly int[] allowedValues = { 1, 5, 10, 20, 30, 40 };

        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GirisEkrani form1 = new GirisEkrani();
            form1.Show();
            this.Hide();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int value = NearestAllowedValue(trackBar1.Value);
            trackBar1.Value = value;
            label2.Text = value.ToString();

            if (value == 1)
                label4.Visible = true;
            else
                label4.Visible = false;
        }

        private int NearestAllowedValue(int value)
        {
            if (allowedValues.Contains(value))
                return value;

            int minDistance = int.MaxValue;
            int nearestValue = value;

            foreach (int allowedValue in allowedValues)
            {
                int distance = Math.Abs(allowedValue - value);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestValue = allowedValue;
                }
            }

            return nearestValue;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 40;
            trackBar1.TickFrequency = 5;
            trackBar1.Value = 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GirisEkrani giris = new GirisEkrani();
            giris.label1.Text = trackBar1.Value.ToString();
            MessageBox.Show("Değişiklikler kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
