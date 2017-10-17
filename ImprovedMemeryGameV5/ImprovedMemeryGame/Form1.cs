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

namespace ImprovedMemeryGame
{
    public partial class Form1 : Form
    {
        Label player10 = new Label();
        Label player20 = new Label();
        Label name1 = new Label();
        Label name2 = new Label();
        Label turn = new Label();

        public int score1 = 0;
        public int score2 = 0;
        public int player1 = 0;// tracking who's turn it is
        public int player2 = 0;// trackign who's turn it is
        PictureBox firstClicked = null; // 1st button to be compared
        PictureBox secondClicked = null; // 2nd button to be compared 
        TextBox playername1 = new TextBox();
        TextBox playername2 = new TextBox();
        public int count1 = 0;
        public int count2 = 0;
        System.Media.SoundPlayer music = new System.Media.SoundPlayer();

        public Form1()
        {
            InitializeComponent();
            CreateStartButton();
            CreateTextbox();
            StartSound();
        }

        public void StartSound()
        {
            music.SoundLocation = "C:\\Users\\Eigenaar\\Desktop\\studie\\project1\\ImprovedMemeryGameV5\\ImprovedMemeryGame\\Resources\\Skyrim Soundtrack.wav";
            music.Play();            
        }
        
        public void CreateStartButton()
        {
            int topstart = 395;
            int leftstart = 200;
            Button start = new Button();
            this.Controls.Add(start);
            start.Size = new Size(150, 150);
            start.Left = leftstart;
            start.Top = topstart;
            start.Text = "start";
            start.BackgroundImageLayout = ImageLayout.Stretch;
            start.Click += new EventHandler(this.Startbutton_Click);

        }

        public void CreateTextbox()
        {
            int top = 200;
            int left = 10;

            playername1.Left = left + 50;
            playername2.Left = left + 50;
            playername1.Top = top;
            playername2.Top = top + 50;
            playername1.Text = "player1";
            playername2.Text = "player2";
            playername1.Font = new Font(name1.Font.FontFamily, 10);
            playername2.Font = new Font(name2.Font.FontFamily, 10);
            this.Controls.Add(playername1);
            this.Controls.Add(playername2);

        }
        
        public void CreateResetButton() 
        {
            int topreset = 395;
            int leftreset = 355;
            Button reset = new Button();
            this.Controls.Add(reset);
            reset.Size = new Size(150, 150);
            reset.Left = leftreset;
            reset.Top = topreset;
            reset.Text = "reset";
            reset.BackgroundImageLayout = ImageLayout.Stretch;
            reset.Click += new EventHandler(this.Resetbutton_Click);
        }

        public void CreateLabels()
        {
            int top = 50;
            int left = 10;
            player10.Left = left;
            player20.Left = left;
            name1.Left = left + 50;
            name2.Left = left + 50;
            player10.Top = top;
            player20.Top = top + 50;
            name1.Top = top ;
            name2.Top = top + 50;
            player10.Text = Convert.ToString(player1);
            player20.Text = Convert.ToString(player1);
            player10.Size = new Size(20,20);
            player20.Size = new Size(20,20);
            name1.Text = playername1.Text;
            name2.Text = playername2.Text;
            name1.Font = new Font(name1.Font.FontFamily, 10);
            name2.Font = new Font(name2.Font.FontFamily, 10);

            turn.Left = left;
            turn.Top = top + 100;
            turn.Size = new Size(100,60);
            turn.Font = new Font(turn.Font.FontFamily, 10);
            if (player1 == player2) { turn.Text =name1.Text + "'s turn"; }
            else { turn.Text = name2.Text+ "'s turn"; }


            this.Controls.Add(turn);
            this.Controls.Add(player10);
            this.Controls.Add(player20);
            this.Controls.Add(name1);
            this.Controls.Add(name2);
        }


        public void CreateFieldButtons()
        {
            int top = 50;
            int left = 200;
            List<int> paren1 = new List<int>();

            for (int x = 1; x < 9; x++)
            {
                paren1.Add(x);
                paren1.Add(x);
            }

            for (int i = 0; i < 16; i++)
            {
                Random getal = new Random();
                int paar = getal.Next(0, paren1.Count);
                int vuller = paren1[(paar)];
                if (paren1.Count > 1) paren1.RemoveAt(paar);
                PictureBox button = new PictureBox();
                button.Left = left;
                button.Top = top;
                this.Controls.Add(button);
                button.Tag = Convert.ToInt32(vuller);// use random to extract numbers form a list to fill in as text
                button.Font = new Font(button.Font.FontFamily, 15);
                button.Image = Properties.Resources._0;
                button.SizeMode = PictureBoxSizeMode.StretchImage;
                left += button.Width + 2;
                button.Size = new Size(70, 70);
                if (i == 3 || i == 7 || i == 11 || i == 15)
                {
                    top += 90;
                    left = 200;
                }
                button.Click += new EventHandler(this.Fieldbutton_Click);
            }
        }
        public void WrongSound()
        {
            System.Media.SoundPlayer wrong = new System.Media.SoundPlayer();
            wrong.SoundLocation = "C:\\Users\\Eigenaar\\Desktop\\studie\\project1\\ImprovedMemeryGameV5\\ImprovedMemeryGame\\Resources\\Mario.wav";
            wrong.Play();
        }

