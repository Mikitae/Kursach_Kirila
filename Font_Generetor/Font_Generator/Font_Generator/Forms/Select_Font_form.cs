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
using Font_Generator;

namespace Font_Generator.Forms
{
    public partial class Select_Font_form : Form
    {
        public Select_Font_form()
        {
            InitializeComponent();

            string[] lines = File.ReadAllLines("self_fonts.txt");

            foreach (string line in lines)
            {
                this.cb_dics.Items.Add(line);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 set_fonts_name = new Form1();
            set_fonts_name.Open_Dic(this.cb_dics.Text);
            set_fonts_name.Show();
            this.Close();
        }


        
    }
}
