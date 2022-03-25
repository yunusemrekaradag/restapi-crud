using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public class Ogrenci
    {
        public string ekle()
        {
            return "insert into OGRENCI (adi) values (@adi);";
        }

        public string listele()
        {
            return "select * from OGRENCI;";
        }

        public string find()
        {
            return "select * from OGRENCI where id=@id;";
        }

        public string guncelle()
        {
            return "update OGRENCI set adi=@adi where id=@id;";
        }

        public string sil()
        {
            return "delete from OGRENCI where id=@id;";
        }
    }
}
