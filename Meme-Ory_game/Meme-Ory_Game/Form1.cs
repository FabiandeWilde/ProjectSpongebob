using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;



namespace Meme_Ory_Game
{
    public partial class Form1 : Form
    {
        #region Variables
        int Amount;
        int maxscore = 0;
        int player1score = 0;
        int player2score = 0;
        int timerCount = 0;
        string thema;
        string path = System.AppDomain.CurrentDomain.BaseDirectory;
        string savefile1 = "Save1.txt";
        string savefile2 = "Save2.txt";
        string savefile3 = "Save3.txt";
        string savefile4 = "Save4.txt";
        string savefile5 = "Save5.txt";
        string savefile6 = "Save6.txt";
        string HighScore = "HighScore.txt";
        string HighScore1 = "HighScore1.txt";
        string HighScore2 = "HighScore2.txt";
        string singeplayerhighscore1 = "Singeplayer1.txt";
        string singeplayerhighscore2 = "Singeplayer2.txt";
        string singeplayerhighscore3 = "Singeplayer3.txt";
        bool player1beurt = true;
        ComboBox Speelveld = new ComboBox();
        ComboBox Gamemode = new ComboBox();
        ComboBox Thema = new ComboBox();
        TextBox PlayerName_1 = new TextBox();
        TextBox PlayerName_2 = new TextBox();
        Button Start = new Button();
        Button SecondStart = new Button();
        Button Thirdstart = new Button();
        Button Highscore = new Button();
        Button rules = new Button();
        Button goback = new Button();
        Button firstClicked = null;
        Button secondClicked = null;
        Button reset = new Button();
        Button Continue = new Button();
        Button Save = new Button();
        Button HighscoreSingleplayer = new Button();
        Button HighscoreMultiplayer = new Button();
        Label Rules = new Label();
        Label Player1Score = new Label();
        Label Player2Score = new Label();
        Label PlayerNameLabel_1 = new Label();
        Label PlayerNameLabel_2 = new Label();
        Label PlayerTurn = new Label();
        Label GamemodeTitle = new Label();
        Label themaTitle = new Label();
        Label veldtypeTitle = new Label();
        Label player1Title = new Label();
        Label player2Title = new Label();
        Label timerLabel = new Label();
        ListView Dynamisch = new ListView();
        ListViewItem item = new ListViewItem();
        TableLayoutPanel MemoryPanel = new TableLayoutPanel();
        PictureBox GameTitle = new PictureBox();
        System.Windows.Forms.Timer timer;
        SoundPlayer mplayer;
        #endregion

        // Start Screen [Methods]
        public Form1()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // = Niet Resisable [Form]
            MaximizeBox = false; // = Niet Maximaliseren [Form] 
            InitializeComponent();
            CreateStartButton();
            CreateRulesButton();
            CreateHighScoreButton();
            CreateGameTitle();
            goback.Visible = false;

            //Image Gamebackground = Properties.Resources.Gamebackground;
            //this.BackgroundImage = Gamebackground;
        }

        // Game Title [PictureBox]
        public void CreateGameTitle()
        {
            this.Controls.Add(GameTitle);
            GameTitle.Location = new Point(320, 10);
            GameTitle.Size = new Size(600, 180);
            GameTitle.Image = Properties.Resources.Gamelogo;
            GameTitle.BackColor = Color.Transparent;
        }

        // Start 1 [Button]
        public void CreateStartButton()
        {
            this.Controls.Add(Start);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            Start.Location = new Point(300, 500);
            Start.Size = new Size(400, 100);
            Start.Text = "Start Game";
            Start.Font = new Font("Lucida Sans", 15);
            Start.Click += new EventHandler(this.Startbutton_Click);
            Start.BackColor = Roze;
            Start.ForeColor = Wit;
        }

        // Start 1 [Function]
        public void Startbutton_Click(object sender, EventArgs e)
        {
            CreateSecondStartbutton();
            CreatePlayerCombobox();
            CreateGoBackButton();
            MemoryPanel.Visible = false;
            Start.Visible = false;
            SecondStart.Visible = true;
            Thirdstart.Visible = false;
            rules.Visible = false;
            Highscore.Visible = false;
            Speelveld.Visible = false;
            PlayerName_1.Visible = false;
            PlayerName_2.Visible = false;
            Gamemode.Visible = true;
            GamemodeTitle.Visible = true;
            goback.Visible = true;
        }

        // Start 2 [Button]
        public void CreateSecondStartbutton()
        {
            this.Controls.Add(SecondStart);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            SecondStart.Location = new Point(350, 300);
            SecondStart.Size = new Size(300, 75);
            SecondStart.Text = "Next";
            SecondStart.Font = new Font("Lucida Sans", 15);
            SecondStart.Click += new EventHandler(this.SecondStartbutton_Click);
            SecondStart.BackColor = Roze;
            SecondStart.ForeColor = Wit;

        }

        // Start 2 [Function]
        public void SecondStartbutton_Click(object sender, EventArgs e)
        {
            CreateThirdStart();
            CreateComboBox();
            CreatePlayerName();
            CreateThemas();
            TitleLabels();
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
            GamemodeTitle.Visible = false;
            themaTitle.Visible = true;
            veldtypeTitle.Visible = true;
            player1Title.Visible = true;
            if (Gamemode.Text == "Singleplayer")
            {
                PlayerName_2.Visible = false;
                Player2Score.Visible = false;
                PlayerNameLabel_2.Visible = false;
                PlayerTurn.Visible = false;
                player2Title.Visible = false;
                player1score = player2score + player1score;
            }
            else
            {
                player2Title.Visible = true;
            }
        }

        // Start 3 [Button]
        public void CreateThirdStart()
        {
            this.Controls.Add(Thirdstart);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            Thirdstart.Size = new Size(300, 75);
            if (Gamemode.Text == "Singleplayer")
            {
                Thirdstart.Location = new Point(350, 400);
            }
            else
            {
                Thirdstart.Location = new Point(350, 450);
            }
            Thirdstart.Text = "Start Game";
            Thirdstart.Font = new Font("Lucida Sans", 15);
            Thirdstart.Click += new EventHandler(this.Thirdstart_Click);
            Thirdstart.BackColor = Roze;
            Thirdstart.ForeColor = Wit;
        }

