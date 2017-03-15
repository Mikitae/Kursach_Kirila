using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font_Generator.Class;



namespace Font_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void сканироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scan scan = new Scan();
            
            this.pb_1.Image = scan.GetImg();
            Bitmap s = scan.GetImg();
            System.Drawing.Image img = (System.Drawing.Image)s;
            System.Drawing.Image src_img = Scan.ScaleImage(img,20,20);
            this.pb_1.Image = src_img;






           
            //this.pb_1.Image = ;
            //this.pb_1.Image = Scan.ScaleImage(Image.FromFile("1.jpg"),20,20);

            
           

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ofd_1.ShowDialog();
            this.tb_1.Text = this.ofd_1.FileName;

        }
    }
}
