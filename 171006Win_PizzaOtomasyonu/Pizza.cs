using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _171006Win_PizzaOtomasyonu
{
    class Pizza
    {
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }
        public Ebat Ebati { get; set; }
        public KenarTip KenarTipi { get; set; }
        public List<string> Malzemeler { get; set; }
        public decimal Tutar
        {
            get
            {
                decimal tutar = 0;
                tutar = Fiyat * (decimal)Ebati.Carpan;
                tutar += KenarTipi.EkFiyat;
                return tutar;
            }
        }
        public override string ToString()
        {
            return Adi;
        }
    }
}
