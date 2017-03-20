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
            System.Drawing.Image img = s;
            System.Drawing.Image src_img = Font_Generator.Class.Scale.ScaleImage(img, 20, 20);
            this.pb_1.Image = src_img;
            //this.pb_1.Image = ;
            //this.pb_1.Image = Scan.ScaleImage(Image.FromFile("1.jpg"),20,20);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap open_image;
            OpenFileDialog open_dialog_image = new OpenFileDialog(); 
            open_dialog_image.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog_image.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    open_image = new Bitmap(open_dialog_image.FileName);
                    Image img_to_scale = open_image;
                    this.pb_1.Image = Font_Generator.Class.Scale.ScaleImage(img_to_scale, 20, 20);
                    //this.pb_1.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
