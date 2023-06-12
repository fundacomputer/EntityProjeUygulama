using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUygulama
{
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.TBLURUN.ToList();
            Listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.URUNAD = TxtUrunAd.Text;
            t.MARKA = TxtMarka.Text;
            t.STOK = short.Parse(TxtStok.Text);
            t.FIYAT = decimal.Parse(TxtFiyat.Text);
            t.KATEGORI = int.Parse(comboBox1.Text);
            t.DURUM = true;
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Sisteme Kaydedildi");
            Listele();
        }
         
        void Listele()
        {
            dataGridView1.DataSource = (from x in db.TBLURUN
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.STOK,
                                            x.FIYAT,
                                            x.TBLKATEGORI.AD,
                                            x.DURUM
                                        }).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtId.Text);//merkez nokta ıd;
            var urun = db.TBLURUN.Find(x);//veritabanında değeri bulma
            db.TBLURUN.Remove(urun);// veritabanında bulunan değeri ıd kaldırma remove metodu();
            db.SaveChanges();//yapılan değişiklikleri kaydetme;
            MessageBox.Show("Ürün Silindi");
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtId.Text);
            var urun = db.TBLURUN.Find(x);
            urun.URUNAD = TxtUrunAd.Text;
            urun.MARKA = TxtMarka.Text;
            urun.STOK = short.Parse(TxtStok.Text);
            db.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı");
            Listele();
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TBLKATEGORI
                               select new
                               {
                                   x.ID,
                                   x.AD

                               }).ToList();

            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "AD";
            comboBox1.DataSource = kategoriler;
        }
    }
}