        // Start 3 [Function]
        public void Thirdstart_Click(object sender, EventArgs e)
        {
            if (Speelveld.Text == "4x4")
                Amount = 4;
            if (Speelveld.Text == "6x6")
                Amount = 6;
            if (Speelveld.Text == "8x8")
                Amount = 8;
            thema = Thema.Text;
            CreateLayoutPanel();
            CreatePlayerNameLabel();
            CreatePlayerScore();
            CreateResetButton();
            CreateContinueSaveButton();
            PlayerTurnLabel();
            Speelveld.Visible = false;
            Thirdstart.Visible = false;
            PlayerName_1.Visible = false;
            PlayerName_2.Visible = false;
            goback.Visible = false;
            Thema.Visible = false;
            MemoryPanel.Visible = true;
            GameTitle.Visible = false;
            themaTitle.Visible = false;
            veldtypeTitle.Visible = false;
            player1Title.Visible = false;
            player2Title.Visible = false;
            if (Gamemode.Text == "Singleplayer")
            {
                CreateTimerLabel();
                CreateTimer();
                Player1Score.Visible = false;
            }
        }

        // Timer [Label]
        public void CreateTimerLabel()
        {
            this.Controls.Add(timerLabel);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            timerLabel.Location = new Point(10, 50);
            timerLabel.Size = new Size(120, 20);
            timerLabel.Text = "Time: " + timerCount.ToString();
            timerLabel.Font = new Font("Lucida Sans", 12);
            timerLabel.ForeColor = Wit;
            timerLabel.BackColor = Roze;
        }

