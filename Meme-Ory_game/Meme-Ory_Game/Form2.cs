﻿using System;
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
            int[] nummers = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            int[] randomarray = random(nummers);        // Running 'Random' method from below to fix position numbers
            
            int Row = 4;
            int Column = 4;
            tableLayoutPanel1.RowCount = Row;
            tableLayoutPanel1.ColumnCount = Column;
            for (int i = 0; i < 4; i++)         // Amount of cells, 4rows by 4columns
            {
                tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            }
            for (int i = 0; i < 16; i++)        // Amount of buttons, 4x4=16 here       
            {
                var button = new Button();
                button.Text = Convert.ToString(randomarray[i]);
                button.Name = string.Format("Button_{0}", (randomarray[i]));
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
            throw new NotImplementedException();
        }
    }
}
