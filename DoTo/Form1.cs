using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

// Yarı Türkçe yarı İngilizce kod için üzgünüm. Normalde İngilizce yazıyorum fakat okul projesi olunca ne yapacağımı pek kestiremedim

namespace DoTo
{
    public partial class Form1 : MaterialForm
    {
        #region Constructor
        public Form1()
        {
            InitializeComponent();
            TemaRengi(Primary.DeepPurple800, Primary.DeepPurple800, Primary.DeepPurple800, Accent.Indigo700, TextShade.WHITE);
            AppbarDuzenle();
        }
        #endregion

        //Helper Fonksiyonlar
        #region TemaRengi
        private void TemaRengi(Primary renk1, Primary renk2, Primary renk3, Accent accent, TextShade textShade)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(renk1, renk2, renk3, accent, textShade);
            controlPanel.BackColor = Color.BlueViolet;
            listView1.BackColor = Color.BlueViolet;
        }
        #endregion

        #region AppBar Duzenle
        private void AppbarDuzenle()
        {
            this.Text = "DoTo";
            this.MinimumSize = new Size(760, 390); 
        }
        #endregion

        #region Bazı Düzenlemeler, Load
        private void SomeArrangements()
        {
            dtp.Left = (controlPanel.Width - dtp.Width) / 2;
            NotuSilBtn.Visible = NotuGoruntuleBtn.Visible = notuDuzenleBtn.Visible = false;
            listView1.Font = new Font("LEMON MILK Light", 12);
            NotuSilBtn.Parent = btnYeniNotEkle.Parent = notuDuzenleBtn.Parent = NotuGoruntuleBtn.Parent = controlPanel;
        }
        #endregion

        #region Notları dosyadan oku ve uygulamada listele
        private void NotlariOkuListele()
        {            
            string dosyaYolu = "notlar.txt";

            // Dosyadaki notları oku ve tamnot dizisine ekle
            string dosya;
            string[] tamNot;
            using (StreamReader sr = new StreamReader(dosyaYolu))
            {                
                dosya = sr.ReadToEnd();
                tamNot = dosya.Split('$');                
            }

            // tamNot dizisinin ilk elemanı boş geliyordu, bu kısım onu düzeltmek için
            var gecicitamNot = tamNot.ToList();
            gecicitamNot.RemoveAt(0);
            tamNot = gecicitamNot.ToArray(); 

            // Notları listview'a ekle
            foreach (string not in tamNot)
            {
                string[] notBilgileri = not.Split(';');
                
                ListViewItem item = new ListViewItem();
                item.Text = notBilgileri[1] + " | " + notBilgileri[0];
                item.SubItems.Add(notBilgileri[1]);
                item.SubItems.Add(notBilgileri[2]);
                item.SubItems.Add(notBilgileri[0]);
                listView1.Items.Add(item);
            }
        }
        #endregion

        #region Notu Sil
        private void NotuSil()
        {
            string dosyaYolu = "notlar.txt";
            string dosya = "";

            // Notları oku
            using (StreamReader sr = new StreamReader(dosyaYolu))
            {
                dosya = sr.ReadToEnd();
            }

            // Seçilen item'ın tüm subitemlarını birleştirerek notun dosyadaki halini elde et
            string secilenNot = "$" + listView1.SelectedItems[0].SubItems[3].Text + ";"
                                    + listView1.SelectedItems[0].SubItems[1].Text + ";"
                                    + listView1.SelectedItems[0].SubItems[2].Text;

            // Dosyadan seçilenNot ile eşleşen notu sil
            dosya = dosya.Replace(secilenNot, "");

            // Dosyaya yeni halini yaz
            using (StreamWriter sw = new StreamWriter(dosyaYolu, false))
            {
                sw.Write(dosya);
            }

            // ListView'dan seçilen item'ı sil
            listView1.SelectedItems[0].Remove();
        }
        #endregion

        #region Form Oluştur
        //Yeni not oluştururken ve notu düzenlerken yeni form açılması gerekiyor
        private void FormOlustur(Form form, TextBox baslikTB, TextBox detayTB, Button kaydetBtn)
        {
            // Not başlığı için metin kutusu oluştur
            Label lblBaslik = new Label();
            lblBaslik.Text = "Başlık:";
            lblBaslik.Location = new Point(10, 10);
            form.Controls.Add(lblBaslik);

            baslikTB.Location = new Point(10, 30);
            form.Controls.Add(baslikTB);

            // Not detayları için metin alanı oluştur
            Label lblDetaylar = new Label();
            lblDetaylar.Text = "Detaylar:";
            lblDetaylar.Location = new Point(10, 60);
            form.Controls.Add(lblDetaylar);

            detayTB.Multiline = true;
            detayTB.Size = new Size(200, 100);
            detayTB.Location = new Point(10, 80);
            form.Controls.Add(detayTB);

            // Kaydet butonu oluştur
            kaydetBtn.Text = "Kaydet";
            kaydetBtn.Location = new Point(10, 190);
            form.Controls.Add(kaydetBtn);
        }
        #endregion

