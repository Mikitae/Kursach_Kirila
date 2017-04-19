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
using System.IO;
using Font_Generator.Forms; 


namespace Font_Generator
{

    public partial class Form1 : Form
    {
        //const int RU = 1;
        //const int ENG = 2;

        MyDic curr_ru;
        int i_row;
        int i_cell;

        //Print_t wse;
       

        public Form1()
        {
            
            InitializeComponent();
            curr_ru = new MyDic();
            //wse = new Print_t();
            this.groupBox2.Hide();
            this.groupBox1.Hide();
            this.groupBox3.Hide();
            this.i_row = 0;
            this.i_cell = 0;

            //wse.Add_dic(curr_ru, RU);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            ToolStripMenuItem menuItem = new ToolStripMenuItem("Шрифт");
            menuItem.Click += Set_saved_dic;
            this.menuStrip1.Items.Add(menuItem);
            /*
            string[] lines = File.ReadAllLines("self_fonts.txt");
            
            foreach (string line in lines)
            {
                menuItem.DropDownItems.Add(line);
            }

            
            
            */

            for (int i = 0; i < 20; i++)
            {
                this.dgv_text.Rows.Add();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void Set_saved_dic(object sender, EventArgs e)
        {
            Select_Font_form dic_load = new Select_Font_form();
            dic_load.ShowDialog();
        }

        private void сканироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Scan scan = new Scan();
                this.pb_1.Image = scan.GetImg();
                Bitmap s = scan.GetImg();
                System.Drawing.Image img = s;
                System.Drawing.Image src_img = Font_Generator.Class.Scale.ScaleImage(img, 20, 20);
                this.pb_1.Image = src_img;
            }
            catch (asprise_imaging_api.ImagingException)
            {
                DialogResult rezult = MessageBox.Show("Сканер не обнаружен.",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //this.pb_1.Image = ;
            //this.pb_1.Image = Scan.ScaleImage(Image.FromFile("1.jpg"),20,20);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.groupBox2.Hide();
            this.groupBox3.Hide();
            this.groupBox1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            //Загружаем изображение
            Bitmap open_image;
            OpenFileDialog open_dialog_image = new OpenFileDialog();
            open_dialog_image.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog_image.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    open_image = new Bitmap(open_dialog_image.FileName);
                    Image img_to_scale = open_image;

                    //Выбераем текущий ключ из кб 
                    //string curr_k = this.cb_letter.SelectedText;
                    string curr_k = this.cb_letter.Text;

                    Bitmap curr_v = new Bitmap(Font_Generator.Class.Scale.ScaleImage(img_to_scale, 20, 20));

                    this.curr_ru.Add_letter(curr_k, curr_v);
                    this.cb_letter.Items.Remove(this.cb_letter.SelectedItem);
                    

                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }





           


            
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void печататьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.groupBox1.Hide();
            this.groupBox2.Hide();
            this.groupBox3.Show();

            this.Focus();
            //this.groupBox3.Focus();
        }

        private void Print(object sender, KeyPressEventArgs e)
        {
            
            
             
            if (this.groupBox3.Visible)
            {
                
                 
	              
                   //   this.pb_1.Image =
                try
                {
                    this.pb_1.Image = this.curr_ru.get_img(Convert.ToString(e.KeyChar));

                    this.dgv_text.Rows[i_row].Cells[i_cell].Value = this.curr_ru.get_img(Convert.ToString(e.KeyChar));
                    //this.i_row = this.i_row+1 >= this.dgv_text.ColumnCount ? 0 : this.i_row+1;
                    if (this.i_cell+1 >= this.dgv_text.ColumnCount)
                    {/*
                        this.dgv_text.Rows.Add();

                        DataGridViewRow row = this.dgv_text.Rows[0];

                        int currentIndex = row.Index;
                        // Удаляем ее из коллекции
                         this.dgv_text.Rows.Remove(row);

                        // А теперь добавляем со смещением
                         this.dgv_text.Rows.Insert(currentIndex + this.dgv_text.RowCount-1, row);
                         //this.dgv_text.Refresh();
                      */
                        
                        this.i_row++;
                        this.i_cell = 0;
                    }
                    else { this.i_cell++; }
                    
                }
                catch (System.Collections.Generic.KeyNotFoundException w)
                {
                    MessageBox.Show("Символ не найден");
                }
                
	              
	            
            }
        }

        private void Silent(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgv_text_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            FontSave_form open_form = new FontSave_form();
            open_form.get_Dic(this.curr_ru);
            //open_form.Show();
            open_form.ShowDialog();

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        internal void Open_Dic(string name)
        {

            Bitmap open_image = new Bitmap("Fonts/"+name+"/r.jpeg");
            this.curr_ru.Add_letter("r", open_image);

            Bitmap open_image1 = new Bitmap("Fonts/" + name + "/w.jpeg");
            this.curr_ru.Add_letter("w", open_image1);
 

        }




    }
}
