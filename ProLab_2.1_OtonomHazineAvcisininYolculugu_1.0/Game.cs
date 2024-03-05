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
    public partial class Game : Form
    {
        static PictureBox pictureBoxChar = new PictureBox();
        private int horizontal_length = 0;
        private int vertical_length = 0;
        private int constantNumber = 10;
        private Label labelRed;
        static Character character;
        private List<PictureBox> redPictureBoxes;

        public Game()
        {
            InitializeComponent();
            character = new Character("resimler/karakter.png", "resimler/karli_karakter.png", Convert.ToInt32(textBox4.Text), textBox3.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GirisEkrani form = new GirisEkrani();
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            try
            {
                horizontal_length = Convert.ToInt32(textBox1.Text);
                vertical_length = Convert.ToInt32(textBox2.Text);
                label2.Text = "";
                panel1.Invalidate();
            }
            catch (Exception ex)
            {
                label2.Font = new Font("Montserrat", 20, FontStyle.Regular);
                label2.Visible = true;
                label2.Text = ex.Message;
            }

            Random random = new Random();
            StaticObstacle treeStatic = new StaticObstacle("resimler/agac.png", "resimler/karli_agac.png", true);
            StaticObstacle rockStatic = new StaticObstacle("resimler/kaya.png", "resimler/karli_kaya.png", true);
            StaticObstacle mountainStatic = new StaticObstacle("resimler/dag.png", "resimler/karli_dag.png", true);
            StaticObstacle wallStatic = new StaticObstacle("resimler/duvar.jpeg", "resimler/karli_duvar.jpg", true);
            DynamicObstacle beeDynamic = new DynamicObstacle("resimler/ari.png", "resimler/karli_ari.png", 3);
            DynamicObstacle birdDynamic = new DynamicObstacle("resimler/kus.png", "resimler/karli_kus.png", 5);

            beeDynamic.ObjectSize = 2;
            birdDynamic.ObjectSize = 2;
            wallStatic.ObjectSize = 10;

            int numberofobject = random.Next(30, 35);
            int halfWidth = panel1.Width / 2;

            string[] summer_objects = { treeStatic.SummerObjectName, rockStatic.SummerObjectName, 
                mountainStatic.SummerObjectName, wallStatic.SummerObjectName, beeDynamic.SummerObjectName, birdDynamic.SummerObjectName };
            string[] winter_objects = { treeStatic.WinterObjectName, rockStatic.WinterObjectName,
                mountainStatic.WinterObjectName, wallStatic.WinterObjectName, beeDynamic. WinterObjectName, birdDynamic.WinterObjectName };

            List<Rectangle> placedRectangles = new List<Rectangle>();

            int mountainCount = 0;
            int wallCount = 0;

            for (int i = 0; i < numberofobject; i++)
            {
                int x_random, y_random;
                bool isOverlapping;

                Rectangle currentRectangle;

                do
                {
                    x_random = random.Next(halfWidth - horizontal_length / 2, halfWidth + (horizontal_length / 2) - constantNumber * 5);
                    y_random = random.Next(0, vertical_length - constantNumber * 8);
                    x_random -= x_random % constantNumber;
                    y_random -= y_random % constantNumber;
                    currentRectangle = new Rectangle(x_random, y_random, constantNumber, constantNumber);
                    isOverlapping = false;

                    foreach (Rectangle placedRectangle in placedRectangles)
                    {
                        if (currentRectangle.IntersectsWith(placedRectangle))
                        {
                            isOverlapping = true;
                            break;
                        }
                    }

                    foreach (Control control in panel1.Controls)
                    {
                        if (control is PictureBox)
                        {
                            PictureBox pictureBox2 = (PictureBox)control;
                            if (currentRectangle.IntersectsWith(pictureBox2.Bounds))
                            {
                                isOverlapping = true;
                                break;
                            }
                        }
                    }
                } while (isOverlapping);

                placedRectangles.Add(currentRectangle);

                int object_no = random.Next(0, summer_objects.Length);
                treeStatic.ObjectSize = random.Next(2, 6);
                rockStatic.ObjectSize = random.Next(2, 4);

                if (winter_objects[object_no] == mountainStatic.WinterObjectName && mountainCount < 3)
                {
                    mountainCount++;
                }
                else if (winter_objects[object_no] == mountainStatic.WinterObjectName && mountainCount >= 3)
                {
                    continue;
                }

                if (winter_objects[object_no] == wallStatic.WinterObjectName || winter_objects[object_no] == wallStatic.SummerObjectName)
                {
                    if (wallCount >= 8)
                    {
                        continue;
                    }
                    wallCount++;
                }

                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = new Point(x_random, y_random);
                pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBox.BackColor = Color.Transparent;

                if (x_random < 600)
                {
                    pictureBox.BackgroundImage = Image.FromFile(winter_objects[object_no]);
                }
                else
                {
                    pictureBox.BackgroundImage = Image.FromFile(summer_objects[object_no]);
                }

                if (winter_objects[object_no] == treeStatic.WinterObjectName || winter_objects[object_no] == treeStatic.SummerObjectName)
                {
                    pictureBox.Size = new Size(constantNumber * treeStatic.ObjectSize, constantNumber * treeStatic.ObjectSize);
                }
                else if (winter_objects[object_no] == rockStatic.WinterObjectName || winter_objects[object_no] == rockStatic.SummerObjectName)
                {
                    pictureBox.Size = new Size(constantNumber * rockStatic.ObjectSize, constantNumber * rockStatic.ObjectSize);
                }
                else if (winter_objects[object_no] == mountainStatic.WinterObjectName || winter_objects[object_no] == mountainStatic.SummerObjectName)
                {
                    pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBox.Size = new Size(constantNumber * 15, constantNumber * 15);
                    pictureBox.SendToBack();
                }
                else if (winter_objects[object_no] == wallStatic.WinterObjectName || winter_objects[object_no] == wallStatic.SummerObjectName)
                {
                    pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBox.Size = new Size(constantNumber * wallStatic.ObjectSize, constantNumber * 1);
                }
                else if (winter_objects[object_no] == beeDynamic.WinterObjectName || winter_objects[object_no] == beeDynamic.SummerObjectName)
                {
                    pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBox.Size = new Size(constantNumber * beeDynamic.ObjectSize, constantNumber * beeDynamic.ObjectSize);
                }
                else if (winter_objects[object_no] == birdDynamic.WinterObjectName || winter_objects[object_no] == birdDynamic.SummerObjectName)
                {
                    pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBox.Size = new Size(constantNumber * birdDynamic.ObjectSize, constantNumber * birdDynamic.ObjectSize);
                }

                panel1.Controls.Add(pictureBox);
            }

            StaticObstacle goldStatic = new StaticObstacle("resimler/altin_sandik.png", "resimler/karli_altin_sandik.png", true);
            StaticObstacle copperStatic = new StaticObstacle("resimler/bakir_sandik.png", "resimler/karli_bakir_sandik.png", true);
            StaticObstacle emeraldStatic = new StaticObstacle("resimler/zumrut_sandik.png", "resimler/karli_zumrut_sandik.png", true);
            StaticObstacle silverStatic = new StaticObstacle("resimler/gumus_sandik.png", "resimler/karli_gumus_sandik.png", true);
            int gold_random_x;
            int gold_random_y;
            int copper_random_x;
            int copper_random_y;
            int emerald_random_x;
            int emerald_random_y;
            int silver_random_x;
            int silver_random_y;
            Random random_tr1 = new Random();

            for (int i = 0; i < 5; i++)
            {
                gold_random_x = random_tr1.Next(halfWidth - horizontal_length / 2, halfWidth + (horizontal_length / 2) - constantNumber * 5);
                gold_random_y = random_tr1.Next(0, vertical_length - constantNumber * 8);
                gold_random_x -= gold_random_x % constantNumber;
                gold_random_y -= gold_random_y % constantNumber;
                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = new Point(gold_random_x, gold_random_y);
                if (gold_random_x < 600)
                    pictureBox.BackgroundImage = Image.FromFile(goldStatic.WinterObjectName);
                else
                    pictureBox.BackgroundImage = Image.FromFile(goldStatic.SummerObjectName);
                pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBox.BackColor = Color.Transparent;
                pictureBox.Size = new Size(constantNumber * 1, constantNumber * 1);
                panel1.Controls.Add(pictureBox);

                copper_random_x = random_tr1.Next(halfWidth - horizontal_length / 2, halfWidth + (horizontal_length / 2) - constantNumber * 5);
                copper_random_y = random_tr1.Next(0, vertical_length - constantNumber * 8);
                copper_random_x -= copper_random_x % constantNumber;
                copper_random_y -= copper_random_y % constantNumber;
                PictureBox pictureBox2 = new PictureBox();
                pictureBox2.Location = new Point(copper_random_x, copper_random_y);
                if (copper_random_x < 600)
                    pictureBox2.BackgroundImage = Image.FromFile(copperStatic.WinterObjectName);
                else
                    pictureBox2.BackgroundImage = Image.FromFile(copperStatic.SummerObjectName);
                pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBox2.BackColor = Color.Transparent;
                pictureBox2.Size = new Size(constantNumber * 1, constantNumber * 1);
                panel1.Controls.Add(pictureBox2);

                emerald_random_x = random_tr1.Next(halfWidth - horizontal_length / 2, halfWidth + (horizontal_length / 2) - constantNumber * 5);
                emerald_random_y = random_tr1.Next(0, vertical_length - constantNumber * 8);
                emerald_random_x -= emerald_random_x % constantNumber;
                emerald_random_y -= emerald_random_y % constantNumber;
                PictureBox pictureBox3 = new PictureBox();
                pictureBox3.Location = new Point(emerald_random_x, emerald_random_y);
                if (emerald_random_x < 600)
                    pictureBox3.BackgroundImage = Image.FromFile(emeraldStatic.WinterObjectName);
                else
                    pictureBox3.BackgroundImage = Image.FromFile(emeraldStatic.SummerObjectName);
                pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBox3.BackColor = Color.Transparent;
                pictureBox3.Size = new Size(constantNumber * 1, constantNumber * 1);
                panel1.Controls.Add(pictureBox3);

                silver_random_x = random_tr1.Next(halfWidth - horizontal_length / 2, halfWidth + (horizontal_length / 2) - constantNumber * 5);
                silver_random_y = random_tr1.Next(0, vertical_length - constantNumber * 8);
                silver_random_x -= silver_random_x % constantNumber;
                silver_random_y -= silver_random_y % constantNumber;
                PictureBox pictureBox4 = new PictureBox();
                pictureBox4.Location = new Point(silver_random_x, silver_random_y);
                if (silver_random_x < 600)
                    pictureBox4.BackgroundImage = Image.FromFile(silverStatic.WinterObjectName);
                else
                    pictureBox4.BackgroundImage = Image.FromFile(silverStatic.SummerObjectName);
                pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBox4.BackColor = Color.Transparent;
                pictureBox4.Size = new Size(constantNumber * 1, constantNumber * 1);
                panel1.Controls.Add(pictureBox4);
            }

            Random randomchar = new Random();
            int character_random_x = randomchar.Next(halfWidth - horizontal_length / 2, halfWidth + (horizontal_length / 2) - constantNumber * 5);
            int character_random_y = randomchar.Next(0, vertical_length - constantNumber * 8);
            character_random_x -= character_random_x % constantNumber;
            character_random_y -= character_random_y % constantNumber;

            pictureBoxChar.Location = new Point(character_random_x, character_random_y);
            if (character_random_x < 600)
                pictureBoxChar.BackgroundImage = Image.FromFile(character.WinterObjectName);
            else
                pictureBoxChar.BackgroundImage = Image.FromFile(character.SummerObjectName);
            pictureBoxChar.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxChar.BackColor = Color.Transparent;
            pictureBoxChar.Size = new Size(constantNumber * 2, constantNumber * 2);
            panel1.Controls.Add(pictureBoxChar);

            labelRed = new Label();
            labelRed.Location = new Point(character_random_x - constantNumber * 3, character_random_y - constantNumber * 2 - 5);
            labelRed.Text = "Burada!";
            labelRed.ForeColor = Color.Red;
            labelRed.BackColor = Color.Transparent;
            labelRed.Font = new Font("Press Start", 10);
            panel1.Controls.Add(labelRed);

            Timer timer = new Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            timer.Start();
            button4.Visible = true;
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            labelRed.Visible = !labelRed.Visible;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black);

            int pixel_length = constantNumber;
            int halfWidth = panel1.Width / 2;
            int halfHeight = panel1.Height / 2;

            Brush brush1 = new SolidBrush(Color.LightBlue);
            g.FillRectangle(brush1, 0, 0, halfWidth, panel1.Height);

            Brush brush2 = new SolidBrush(Color.SandyBrown);
            g.FillRectangle(brush2, halfWidth, 0, halfWidth, panel1.Height);

            for (int i = 0; i <= vertical_length / pixel_length; i++)
            {
                int x = i * pixel_length;
                g.DrawLine(pen, halfWidth - horizontal_length / 2, x, halfWidth + horizontal_length / 2, x);
            }

            for (int i = 0; i <= horizontal_length / pixel_length; i++)
            {
                int y = i * pixel_length;
                g.DrawLine(pen, halfWidth - horizontal_length / 2 + y, 0, halfWidth - horizontal_length / 2 + y, vertical_length);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random random2 = new Random();
            horizontal_length = random2.Next(600, 1201);
            horizontal_length -= horizontal_length % constantNumber;
            if (constantNumber == 10 && horizontal_length % 20 != 0)
                horizontal_length += 20 / 2;
            textBox1.Text = horizontal_length.ToString();
            vertical_length = random2.Next(600, 1201);
            vertical_length -= vertical_length % constantNumber;
            textBox2.Text = vertical_length.ToString();
            button1_Click(sender, e);
            button4.Visible = true;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox3.Text = "Arthur";
                textBox3.ForeColor = SystemColors.ScrollBar;
            }
            else if(!string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox4.Text = "1";
                textBox4.ForeColor = SystemColors.ScrollBar;
            }
            else if (!string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox4.ForeColor = Color.Black;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Text = "Kaydedildi!";
            button5.Font = new Font("Press Start", 12);
            textBox3.ForeColor = Color.Black;
            textBox4.ForeColor = Color.Black;
            label8.Text = character.Name + "'un\n  yolculugu";
            label8.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            foreach (PictureBox pb in redPictureBoxes)
            {
                panel1.Controls.Remove(pb);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
