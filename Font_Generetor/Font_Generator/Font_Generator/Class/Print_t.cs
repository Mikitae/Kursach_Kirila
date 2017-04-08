using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Font_Generator.Class
{
    class Print_t
    {
        MyDic dic;

        // Мультиязычный словарь
        //Dictionary<int, MyDic> j; 
        //const int RU = 1;
        //const int ENG = 2;

        

        public Print_t()
        {
            dic = new MyDic();
        }

        public Bitmap get_img(string key)
        {
            return this.dic.get_img(key);
        }

        /*
        public void Add_dic(MyDic dic, int lang)
        {
            this.j.Add(lang, dic);
        }*/

        public void Set_dic(MyDic dic)
        {
            this.dic = dic;
        }
    }
}
