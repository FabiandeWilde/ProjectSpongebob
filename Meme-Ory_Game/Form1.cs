using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meme_Ory_Game
{
    public partial class Form1 : Form
    {
        int Amount;
        ComboBox Speelveld = new ComboBox();
        Button start = new Button();
        TableLayoutPanel MemoryPanel = new TableLayoutPanel();

        public Form1()
        {
            InitializeComponent();
            CreateStartButton();
            CreateComboBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void CreateStartButton()
        {
            int topstart = 200;
            int leftstart = 200;
            this.Controls.Add(start);
            start.Size = new Size(150, 150);
            start.Left = leftstart;
            start.Top = topstart;
            start.Text = "start";
            start.BackgroundImageLayout = ImageLayout.Stretch;
            start.Click += new EventHandler(this.Startbutton_Click);
        }

        public void CreateComboBox()
        {
            this.Controls.Add(Speelveld);
            Speelveld.Location = new Point (100, 200);
            Speelveld.Size = new Size(100, 100);
            Speelveld.Items.AddRange(new object[] { "4x4", "5x5", "6x6", "7x7", "8x8" });
        }

        public void CreateResetButton()
        {
            int topreset = 350;
            int leftreset = 100;
            Button reset = new Button();
            this.Controls.Add(reset);
            reset.Size = new Size(100,20);
            reset.Left = leftreset;
            reset.Top = topreset;
            reset.Text = "reset";
            reset.BackgroundImageLayout = ImageLayout.Stretch;
            reset.Click += new EventHandler(this.Resetbutton_Click);
        }

        public void CreateLayoutPanel()
        {
            MemoryPanel.Controls.Clear();
            MemoryPanel.RowStyles.Clear();
            MemoryPanel.ColumnStyles.Clear();
            int Amountx = Convert.ToInt16(Math.Pow(Amount, 2));
            int[] numberCards = new int[Amountx];       
            int[] randomarray = random(numberCards);
            MemoryPanel.Location = new System.Drawing.Point(26, 12);
            MemoryPanel.Size = new System.Drawing.Size(300,300);
            MemoryPanel.RowCount = Amount;
            MemoryPanel.ColumnCount = Amount;
            for (int i = 0; i < (Amount); i++)        
            {
                MemoryPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
                MemoryPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            }
            for (int i = 0; i < (Amount * Amount); i++)            
            {
                var button = new Button();
                button.Text = Convert.ToString(randomarray[i]);
                button.Name = Convert.ToString(randomarray[i]);
                button.Dock = DockStyle.Fill;
                MemoryPanel.Controls.Add(button);
                button.Click += new System.EventHandler(FlipCard);
            }
            this.Controls.Add(MemoryPanel);
        }

        public void Startbutton_Click(object sender, EventArgs e)
        {
            if (Speelveld.Text == "4x4")
                Amount = 4;
            if (Speelveld.Text == "5x5")
                Amount = 5;
            if (Speelveld.Text == "6x6")
                Amount = 6;
            if (Speelveld.Text == "7x7")
                Amount = 7;
            if (Speelveld.Text == "8x8")
                Amount = 8;
            Speelveld.Visible = false;
            start.Visible = false;
            CreateResetButton();
            CreateLayoutPanel();                    
        }

        public void Resetbutton_Click(object sender, EventArgs e)
        {
            CreateLayoutPanel();
        }

        public static int[] random(int[] array)         // Method to refill the 0,0 array with random non-duplicate numbers between from 1 to 16
            {
                var random = new Random();

                int[] randomArray = Enumerable.Range(1, array.Length).OrderBy(x => random.Next()).ToArray();
                return randomArray;
            }

        private void FlipCard(object sender, EventArgs e)
        {
                Button clickedButton = sender as Button;
                int nummer = Convert.ToInt32(clickedButton.Name);
                clickedButton.BackgroundImage = KrijgImage(nummer); //nummer = naam van button = het nummer uit de random array.
                clickedButton.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public static Image KrijgImage(int nummer) //Method voor de BackgroundImage
        {
            switch (nummer)
            {
                //elk paar krijgt dezelfde achtergrond via button_Click
                //moet langer worden voor grotere spellen dan 4x4
                case 1:
                case 2:
                    Image image1 = Properties.Resources.image_1;
                    return image1;
                case 3:
                case 4:
                    Image image2 = Properties.Resources.image_2;
                    return image2;
                case 5:
                case 6:
                    Image image3 = Properties.Resources.image_3;
                    return image3;
                case 7:
                case 8:
                    Image image4 = Properties.Resources.image_4;
                    return image4;
                case 9:
                case 10:
                    Image image5 = Properties.Resources.image_5;
                    return image5;
                case 11:
                case 12:
                    Image image6 = Properties.Resources.image_6;
                    return image6;
                case 13:
                case 14:
                    Image image7 = Properties.Resources.image_7;
                    return image7;
                case 15:
                case 16:
                    Image image8 = Properties.Resources.image_8;
                    return image8;
                case 17:
                case 18:
                    Image image9 = Properties.Resources.image_9;
                    return image9;
                case 19:
                case 20:
                    Image image10 = Properties.Resources.image_10;
                    return image10;
                case 21:
                case 22:
                    Image image11 = Properties.Resources.image_11;
                    return image11;
                case 23:
                case 24:
                    Image image12 = Properties.Resources.image_12;
                    return image12;
                case 25:
                case 26:
                    Image image13 = Properties.Resources.image_13;
                    return image13;
                case 27:
                case 28:
                    Image image14 = Properties.Resources.image_14;
                    return image14;
                case 29:
                case 30:
                    Image image15 = Properties.Resources.image_15;
                    return image15;
                case 31:
                case 32:
                    Image image16 = Properties.Resources.image_16;
                    return image16;

                default:
                    Image dickbutt = null;
                    return dickbutt;
            }
        }

    }
} 
