using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _171006Win_PizzaOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ebat kucuk = new Ebat { Adi = "Küçük", Carpan=1 };
            Ebat orta = new Ebat { Adi = "Orta", Carpan = 1.25 };
            Ebat buyuk = new Ebat { Adi = "Büyük", Carpan = 1.75 };
            Ebat maxi = new Ebat { Adi = "Maxi ", Carpan = 2 };
            cmbEbat.Items.Add(kucuk);
            cmbEbat.Items.Add(orta);
            cmbEbat.Items.Add(buyuk);
            cmbEbat.Items.Add(maxi);

            Pizza klasik = new Pizza { Adi = "Klasik", Fiyat = 14 };
            Pizza karisik = new Pizza { Adi = "Karışık", Fiyat = 17 };
            Pizza turkish = new Pizza { Adi = "Turkish", Fiyat = 20 };
            Pizza tuna = new Pizza { Adi = "Tuna", Fiyat = 21 };
            Pizza akdeniz = new Pizza { Adi = "Akdeniz", Fiyat = 22 };
            Pizza karadeniz = new Pizza { Adi = "Karadeniz", Fiyat = 22 };
            listPizzalar.Items.Add(klasik);
            listPizzalar.Items.Add(karisik);
            listPizzalar.Items.Add(turkish);
            listPizzalar.Items.Add(tuna);
            listPizzalar.Items.Add(akdeniz);
            listPizzalar.Items.Add(karadeniz);

            KenarTip ince = new KenarTip { Adi = "İnce Kenar", EkFiyat = 0 };
            rdbInceKenar.Tag = ince;
            KenarTip kalin = new KenarTip { Adi = "Kalın Kenar", EkFiyat = 2 };
            rdbKalinKenar.Tag = kalin;



        }
        Siparis s;
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            Pizza p = (Pizza)listPizzalar.SelectedItem;
            p.Ebati =(Ebat) cmbEbat.SelectedItem;
            p.KenarTipi = rdbInceKenar.Checked ? (KenarTip)rdbInceKenar.Tag : (KenarTip)rdbKalinKenar.Tag;
            p.Malzemeler = new List<string>();
            foreach (CheckBox ctrl in groupBox1.Controls)
            {
                if (ctrl.Checked)
                {
                    p.Malzemeler.Add(ctrl.Text);
                }
            }
            decimal tutar = nudAdet.Value * p.Tutar;
            txtTutar.Text = tutar.ToString();
            s = new Siparis();
            s.Pizza = p;
            s.Adet =(int) nudAdet.Value;
           
        }

        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            if (s != null) {
                listSepet.Items.Add(s);
                }
        }

        private void btnSiparisOnay_Click(object sender, EventArgs e)
        {
            decimal toplamTutar = 0;
            int sayac = 0;
            foreach (Siparis spr in listSepet.Items)
            {
                toplamTutar += spr.Adet * spr.Pizza.Tutar;
                sayac++;
            }
            lblToplamTutar.Text = toplamTutar.ToString();
            MessageBox.Show(string.Format("Toplam Sipariş Adediniz :{0} Toplam Sipariş Tutarınız :{1}" ,sayac, toplamTutar));
        }
    }
}
