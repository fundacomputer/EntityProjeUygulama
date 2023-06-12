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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.TBLKATEGORI.Count().ToString();
            label4.Text = db.TBLURUN.Count().ToString();
            label6.Text = db.TBLMUSTERI.Count(x => x.DURUM == true).ToString();
            label8.Text = db.TBLMUSTERI.Count(x => x.DURUM == false).ToString();
            label12.Text = db.TBLURUN.Sum(x => x.STOK).ToString();
            label20.Text = db.TBLSATIS.Sum(x => x.FIYAT).ToString() + "TL";
            label14.Text = (from x in db.TBLURUN orderby x.FIYAT descending select x.URUNAD).FirstOrDefault().ToString();
            label16.Text = (from x in db.TBLURUN orderby x.FIYAT ascending select x.URUNAD).FirstOrDefault().ToString();
            label10.Text = db.TBLURUN.Count(x => x.KATEGORI == 1).ToString();
            label24.Text = db.TBLURUN.Count(x => x.URUNAD == "BUZDOLABI").ToString();
            label18.Text = (from x in db.TBLMUSTERI select x.SEHIR).Distinct().Count().ToString();
            label22.Text = db.MARKAGETİR().FirstOrDefault();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
