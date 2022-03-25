using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Ogrenci
    {
        //Properties:
        public int id { get; set; }
        public string adi { get; set; }

        //Actions:
        public bool ekle()
        {
            Execute _execute = new Execute();
            SQL.Ogrenci _sqlOgrenci = new SQL.Ogrenci();
            string _sql = _sqlOgrenci.ekle();
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@adi", adi));
            string _hataMesaji = "";

            return _execute.execute(_sql, _params.ToArray(), false, ref _hataMesaji);
        }

        public DataTable listele()
        {
            Execute _execute = new Execute();
            SQL.Ogrenci _sqlOgrenci = new SQL.Ogrenci();
            string _sql = _sqlOgrenci.listele();
            string _hataMesaji = "";

            return _execute.executeDT(_sql, null, false, ref _hataMesaji);
        }

        public DataTable find(int _id)
        {
            Execute _execute = new Execute();
            SQL.Ogrenci _sqlOgrenci = new SQL.Ogrenci();
            string _sql = _sqlOgrenci.find();
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@id", _id));
            string _hataMesaji = "";

            return _execute.executeDT(_sql, _params.ToArray(), false, ref _hataMesaji);
        }

        public bool guncelle()
        {
            Execute _execute = new Execute();
            SQL.Ogrenci _sqlOgrenci = new SQL.Ogrenci();
            string _sql = _sqlOgrenci.guncelle();
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@id", id));
            _params.Add(new SqlParameter("@adi", adi));
            string _hataMesaji = "";

            return _execute.execute(_sql, _params.ToArray(), false, ref _hataMesaji);
        }

        public bool sil(int _id)
        {
            Execute _execute = new Execute();
            SQL.Ogrenci _sqlOgrenci = new SQL.Ogrenci();
            string _sql = _sqlOgrenci.sil();
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@id", _id));
            string _hataMesaji = "";

            return _execute.execute(_sql, _params.ToArray(), false, ref _hataMesaji);
        }
    }
}