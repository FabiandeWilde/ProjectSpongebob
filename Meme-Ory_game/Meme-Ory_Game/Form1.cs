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
        ComboBox Gamemode = new ComboBox();
        ComboBox Thema = new ComboBox();
        Button Start = new Button();
        Button SecondStart = new Button();
        Button Thirdstart = new Button();
        TableLayoutPanel MemoryPanel = new TableLayoutPanel();
        Button firstClicked = null;
        Button secondClicked = null;
        Button rules = new Button();
        Button goback = new Button();
        Label Rules = new Label();
        bool player1beurt = true;
        int player1score = 0;
        int player2score = 0;
        Label Player1Score = new Label();
        Label Player2Score = new Label();
        TextBox PlayerName_1 = new TextBox();
        TextBox PlayerName_2 = new TextBox();
        Label PlayerNameLabel_1 = new Label();
        Label PlayerNameLabel_2 = new Label();
        Label PlayerTurn = new Label();
        int maxscore = 0;

        public Form1()
        {
            InitializeComponent();
            CreateStartButton();
            CreateRulesButton();
            CreateGoBackButton();
            goback.Visible = false;
        }

        public void CreateStartButton()
        {
            this.Controls.Add(Start);
            Start.Location = new Point(100, 150);
            Start.Size = new Size(200, 50);
            Start.Text = "start";
            Start.Click += new EventHandler(this.Startbutton_Click);
        }

        public void CreateSecondStartbutton()
        {
            this.Controls.Add(SecondStart);
            SecondStart.Location = new Point(100, 250);
            SecondStart.Size = new Size(200, 50);
            SecondStart.Text = "start";
            SecondStart.Click += new EventHandler(this.SecondStartbutton_Click);

        }

        public void CreateGoBackButton()
        {
            this.Controls.Add(goback);
            goback.Size = new Size(70, 30);
            goback.Location = new Point(30, 320);
            goback.Text = "Ga terug";
            goback.BackgroundImageLayout = ImageLayout.Stretch;
            goback.Click += new EventHandler(this.GoBackbutton_Click);
        }

        public void CreateRulesButton()
        {
            this.Controls.Add(rules);
            rules.Size = new Size(150, 150);
            rules.Location = new Point(200, 50);
            rules.Text = "Spelregels";
            rules.BackgroundImageLayout = ImageLayout.Stretch;
            rules.Click += new EventHandler(this.Rulesbutton_Click);
        }

        public void CreateThirdStart()
        {
            this.Controls.Add(Thirdstart);
            Thirdstart.Size = new Size(100, 100);
            Thirdstart.Location = new Point(100, 250);
            Thirdstart.Text = "Start Game";
            Thirdstart.Click += new EventHandler(this.Thirdstart_Click);
        }

        public void CreateComboBox()
        {
            this.Controls.Add(Speelveld);
            Speelveld.Location = new Point(100, 200);
            Speelveld.Size = new Size(100, 100);
            Speelveld.Items.Clear();
            Speelveld.Items.AddRange(new object[] { "4x4", "6x6", "8x8" });
        }

        public void CreatePlayerCombobox()
        {
            this.Controls.Add(Gamemode);
            Gamemode.Location=new Point (100,200);
            Gamemode.Location = new Point(100, 200);
            Gamemode.Size = new Size(100, 100);
            Gamemode.Items.Clear();
            Gamemode.Items.AddRange(new object[] { "Singleplayer", "Multiplayer" });
        }

        public void CreateThemas()
        {
            this.Controls.Add(Thema);
            Thema.Location = new Point(250, 110);
            Thema.Size = new Size(200, 100);
            Thema.Items.Clear();
            Thema.Items.AddRange(new object[] { "Classic", "Dank Memes", "Trippin' Balls", "Grandmother's Favorite" });
        }       // Heeft nog geen werking met combobox input <<< bestaat nu al wel in programma

        public void CreateResetButton()
        {
            int topreset = 350;
            int leftreset = 100;
            Button reset = new Button();
            this.Controls.Add(reset);
            reset.Size = new Size(100, 20);
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
            MemoryPanel.Location = new System.Drawing.Point(200, 10);
            MemoryPanel.Size = new System.Drawing.Size(300, 300);
            MemoryPanel.RowCount = Amount;
            MemoryPanel.ColumnCount = Amount;
            for (int i = 0; i < (Amount); i++)
            {
                MemoryPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
                MemoryPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            }
            for (int i = 0; i < (Amountx); i++)
            {
                var button = new Button();
                button.Text = Convert.ToString(randomarray[i]);
                button.Name = Convert.ToString(randomarray[i]);
                button.Dock = DockStyle.Fill;
                MemoryPanel.Controls.Add(button);
                button.Click += new System.EventHandler(FlipCard);
            }
            maxscore = Amount * Amount / 2;
            this.Controls.Add(MemoryPanel);
        }

        public void CreatePlayerName()
        {
            this.Controls.Add(PlayerName_1);
            this.Controls.Add(PlayerName_2);
            PlayerName_1.Location = new Point(100, 50);
            PlayerName_2.Location = new Point(100, 100);
            PlayerName_1.Size = new Size(100, 50);
            PlayerName_2.Size = new Size(100, 50);
            PlayerName_1.Text = PlayerTurn.Text;
            PlayerName_2.Text = PlayerTurn.Text;
        }

        public void CreatePlayerNameLabel()
        {
            this.Controls.Add(PlayerNameLabel_1);
            this.Controls.Add(PlayerNameLabel_2);
            PlayerNameLabel_1.Location = new Point(10, 10);
            PlayerNameLabel_2.Location = new Point(10, 60);
            PlayerNameLabel_1.Size = new Size(100, 50);
            PlayerNameLabel_2.Size = new Size(100, 50);
            PlayerNameLabel_1.Text = PlayerName_1.Text;
            PlayerNameLabel_2.Text = PlayerName_2.Text;
        }

        public void CreatePlayerScore()
        {
            this.Controls.Add(Player1Score);
            this.Controls.Add(Player2Score);
            this.Controls.Add(PlayerTurn);
            Player1Score.Text = Convert.ToString(player1score);
            Player2Score.Text = Convert.ToString(player2score);
            Player1Score.Location = new Point(110, 10);
            Player2Score.Location = new Point(110, 60);
            PlayerTurn.Location = new Point(30, 120);
            Player1Score.Size = new Size(30,30);
            Player2Score.Size = new Size(30, 30);
        }

        public void Startbutton_Click(object sender, EventArgs e)
        {
            CreateSecondStartbutton();
            CreatePlayerCombobox();
            MemoryPanel.Visible = false;
            Start.Visible = false;
            goback.Visible = true;
            SecondStart.Visible = true;
            Thirdstart.Visible = false;
            rules.Visible = false;
            Speelveld.Visible = false;
            PlayerName_1.Visible = false;
            PlayerName_2.Visible = false;
            Gamemode.Visible = true;
        }

        public void SecondStartbutton_Click(object sender, EventArgs e)
        {
            CreateThirdStart();
            CreateComboBox();
            CreatePlayerName();
            CreateThemas();
            Thema.Visible = true;
            Start.Visible = false;
            goback.Visible = true;
            Speelveld.Visible = true;
            PlayerName_1.Visible = true;
            PlayerName_2.Visible = true;
            SecondStart.Visible = false;
            Thirdstart.Visible = true;
            rules.Visible = false;
            Gamemode.Visible = false;
            /*if (Gamemode.Text == "Singleplayer")
            {
                PlayerName_2.Visible = false;
                Player2Score.Visible = false;
                PlayerTurn.Visible = false;
                player1score = player2score + player1score;
            }*/
        }

        public void Thirdstart_Click(object sender, EventArgs e)
        {
            if (Speelveld.Text == "4x4")
                Amount = 4;
            if (Speelveld.Text == "6x6")
                Amount = 6;
            if (Speelveld.Text == "8x8")
                Amount = 8;
            Speelveld.Visible = false;
            Thirdstart.Visible = false;
            PlayerName_1.Visible = false;
            PlayerName_2.Visible = false;
            goback.Visible = false;
            Thema.Visible = false;
            PlayerTurn.Text = PlayerName_1.Text + "'s turn";
            CreateLayoutPanel();
            CreatePlayerNameLabel();
            CreatePlayerScore();
            CreateResetButton();
            MemoryPanel.Visible = true;
        }

        public void Resetbutton_Click(object sender, EventArgs e)
        {
            CreateLayoutPanel();
            Player1Score.Text = Convert.ToString(player1score=0);
            Player2Score.Text = Convert.ToString(player2score=0);     
        }

        public void Rulesbutton_Click(object sender, EventArgs e)
        {
            Start.Visible = false;
            rules.Visible = false;
            goback.Visible = true;
        }

        public void GoBackbutton_Click(object sender, EventArgs e)
        {
            Speelveld.Visible = false;
            Gamemode.Visible = false;
            Start.Visible = true;
            rules.Visible = true;
            goback.Visible = false;
            SecondStart.Visible = false;
            Thirdstart.Visible = false;
            PlayerName_1.Visible = false;
            PlayerName_2.Visible = false;
            Thema.Visible = false;
        }

        public static int[] random(int[] array)         // Method to refill the 0,0 array with random non-duplicate numbers between from 1 to 16
        {
            var random = new Random();

            int[] randomArray = Enumerable.Range(1, array.Length).OrderBy(x => random.Next()).ToArray();
            return randomArray;
        }

        public async void FlipCard(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int nummer = Convert.ToInt32(clickedButton.Name);
            clickedButton.Image = KrijgImage(nummer); //nummer = naam van button = het nummer uit de random array.

            if (firstClicked == null)// filling 1st comparer
            {
                firstClicked = clickedButton;
                return;
            }

            secondClicked = clickedButton; // filling 2nd comparer   

            if ((Convert.ToInt32(firstClicked.Text) % 2 != 0))
            {
                if (Convert.ToInt32(firstClicked.Text) == (Convert.ToInt32(secondClicked.Text) - 1))
                {
                    if (player1beurt == true) { player1score++; Player1Score.Text = Convert.ToString(player1score); }
                    else { player2score++; Player2Score.Text = Convert.ToString(player2score); }

                    if (player1score + player2score == maxscore - 1) { MessageBox.Show("biatch"); }
                    firstClicked.Enabled = false;
                    secondClicked.Enabled = false;
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                else
                {
                    if (player1beurt == true) { player1beurt = false; PlayerTurn.Text = PlayerName_2.Text + "'s turn"; }
                    else { player1beurt = true; PlayerTurn.Text = PlayerName_1.Text + "'s turn"; }
                    await Task.Delay(500);
                    firstClicked.Image = Properties.Resources.image_1;
                    secondClicked.Image = Properties.Resources.image_1;
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
            }
            else
            {
                if (Convert.ToInt32(firstClicked.Text) == (Convert.ToInt32(secondClicked.Text) + 1))
                {
                    if (player1beurt == true)
                    {
                        player1score++; Player1Score.Text = Convert.ToString(player1score);
                    }
                    else
                    {
                        player2score++; Player2Score.Text = Convert.ToString(player2score);
                    }
                    if (player1score + player2score == maxscore - 1) { MessageBox.Show("biatch"); }
                    firstClicked.Enabled = false;
                    firstClicked.Enabled = false;
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                else
                {
                    if (player1beurt == true) { player1beurt = false; PlayerTurn.Text = PlayerName_2.Text + "'s turn"; }
                    else { player1beurt = true; PlayerTurn.Text = PlayerName_1.Text + "'s turn"; }
                    await Task.Delay(500);
                    firstClicked.Image = Properties.Resources.image_1;
                    secondClicked.Image = Properties.Resources.image_1;
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
            }
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
} 
