using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;



namespace Font_Generator.Class
{
    public class MyDic
    {
        Dictionary<string, Bitmap> alpha;

        public MyDic()
        {
            alpha = new Dictionary<string,Bitmap>();
        }

        public void Add_letter(string key, Bitmap value){
            this.alpha.Add(key, value);
        }

        public Bitmap get_img(string key)
        {
            return this.alpha[key];
        }

        public void Save_dic(string path)
        {
            foreach (System.Collections.Generic.KeyValuePair<string,Bitmap> elem in this.alpha)
            {
                Image save = elem.Value;
                //Image save = this.new_dic.get_img("r");
                save.Save(path + "/" + elem.Key + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);    
            } 
        }

    
    
    }
}
