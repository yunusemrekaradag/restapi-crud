using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        public class Ogrenci
        {
            //Properties:
            public int id { get; set; }
            public string adi { get; set; }
        }

        //Global Variables:
        private string _apiBaseAddress = "http://www.z36-api.com/";
        //private string _apiBaseAddress = "http://localhost:53865/";

        private DataTable callGetSyncAPI()
        {
            //api den donecek json ın cast edilecegi degisken
            DataTable dtResult = new DataTable();

            //api call islemleri icin kullanacagimiz sinif
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiBaseAddress);

            //api den donen response un atilacagi degisken
            HttpResponseMessage response = client.GetAsync("api/Ogrenci/Get").Result;

            //api cagirma / calistirma sonucu basarili ise
            if (response.IsSuccessStatusCode == true)
            {
                //api response undan donen json text inin okunması
                string strJson = response.Content.ReadAsStringAsync().Result;

                //convert json text to datatable
                dtResult = (DataTable)JsonConvert.DeserializeObject(strJson, (typeof(DataTable)));
            }

            //datagrid e datatable verilerini basma
            return dtResult;
        }

        private async Task<DataTable> callGetAsyncAPI()
        {
            //api den donecek json ın cast edilecegi degisken
            DataTable dtResult = new DataTable();

            //api call islemleri icin kullanacagimiz sinif
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiBaseAddress);

            //api den donen response un atilacagi degisken
            HttpResponseMessage response = await client.GetAsync("api/Ogrenci/GetAsync");

            //api cagirma / calistirma sonucu basarili ise
            if (response.IsSuccessStatusCode == true)
            {
                //api response undan donen json text inin okunması
                string strJson = await response.Content.ReadAsStringAsync();

                //convert json text to datatable
                dtResult = (DataTable)JsonConvert.DeserializeObject(strJson, (typeof(DataTable)));
            }

            //datagrid e datatable verilerini basma
            return dtResult;
        }

        void callGetSyncAPI(int id)
        {
            DataTable dtResult = new DataTable();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiBaseAddress);
            HttpResponseMessage response = client.GetAsync("api/Ogrenci/Get/" + id.ToString()).Result;

            if (response.IsSuccessStatusCode == true)
            {
                string strJson = response.Content.ReadAsStringAsync().Result;

                dtResult = (DataTable)JsonConvert.DeserializeObject(strJson, (typeof(DataTable)));

                lblId.Text = dtResult.Rows[0]["id"].ToString();
                txtAdi.Text = dtResult.Rows[0]["adi"].ToString();
            }
            else
            {
                lblId.Text = "";
                txtAdi.Text = "";
            }
        }

        void callPostSyncAPI()
        {
            //api den donecek json ın cast edilecegi degisken
            bool result = false;

            //api call islemleri icin kullanacagimiz sinif
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiBaseAddress);

            //Ogrenci input olusturuluyor
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.adi = txtAdi.Text;

            //httpcontent input(s) degeri olusturuluyor
            HttpContent hcOgrenci = new StringContent(JsonConvert.SerializeObject(ogrenci), Encoding.UTF8, "application/json");

            //api den donen response un atilacagi degisken
            HttpResponseMessage response = client.PostAsync("api/Ogrenci/Post", hcOgrenci).Result;

            //api cagirma / calistirma sonucu basarili ise
            if (response.IsSuccessStatusCode == true)
            {
                //api response undan donen json text inin okunması
                string strJson = response.Content.ReadAsStringAsync().Result;

                //convert json text to datatable
                result = (bool)JsonConvert.DeserializeObject(strJson, (typeof(bool)));
            }

            //datagrid e datatable verilerini basma
            dataGridView1.DataSource= callGetSyncAPI();
        }

        async void callPostAsyncAPI()
        {
            //api den donecek json ın cast edilecegi degisken
            bool result = false;

            //api call islemleri icin kullanacagimiz sinif
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiBaseAddress);

            //Ogrenci input olusturuluyor
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.adi = txtAdi.Text;

            //httpcontent input(s) degeri olusturuluyor
            HttpContent hcOgrenci = new StringContent(JsonConvert.SerializeObject(ogrenci), Encoding.UTF8, "application/json");

            //api den donen response un atilacagi degisken
            HttpResponseMessage response = await client.PostAsync("api/Ogrenci/PostAsync", hcOgrenci);

            //api cagirma / calistirma sonucu basarili ise
            if (response.IsSuccessStatusCode == true)
            {
                //api response undan donen json text inin okunması
                string strJson = await response.Content.ReadAsStringAsync();

                //convert json text to datatable
                result = (bool)JsonConvert.DeserializeObject(strJson, (typeof(bool)));
            }

            //datagrid e datatable verilerini basma
            dataGridView1.DataSource = await callGetAsyncAPI();
        }

        void callPutSyncAPI()
        {
            //api den donecek json ın cast edilecegi degisken
            bool result = false;

            //api call islemleri icin kullanacagimiz sinif
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiBaseAddress);

            //Ogrenci input olusturuluyor
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.id = int.Parse(lblId.Text);
            ogrenci.adi = txtAdi.Text;

            //httpcontent input(s) degeri olusturuluyor
            HttpContent hcOgrenci = new StringContent(JsonConvert.SerializeObject(ogrenci), Encoding.UTF8, "application/json");

            //api den donen response un atilacagi degisken
            HttpResponseMessage response = client.PutAsync("api/Ogrenci/Put", hcOgrenci).Result;

            //api cagirma / calistirma sonucu basarili ise
            if (response.IsSuccessStatusCode == true)
            {
                //api response undan donen json text inin okunması
                string strJson = response.Content.ReadAsStringAsync().Result;

                //convert json text to datatable
                result = (bool)JsonConvert.DeserializeObject(strJson, (typeof(bool)));
            }

            //datagrid e datatable verilerini basma
            dataGridView1.DataSource = callGetSyncAPI();
        }

        async void callPutAsyncAPI()
        {
            //api den donecek json ın cast edilecegi degisken
            bool result = false;

            //api call islemleri icin kullanacagimiz sinif
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiBaseAddress);

            //Ogrenci input olusturuluyor
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.id = int.Parse(lblId.Text);
            ogrenci.adi = txtAdi.Text;

            //httpcontent input(s) degeri olusturuluyor
            HttpContent hcOgrenci = new StringContent(JsonConvert.SerializeObject(ogrenci), Encoding.UTF8, "application/json");

            //api den donen response un atilacagi degisken
            HttpResponseMessage response = await client.PutAsync("api/Ogrenci/PutAsync", hcOgrenci);

            //api cagirma / calistirma sonucu basarili ise
            if (response.IsSuccessStatusCode == true)
            {
                //api response undan donen json text inin okunması
                string strJson = await response.Content.ReadAsStringAsync();

                //convert json text to bool
                result = (bool)JsonConvert.DeserializeObject(strJson, (typeof(bool)));
            }

            //datagrid e datatable verilerini basma
            dataGridView1.DataSource = await callGetAsyncAPI();
        }

        void callDeleteSyncAPI()
        {
            //api den donecek json ın cast edilecegi degisken
            bool result = false;

            //api call islemleri icin kullanacagimiz sinif
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiBaseAddress);

            //api den donen response un atilacagi degisken
            HttpResponseMessage response = client.DeleteAsync("api/Ogrenci/Delete/" + lblId.Text).Result;

            //api cagirma / calistirma sonucu basarili ise
            if (response.IsSuccessStatusCode == true)
            {
                //api response undan donen json text inin okunması
                string strJson = response.Content.ReadAsStringAsync().Result;

                //convert json text to datatable
                result = (bool)JsonConvert.DeserializeObject(strJson, (typeof(bool)));
            }

            //datagrid e datatable verilerini basma
            dataGridView1.DataSource = callGetSyncAPI();
        }

        async Task<bool> callDeleteAsyncAPI(int id)
        {
            bool result = false;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiBaseAddress);
            HttpResponseMessage response = await client.DeleteAsync("api/Ogrenci/DeleteAsync/" + id.ToString());

            if (response.IsSuccessStatusCode == true)
            {
                string strJson = await response.Content.ReadAsStringAsync();

                result = (bool)JsonConvert.DeserializeObject(strJson, (typeof(bool)));
            }

            return result;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int _idSecilen = int.Parse(dataGridView1.SelectedRows[0].Cells["id"].Value.ToString());

            callGetSyncAPI(_idSecilen);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblId.Text = "";
            txtAdi.Text = "";

            txtAdi.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Text = Convert.ToString(int.Parse(button6.Text) + 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= callGetSyncAPI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            callPostSyncAPI();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            callPutSyncAPI();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            callDeleteSyncAPI();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            callPostAsyncAPI();
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await callGetAsyncAPI();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            callPutAsyncAPI();
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            bool sonuc = await callDeleteAsyncAPI(int.Parse(lblId.Text));

            if(sonuc==true)        dataGridView1.DataSource = await callGetAsyncAPI();
        }
    }
}
