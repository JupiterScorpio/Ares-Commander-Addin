﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARES_Preval
{
    public partial class MarginForm : Form
    {
        public MarginForm()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Commands.MarginSave();
            Commands.MarginBlock();
            this.Close();
        }

        private void btn_front_Click(object sender, EventArgs e)
        {
            this.Hide();
            Commands.Frontmargin();
            this.Show();
        }

        private void btn_rear_Click(object sender, EventArgs e)
        {
            this.Hide();
            Commands.Rearmargin();
            this.Show();
        }

        private void btn_side1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Commands.Side1margin();
            this.Show();
        }

        private void btn_side2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Commands.Side2margin();
            this.Show();
        }

        private void btn_width_Click(object sender, EventArgs e)
        {
            this.Hide();
            width_txt.Text = Convert.ToString(Math.Round(Commands.PlotWidth(), 1));
            this.Show();
        }



        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_depth_Click(object sender, EventArgs e)
        {
            this.Hide();
            depth_txt.Text = Convert.ToString(Math.Round(Commands.PlotDepth(), 1));
            this.Show();
        }
    }
}