        #region Yeni Not Ekle
        private void YeniNotEkle()
        {
            // Yeni bir form aç
            Form yeniNotForm = new Form();
            yeniNotForm.Text = "Yeni Not Ekle";
            TextBox txtBaslik = new TextBox();
            TextBox txtDetaylar = new TextBox();
            Button btnKaydet = new Button();

            FormOlustur(yeniNotForm, txtBaslik, txtDetaylar, btnKaydet);            

            // Kaydet butonuyla notu listview'e ekle
            btnKaydet.Click += (sender2, e2) =>
            {
                DateTime txtTarih = dtp.Value;
                ListViewItem item = new ListViewItem();
                item.Text = txtBaslik.Text + " | " + dtp.Value.ToShortDateString();
                item.SubItems.Add(txtBaslik.Text);
                item.SubItems.Add(txtDetaylar.Text);
                item.SubItems.Add(txtTarih.ToShortDateString());
                listView1.Items.Add(item);

                // Notları dosyaya kaydet
                string dosyaYolu = "notlar.txt";
                using (StreamWriter sw = new StreamWriter(dosyaYolu, true))
                {
                    sw.WriteLine("$" + txtTarih.ToShortDateString() + ";" + txtBaslik.Text + ";" + txtDetaylar.Text);
                }

                yeniNotForm.Close(); // Formu kapat
            };

            yeniNotForm.ShowDialog(); // Formu göster
        }
        #endregion

        #region Notu Düzenle
        private void NotuDuzenle()
        {
            if (listView1.SelectedItems.Count == 1)
            {
                //Detaylar ve başlık değerlerini al
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string detaylar = selectedItem.SubItems[2].Text;
                string baslik = selectedItem.SubItems[1].Text;

                // Yeni bir form aç
                Form notuDuzenleForm = new Form();
                notuDuzenleForm.Text = "Notu Düzenle";
                TextBox txtBaslik = new TextBox();
                TextBox txtDetaylar = new TextBox();
                Button btnKaydet = new Button();

                FormOlustur(notuDuzenleForm, txtBaslik, txtDetaylar, btnKaydet);

                // Kaydet butonuyla notu listview'a ekle ve dosyaya kaydet
                btnKaydet.Click += (sender2, e2) =>
                {
                    NotuSil();//Eski notu sil
                    DateTime txtTarih = dtp.Value;
                    ListViewItem item = new ListViewItem();
                    item.Text = txtBaslik.Text + " | " + dtp.Value.ToShortDateString();
                    item.SubItems.Add(txtBaslik.Text);
                    item.SubItems.Add(txtDetaylar.Text);
                    item.SubItems.Add(txtTarih.ToShortDateString());
                    listView1.Items.Add(item);

                    // Notları dosyaya kaydet
                    string dosyaYolu = "notlar.txt";
                    using (StreamWriter sw = new StreamWriter(dosyaYolu, true))
                    {
                        sw.WriteLine("$" + txtTarih.ToShortDateString() + ";" + txtBaslik.Text + ";" + txtDetaylar.Text);
                    }

                    notuDuzenleForm.Close(); // Formu kapat
                };

                notuDuzenleForm.ShowDialog(); // Formu göster
            }
        }
        #endregion

        #region Notu Göster
        private void NotuGoster()
        {
            // Seçilen öğenin metnini al
            string selectedText = listView1.SelectedItems[0].SubItems[2].Text;

            // Mesaj kutusunda göster
            MessageBox.Show(selectedText);
        }
        #endregion

        //------------------------------------------------------------------------------------------

        #region Form Fonksiyonları
        private void Form1_Load(object sender, EventArgs e)
        {
            NotlariOkuListele();
            SomeArrangements();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            controlPanel.Width = todoPanel.Width / 3;
            dtp.Left = (controlPanel.Width - dtp.Width) / 2;
            listView1.Width = todoPanel.Width - controlPanel.Width;
        }

        private void listView1_ItemActivate_1(object sender, EventArgs e)
        {
            NotuGoster();
        }

        private void btnYeniNotEkle_Click(object sender, EventArgs e)
        {
            YeniNotEkle();
        }

        private void NotuSilBtn_Click(object sender, EventArgs e)
        {
            NotuSil();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {//Bir liste objesi seçiliyse bu tuşları görünür yap, değilse gizle
            NotuSilBtn.Visible = NotuGoruntuleBtn.Visible = notuDuzenleBtn.Visible = (listView1.SelectedItems.Count > 0);
        }

        private void notuDuzenleBtn_Click(object sender, EventArgs e)
        {
            NotuDuzenle();
        }

        private void NotuGoruntuleBtn_Click(object sender, EventArgs e)
        {
            NotuGoster();
        }
        #endregion
    }
}
