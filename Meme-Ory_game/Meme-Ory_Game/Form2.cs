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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
             
            int Amount = 4;
            int Amountx = Convert.ToInt16(Math.Pow(Amount, 2));
            int[] numberCards = new int[Amountx];        // Atm 6x6, manier zoeken om dit te maken zodat gebruiker kiest hoe groot het speelveld is
            int[] randomarray = random(numberCards);        // Running 'Random' method from below to fix position numbers

            int Row = Amount;
            int Column = Amount;
            tableLayoutPanel1.RowCount = Row;
            tableLayoutPanel1.ColumnCount = Column;
            for (int i = 0; i < (Row); i++)         // Amount of cells, 4rows by 4columns
            {
                tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            }
            for (int i = 0; i < (Row*Column); i++)        // Amount of buttons      
            {
                var button = new Button();
                button.Text = Convert.ToString(randomarray[i]);
                button.Name = Convert.ToString((randomarray[i]));
                button.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(button);
                button.Click += new System.EventHandler(button_Click);
            }            
        }
        public static int[] random(int[] array)         // Method to refill the 0,0 array with random non-duplicate numbers between from 1 to 16
        {
            var random = new Random();

            int[] randomArray = Enumerable.Range(1, array.Length).OrderBy(x => random.Next()).ToArray();
            return randomArray;
        }

        private void button_Click(object sender, EventArgs e)
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
        
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
