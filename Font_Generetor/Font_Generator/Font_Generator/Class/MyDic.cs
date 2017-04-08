using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Font_Generator.Class
{
    class MyDic
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
    
    
    }
}
