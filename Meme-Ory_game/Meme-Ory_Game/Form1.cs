﻿using System;
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
using System.Collections;



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
        string singleplayerhighscore1 = "Singleplayer1.txt";
        string singleplayerhighscore2 = "Singleplayer2.txt";
        string singleplayerhighscore3 = "Singleplayer3.txt";
        bool player1beurt = true;
        bool muted = true;
        ComboBox Speelveld = new ComboBox();
        ComboBox Gamemode = new ComboBox();
        ComboBox Thema = new ComboBox();
        ComboBox musicselect = new ComboBox();
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
       // ListViewItem item = new ListViewItem();
        TableLayoutPanel MemoryPanel = new TableLayoutPanel();
        PictureBox GameTitle = new PictureBox();
        Button mute = new Button();
        System.Windows.Forms.Timer timer;
        SoundPlayer mplayer;
        Label tester = new Label();
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
           // loadingimages(); // test field
          //    musicselection(); // test field

            //Image Gamebackground = Properties.Resources.Gamebackground;
            //this.BackgroundImage = Gamebackground;
        }

        // Game Title [PictureBox]
        public void CreateGameTitle()
        {
            this.Controls.Add(GameTitle);
            GameTitle.Location = new Point(320, 10);
            GameTitle.Size = new Size(600, 140);
            GameTitle.Image = Properties.Resources.Gamelogo;
            GameTitle.BackColor = Color.Transparent;
           
        }

        public void ClearAll()
        {
            foreach (Control tester in Controls)
            {
                if (tester.Visible == true) { tester.Visible = false; }
            }
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
        public void Startbutton_Click(object sender, EventArgs e) //improved
        {
            ClearAll();
            CreateSecondStartbutton();
            CreatePlayerCombobox();
            CreateGoBackButton();
            SecondStart.Visible = true;
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
        public void SecondStartbutton_Click(object sender, EventArgs e)//improved
        {
            ClearAll();
            CreateThirdStart();
            CreateComboBox();
            CreatePlayerName();
            CreateThemas();
            TitleLabels();

            Thema.Visible = true;
            goback.Visible = true;
            Speelveld.Visible = true;
            PlayerName_1.Visible = true;
            PlayerName_2.Visible = true;
            Thirdstart.Visible = true;
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
        public void Thirdstart_Click(object sender, EventArgs e) // improved
        {
            ClearAll();
            if (Speelveld.Text == "4x4")
                Amount = 4;
            else if (Speelveld.Text == "6x6")
                Amount = 6;
            else if (Speelveld.Text == "8x8")
                Amount = 8;
            thema = Thema.Text;
            CreateLayoutPanel();
            CreatePlayerNameLabel();
            CreatePlayerScore();
            CreateResetButton();
            CreateContinueSaveButton();
            PlayerTurnLabel();
            MemoryPanel.Visible = true;
            PlayerNameLabel_1.Visible = true;
            Save.Visible = true;
            Continue.Visible = true;
            reset.Visible = true;
            goback.Visible = true;
            goback.Location = new Point(820, 10);
            mplayer = Musicplayer(thema);
            mplayer.PlayLooping();
            MuteMusic();
            if (Gamemode.Text == "Singleplayer")
            {
                //CreateTimerLabel();
                //CreateTimer();
                Player1Score.Visible = false;
                //timerLabel.Visible = true;
            }
            else
            {
                Player2Score.Visible = true;
                PlayerNameLabel_2.Visible = true;

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
        public void Highscore_Click(object sender, EventArgs e) //improved
        {
            ClearAll();
            CreateGoBackButton();
            goback.Visible = true;
            CreateListview();
            GameTitle.Visible = true;

        }

        // Highscore [List]
        public void CreateListview() // improved
        {
            // making of the highscore labels
            int labelXas = 200;
            int labelYas = 180;
            int sizeX = 200;
            int sizeY = 20;
            for (int x = 0; x < 5; x++)
            {
                Label modes = new Label();
                modes.Size = new Size(sizeX, sizeY);
                modes.Left = labelXas;
                modes.Top = labelYas;
                modes.BackColor = Color.Azure;
                modes.TextAlign = ContentAlignment.MiddleCenter;
                modes.BorderStyle = BorderStyle.FixedSingle;
                switch (x)
                {
                    case 0:
                        modes.Text = "4x4"; modes.Name = Convert.ToString(x);
                        break;
                    case 1:
                        modes.Text = "6x6"; modes.Name = Convert.ToString(x);
                        break;
                    case 2:
                        modes.Text = "8x8"; modes.Name = Convert.ToString(x);
                        break;
                    case 3:
                        modes.Text = "multiplayer"; modes.Name = Convert.ToString(x);
                        break;
                    default:
                        modes.Text = "singleplayer"; modes.Name = Convert.ToString(x);
                        break;
                }

                if (x < 3) { labelXas += 200; }
                else { labelYas += 240; }

                if (x == 2)
                {
                    labelXas = 200; labelYas = 160;
                    sizeX = 600;
                }
                this.Controls.Add(modes);
                // end 
            }
            //if no highscore file exist make an empty one to prevent errors with loading of the listviews
            if (!File.Exists((path + HighScore)))  {File.AppendAllText(path + HighScore, string.Empty);}
            if (!File.Exists((path + HighScore1))) { File.AppendAllText(path + HighScore1, string.Empty); }
            if (!File.Exists((path + HighScore2))) { File.AppendAllText(path + HighScore2, string.Empty); }
            if (!File.Exists((path + singleplayerhighscore1))) { File.AppendAllText(path + singleplayerhighscore1, string.Empty); }
            if (!File.Exists((path + singleplayerhighscore2))) { File.AppendAllText(path + singleplayerhighscore2, string.Empty); }
            if (!File.Exists((path + singleplayerhighscore3))) { File.AppendAllText(path + singleplayerhighscore3, string.Empty); }
            // end

            // retrieving and storing of data
            string tekst = File.ReadAllText(path + HighScore);
            string[] scores1 = tekst.Split('-');
            string tekst2 = File.ReadAllText(path + HighScore1);
            string[] scores2 = tekst2.Split('-');
            string tekst3 = File.ReadAllText(path + HighScore2);
            string[] scores3 = tekst3.Split('-');
            string tekst4 = File.ReadAllText(path + singleplayerhighscore1);
            string[] scores4 = tekst4.Split('-');
            string tekst5 = File.ReadAllText(path + singleplayerhighscore2);
            string[] scores5 = tekst5.Split('-');
            string tekst6 = File.ReadAllText(path + singleplayerhighscore3);
            string[] scores6 = tekst6.Split('-');
            string[][] JaggedArrayScores = new string[6][];
            JaggedArrayScores[0] = scores1;
            JaggedArrayScores[1] = scores2;
            JaggedArrayScores[2] = scores3;
            JaggedArrayScores[3] = scores4;
            JaggedArrayScores[4] = scores5;
            JaggedArrayScores[5] = scores6;
            //end  
            // making of the listview controls(the highscore lists)
            int Xas = 200;
            int Yas = 200;
            for (int teller = 0; teller < 6; teller++)
            {
                ListView Dynamisch = new ListView();
                Dynamisch.Bounds = new Rectangle(new Point(Xas, Yas), new Size(200, 200));
                Dynamisch.View = View.Details;
                Dynamisch.AllowColumnReorder = true;
                Dynamisch.FullRowSelect = true;
                Dynamisch.GridLines = true;
                Dynamisch.BackColor = Color.Wheat;
                if (teller < 3)
                {                  
                    Dynamisch.Columns.Add("Score", -2, HorizontalAlignment.Left);
                    Dynamisch.Columns.Add("Name", -2, HorizontalAlignment.Left);
                    Dynamisch.Sorting = SortOrder.Ascending;
             
                }
                else
                {
                    Dynamisch.Columns.Add("Time", -2, HorizontalAlignment.Left);                     
                    Dynamisch.Columns.Add("Name", -2, HorizontalAlignment.Left);
                    Dynamisch.Sorting = SortOrder.Ascending;

                }
                Dynamisch.Name = Convert.ToString(teller);

                Xas += 200;
                if (teller == 2) { Xas = 200; Yas += 220; }
                this.Controls.Add(Dynamisch);
                //end
            }
            // filling the score lists
            int jaggedcounter = 0;
            foreach (Control variable in Controls)
            {                
                if (variable is ListView)
                {
                  int x = 0;                       
                  for (int i = 0; i < JaggedArrayScores[jaggedcounter].Length - 2; i += 2)
                      {
                        ListViewItem item = new ListViewItem();
                        item.Text = "x"; // 1st column
                        item.SubItems.Add("x"); // 2nd column             
                        (variable as ListView).Items.Add(item);
                        (variable as ListView).Items[x].SubItems[0].Text = JaggedArrayScores[jaggedcounter][i + 1]; // 1st value from array (the score)
                        (variable as ListView).Items[x].SubItems[1].Text = JaggedArrayScores[jaggedcounter][i]; // 2nd value from array       (the name)         
                            x++;
                      }
                  jaggedcounter++;
                    //end
                 }
             }
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
            // fills the variables from the specific save file
            string tekst = "-";
            int teller = 0;
            int trueteller = 0;
            string[] scores = new string[] { };
            if (Gamemode.Text == "Multiplayer")
            {
                if (Amount == 4) { tekst = File.ReadAllText(savefile1); }
          else  if (Amount == 6) { tekst = File.ReadAllText(savefile2); }
          else  if (Amount == 8) { tekst = File.ReadAllText(savefile3); }

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
               else if (Amount == 6) { tekst = File.ReadAllText(savefile5); }
               else if (Amount == 8) { tekst = File.ReadAllText(savefile6); }
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

            string thema = Thema.Text;
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
                        (x as Button).BackgroundImage = CustomCards(nummer, thema);
                    }
                    trueteller += 2;
                }
            }
        }

        // Save [Function]
        public void SaveButton_Click(object sender, EventArgs e)
        {
            string[] savefilesarray = new string[6];
            savefilesarray[0] = savefile1;
            savefilesarray[1] = savefile2;
            savefilesarray[2] = savefile3;
            savefilesarray[3] = savefile4;
            savefilesarray[4] = savefile5;
            savefilesarray[5] = savefile6;
            string specificsavefile = " ";
            // Variables to be saved:
            // Player names ~~ player scores ~~ turn scores ~~ player's turn name ~~ field tiles ~~ timer(singelplayer)
            if (firstClicked!= null)
            {
                firstClicked.BackgroundImage = Background(thema);
                firstClicked.Enabled = true;
                firstClicked = null;
            }


            if (Gamemode.Text == "Multiplayer")
            {
                if (Amount == 4) { specificsavefile = savefilesarray[0]; }
                else if (Amount == 6) { specificsavefile = savefilesarray[1]; }
                else if (Amount == 6) { specificsavefile = savefilesarray[2]; }
                //make loop above it to set savefile variable

                File.WriteAllText(specificsavefile, String.Empty);
                File.AppendAllText(path + specificsavefile, (PlayerNameLabel_1.Text + "-" + player1score + "-" + PlayerNameLabel_2.Text + "-" + player2score + "-" + player1beurt + "-" + PlayerTurn.Text + "-"));

                foreach (Control x in MemoryPanel.Controls) // Saving of the cards
                {
                    if (x is Button)
                    {
                        File.AppendAllText(specificsavefile, Convert.ToString(x.Name) + "-");
                        if (((x as Button).Enabled) == false)
                        {
                            File.AppendAllText(specificsavefile, "false" + "-");
                        }
                        else
                        {
                            File.AppendAllText(specificsavefile, "true" + "-");
                        }
                    }
                }
            }
            else  // singeplayer
            {

                if      (Amount == 4) { specificsavefile = savefilesarray[3]; }
                else if (Amount == 6) { specificsavefile = savefilesarray[4]; }
                else if (Amount == 6) { specificsavefile = savefilesarray[5]; }
              
                    File.WriteAllText(specificsavefile, String.Empty);
                    File.AppendAllText(path + specificsavefile, (PlayerNameLabel_1.Text + "-" + timerCount + "-" + player1score + "-" + player1score + "-"));

                    foreach (Control x in MemoryPanel.Controls) // Saving of the cards
                    {
                        if (x is Button)
                        {
                            File.AppendAllText(specificsavefile, Convert.ToString(x.Name) + "-");
                            if (((x as Button).Enabled) == false)
                            {
                                File.AppendAllText(specificsavefile, "false" + "-");
                            }
                            else
                            {
                                File.AppendAllText(specificsavefile, "true" + "-");
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
        public void GoBackbutton_Click(object sender, EventArgs e) // improved
        {
            if (mplayer !=null)
            {
                mplayer.Stop();
                mplayer.Stream = null;
            }
           
            FormClosed += (o, a) => new Form1().ShowDialog();
            Hide();
            Close();
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
        public void Rulesbutton_Click(object sender, EventArgs e)//improved
        {
            CreateGoBackButton();
            ClearAll();
            goback.Visible = true;
            Rules.Visible = true;
            CreateRulesLabel();
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

        // Rules [Textfield]
        public void CreateRulesLabel()
        {
            this.Controls.Add(Rules);
            Rules.Size = new Size(444, 457);
            Rules.Text = "Spelregels \n\nSpelers\nHet spel kan alleen of met twee spelers gespeeld worden.\n\nDoel\nHet doel van het singleplayer spel is om binnen de tijd,\nzoveel mogelijk paren van kaartjes te maken.\nHoe sneller je bent, hoe hoger je score.\n\nHet doel van het multiplayer spel is om zoveel mogelijk paartjes van kaarten te maken.\nAls je meer paartjes hebt dan je tegenstander, win je het spel.\n\nRegels\nBij singleplayer voer je je naam in en je kiest op welke moeilijkheidsgraad je wilt spelen.\nJe speelt tegen tijd.\n\nBij multiplayer is de eerste speler die zijn naam in voert is als eerste aan de beurt.\nAls je een correct paar hebt, mag je nog een keer.\nAls je een incorrect paar hebt, is de tegenstander aan de beurt.\nHet spel gaat door totdat het laatste paartje is omgedraait.\nVoor het laatste omgedraaide paar zijn er geen punten te verkrijgen.\n\nTips\nLet op welke kaartjes je tegenstander omdraait, zodat je niet hetzelfde doet.";
            Rules.BackgroundImageLayout = ImageLayout.Stretch;
        }

        // Reset [Function]
        public void Resetbutton_Click(object sender, EventArgs e)
        {
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

        // Field Size [ComboBox]
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
            Speelveld.DropDownStyle = ComboBoxStyle.DropDownList;
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
            Gamemode.DropDownStyle = ComboBoxStyle.DropDownList;

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

        // Theme [Box] dropdownlist of possible selectable themes
        public void CreateThemas()
        {
            this.Controls.Add(Thema);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            Thema.Location = new Point(350, 300);
            Thema.Size = new Size(300, 50);
            Thema.Font = new Font("Lucida Sans", 15);
            Thema.Items.Clear();
            string[] dirs = Directory.GetDirectories(path);
            int PathLength = path.Length;
            string MusicRemove = path +"CAGETUNES";// to remove music directory, which is a no go becuase of cruel groupmembers
            dirs = dirs.Where(val => val != MusicRemove).ToArray();// see above
            foreach (string directorynames in dirs)
            {

                directorynames.Replace(path, "");
                Thema.Items.Add(directorynames.Remove(0,PathLength));

            };
            Thema.SelectedIndex = 0;
            Thema.BackColor = Wit;
            Thema.ForeColor = Roze;
            Thema.DropDownStyle = ComboBoxStyle.DropDownList;
        }     

        // Field layout [Panel]
        public void CreateLayoutPanel()
        { 
            if (Gamemode.Text == "Singleplayer")
            {
                CreateTimerLabel();
                CreateTimer();
                timerLabel.Visible = true;
            }
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
            CreateBackground(thema);
          
          

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
            string thema = Thema.Text;

            foreach (Control lastflip in MemoryPanel.Controls)
            {
                if (lastflip is Button)
                {
                    int nummer = Convert.ToInt32(lastflip.Name);
                    if ((lastflip as Button).Enabled == true)
                    {
         
                        lastflip.BackgroundImage = CustomCards(nummer, thema);
                        lastflip.BackgroundImageLayout = ImageLayout.Stretch; ;
                    }
                }
            }
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
                    else if (Amount == 6)
                    {
                        File.AppendAllText(path + HighScore1, (PlayerName_2.Text + "-" + player2score + "-" + Environment.NewLine));
                    }
                    else if (Amount == 8)
                    {
                        File.AppendAllText(path + HighScore2, (PlayerName_2.Text + "-" + player2score + "-" + Environment.NewLine));
                    }
                    MessageBox.Show(PlayerName_2.Text + " won this game with " + player2score + " to " + player1score);
                }
            }
         if (Gamemode.Text == "Singleplayer")
            {
                timer.Stop();
                if (Amount == 4)
                {
                    File.AppendAllText(path + singleplayerhighscore1, (PlayerName_1.Text + "-" + timerCount + "-" + Environment.NewLine));
                }
                else if (Amount == 6)
                {
                    File.AppendAllText(path + singleplayerhighscore2, (PlayerName_1.Text + "-" + timerCount + "-" + Environment.NewLine));
                }
                else if (Amount == 8)
                {
                    File.AppendAllText(path + singleplayerhighscore3, (PlayerName_1.Text + "-" + timerCount + "-" + Environment.NewLine));
                }
                MessageBox.Show(PlayerName_1.Text + " won this game within " + timerCount + " seconds");
            }

        }

        // Flip Card [Function]
        public async void FlipCard(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int nummer = Convert.ToInt32(clickedButton.Name);
            string thema = Thema.Text;
     
            clickedButton.BackgroundImage = CustomCards(nummer, thema);
            clickedButton.BackgroundImageLayout = ImageLayout.Stretch;

            if (firstClicked == null)// filling 1st comparer
            {
                firstClicked = clickedButton;
                firstClicked.Enabled = false;
                return;
            }

            secondClicked = clickedButton; // filling 2nd comparer   
            #region
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
            #endregion
        }

        // Cardback [Image] 
        public static Image Background(string thema) 
        {
            string[] files = Directory.GetFiles(thema, "*", SearchOption.TopDirectoryOnly);
            int image33 = (files.Length * 2) - 2;         
            Image keuze = CustomCards(image33, thema);
            return keuze;
        }

        public static Image CustomCards(int nummer, string thema)
        {
            
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            string[] files = Directory.GetFiles(thema, "*", SearchOption.TopDirectoryOnly);
            
            int nummer2 = nummer / 2;
            if (nummer % 2 != 0)
            {
                nummer2 = (nummer + 1) / 2;
            }           
            List<Image> playingcards = new List<Image> { };
            foreach (var filename in files)
            {
                Bitmap bmp = null;
                try
                {
                    bmp = new Bitmap(filename);
                }
                catch (Exception e)  { MessageBox.Show(e.Message);    continue;}

                playingcards.Add(bmp);
            }
            Image plaatje = playingcards[nummer2 - 1];
            return plaatje;
            
        }

        // Background Music [Soundplayer]
        public static SoundPlayer Musicplayer(string thema)// loopable supremely loopable maybe maybe not
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
          else  if (thema == "Nicolas Cage")
            {
                SoundPlayer player = new SoundPlayer
                {
                    Stream = Properties.Resources.Not_the_Bees_Nic_Cage_in_The_Wicker_Man
                };
                player.Load();
                return player;
            }

            else if (thema == "Memes")
            {
                SoundPlayer player = new SoundPlayer
                {
                    Stream = Properties.Resources.Koji_Kondo_Super_Mario_64_Dire__Dire_Docks__underwater_cave__www_my_free_mp3_net_
                };
                player.Load();
                return player;

            }
            else if (thema == "Rick & Morty")
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

        // Muting Music [Button]
        public void MuteMusic()
        {
            this.Controls.Add(mute);
            var Roze = System.Drawing.Color.FromArgb(199, 21, 133);
            var Wit = System.Drawing.Color.FromArgb(255, 255, 255);
            mute.Location = new Point(840, 560);
            mute.Size = new Size(80, 80);
            mute.Click += new EventHandler(this.MuteButton_Click);
            mute.ForeColor = Wit;
            mute.BackColor = Roze;
            mute.Image = Properties.Resources.mute;

        }

        //Muting Music [Button]
        public void MuteButton_Click(object sender, EventArgs e)
        {
            if (muted == false)
            {
                mplayer.Stop();
                muted = true;
                mute.Image = Properties.Resources.mute;
            }
            else
            {
                mplayer.PlayLooping();
                muted = false;
                mute.Image = Properties.Resources.speaker;
            }
        }

        // Background [Image]
        public void CreateBackground(string thema)
        {
            string[] files = Directory.GetFiles(thema, "*", SearchOption.TopDirectoryOnly);
            int suckymybutty = files.Length * 2;
            string background = Thema.Text;
            Image Gamebackground  ;
            Gamebackground = CustomCards(suckymybutty, thema);           
            this.BackgroundImage = Gamebackground;
        }
         
        // ???
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
