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
        ComboBox Thema = new ComboBox();
        string thema;
        Button Start = new Button();
        Button Secondstart = new Button();
        TableLayoutPanel MemoryPanel = new TableLayoutPanel();
        Button firstClicked = null;
        Button secondClicked = null;
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
            CreateStartbutton();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void CreateStartbutton()
        {
            this.Controls.Add(Start);
            Start.Location = new Point(100, 150);
            Start.Size = new Size(200, 50);
            Start.Text = "start";
            Start.Click += new EventHandler(this.Startbutton_Click);
        }

        public void CreateSecondStart()
        {
            this.Controls.Add(Secondstart);
            Secondstart.Size = new Size(100, 100);
            Secondstart.Location = new Point(100, 250);
            Secondstart.Text = "Start Game";
            Secondstart.Click += new EventHandler(this.Secondstart_Click);
        }

        public void CreateComboBox()
        {
            this.Controls.Add(Speelveld);
            Speelveld.Location = new Point(100, 200);
            Speelveld.Size = new Size(100, 100);
            Speelveld.Items.AddRange(new object[] { "4x4", "5x5", "6x6", "7x7", "8x8" });
        }

        public void CreateComboBox2()
        {
            this.Controls.Add(Thema);
            Thema.Location = new Point(100, 221);
            Thema.Size = new Size(100, 100);
            Thema.Items.AddRange(new object[] { "speelkaarten", "spongebob", "meme", "cage"});
        }

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
            int Amountx = Convert.ToInt32(Amount * Amount);
            int[] randomarray = random(Amountx);
            MemoryPanel.Location = new System.Drawing.Point(200, 10);
            MemoryPanel.Size = new System.Drawing.Size(300, 300);
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
                button.BackgroundImage = achtergrond(thema);
                button.BackgroundImageLayout = ImageLayout.Stretch;
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
            CreateSecondStart();
            CreateComboBox();
            CreateComboBox2();
            CreatePlayerName();
            Start.Visible = false;
        }

        public void Secondstart_Click(object sender, EventArgs e)
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
            thema = Thema.Text;
            Speelveld.Visible = false;
            Thema.Visible = false;
            Start.Visible = false;
            PlayerName_1.Visible = false;
            PlayerName_2.Visible = false;
            PlayerTurn.Text = PlayerName_1.Text + "'s turn";
            CreateLayoutPanel();
            CreatePlayerNameLabel();
            CreatePlayerScore();
            CreateResetButton();
        }

        public void Resetbutton_Click(object sender, EventArgs e)
        {
            CreateLayoutPanel();
        }

        public static int[] random(int getal)         // Method to refill the 0,0 array with random non-duplicate numbers between from 1 to 16
        {
            var random = new Random();

            int[] randomArray = Enumerable.Range(1, getal).OrderBy(x => random.Next()).ToArray();
            return randomArray;
        }

        public async void FlipCard(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int nummer = Convert.ToInt32(clickedButton.Name);
            if (thema == "spongebob")
            {
                clickedButton.BackgroundImage = spongebob(nummer);
            }
            if (thema == "meme")
            {
                clickedButton.BackgroundImage = meme(nummer);
            }
            if (thema == "cage")
            {
                clickedButton.BackgroundImage = cage(nummer);
            }
            if (thema == "speelkaarten")
            {
                clickedButton.BackgroundImage = speelkaarten(nummer);
            }




            clickedButton.BackgroundImageLayout = ImageLayout.Stretch;
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
                    else { player2score++; Player1Score.Text = Convert.ToString(player2score); }

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
                    firstClicked.BackgroundImage =  achtergrond(thema);
                    secondClicked.BackgroundImage = achtergrond(thema);
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
                    firstClicked.BackgroundImage = achtergrond(thema);
                    secondClicked.BackgroundImage = achtergrond(thema);
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
            }
        }
        public static Image achtergrond(string themakeuze)
        {
            
            if (themakeuze == "cage")
            {
                Image keuze = Properties.Resources.nicolas_0;
                return keuze;
            }
            else if (themakeuze == "spongebob")
            {
                Image keuze = Properties.Resources.spongebob_0;
                return keuze;
            }
            
            else if (themakeuze == "meme")
            {
                Image keuze = Properties.Resources.Meme_0;
                return keuze;
            }

            else
            {
                Image keuze = Properties.Resources.image_0;
                return keuze;
            }

            

        }

        public static Image speelkaarten(int nummer)
        {
            int nummer2 = nummer / 2;
            if (nummer % 2 != 0)
            {
                nummer2 = (nummer + 1) / 2;
            }

            List<Image> i01 = new List<Image>();
            i01.Add(Properties.Resources.image_1);
            i01.Add(Properties.Resources.image_2);
            i01.Add(Properties.Resources.image_3);
            i01.Add(Properties.Resources.image_4);
            i01.Add(Properties.Resources.image_5);
            i01.Add(Properties.Resources.image_6);
            i01.Add(Properties.Resources.image_7);
            i01.Add(Properties.Resources.image_8);
            i01.Add(Properties.Resources.image_9);
            i01.Add(Properties.Resources.image_10);
            i01.Add(Properties.Resources.image_11);
            i01.Add(Properties.Resources.image_12);
            i01.Add(Properties.Resources.image_13);
            i01.Add(Properties.Resources.image_14);
            i01.Add(Properties.Resources.image_15);
            i01.Add(Properties.Resources.image_16);
            i01.Add(Properties.Resources.image_17);
            i01.Add(Properties.Resources.image_18);
            i01.Add(Properties.Resources.image_19);
            i01.Add(Properties.Resources.image_20);
            i01.Add(Properties.Resources.image_21);
            i01.Add(Properties.Resources.image_22);
            i01.Add(Properties.Resources.image_23);
            i01.Add(Properties.Resources.image_24);
            i01.Add(Properties.Resources.image_25);
            i01.Add(Properties.Resources.image_26);
            i01.Add(Properties.Resources.image_27);
            i01.Add(Properties.Resources.image_28);
            i01.Add(Properties.Resources.image_29);
            i01.Add(Properties.Resources.image_30);
            i01.Add(Properties.Resources.image_31);
            i01.Add(Properties.Resources.image_32);
            Image plaatje = i01[nummer2 - 1];
            return plaatje;
        }
        public static Image spongebob(int nummer)
        {
            int nummer2 = nummer / 2;
            if (nummer % 2 != 0)
            {
                nummer2 = (nummer + 1) / 2;
            }

            List<Image> b01 = new List<Image>();
            b01.Add(Properties.Resources.spongebob_1);
            b01.Add(Properties.Resources.spongebob_2);
            b01.Add(Properties.Resources.spongebob_3);
            b01.Add(Properties.Resources.spongebob_4);
            b01.Add(Properties.Resources.spongebob_5);
            b01.Add(Properties.Resources.spongebob_6);
            b01.Add(Properties.Resources.spongebob_7);
            b01.Add(Properties.Resources.spongebob_8);
            b01.Add(Properties.Resources.spongebob_9);
            b01.Add(Properties.Resources.spongebob_10);
            b01.Add(Properties.Resources.spongebob_11);
            b01.Add(Properties.Resources.spongebob_12);
            b01.Add(Properties.Resources.spongebob_13);
            b01.Add(Properties.Resources.spongebob_14);
            b01.Add(Properties.Resources.spongebob_15);
            b01.Add(Properties.Resources.spongebob_16);
            b01.Add(Properties.Resources.spongebob_17);
            b01.Add(Properties.Resources.spongebob_18);
            b01.Add(Properties.Resources.spongebob_19);
            b01.Add(Properties.Resources.spongebob_20);
            b01.Add(Properties.Resources.spongebob_21);
            b01.Add(Properties.Resources.spongebob_22);
            b01.Add(Properties.Resources.spongebob_23);
            b01.Add(Properties.Resources.spongebob_24);
            b01.Add(Properties.Resources.spongebob_25);
            b01.Add(Properties.Resources.spongebob_26);
            b01.Add(Properties.Resources.spongebob_27);
            b01.Add(Properties.Resources.spongebob_28);
            b01.Add(Properties.Resources.spongebob_29);
            b01.Add(Properties.Resources.spongebob_30);
            b01.Add(Properties.Resources.spongebob_31);
            b01.Add(Properties.Resources.spongebob_32);
            Image plaatje = b01[nummer2 - 1];
            return plaatje;
        }
        public static Image cage(int nummer)
        {
            int nummer2 = nummer / 2;
            if (nummer % 2 != 0)
            {
                nummer2 = (nummer + 1)/2;
            }

            List<Image> a01 = new List<Image>();
            a01.Add(Properties.Resources.nicolas_1);
            a01.Add(Properties.Resources.nicolas_2);
            a01.Add(Properties.Resources.nicolas_3);
            a01.Add(Properties.Resources.nicolas_4);
            a01.Add(Properties.Resources.nicolas_5);
            a01.Add(Properties.Resources.nicolas_6);
            a01.Add(Properties.Resources.nicolas_7);
            a01.Add(Properties.Resources.nicolas_8);
            a01.Add(Properties.Resources.nicolas_9);
            a01.Add(Properties.Resources.nicolas_10);
            a01.Add(Properties.Resources.nicolas_11);
            a01.Add(Properties.Resources.nicolas_12);
            a01.Add(Properties.Resources.nicolas_13);
            a01.Add(Properties.Resources.nicolas_14);
            a01.Add(Properties.Resources.nicolas_15);
            a01.Add(Properties.Resources.nicolas_16);
            a01.Add(Properties.Resources.nicolas_17);
            a01.Add(Properties.Resources.nicolas_18);
            a01.Add(Properties.Resources.nicolas_19);
            a01.Add(Properties.Resources.nicolas_20);
            a01.Add(Properties.Resources.nicolas_21);
            a01.Add(Properties.Resources.nicolas_22);
            a01.Add(Properties.Resources.nicolas_23);
            a01.Add(Properties.Resources.nicolas_24);
            a01.Add(Properties.Resources.nicolas_25);
            a01.Add(Properties.Resources.nicolas_26);
            a01.Add(Properties.Resources.nicolas_27);
            a01.Add(Properties.Resources.nicolas_28);
            a01.Add(Properties.Resources.nicolas_29);
            a01.Add(Properties.Resources.nicolas_30);
            a01.Add(Properties.Resources.nicolas_31);
            a01.Add(Properties.Resources.nicolas_32);
            Image plaatje = a01[nummer2 - 1];
            return plaatje;
        }
        public static Image meme(int nummer)
        {
            int nummer2 = nummer / 2;
            if (nummer % 2 != 0)
            {
                nummer2 = (nummer + 1) / 2;
            }

            List<Image> m01 = new List<Image>();
            m01.Add(Properties.Resources.Meme_1);
            m01.Add(Properties.Resources.Meme_2);
            m01.Add(Properties.Resources.Meme_3);
            m01.Add(Properties.Resources.Meme_4);
            m01.Add(Properties.Resources.Meme_5);
            m01.Add(Properties.Resources.Meme_6);
            m01.Add(Properties.Resources.Meme_7);
            m01.Add(Properties.Resources.Meme_8);
            m01.Add(Properties.Resources.Meme_9);
            m01.Add(Properties.Resources.Meme_10);
            m01.Add(Properties.Resources.Meme_11);
           m01.Add(Properties.Resources.Meme_12);
            m01.Add(Properties.Resources.Meme_13);
            m01.Add(Properties.Resources.Meme_14);
            m01.Add(Properties.Resources.Meme_15);
            m01.Add(Properties.Resources.Meme_16);
            m01.Add(Properties.Resources.Meme_17);
            m01.Add(Properties.Resources.Meme_18);
            m01.Add(Properties.Resources.Meme_19);
            m01.Add(Properties.Resources.Meme_20);
            m01.Add(Properties.Resources.Meme_21);
            m01.Add(Properties.Resources.Meme_22);
            m01.Add(Properties.Resources.Meme_23);
            m01.Add(Properties.Resources.Meme_24);
            m01.Add(Properties.Resources.Meme_25);
            m01.Add(Properties.Resources.Meme_26);
            m01.Add(Properties.Resources.Meme_27);
            m01.Add(Properties.Resources.Meme_28);
            m01.Add(Properties.Resources.Meme_29);
            m01.Add(Properties.Resources.Meme_30);
            m01.Add(Properties.Resources.Meme_31);
            m01.Add(Properties.Resources.Meme_32);
            Image plaatje = m01[nummer2 - 1];
            return plaatje;
        }
    }

    
} 
