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

namespace Meme_Ory_Game
{
    public partial class Form1 : Form
    {
        int Amount;
        ComboBox Speelveld = new ComboBox();
        ComboBox Gamemode = new ComboBox();
        ComboBox Thema = new ComboBox();
        string thema;
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
        string path = System.AppDomain.CurrentDomain.BaseDirectory;
        string savefile1 = "Save1.txt";
        string savefile2 = "Save2.txt";
        string savefile3 = "Save3.txt";
        string HighScore = "HighScore.txt";
        string HighScore1 = "HighScore1.txt";
        string HighScore2 = "HighScore2.txt";

        public Form1()
        {
            InitializeComponent();
            CreateStartButton();
            CreateRulesButton();
            CreateHighScoreButton();
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

        public void CreateHighScoreButton()
        {
            Button HighScore = new Button();
            this.Controls.Add(HighScore);
            HighScore.Location = new Point(100, 250);
            HighScore.Size = new Size(100, 50);
            HighScore.Text = "HighScores";
            HighScore.Click += new EventHandler(this.HighScore_Click);
        }

        public void CreateListview()
        {
            string tekst = File.ReadAllText(path + HighScore);
            string[] scores = tekst.Split(' ');
            ListView listView1 = new ListView();
            listView1.Bounds = new Rectangle(new Point(10, 10), new Size(200, 200));
            listView1.View = View.Details;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Sorting = SortOrder.Descending;
            listView1.Columns.Add("Score", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", -2, HorizontalAlignment.Left);

            int x = 0;
            for (int i = 0; i < (scores.Length - 2); i += 2)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ""; // 1st column
                item.SubItems.Add(""); // 2nd column             
                listView1.Items.Add(item);
                listView1.Items[x].SubItems[0].Text = scores[(i + 1)]; // 1st value from array
                listView1.Items[x].SubItems[1].Text = scores[i]; // 2nd value from array                
                if (i % 2 == 0) x++;
            }
            // Create two ImageList objects.
            ImageList imageListSmall = new ImageList();
            ImageList imageListLarge = new ImageList();
            //Assign the ImageList objects to the ListView.
            listView1.LargeImageList = imageListLarge;
            listView1.SmallImageList = imageListSmall;
            // Add the ListView to the control collection.
            this.Controls.Add(listView1);

            //~~~listview 2

            string tekst2 = File.ReadAllText(path + HighScore1);
            string[] scores2 = tekst2.Split(' ');
            ListView listView12 = new ListView();
            listView12.Bounds = new Rectangle(new Point(410, 10), new Size(200, 200));
            listView12.View = View.Details;
            listView12.AllowColumnReorder = true;
            listView12.FullRowSelect = true;
            listView12.GridLines = true;
            listView12.Sorting = SortOrder.Descending;
            listView12.Columns.Add("Score", -2, HorizontalAlignment.Left);
            listView12.Columns.Add("Name", -2, HorizontalAlignment.Left);

            int xx = 0;
            for (int i = 0; i < (scores2.Length - 2); i += 2)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ""; // 1st column
                item.SubItems.Add(""); // 2nd column             
                listView12.Items.Add(item);
                listView12.Items[xx].SubItems[0].Text = scores2[(i + 1)]; // 1st value from array
                listView12.Items[xx].SubItems[1].Text = scores2[i]; // 2nd value from array                
                if (i % 2 == 0) xx++;
            }
            // Create two ImageList objects.
            ImageList imageListSmall2 = new ImageList();
            ImageList imageListLarge2 = new ImageList();
            //Assign the ImageList objects to the ListView.
            listView12.LargeImageList = imageListLarge;
            listView12.SmallImageList = imageListSmall;
            // Add the ListView to the control collection.
            this.Controls.Add(listView12);

            //~~~~ liestview 3
            string tekst3 = File.ReadAllText(path + HighScore2);
            string[] scores3 = tekst3.Split(' ');
            ListView listView13 = new ListView();
            listView13.Bounds = new Rectangle(new Point(610, 10), new Size(200, 200));
            listView13.View = View.Details;
            listView13.AllowColumnReorder = true;
            listView13.FullRowSelect = true;
            listView13.GridLines = true;
            listView13.Sorting = SortOrder.Descending;
            listView13.Columns.Add("Score", -2, HorizontalAlignment.Left);
            listView13.Columns.Add("Name", -2, HorizontalAlignment.Left);

            int xxx = 0;
            for (int i = 0; i < (scores3.Length - 2); i += 2)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ""; // 1st column
                item.SubItems.Add(""); // 2nd column             
                listView13.Items.Add(item);
                listView13.Items[xxx].SubItems[0].Text = scores3[(i + 1)]; // 1st value from array
                listView13.Items[xxx].SubItems[1].Text = scores3[i]; // 2nd value from array                
                if (i % 2 == 0) xxx++;
            }
            // Create two ImageList objects.
            ImageList imageListSmall3 = new ImageList();
            ImageList imageListLarge3 = new ImageList();
            //Assign the ImageList objects to the ListView.
            listView13.LargeImageList = imageListLarge;
            listView13.SmallImageList = imageListSmall;
            // Add the ListView to the control collection.
            this.Controls.Add(listView13);

        }       // 

