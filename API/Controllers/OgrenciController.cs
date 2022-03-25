using API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class OgrenciController : ApiController
    {
        [HttpPost]
        public bool Post(Ogrenci _ogrenci)
        {
            return _Post(_ogrenci);
        }

        [HttpPost]
        public async Task<bool> PostAsync(Ogrenci _ogrenci)
        {
            return await Task.Run(() => _Post(_ogrenci));
        }

        [HttpGet]
        public DataTable Get()
        {
            return _Get();
        }

        [HttpGet]
        public async Task<DataTable> GetAsync()
        {
            return await Task.Run(() => _Get());
        }

        [HttpGet]
        public DataTable Get(int id)
        {
            System.Threading.Thread.Sleep(5000);

            return (new Ogrenci()).find(id);
        }

        [HttpPut]
        public bool Put(Ogrenci _ogrenci)
        {
            return _Put(_ogrenci);
        }

        [HttpPut]
        public async Task<bool> PutAsync(Ogrenci _ogrenci)
        {
            return await Task.Run(() => _Put(_ogrenci));
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return _Delete(id);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int id)
        {
            return await Task.Run(() => _Delete(id));
        }

        private bool _Post(Ogrenci _ogrenci)
        {
            System.Threading.Thread.Sleep(5000);

            return _ogrenci.ekle();
        }

        private bool _Put(Ogrenci _ogrenci)
        {
            System.Threading.Thread.Sleep(5000);

            return _ogrenci.guncelle();
        }

        private bool _Delete(int id)
        {
            System.Threading.Thread.Sleep(5000);

            return (new Ogrenci()).sil(id);
        }

        private DataTable _Get()
        {
            System.Threading.Thread.Sleep(5000);

            return (new Ogrenci()).listele();
        }
    }
}
