using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asprise_imaging_api;
using System.Drawing;
using System.Windows.Forms;


namespace Font_Generator.Class
{
    class Scan
    {
        private Bitmap img;

        public Scan()
        {
            try
            {
                Result result = new AspriseImaging().Scan(new Request().AddOutputItem(new RequestOutputItem(AspriseImaging.OUTPUT_RETURN_BASE64, AspriseImaging.FORMAT_JPG))// Output type and image format
              , "default", true, true); // "select" a scanner or use "default" scanner without selection
                this.img = result.GetImage(0);
            }
            catch (asprise_imaging_api.ImagingException)
            {
                DialogResult rezult = MessageBox.Show("Сканер не обнаружен.",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Bitmap GetImg()
        {
            return this.img;
        }
    }
}

