using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using asprise_scan_scanner_twain_wia_api;
using asprise_imaging_api;

namespace Font_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ofd_1.ShowDialog();
            this.tb_1.Text = this.ofd_1.FileName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            Result result = new AspriseImaging().Scan(new Request(), new RequestOutputItem(AspriseImaging.OUTPUT_RETURN_BASE64, AspriseImaging.FORMAT_JPG) // Output type and image format
 ), "select", true, true); // "select" a scanner or use "default" scanner without selection

               Result result = new AspriseImaging().Scan(new Request(), new RequestOutputItem(AspriseImaging.OUTPUT_RETURN_BASE64, AspriseImaging.FORMAT_JPG) // Output type and image format
 ), "select", true, true); // "select" a scanner or use "default" scanner without selection

            Result result = new AspriseImaging().Scan(new Request()
   new RequestOutputItem(AspriseImaging.OUTPUT_RETURN_BASE64, AspriseImaging.FORMAT_JPG) // Output type and image format
 ), "select", true, true); // "select" a scanner or use "default" scanner without selection
             */


           // Result result = new AspriseImaging().Scan(new Request(),"default",true,true);


            Result result = new AspriseImaging().Scan(new Request().AddOutputItem(new RequestOutputItem(AspriseImaging.OUTPUT_RETURN_BASE64, AspriseImaging.FORMAT_JPG))// Output type and image format
            , "default", true, true); // "select" a scanner or use "default" scanner without selection

            this.tb_1.Text = result.ToString();


            Bitmap s = result.GetImage(0);
            //Bitmap sw = result.GetImage(1);
            //Bitmap swch = result.GetImage(0);

            //pb_1.Image = System.Drawing.Image.FromFile("1.jpg");
            //List<Image> ml = result.GetImages();
            
  
            this.pb_1.Image = s;
           

            //this.tb_1.Text = Convert.ToString( result.GetImage(0));
            

            
            
            
            

        }
    }
}
