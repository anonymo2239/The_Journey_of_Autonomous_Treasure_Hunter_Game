using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace ProLab_2._1_OtonomHazineAvcisininYolculugu_1._0
{
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }

        static int mute = 0;
        private SoundPlayer player1;
        private SoundPlayer player2;
        

        private void Form1_Load(object sender, EventArgs e)
        {
            string muzikYolu1 = "bir.wav";
            player1 = new SoundPlayer(muzikYolu1);
            string muzikYolu2 = "iki.wav";
            player2 = new SoundPlayer(muzikYolu2);
            player1.PlayLooping();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("220201048\nAdem Alperen Arda\nKocaeli Üniversitesi Bilgisayar Mühendisliği-2024", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            mute++;
            if (mute % 2 != 0)
            {
                player1.Stop();
                player2.Stop();
                pictureBox2.Image = Image.FromFile("resimler/mute.png");
            }
            else
            {
                player2.PlayLooping();
                pictureBox2.Image = Image.FromFile("resimler/speaker2.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            { Application.Exit(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
            this.Hide();
        }
    }
}
