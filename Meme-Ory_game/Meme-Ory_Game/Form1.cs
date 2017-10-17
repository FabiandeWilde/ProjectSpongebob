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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 settingsForm = new Form5();       // Opens "naaminvoer, na naaminvoer Memoryspel"
            settingsForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 settingsForm = new Form3();       // Opens "spelregels"
            settingsForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 settingsForm = new Form4();       // Opens "highscores"
            settingsForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