        public void CreateContinueSaveButton()
        {
            Button Continue = new Button();
            Button Save = new Button();

            Save.Location = new Point(0, 150);
            Save.Size = new Size(80, 50);
            Save.Text = "save";
            Save.Click += new EventHandler(this.SaveButton_Click);

            Continue.Location = new Point(0, 200);
            Continue.Size = new Size(80, 50);
            Continue.Text = "Continue";
            Continue.Click += new EventHandler(this.ContinueButton_Click);

            this.Controls.Add(Save);
            this.Controls.Add(Continue);
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
            Speelveld.SelectedIndex = 0;
        }

        public void CreatePlayerCombobox()
        {
            this.Controls.Add(Gamemode);
            Gamemode.Location=new Point (100,200);
            Gamemode.Location = new Point(100, 200);
            Gamemode.Size = new Size(100, 100);
            Gamemode.Items.Clear();
            Gamemode.Items.AddRange(new object[] { "Singleplayer", "Multiplayer" });
            Gamemode.SelectedIndex = 0;
        }

        public void CreateThemas()
        {
            this.Controls.Add(Thema);
            Thema.Location = new Point(250, 110);
            Thema.Size = new Size(200, 100);
            Thema.Items.Clear();
            Thema.Items.AddRange(new object[] { "speelkaarten", "meme", "cage", "spongebob" });
            Thema.SelectedIndex = 0;
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
            int[] numberCards = new int[Amountx];
            int[] randomarray = random(numberCards);
            MemoryPanel.Location = new System.Drawing.Point(200, 10);
            MemoryPanel.Size = new System.Drawing.Size(600, 600);
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
            PlayerName_1.Text = "";
            PlayerName_2.Text = "";
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

        public void ContinueButton_Click(object sender, EventArgs e)
        {
            string tekst = " ";
            if (Amount == 4) { tekst = File.ReadAllText(savefile1); }
            if (Amount == 6) { tekst = File.ReadAllText(savefile2); }
            if (Amount == 8) { tekst = File.ReadAllText(savefile3); }


            string[] scores = tekst.Split(' ');
            PlayerNameLabel_1.Text = scores[0];
            player1score = Convert.ToInt32(scores[1]);
            Player1Score.Text = scores[1];
            PlayerNameLabel_2.Text = scores[2];
            player2score = Convert.ToInt32(scores[3]);
            Player2Score.Text = scores[3];
            player1beurt = Convert.ToBoolean(scores[4]);
            PlayerTurn.Text = scores[5];
            int teller = 7;
            int trueteller = 8;

            foreach (Control x in MemoryPanel.Controls)
            {
                if (x is Button)
                {
                    x.Text = scores[teller];//essential
                    teller += 2;//essential
                    x.Enabled = Convert.ToBoolean(scores[trueteller]);// change to enable 
                    if (x.Enabled == false)
                    {
                        int nummer = Convert.ToInt32(x.Name);
                        if (Thema.Text == "spongebob")
                        {
                            nummer = Convert.ToInt32(x.Name);
                            (x as Button).Image = spongebob(nummer); 
                        }
                        if (Thema.Text == "meme")
                        {
                            nummer = Convert.ToInt32(x.Name);
                            (x as Button).Image = meme(nummer);
                        }
                        if (Thema.Text == "cage")
                        {
                            nummer = Convert.ToInt32(x.Name);
                            (x as Button).Image = cage(nummer);
                        }
                        if (Thema.Text == "speelkaarten")
                        {
                            nummer = Convert.ToInt32(x.Name);
                            (x as Button).Image = speelkaarten(nummer);
                        }
                       
                    }
                    trueteller += 2;
                }
            }
        }

        public void SaveButton_Click(object sender, EventArgs e)
        {
            // variables to be saved:
            // player names ~~ player scores ~~ turn scores ~~ player's turn name ~~ field tiles ~~ timer(singelplayer)
            //PictureBox vergelijker = new PictureBox();
            //vergelijker.Image = Properties.Resources._0;
            if (Amount == 4)
            {
                File.WriteAllText(savefile1, String.Empty);

                File.AppendAllText(path + savefile1,
                (PlayerNameLabel_1.Text + " " + player1score + " " + PlayerNameLabel_2.Text + " " + player2score + " " + player1beurt + " " + PlayerTurn.Text + " "));

                foreach (Control x in MemoryPanel.Controls)// saving of the cards
                {
                    if (x is Button)
                    {
                        File.AppendAllText(savefile1,
                        Convert.ToString(x.Text) + " ");
                        if (((x as Button).Enabled) == false)
                        {
                            File.AppendAllText(savefile1,
                             "false" + " ");
                        }
                        else
                        {
                            File.AppendAllText(savefile1,
                            "true" + " ");
                        }
                    }
                }
            }
            if (Amount == 6)
            {
                File.WriteAllText(path + savefile2, String.Empty);

                File.AppendAllText(path + savefile2,
                (PlayerNameLabel_1.Text + " " + player1score + " " + PlayerNameLabel_2.Text + " " + player2score + " " + player1beurt + " " + PlayerTurn.Text + " "));

                foreach (Control x in MemoryPanel.Controls)// saving of the cards
                {
                    if (x is Button)
                    {
                        File.AppendAllText(path + savefile2,
                        Convert.ToString(x.Text) + " ");
                        if (((x as Button).Enabled) == false)
                        {
                            File.AppendAllText(path + savefile2,
                             "false" + " ");
                        }
                        else
                        {
                            File.AppendAllText(path + savefile2,
                            "true" + " ");
                        }
                    }
                }
            }
            if (Amount == 8)
            {
                File.WriteAllText(path + savefile3, String.Empty);

                File.AppendAllText(path + savefile3,
                (PlayerNameLabel_1.Text + " " + player1score + " " + PlayerNameLabel_2.Text + " " + player2score + " " + player1beurt + " " + PlayerTurn.Text + " "));

                foreach (Control x in MemoryPanel.Controls)// saving of the cards
                {
                    if (x is Button)
                    {
                        File.AppendAllText(path + savefile3,
                        Convert.ToString(x.Text) + " ");
                        if (((x as Button).Enabled) == false)
                        {
                            File.AppendAllText(path + savefile3,
                             "false" + " ");
                        }
                        else
                        {
                            File.AppendAllText(path + savefile3,
                            "true" + " ");
                        }
                    }
                }
            }
        } ///////////// 

        public void HighScore_Click(object sender, EventArgs e)
        {
            CreateListview();
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
            if (Gamemode.Text == "Singleplayer")
            {
                PlayerName_2.Visible = false;
                Player2Score.Visible = false;
                PlayerNameLabel_2.Visible = false;
                PlayerTurn.Visible = false;
                player1score = player2score + player1score;
            }
        }

        public void Thirdstart_Click(object sender, EventArgs e)
        {
            if (Speelveld.Text == "4x4")
                Amount = 4;
            if (Speelveld.Text == "6x6")
                Amount = 6;
            if (Speelveld.Text == "8x8")
                Amount = 8;
            thema = Thema.Text;
            Speelveld.Visible = false;
            Thirdstart.Visible = false;
            PlayerName_1.Visible = false;
            PlayerName_2.Visible = false;
            goback.Visible = false;
            Thema.Visible = false;   
            CreateLayoutPanel();
            CreatePlayerNameLabel();
            CreatePlayerScore();
            CreateResetButton();
            CreateContinueSaveButton();
            MemoryPanel.Visible = true;
            PlayerTurn.Text = PlayerName_1.Text + "'s turn";
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

        public void Victory()
        {
            if (player1score > player2score)
            {
                if (Amount == 4)  
                {
                    File.AppendAllText(path + HighScore, (PlayerName_1.Text + " " + player1score + " " + Environment.NewLine));
                }
                if (Amount == 6)
                {
                    File.AppendAllText(path + HighScore1, (PlayerName_1.Text + " " + player1score + " " + Environment.NewLine));
                }
                if (Amount == 8)
                {
                    File.AppendAllText(path + HighScore2, (PlayerName_1.Text + " " + player1score + " " + Environment.NewLine));
                }
                MessageBox.Show(PlayerNameLabel_1.Text);
            }
            else
            {
                if (Amount == 4)
                {
                    File.AppendAllText(path + HighScore, (PlayerName_2.Text + " " + player2score + " " + Environment.NewLine));
                }
                if (Amount == 6)
                {
                    File.AppendAllText(path + HighScore1, (PlayerName_2.Text + " " + player2score + " " + Environment.NewLine));
                }
                if (Amount == 8)
                {
                    File.AppendAllText(path + HighScore2, (PlayerName_2.Text + " " + player2score + " " + Environment.NewLine));
                }
                MessageBox.Show(PlayerNameLabel_2.Text);
            }
        }

        public async void FlipCard(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int nummer = Convert.ToInt32(clickedButton.Name);
            if (Thema.Text == "spongebob")
            {
                clickedButton.BackgroundImage = spongebob(nummer);
            }
            if (Thema.Text == "meme")
            {
                clickedButton.BackgroundImage = meme(nummer);
            }
            if (Thema.Text == "cage")
            {
                clickedButton.BackgroundImage = cage(nummer);
            }
            if (Thema.Text == "speelkaarten")
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
                    await Task.Delay(500);
                    firstClicked.BackgroundImage = achtergrond(thema);
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
                    if (player1score + player2score == maxscore - 1) { Victory(); }
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

        public static Image achtergrond(string thema)
        {

            if (thema== "cage")
            {
                Image keuze = Properties.Resources.nicolas_0;
                return keuze;
            }
            else if (thema == "spongebob")
            {
                Image keuze = Properties.Resources.spongebob_0;
                return keuze;
            }

            else if (thema == "meme")
            {
                Image keuze = Properties.Resources.Meme_0;
                return keuze;
            }

            else //if (themakeuze == "speelkaarten")
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
                nummer2 = (nummer + 1) / 2;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
} 
