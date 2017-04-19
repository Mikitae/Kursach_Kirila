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
using Font_Generator.Class;



namespace Font_Generator.Forms
{
    public partial class FontSave_form : Form
    {
        private MyDic new_dic;
        
        public FontSave_form()
        {
            InitializeComponent();
            this.new_dic = new MyDic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("self_fonts.txt");
            bool err_name = false;

            foreach (string line in lines)
            {
                if (line.ToLower() == this.tb_name.Text.ToLower())
                {
                    MessageBox.Show("Шрифт уже существует\r\nВведите другое название.");
                    err_name = true;
                    break;
                } 
            }

            if (!err_name)
            {
                string path = @"Fonts/" + this.tb_name.Text;
                Directory.CreateDirectory(path);

                this.new_dic.Save_dic(path);
                StreamWriter new_dic = new StreamWriter("self_fonts.txt", true);
                
                new_dic.WriteLine(this.tb_name.Text);
                //new_dic.Flush();
                new_dic.Close();
                //File new_dic = new File();
                this.Close();
                
            }

        
        }


        internal void get_Dic(MyDic dic)
        {
            this.new_dic = dic;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