        public void Startbutton_Click(object sender, EventArgs e)
        {
            CreateFieldButtons();
            CreateLabels();
            CreateResetButton();
            playername1.Visible = false;
            playername2.Visible = false;
            music.Stop();
            System.Media.SoundPlayer HereWeGo = new System.Media.SoundPlayer();
            HereWeGo.SoundLocation = "C:\\Users\\Eigenaar\\Desktop\\studie\\project1\\ImprovedMemeryGameV5\\ImprovedMemeryGame\\Resources\\HereWeGo.wav";
            HereWeGo.Load();
            HereWeGo.Play();
        }

        public void Resetbutton_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls) if (x is PictureBox) (x as PictureBox).Image = Properties.Resources._0;

            List<int> paren1 = new List<int>();

            for (int x = 1; x < 9; x++)
            {
                paren1.Add(x);
                paren1.Add(x);
            } 
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox)
                    {
                        Random getal = new Random();
                        int paar = getal.Next(0, paren1.Count);
                        int vuller = paren1[(paar)];
                        (x as PictureBox).Tag = vuller.ToString();
                        if (paren1.Count > 1) paren1.RemoveAt(paar);
                    }
                }
            player10.Text = Convert.ToString(0);
            player20.Text = Convert.ToString(0);
            count1 = 0;
            count2 = 0;
            turn.Text = playername1.Text+ "'s turn";
          }

        public async void Fieldbutton_Click(object sender, EventArgs e)//  button event
        {
             PictureBox ClickedButton = sender as PictureBox;

            if (firstClicked == null)// filling 1st comparer
            {
                firstClicked = ClickedButton;
                switch (Convert.ToInt32(firstClicked.Tag))
                {
                    case 1:
                        firstClicked.Image = Properties.Resources._1;
                        break;
                    case 2:
                        firstClicked.Image = Properties.Resources._2;
                        break;
                    case 3:
                        firstClicked.Image = Properties.Resources._3;
                        break;
                    case 4:
                        firstClicked.Image = Properties.Resources._4;
                        break;
                    case 5:
                        firstClicked.Image = Properties.Resources._5;
                        break;
                    case 6:
                        firstClicked.Image = Properties.Resources._6;
                        break;
                    case 7:
                        firstClicked.Image = Properties.Resources._7;
                        break;
                    case 8:
                        firstClicked.Image = Properties.Resources._8;
                        break;
                    default:
                       firstClicked.Image = Properties.Resources._0;
                        break;
                }
                return;  
            }
            
            secondClicked = ClickedButton; // filling 2nd comparer

            switch (Convert.ToInt32(secondClicked.Tag))
            {
                case 1:
                    secondClicked.Image = Properties.Resources._1;
                    break;
                case 2:
                    secondClicked.Image = Properties.Resources._2;
                    break;
                case 3:
                    secondClicked.Image = Properties.Resources._3;
                    break;
                case 4:
                    secondClicked.Image = Properties.Resources._4;
                    break;
                case 5:
                    secondClicked.Image = Properties.Resources._5;
                    break;
                case 6:
                    secondClicked.Image = Properties.Resources._6;
                    break;
                case 7:
                    secondClicked.Image = Properties.Resources._7;
                    break;
                case 8:
                    secondClicked.Image = Properties.Resources._8;
                    break;
                default:
                    secondClicked.Image = Properties.Resources._0;
                    break;
            }
            
            if (firstClicked.Tag.ToString() == secondClicked.Tag.ToString())
            {                

                if (player1 == player2) { count1++; }
                else { count2++; }
                player10.Text = Convert.ToString(count1);
                player20.Text = Convert.ToString(count2);
                firstClicked = null;
                secondClicked = null;

                if (Convert.ToInt32(player10.Text) + Convert.ToInt32(player20.Text) == 8)
                {
                    if (Convert.ToInt32(player10.Text) > Convert.ToInt32(player20.Text))
                    {
                        MessageBox.Show(playername1.Text +" is Victorius");
                        return;
                    }
                    else if (Convert.ToInt32(player10.Text) < Convert.ToInt32(player20.Text))
                    {
                        MessageBox.Show( playername2.Text +" is Victorius");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No victor, it is a DRAW");
                         return;
                    }
                }
              return;
            }
            else
            {
                WrongSound();
                await Task.Delay(500);
                firstClicked.Image = Properties.Resources._0;
                secondClicked.Image = Properties.Resources._0;
                firstClicked = null;
                secondClicked = null;                

                if (player1 == player2)
                { player1++;
                    turn.Text = playername2.Text + "'s turn";
                }
                else
                { player2++;
                    turn.Text = playername1.Text + "'s turn";
                }
                return;
            }
        }
     }
}
