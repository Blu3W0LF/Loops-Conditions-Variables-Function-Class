using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajUygulamasi
{
    public partial class Form1 : Form
    {

        // Değişken tipleri (Global)//
        private bool kadinerkekkontrol;
        string isim;
        string soyisim;
        int yas;
        DateTime kayittarihi;
        int[] erkek = { 5, 6, 7 };
        string[] kadin = { "ayakkabı", "çanta", "elbise" };


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Kayıt etme buttonu
        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            // Girilen değerleri değişkenlere alıyoruz
            isim = textBoxAd.Text;
            soyisim = textBoxSoyad.Text;
            yas =  Convert.ToInt32(textBoxYas.Value);
            kayittarihi = dateTimePicker.Value;



            // kontrollerden almış olduğumuz değerlerde false ise kadın dizinleriniz yazdırdık
            if (!kadinerkekkontrol) 
            {
                for (int i = 0; i < kadin.Length; i++)
                {
                    MessageBox.Show(i+1+ ") ---> " + kadin[i], "kadın dize elemanları");
                }
                
            }
            else// kontrollerden almış olduğumuz değerlerde true ise erkek dizinleriniz yazdırdık
            {
                int say = 0;
                foreach (int item in erkek)
                {
                    say++;
                    MessageBox.Show(say + ") ---> " + item.ToString(), "erkek dize elemanları");
                }
                
            }

            KisiEkle();
        }

        // radio buttonlarından değişiklik yapıldıysa kadın için 'false', erkek için 'true' olarak ayarladık
        private void radioButtonKadin_CheckedChanged(object sender, EventArgs e)
        {
            kadinerkekkontrol = false;
        }

        private void radioButtonErkek_CheckedChanged(object sender, EventArgs e)
        {
            kadinerkekkontrol = true;
        }



        // Kişisel Bilgiler için sınıf oluşturduk (nesne tabanlı programlama)
        public class KisiBilgisi
        {
            public string ad { get; set; }
            public string soyad { get; set; }
            public int yas { get; set; }
            public DateTime kayittarihi { get; set; }
            public bool cinsiyeti { get; set; }

        }

        private KisiBilgisi KisiEkle() // Geriye Sınıf tipinde dönüş yapan bir fonksiyon oluşturduk.
        {
            // Değişkenlerdeki bilgileri oluşturmuş olduğumuzsınıftan boş bir eleman ürettik ve içerisine ekeldik.

            KisiBilgisi kisiBilgisi = new KisiBilgisi();
            kisiBilgisi.ad = isim;
            kisiBilgisi.soyad = soyisim;
            kisiBilgisi.yas = yas;
            kisiBilgisi.kayittarihi = kayittarihi;
            
            // Radio button değişikliğinde kadın seçiliyse sınıf elemanımıza kadını false olarak ekledik.
            if (!kadinerkekkontrol)
            {
                kisiBilgisi.cinsiyeti = false;
            }
            else // Radio button değişikliğinde kadın seçiliyse değil se sınıf elemanımıza kadını true olarak ekledik.
            {
                kisiBilgisi.cinsiyeti = true;
            }

            //Sınıf Elemanızmıza eklediğimiz Bilgileri döndürdük.
            return kisiBilgisi;


        }

        private void buttonGoster_Click(object sender, EventArgs e)
        {

            //fonksiyondan gelene Bilgileri yazdırabilmek için sınıfımızdan yeni bir eleman oluşturduk ve fonksiyona eşitledik
            KisiBilgisi kisiselBilgi = KisiEkle();

            // ve istediğimiz bilgileri yazdırdık.
            MessageBox.Show("Adı = "+ kisiselBilgi.ad+"\n" +
                            "SoyAdı = " + kisiselBilgi.soyad + "\n" +
                            "Kişi Yaşı = " + kisiselBilgi.yas + "\n" +
                            "Kayıt Tarihi = " + kisiselBilgi.kayittarihi + "\n" +
                            "Cinsiyeti = " + kisiselBilgi.cinsiyeti );
        }
    }
}