        // Timer [Timer]
        public void CreateTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = 1000; // Om de seconde timerCount++
            timer.Start();
        }

        // Timer [Function]
        public void Timer_Tick(object sender, EventArgs e)
        {
            timerCount++;
            timerLabel.Text = "Time: " + timerCount.ToString();
        }

        // Highscore [Button]
        public void CreateHighScoreButton()
        {
            this.Controls.Add(Highscore);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            Highscore.Location = new Point(300, 350);
            Highscore.Size = new Size(400, 100);
            Highscore.Text = "Highscore";
            Highscore.Font = new Font("Lucida Sans", 15);
            Highscore.Click += new EventHandler(this.Highscore_Click);
            Highscore.BackColor = Roze;
            Highscore.ForeColor = Wit;
        }

        // Highscore [Function]
        public void Highscore_Click(object sender, EventArgs e)
        {
            CreateHighscoreSPButton();
            CreateHighscoreMPButton();
            CreateGoBackButton();
            Start.Visible = false;
            Highscore.Visible = false;
            rules.Visible = false;
            goback.Visible = true;
            HighscoreSingleplayer.Visible = true;
            HighscoreMultiplayer.Visible = true;
        }

        // Highscore [List]
        public void CreateListview() 
        {
            // Search
            string tekst = File.ReadAllText(path + HighScore);
            string[] scores = tekst.Split('-');
            string tekst2 = File.ReadAllText(path + HighScore1);
            string[] scores2 = tekst2.Split('-');
            string tekst3 = File.ReadAllText(path + HighScore2);
            string[] scores3 = tekst3.Split('-');
            string tekst4 = File.ReadAllText(path + singeplayerhighscore1);
            string[] scores4 = tekst4.Split('-');
            string tekst5 = File.ReadAllText(path + singeplayerhighscore2);
            string[] scores5 = tekst5.Split('-');
            string tekst6 = File.ReadAllText(path + singeplayerhighscore3);
            string[] scores6 = tekst6.Split('-');

            int Xas = 10;
            int Yas = 10;
            for (int teller = 0; teller < 6; teller++)
            {
                Dynamisch.Bounds = new Rectangle(new Point(Xas, Yas), new Size(200, 200));
                Dynamisch.View = View.Details;
                Dynamisch.AllowColumnReorder = true;
                Dynamisch.FullRowSelect = true;
                Dynamisch.GridLines = true;
                Dynamisch.Sorting = SortOrder.Ascending;
                Dynamisch.Columns.Add("Time", -2, HorizontalAlignment.Left);
                Dynamisch.Columns.Add("Name", -2, HorizontalAlignment.Left);
                Dynamisch.Name = Convert.ToString(teller);

                Xas += 200;
                this.Controls.Add(Dynamisch);
            }

            foreach (Control variable in this.Controls)
            {
                if (variable is ListView)
                {
                    if ((variable as ListView).Name == "1")
                    {
                        int x = 0;
                        for (int i = 0; i < (scores.Length - 2); i += 2)
                        {
                            item.Text = ""; // 1st column
                            item.SubItems.Add(""); // 2nd column             
                            (variable as ListView).Items.Add(item);
                            (variable as ListView).Items[x].SubItems[0].Text = scores[(i + 1)]; // 1st value from array
                            (variable as ListView).Items[x].SubItems[1].Text = scores[i]; // 2nd value from array                
                            if (i % 2 == 0) x++;
                        }

                    }
                    if ((variable as ListView).Name == "2")
                    {
                        int x = 0;
                        for (int i = 0; i < (scores2.Length - 2); i += 2)
                        {
                            item.Text = ""; // 1st column
                            item.SubItems.Add(""); // 2nd column             
                            (variable as ListView).Items.Add(item);
                            (variable as ListView).Items[x].SubItems[0].Text = scores2[(i + 1)]; // 1st value from array
                            (variable as ListView).Items[x].SubItems[1].Text = scores2[i]; // 2nd value from array                
                            if (i % 2 == 0) x++;
                        }

                    }
                    if ((variable as ListView).Name == "3")
                    {
                        int x = 0;
                        for (int i = 0; i < (scores3.Length - 2); i += 2)
                        {
                            item.Text = ""; // 1st column
                            item.SubItems.Add(""); // 2nd column             
                            (variable as ListView).Items.Add(item);
                            (variable as ListView).Items[x].SubItems[0].Text = scores3[(i + 1)]; // 1st value from array
                            (variable as ListView).Items[x].SubItems[1].Text = scores3[i]; // 2nd value from array                
                            if (i % 2 == 0) x++;
                        }

                    }
                    if ((variable as ListView).Name == "4")
                    {
                        int x = 0;
                        for (int i = 0; i < (scores4.Length - 2); i += 2)
                        {
                            item.Text = ""; // 1st column
                            item.SubItems.Add(""); // 2nd column             
                            (variable as ListView).Items.Add(item);
                            (variable as ListView).Items[x].SubItems[0].Text = scores4[(i + 1)]; // 1st value from array
                            (variable as ListView).Items[x].SubItems[1].Text = scores4[i]; // 2nd value from array                
                            if (i % 2 == 0) x++;
                        }

                    }
                    if ((variable as ListView).Name == "5")
                    {
                        int x = 0;
                        for (int i = 0; i < (scores5.Length - 2); i += 2)
                        {
                            item.Text = ""; // 1st column
                            item.SubItems.Add(""); // 2nd column             
                            (variable as ListView).Items.Add(item);
                            (variable as ListView).Items[x].SubItems[0].Text = scores5[(i + 1)]; // 1st value from array
                            (variable as ListView).Items[x].SubItems[1].Text = scores5[i]; // 2nd value from array                
                            if (i % 2 == 0) x++;
                        }

                    }
                    if ((variable as ListView).Name == "6")
                    {
                        int x = 0;
                        for (int i = 0; i < (scores6.Length - 2); i += 2)
                        {
                            item.Text = ""; // 1st column
                            item.SubItems.Add(""); // 2nd column             
                            (variable as ListView).Items.Add(item);
                            (variable as ListView).Items[x].SubItems[0].Text = scores6[(i + 1)]; // 1st value from array
                            (variable as ListView).Items[x].SubItems[1].Text = scores6[i]; // 2nd value from array                
                            if (i % 2 == 0) x++;
                        }
                    }
                }
            }
        }

        // HighscoreSingleplayer [Button]
        public void CreateHighscoreSPButton()
        {
            this.Controls.Add(HighscoreSingleplayer);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            HighscoreSingleplayer.Location = new Point(300, 225);
            HighscoreSingleplayer.Size = new Size(400, 100);
            HighscoreSingleplayer.Font = new Font("Lucida Sans", 15);
            HighscoreSingleplayer.Text = "Singleplayer Highscore";
            HighscoreSingleplayer.BackgroundImageLayout = ImageLayout.Stretch;
            HighscoreSingleplayer.Click += new EventHandler(this.HighscoreSingleplayer_Click);
            HighscoreSingleplayer.BackColor = Roze;
            HighscoreSingleplayer.ForeColor = Wit;
        }
        
        // HighscoreSingleplayer [Function]
        public void HighscoreSingleplayer_Click(object sender, EventArgs e)
        {
            CreateListview();
        }

        // HighscoreMultiplayer [Button]
        public void CreateHighscoreMPButton()
        {
            this.Controls.Add(HighscoreMultiplayer);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            HighscoreMultiplayer.Location = new Point(300, 375);
            HighscoreMultiplayer.Size = new Size(400, 100);
            HighscoreMultiplayer.Font = new Font("Lucida Sans", 15);
            HighscoreMultiplayer.Text = "Multiplayer Highscore";
            HighscoreMultiplayer.BackgroundImageLayout = ImageLayout.Stretch;
            HighscoreMultiplayer.Click += new EventHandler(this.HighscoreMultiplayer_Click);
            HighscoreMultiplayer.BackColor = Roze;
            HighscoreMultiplayer.ForeColor = Wit;
        }

        // HighscoreMultiplayer [Function]
        public void HighscoreMultiplayer_Click(object sender, EventArgs e)
        {
            CreateListview();
        }

        // Continue [Button] && Save [Button]
        public void CreateContinueSaveButton()
        {
            this.Controls.Add(Save);
            this.Controls.Add(Continue);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            Save.Location = new Point(15, 435);
            Save.Size = new Size(175, 50);
            Save.Text = "Save Game";
            Save.Font = new Font("Lucida Sans", 10);
            Save.Click += new EventHandler(this.SaveButton_Click);
            Save.BackColor = Roze;
            Save.ForeColor = Wit;

            Continue.Location = new Point(15, 495);
            Continue.Size = new Size(175, 50);
            Continue.Text = "Continue";
            Continue.Font = new Font("Lucida Sans", 10);
            Continue.Click += new EventHandler(this.ContinueButton_Click);
            Continue.BackColor = Roze;
            Continue.ForeColor = Wit;
        }

        // Continue [Function]
        public void ContinueButton_Click(object sender, EventArgs e)
        {

            string tekst = "-";
            int teller = 0;
            int trueteller = 0;
            string[] scores = new string[] { };
            if (Gamemode.Text == "Multiplayer")
            {
                if (Amount == 4) { tekst = File.ReadAllText(savefile1); }
                if (Amount == 6) { tekst = File.ReadAllText(savefile2); }
                if (Amount == 8) { tekst = File.ReadAllText(savefile3); }


                scores = tekst.Split('-');
                PlayerNameLabel_1.Text = scores[0];
                player1score = Convert.ToInt32(scores[1]);
                Player1Score.Text = scores[1];
                PlayerNameLabel_2.Text = scores[2];
                player2score = Convert.ToInt32(scores[3]);
                Player2Score.Text = scores[3];
                player1beurt = Convert.ToBoolean(scores[4]);
                PlayerTurn.Text = scores[5];
                teller = 6;
                trueteller = 7;

            }
            else
            {
                if (Amount == 4) { tekst = File.ReadAllText(savefile4); }
                if (Amount == 6) { tekst = File.ReadAllText(savefile5); }
                if (Amount == 8) { tekst = File.ReadAllText(savefile6); }
                scores = tekst.Split('-');

                PlayerNameLabel_1.Text = scores[0];
                timerCount = Convert.ToInt32(scores[1]);
                player1score = 0;
                player2score = 0;
                player1score = Convert.ToInt32(scores[2]);
                player2score = Convert.ToInt32(scores[3]);
                teller = 4;
                trueteller = 5;
            }


            foreach (Control x in MemoryPanel.Controls)
            {
                if (x is Button)
                {
                    x.Name = scores[teller];//essential
                    teller += 2;//essential
                    x.Enabled = Convert.ToBoolean(scores[trueteller]);// change to enable 
                    if (x.Enabled == false)
                    {
                        int nummer = Convert.ToInt32(x.Name);
                        if (Thema.Text == "Spongebob")
                        {
                            nummer = Convert.ToInt32(x.Name);
                            (x as Button).BackgroundImage = Spongebob(nummer);
                        }
                        if (Thema.Text == "Memes")
                        {
                            nummer = Convert.ToInt32(x.Name);
                            (x as Button).BackgroundImage = Meme(nummer);
                        }
                        if (Thema.Text == "Nicolas Cage")
                        {
                            nummer = Convert.ToInt32(x.Name);
                            (x as Button).BackgroundImage = Cage(nummer);
                        }
                        if (Thema.Text == "Playing Cards")
                        {
                            nummer = Convert.ToInt32(x.Name);
                            (x as Button).BackgroundImage = Speelkaarten(nummer);
                        }
                        if (Thema.Text == "Rick & Morty")
                        {
                            nummer = Convert.ToInt32(x.Name);
                            (x as Button).BackgroundImage = RickMorty(nummer);
                        }
                    }
                    trueteller += 2;
                }
            }
        }

        // Save [Function]
        public void SaveButton_Click(object sender, EventArgs e)
        {
            // Variables to be saved:
            // Player names ~~ player scores ~~ turn scores ~~ player's turn name ~~ field tiles ~~ timer(singelplayer)
            // PictureBox vergelijker = new PictureBox();
            // Vergelijker.Image = Properties.Resources._0;
            if (Gamemode.Text == "Multiplayer")
            {
                if (Amount == 4)
                {
                    File.WriteAllText(savefile1, String.Empty);
                    File.AppendAllText(path + savefile1, (PlayerNameLabel_1.Text + "-" + player1score + "-" + PlayerNameLabel_2.Text + "-" + player2score + "-" + player1beurt + "-" + PlayerTurn.Text + "-"));

                    foreach (Control x in MemoryPanel.Controls) // Saving of the cards
                    {
                        if (x is Button)
                        {
                            File.AppendAllText(savefile1, Convert.ToString(x.Name) + "-");
                            if (((x as Button).Enabled) == false)
                            {
                                File.AppendAllText(savefile1, "false" + "-");
                            }
                            else
                            {
                                File.AppendAllText(savefile1, "true" + "-");
                            }
                        }
                    }
                }
                if (Amount == 6)
                {
                    File.WriteAllText(path + savefile2, String.Empty);
                    File.AppendAllText(path + savefile2, (PlayerNameLabel_1.Text + "-" + player1score + "-" + PlayerNameLabel_2.Text + "-" + player2score + "-" + player1beurt + "-" + PlayerTurn.Text + "-"));

                    foreach (Control x in MemoryPanel.Controls) // Saving of the cards
                    {
                        if (x is Button)
                        {
                            File.AppendAllText(path + savefile2, Convert.ToString(x.Name) + "-");
                            if (((x as Button).Enabled) == false)
                            {
                                File.AppendAllText(path + savefile2, "false" + "-");
                            }
                            else
                            {
                                File.AppendAllText(path + savefile2, "true" + "-");
                            }
                        }
                    }
                }
                if (Amount == 8)
                {
                    File.WriteAllText(path + savefile3, String.Empty);
                    File.AppendAllText(path + savefile3, (PlayerNameLabel_1.Text + "-" + player1score + "-" + PlayerNameLabel_2.Text + "-" + player2score + "-" + player1beurt + "-" + PlayerTurn.Text + "-"));

                    foreach (Control x in MemoryPanel.Controls) // Saving of the cards
                    {
                        if (x is Button)
                        {
                            File.AppendAllText(path + savefile3, Convert.ToString(x.Name) + "-");
                            if (((x as Button).Enabled) == false)
                            {
                                File.AppendAllText(path + savefile3, "false" + "-");
                            }
                            else
                            {
                                File.AppendAllText(path + savefile3, "true" + "-");
                            }
                        }
                    }
                }
            }
            else  // singeplayer
            {
                if (Amount == 4)
                {
                    File.WriteAllText(savefile4, String.Empty);
                    File.AppendAllText(path + savefile4, (PlayerNameLabel_1.Text + "-" + timerCount + "-" + player1score + "-" + player1score + "-"));

                    foreach (Control x in MemoryPanel.Controls) // Saving of the cards
                    {
                        if (x is Button)
                        {
                            File.AppendAllText(savefile4, Convert.ToString(x.Name) + "-");
                            if (((x as Button).Enabled) == false)
                            {
                                File.AppendAllText(savefile4, "false" + "-");
                            }
                            else
                            {
                                File.AppendAllText(savefile4, "true" + "-");
                            }
                        }
                    }
                }
                if (Amount == 6)
                {
                    File.WriteAllText(path + savefile5, String.Empty);
                    File.AppendAllText(path + savefile5, (PlayerNameLabel_1.Text + "-" + timerCount + "-" + player1score + "-" + player1score + "-"));

                    foreach (Control x in MemoryPanel.Controls) // Saving of the cards
                    {
                        if (x is Button)
                        {
                            File.AppendAllText(path + savefile5, Convert.ToString(x.Name) + "-");
                            if (((x as Button).Enabled) == false)
                            {
                                File.AppendAllText(path + savefile5, "false" + "-");
                            }
                            else
                            {
                                File.AppendAllText(path + savefile5, "true" + "-");
                            }
                        }
                    }
                }
                if (Amount == 8)
                {
                    File.WriteAllText(path + savefile6, String.Empty);
                    File.AppendAllText(path + savefile6, (PlayerNameLabel_1.Text + "-" + timerCount + "-" + player1score + "-" + player1score + "-"));

                    foreach (Control x in MemoryPanel.Controls) // Saving of the cards
                    {
                        if (x is Button)
                        {
                            File.AppendAllText(path + savefile6, Convert.ToString(x.Name) + "-");
                            if (((x as Button).Enabled) == false)
                            {
                                File.AppendAllText(path + savefile6, "false" + "-");
                            }
                            else
                            {
                                File.AppendAllText(path + savefile6, "true" + "-");
                            }
                        }
                    }
                }
            }
        }

        // Go Back [Button]
        public void CreateGoBackButton()
        {
            this.Controls.Add(goback);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            goback.Location = new Point(10, 580);
            goback.Size = new Size(100, 50);
            goback.Font = new Font("Lucida Sans", 10);
            goback.Text = "Go Back";
            goback.BackgroundImageLayout = ImageLayout.Stretch;
            goback.Click += new EventHandler(this.GoBackbutton_Click);
            goback.BackColor = Roze;
            goback.ForeColor = Wit;
        }

        // Go Back [Function]
        public void GoBackbutton_Click(object sender, EventArgs e)
        {
            Speelveld.Visible = false;
            Gamemode.Visible = false;
            GamemodeTitle.Visible = false;
            Start.Visible = true;
            rules.Visible = true;
            Highscore.Visible = true;
            SecondStart.Visible = false;
            Thirdstart.Visible = false;
            PlayerName_1.Visible = false;
            PlayerName_2.Visible = false;
            Thema.Visible = false;
            themaTitle.Visible = false;
            veldtypeTitle.Visible = false;
            player1Title.Visible = false;
            player2Title.Visible = false;
            goback.Visible = false;
            HighscoreSingleplayer.Visible = false;
            HighscoreMultiplayer.Visible = false;
        }

        // Rules [Button]
        public void CreateRulesButton()
        {
            this.Controls.Add(rules);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            rules.Location = new Point(300, 200);
            rules.Size = new Size(400, 100);
            rules.Text = "Instructions";
            rules.Font = new Font("Lucida Sans", 15);
            rules.Click += new EventHandler(this.Rulesbutton_Click);
            rules.BackColor = Roze;
            rules.ForeColor = Wit;
        }

        // Rules [Function]
        public void Rulesbutton_Click(object sender, EventArgs e)
        {
            CreateGoBackButton();
            Start.Visible = false;
            rules.Visible = false;
            goback.Visible = true;
            Highscore.Visible = false;
        }

        // Reset [Button]
        public void CreateResetButton()
        {
            this.Controls.Add(reset);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            reset.Location = new Point(15, 555);
            reset.Size = new Size(175, 50);
            reset.Text = "Reset Game";
            reset.Font = new Font("Lucida Sans", 10);
            reset.BackgroundImageLayout = ImageLayout.Stretch;
            reset.Click += new EventHandler(this.Resetbutton_Click);
            reset.BackColor = Roze;
            reset.ForeColor = Wit;
        }

        // Reset [Function]
        public void Resetbutton_Click(object sender, EventArgs e)
        {
            mplayer= null;
            CreateLayoutPanel();

            if (Gamemode.Text == "Singleplayer")
            {
                timer.Start();
                timerCount = 0;
                player1score = 0;
                player2score = 0;
            }
            else
            {
                Player1Score.Text = Convert.ToString(player1score = 0);
                Player2Score.Text = Convert.ToString(player2score = 0);
            }
        }

        // Field Size [Box]
        public void CreateComboBox()
        {
            this.Controls.Add(Speelveld);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            Speelveld.Location = new Point(350, 250);
            Speelveld.Size = new Size(300, 50);
            Speelveld.Font = new Font("Lucida Sans", 15);
            Speelveld.Items.Clear();
            Speelveld.Items.AddRange(new object[] { "4x4", "6x6", "8x8" });
            Speelveld.SelectedIndex = 0;
            Speelveld.BackColor = Wit;
            Speelveld.ForeColor = Roze;
        }

        // Gamemode [Box] && Gamemode Title [Label]
        public void CreatePlayerCombobox()
        {
            this.Controls.Add(Gamemode);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            Gamemode.Location = new Point(350, 250);
            Gamemode.Size = new Size(300, 50);
            Gamemode.Font = new Font("Lucida Sans", 15);
            Gamemode.Items.Clear();
            Gamemode.Items.AddRange(new object[] { "Singleplayer", "Multiplayer" });
            Gamemode.SelectedIndex = 0;
            Gamemode.BackColor = Wit;
            Gamemode.ForeColor = Roze;

            this.Controls.Add(GamemodeTitle);
            GamemodeTitle.Location = new Point(150, 250);
            GamemodeTitle.Size = new Size(250, 30);
            GamemodeTitle.Font = new Font("Lucida Sans", 12);
            GamemodeTitle.Text = "Choose Game Mode:";
            GamemodeTitle.ForeColor = Wit;
            GamemodeTitle.BackColor = Roze;

        }

        // Title && Player Name [Label]
        public void TitleLabels()
        {
            this.Controls.Add(themaTitle);
            this.Controls.Add(veldtypeTitle);
            this.Controls.Add(player1Title);
            this.Controls.Add(player2Title);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            themaTitle.Location = new Point(150, 300);
            themaTitle.Size = new Size(200, 30);
            veldtypeTitle.Location = new Point(150, 250);
            veldtypeTitle.Size = new Size(200, 30);
            player1Title.Location = new Point(150, 350);
            player1Title.Size = new Size(200, 30);
            player2Title.Location = new Point(150, 400);
            player2Title.Size = new Size(200, 30);
            themaTitle.Font = new Font("Lucida Sans", 12);
            veldtypeTitle.Font = new Font("Lucida Sans", 12);
            player1Title.Font = new Font("Lucida Sans", 12);
            player2Title.Font = new Font("Lucida Sans", 12);
            themaTitle.Text = "Choose Game Theme: ";
            veldtypeTitle.Text = "Choose Game Size: ";
            if (Gamemode.Text == "Singleplayer")
            {
                player1Title.Text = "Enter Player Name: ";
            }
            else
            {
                player1Title.Text = "Enter Player 1 Name: ";
                player2Title.Text = "Enter Player 2 Name: ";
                player2Title.BackColor = Roze;
                player2Title.ForeColor = Wit;
            }
            themaTitle.ForeColor = Wit;
            veldtypeTitle.ForeColor = Wit;
            player1Title.ForeColor = Wit;
            themaTitle.BackColor = Roze;
            veldtypeTitle.BackColor = Roze;
            player1Title.BackColor = Roze;


        }

        // Theme [Box]
        public void CreateThemas()
        {
            this.Controls.Add(Thema);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            Thema.Location = new Point(350, 300);
            Thema.Size = new Size(300, 50);
            Thema.Font = new Font("Lucida Sans", 15);
            Thema.Items.Clear();
            Thema.Items.AddRange(new object[] { "Playing Cards", "Memes", "Nicolas Cage", "Spongebob", "Rick & Morty" });
            Thema.SelectedIndex = 0;
            Thema.BackColor = Wit;
            Thema.ForeColor = Roze;
        }      

        // Field layout [Panel]
        public void CreateLayoutPanel()
        {
            
            MemoryPanel.Controls.Clear();
            MemoryPanel.RowStyles.Clear();
            MemoryPanel.ColumnStyles.Clear();
            int Amountx = Convert.ToInt32(Amount * Amount);
            int[] randomarray = Random(Amountx);
            MemoryPanel.Location = new System.Drawing.Point(200, 10);
            MemoryPanel.Size = new System.Drawing.Size(600, 600);
            MemoryPanel.RowCount = Amount;
            MemoryPanel.ColumnCount = Amount;
            MemoryPanel.BackColor = Color.Transparent;

            for (int i = 0; i < (Amount); i++)
            {
                MemoryPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
                MemoryPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            }
            for (int i = 0; i < (Amountx); i++)
            {
                var button = new Button
                {
                    //Text enabled for testing, removed for final product
                    Text = Convert.ToString(randomarray[i]),
                    Name = Convert.ToString(randomarray[i]),
                    BackgroundImage = Background(thema),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Dock = DockStyle.Fill,
                    Cursor = Cursors.Hand
            };
                MemoryPanel.Controls.Add(button);
                button.Click += new System.EventHandler(FlipCard);
            }
            maxscore = Amount * Amount / 2;
            this.Controls.Add(MemoryPanel);
            //CreateBackground(thema);
            mplayer = Musicplayer(thema);
            mplayer.PlayLooping();

        }

        // Player [Textbox]
        public void CreatePlayerName()
        {
            this.Controls.Add(PlayerName_1);
            this.Controls.Add(PlayerName_2);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            PlayerName_1.Location = new Point(350, 350);
            PlayerName_2.Location = new Point(350, 400);
            PlayerName_1.Size = new Size(300, 50);
            PlayerName_2.Size = new Size(300, 50);
            PlayerName_1.Text = "";
            PlayerName_2.Text = "";
            PlayerName_1.Font = new Font("Lucida Sans", 15);
            PlayerName_2.Font = new Font("Lucida Sans", 15);
            PlayerName_1.BackColor = Wit;
            PlayerName_1.ForeColor = Roze;
            PlayerName_2.BackColor = Wit;
            PlayerName_2.ForeColor = Roze;
        }

        // Player [Label]
        public void CreatePlayerNameLabel()
        {
            this.Controls.Add(PlayerNameLabel_1);
            this.Controls.Add(PlayerNameLabel_2);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            if (Gamemode.Text == "Singleplayer")
            {
                PlayerNameLabel_1.Location = new Point(10, 10);
            }
            else
            {
                PlayerNameLabel_1.Location = new Point(10, 60);
                PlayerNameLabel_2.Location = new Point(10, 110);
            }
            PlayerNameLabel_1.Size = new Size(120, 20);
            PlayerNameLabel_2.Size = new Size(120, 20);
            PlayerNameLabel_1.Text = PlayerName_1.Text;
            PlayerNameLabel_2.Text = PlayerName_2.Text;
            PlayerNameLabel_1.Font = new Font("Lucida Sans", 12);
            PlayerNameLabel_2.Font = new Font("Lucida Sans", 12);
            PlayerNameLabel_1.ForeColor = Wit;
            PlayerNameLabel_2.ForeColor = Wit;
            PlayerNameLabel_1.BackColor = Roze;
            PlayerNameLabel_2.BackColor = Roze;
            if (PlayerNameLabel_1.Text == "")
            {
                PlayerNameLabel_1.Text = "Player 1";
                PlayerName_1.Text = "Player 1";
            }
            if (PlayerNameLabel_2.Text == "")
            {
                PlayerNameLabel_2.Text = "Player 2";
                PlayerName_2.Text = "Player 2";
            }
        }

        // Player Turn [Label]
        public void PlayerTurnLabel()
        {
            this.Controls.Add(PlayerTurn);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            PlayerTurn.Location = new Point(10, 10);
            PlayerTurn.Size = new Size(150, 30);
            PlayerTurn.Text = PlayerName_1.Text + "'s turn";
            PlayerTurn.Font = new Font("Lucida Sans", 12);
            PlayerTurn.ForeColor = Wit;
            PlayerTurn.BackColor = Roze;
        }

        // Score [Label]
        public void CreatePlayerScore()
        {
            this.Controls.Add(Player1Score);
            this.Controls.Add(Player2Score);
            this.Controls.Add(PlayerTurn);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            if (Gamemode.Text == "Singleplayer")
            {
                Player1Score.Location = new Point(110, 10);
            }
            else
            {
                Player1Score.Location = new Point(130, 60);
                Player2Score.Location = new Point(130, 110);
            }
            Player1Score.Text = Convert.ToString(player1score);
            Player2Score.Text = Convert.ToString(player2score);
            PlayerTurn.Location = new Point(30, 120);
            Player1Score.Size = new Size(30, 20);
            Player2Score.Size = new Size(30, 20);
            Player1Score.Font = new Font("Lucida Sans", 12);
            Player2Score.Font = new Font("Lucida Sans", 12);
            Player1Score.ForeColor = Wit;
            Player2Score.ForeColor = Wit;
            Player1Score.BackColor = Roze;
            Player2Score.BackColor = Roze;
        }

        // Random int[] [Function]
        public static int[] Random(int nummer)         
        {
            // Fill array with random numbers from 1 to 'nummer'
            var random = new Random();

            int[] randomArray = Enumerable.Range(1, nummer).OrderBy(x => random.Next()).ToArray();
            return randomArray;
        }

        // Victory Screen [MessageBox]
        public void Victory()
        {
            if (Gamemode.Text == "Multiplayer")
            {
                if (player1score > player2score)
                {
                    if (Amount == 4)
                    {
                        File.AppendAllText(path + HighScore, (PlayerName_1.Text + "-" + player1score + "-" + Environment.NewLine));
                    }
                    if (Amount == 6)
                    {
                        File.AppendAllText(path + HighScore1, (PlayerName_1.Text + "-" + player1score + "-" + Environment.NewLine));
                    }
                    if (Amount == 8)
                    {
                        File.AppendAllText(path + HighScore2, (PlayerName_1.Text + "-" + player1score + "-" + Environment.NewLine));
                    }
                    MessageBox.Show(PlayerName_1.Text + " won this game with " + player1score + " to " + player2score);
                }
                else
                {
                    if (Amount == 4)
                    {
                        File.AppendAllText(path + HighScore, (PlayerName_2.Text + "-" + player2score + "-" + Environment.NewLine));
                    }
                    if (Amount == 6)
                    {
                        File.AppendAllText(path + HighScore1, (PlayerName_2.Text + "-" + player2score + "-" + Environment.NewLine));
                    }
                    if (Amount == 8)
                    {
                        File.AppendAllText(path + HighScore2, (PlayerName_2.Text + "-" + player2score + "-" + Environment.NewLine));
                    }
                    MessageBox.Show(PlayerName_2.Text + " won this game with " + player2score + " to " + player1score);
                }
            }
            else if (Gamemode.Text == "Singleplayer")
            {
                timer.Stop();
                if (Amount == 4)
                {
                    File.AppendAllText(path + HighScore, (PlayerName_1.Text + "-" + player1score + "-" + Environment.NewLine));
                }
                if (Amount == 6)
                {
                    File.AppendAllText(path + HighScore1, (PlayerName_1.Text + "-" + player1score + "-" + Environment.NewLine));
                }
                if (Amount == 8)
                {
                    File.AppendAllText(path + HighScore2, (PlayerName_1.Text + "-" + player1score + "-" + Environment.NewLine));
                }
                MessageBox.Show(PlayerName_1.Text + " won this game within " + timerCount + " seconds");
            }
            else
            { }
        }

        // Flip Card [Function]
        public async void FlipCard(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int nummer = Convert.ToInt32(clickedButton.Name);
            if (Thema.Text == "Spongebob")
            {
                clickedButton.BackgroundImage = Spongebob(nummer);
            }
            if (Thema.Text == "Memes")
            {
                clickedButton.BackgroundImage = Meme(nummer);
            }
            if (Thema.Text == "Nicolas Cage")
            {
                clickedButton.BackgroundImage = Cage(nummer);
            }
            if (Thema.Text == "Playing Cards")
            {
                clickedButton.BackgroundImage = Speelkaarten(nummer);
            }
            if (Thema.Text == "Rick & Morty")
            {
                clickedButton.BackgroundImage = RickMorty(nummer);
            }
            
            clickedButton.BackgroundImageLayout = ImageLayout.Stretch;


            if (firstClicked == null)// filling 1st comparer
            {
                firstClicked = clickedButton;
                firstClicked.Enabled = false;
                return;
            }

            secondClicked = clickedButton; // filling 2nd comparer   

            if ((Convert.ToInt32(firstClicked.Name) % 2 != 0))
            {
                if (Convert.ToInt32(firstClicked.Name) == (Convert.ToInt32(secondClicked.Name) - 1))
                {
                    if (player1beurt == true) { player1score++; Player1Score.Text = Convert.ToString(player1score); }

                    else { player2score++; Player2Score.Text = Convert.ToString(player2score); }

                    if (player1score + player2score == maxscore - 1) { Victory(); }
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
                    await Task.Delay(50);
                    System.Threading.Thread.Sleep(500);
                    firstClicked.BackgroundImage = Background(thema);
                    secondClicked.BackgroundImage = Background(thema);
                    firstClicked.Enabled = true;
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
            }
            else
            {
                if (Convert.ToInt32(secondClicked.Name) == (Convert.ToInt32(firstClicked.Name) - 1))
                {
                    if (player1beurt == true)
                    {
                        player1score++; Player1Score.Text = Convert.ToString(player1score);
                    }
                    else
                    {
                        player2score++; Player2Score.Text = Convert.ToString(player2score);
                    }
                    if (player1score + player2score == maxscore - 1) { Victory(); }
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
                    await Task.Delay(50);
                    System.Threading.Thread.Sleep(500);
                    firstClicked.BackgroundImage = Background(thema);
                    secondClicked.BackgroundImage = Background(thema);
                    firstClicked.Enabled = true;
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
            }
        }

        // Cardback [Image]
        public static Image Background(string thema)
        {

            if (thema== "Nicolas Cage")
            {
                Image keuze = Properties.Resources.nicolas_0;
                return keuze;
            }
            else if (thema == "Spongebob")
            {
                Image keuze = Properties.Resources.spongebob_0;
                return keuze;
            }

            else if (thema == "Memes")
            {
                Image keuze = Properties.Resources.Meme_0;
                return keuze;
            }
            else if (thema == "Rick & Morty")
            {
                Image keuze = Properties.Resources.rmcardback;
                return keuze;
            }
            else //if (thema == "Playing Cards")
            {
                Image keuze = Properties.Resources.pccardback;
                return keuze;
            }

        }

        // Default [Card Image]
        public static Image Speelkaarten(int nummer)
        {
            int nummer2 = nummer / 2;
            if (nummer % 2 != 0)
            {
                nummer2 = (nummer + 1) / 2;
            }

            List<Image> i01 = new List<Image>
            {
                Properties.Resources.image_1,
                Properties.Resources.image_2,
                Properties.Resources.image_3,
                Properties.Resources.image_4,
                Properties.Resources.image_5,
                Properties.Resources.image_6,
                Properties.Resources.image_7,
                Properties.Resources.image_8,
                Properties.Resources.image_9,
                Properties.Resources.image_10,
                Properties.Resources.image_11,
                Properties.Resources.image_12,
                Properties.Resources.image_13,
                Properties.Resources.image_14,
                Properties.Resources.image_15,
                Properties.Resources.image_16,
                Properties.Resources.image_17,
                Properties.Resources.image_18,
                Properties.Resources.image_19,
                Properties.Resources.image_20,
                Properties.Resources.image_21,
                Properties.Resources.image_22,
                Properties.Resources.image_23,
                Properties.Resources.image_24,
                Properties.Resources.image_25,
                Properties.Resources.image_26,
                Properties.Resources.image_27,
                Properties.Resources.image_28,
                Properties.Resources.image_29,
                Properties.Resources.image_30,
                Properties.Resources.image_31,
                Properties.Resources.image_32
            };
            Image plaatje = i01[nummer2 - 1];
            return plaatje;
        }

        // Sponge Bob [Card Image]
        public static Image Spongebob(int nummer)
        {
            int nummer2 = nummer / 2;
            if (nummer % 2 != 0)
            {
                nummer2 = (nummer + 1) / 2;
            }

            #region SpongeBob Cardback
            List<Image> b01 = new List<Image>
            {
                Properties.Resources.spongebob_1,
                Properties.Resources.spongebob_2,
                Properties.Resources.spongebob_3,
                Properties.Resources.spongebob_4,
                Properties.Resources.spongebob_5,
                Properties.Resources.spongebob_6,
                Properties.Resources.spongebob_7,
                Properties.Resources.spongebob_8,
                Properties.Resources.spongebob_9,
                Properties.Resources.spongebob_10,
                Properties.Resources.spongebob_11,
                Properties.Resources.spongebob_12,
                Properties.Resources.spongebob_13,
                Properties.Resources.spongebob_14,
                Properties.Resources.spongebob_15,
                Properties.Resources.spongebob_16,
                Properties.Resources.spongebob_17,
                Properties.Resources.spongebob_18,
                Properties.Resources.spongebob_19,
                Properties.Resources.spongebob_20,
                Properties.Resources.spongebob_21,
                Properties.Resources.spongebob_22,
                Properties.Resources.spongebob_23,
                Properties.Resources.spongebob_24,
                Properties.Resources.spongebob_25,
                Properties.Resources.spongebob_26,
                Properties.Resources.spongebob_27,
                Properties.Resources.spongebob_28,
                Properties.Resources.spongebob_29,
                Properties.Resources.spongebob_30,
                Properties.Resources.spongebob_31,
                Properties.Resources.spongebob_32
            };
            Image plaatje = b01[nummer2 - 1];
            return plaatje;
            #endregion
        }

        // Nicolas Cage [Card Image]
        public static Image Cage(int nummer)
        {
            int nummer2 = nummer / 2;
            if (nummer % 2 != 0)
            {
                nummer2 = (nummer + 1) / 2;
            }
            #region Nicolas Cage Cardback
            List<Image> a01 = new List<Image>
            {
                Properties.Resources.nicolas_1,
                Properties.Resources.nicolas_2,
                Properties.Resources.nicolas_3,
                Properties.Resources.nicolas_4,
                Properties.Resources.nicolas_5,
                Properties.Resources.nicolas_6,
                Properties.Resources.nicolas_7,
                Properties.Resources.nicolas_8,
                Properties.Resources.nicolas_9,
                Properties.Resources.nicolas_10,
                Properties.Resources.nicolas_11,
                Properties.Resources.nicolas_12,
                Properties.Resources.nicolas_13,
                Properties.Resources.nicolas_14,
                Properties.Resources.nicolas_15,
                Properties.Resources.nicolas_16,
                Properties.Resources.nicolas_17,
                Properties.Resources.nicolas_18,
                Properties.Resources.nicolas_19,
                Properties.Resources.nicolas_20,
                Properties.Resources.nicolas_21,
                Properties.Resources.nicolas_22,
                Properties.Resources.nicolas_23,
                Properties.Resources.nicolas_24,
                Properties.Resources.nicolas_25,
                Properties.Resources.nicolas_26,
                Properties.Resources.nicolas_27,
                Properties.Resources.nicolas_28,
                Properties.Resources.nicolas_29,
                Properties.Resources.nicolas_30,
                Properties.Resources.nicolas_31,
                Properties.Resources.nicolas_32
            };
            Image plaatje = a01[nummer2 - 1];
            return plaatje;
            #endregion
        }

        // Meme [Card Image]
        public static Image Meme(int nummer)
        {
            int nummer2 = nummer / 2;
            if (nummer % 2 != 0)
            {
                nummer2 = (nummer + 1) / 2;
            }
            #region Meme Cardback
            List<Image> m01 = new List<Image>
            {
                Properties.Resources.Meme_1,
                Properties.Resources.Meme_2,
                Properties.Resources.Meme_3,
                Properties.Resources.Meme_4,
                Properties.Resources.Meme_5,
                Properties.Resources.Meme_6,
                Properties.Resources.Meme_7,
                Properties.Resources.Meme_8,
                Properties.Resources.Meme_9,
                Properties.Resources.Meme_10,
                Properties.Resources.Meme_11,
                Properties.Resources.Meme_12,
                Properties.Resources.Meme_13,
                Properties.Resources.Meme_14,
                Properties.Resources.Meme_15,
                Properties.Resources.Meme_16,
                Properties.Resources.Meme_17,
                Properties.Resources.Meme_18,
                Properties.Resources.Meme_19,
                Properties.Resources.Meme_20,
                Properties.Resources.Meme_21,
                Properties.Resources.Meme_22,
                Properties.Resources.Meme_23,
                Properties.Resources.Meme_24,
                Properties.Resources.Meme_25,
                Properties.Resources.Meme_26,
                Properties.Resources.Meme_27,
                Properties.Resources.Meme_28,
                Properties.Resources.Meme_29,
                Properties.Resources.Meme_30,
                Properties.Resources.Meme_31,
                Properties.Resources.Meme_32
            };
            Image plaatje = m01[nummer2 - 1];
            return plaatje;
            #endregion 
        }

        // Rick & Morty [Card Image]
        public static Image RickMorty(int nummer)
        {
            int nummer2 = nummer / 2;
            if (nummer % 2 != 0)
            {
                nummer2 = (nummer + 1) / 2;
            }
            #region Meme Cardback
            List<Image> m01 = new List<Image>
            {
                Properties.Resources.rmcard_1,
                Properties.Resources.rmcard_2,
                Properties.Resources.rmcard_3,
                Properties.Resources.rmcard_4,
                Properties.Resources.rmcard_5,
                Properties.Resources.rmcard_6,
                Properties.Resources.rmcard_7,
                Properties.Resources.rmcard_8,
                Properties.Resources.rmcard_9,
                Properties.Resources.rmcard_10,
                Properties.Resources.rmcard_11,
                Properties.Resources.rmcard_12,
                Properties.Resources.rmcard_13,
                Properties.Resources.rmcard_14,
                Properties.Resources.rmcard_15,
                Properties.Resources.rmcard_16,
                Properties.Resources.rmcard_17,
                Properties.Resources.rmcard_18,
                Properties.Resources.rmcard_19,
                Properties.Resources.rmcard_20,
                Properties.Resources.rmcard_21,
                Properties.Resources.rmcard_22,
                Properties.Resources.rmcard_23,
                Properties.Resources.rmcard_24,
                Properties.Resources.rmcard_25,
                Properties.Resources.rmcard_26,
                Properties.Resources.rmcard_27,
                Properties.Resources.rmcard_28,
                Properties.Resources.rmcard_29,
                Properties.Resources.rmcard_30,
                Properties.Resources.rmcard_31,
                Properties.Resources.rmcard_32
            };
            Image plaatje = m01[nummer2 - 1];
            return plaatje;
            #endregion 
        }
        

        // Background Music [Soundplayer]
        public static SoundPlayer Musicplayer(string thema)
        {
            
            if (thema == "Spongebob")
            {
                SoundPlayer player = new SoundPlayer
                {
                    Stream = Properties.Resources.SpongeBob_Trap_Remix_Krusty_Krab
                };
                player.Load();
                return player;
            }
            if (thema == "Nicolas Cage")
            {
                SoundPlayer player = new SoundPlayer
                {
                    Stream = Properties.Resources.epic
                };
                player.Load();
                return player;
            }
            
            if (thema == "Memes")
            {
                SoundPlayer player = new SoundPlayer
                {
                    Stream = Properties.Resources.Koji_Kondo_Super_Mario_64_Dire__Dire_Docks__underwater_cave__www_my_free_mp3_net_
                };
                player.Load();
                return player;

            }
            if (thema == "Rick & Morty")
            {
                SoundPlayer player = new SoundPlayer
                {
                    Stream = Properties.Resources.rmmusic
                };
                player.Load();
                return player;

            }
            else 
            {
                SoundPlayer player = new SoundPlayer
                {
                    Stream = Properties.Resources.XX_Intro_www_my_free_mp3_net_
                };
                player.Load();
                return player;

            }
        }

        // Background [Image]
        public void CreateBackground (string thema)
        {
            if (thema == "Spongebob")
            {
                Image Gamebackground = Properties.Resources.SBbackground;
                this.BackgroundImage = Gamebackground;
            }
            if (thema == "Nicolas Cage")
            {
                Image Gamebackground = Properties.Resources.NCbackground;
                this.BackgroundImage = Gamebackground;
            }
            if (thema == "Playing Cards")
            {
                Image Gamebackground = Properties.Resources.PCbackground;
                this.BackgroundImage = Gamebackground;
            }
            if (thema == "Memes")
            {
                Image Gamebackground = Properties.Resources.Mbackground;
                this.BackgroundImage = Gamebackground;
            }
            if (thema == "Rick & Morty")
            {
                Image Gamebackground = Properties.Resources.rmbackground;
                this.BackgroundImage = Gamebackground;
            }
        }

        // ???
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
} 
