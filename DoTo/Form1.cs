#region Using
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
#endregion

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

        //Helper Fonskiyonlar
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

        #region NotlariOkuListele
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

            // Seçilen item'ın tüm subitemlarını birleştirerek notu elde et
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

        #region Yeni Not Ekle
        private void YeniNotEkle()
        {
            // Yeni bir form aç
            Form yeniNotForm = new Form();
            yeniNotForm.Text = "Yeni Not Ekle";

            // Not başlığı için metin kutusu oluştur
            Label lblBaslik = new Label();
            lblBaslik.Text = "Başlık:";
            lblBaslik.Location = new Point(10, 10);
            yeniNotForm.Controls.Add(lblBaslik);

            TextBox txtBaslik = new TextBox();
            txtBaslik.Location = new Point(10, 30);
            yeniNotForm.Controls.Add(txtBaslik);

            // Not detayları için metin alanı oluştur
            Label lblDetaylar = new Label();
            lblDetaylar.Text = "Detaylar:";
            lblDetaylar.Location = new Point(10, 60);
            yeniNotForm.Controls.Add(lblDetaylar);

            TextBox txtDetaylar = new TextBox();
            txtDetaylar.Multiline = true;
            txtDetaylar.Size = new Size(200, 100);
            txtDetaylar.Location = new Point(10, 80);
            yeniNotForm.Controls.Add(txtDetaylar);

            // Kaydet butonu oluştur
            Button btnKaydet = new Button();
            btnKaydet.Text = "Kaydet";
            btnKaydet.Location = new Point(10, 190);
            yeniNotForm.Controls.Add(btnKaydet);

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

        //------------------------------------------------------------------------------------------

        #region Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            dtp.Left = (controlPanel.Width - dtp.Width) / 2;
            NotlariOkuListele();
            NotuSilBtn.Visible = NotuGoruntuleBtn.Visible = notuDuzenleBtn.Visible = false;
            listView1.Font = new Font("LEMON MILK Light", 12);
            NotuSilBtn.Parent = btnYeniNotEkle.Parent = notuDuzenleBtn.Parent = NotuGoruntuleBtn.Parent = controlPanel;
            this.ForeColor = Color.Indigo;
        }
        #endregion

        #region Form Resize
        private void Form1_Resize(object sender, EventArgs e)
        {
            controlPanel.Width = todoPanel.Width / 3;
            dtp.Left = (controlPanel.Width - dtp.Width) / 2;
            listView1.Width = todoPanel.Width - controlPanel.Width;
        }
        #endregion

        #region Listview item activate
        private void listView1_ItemActivate_1(object sender, EventArgs e)
        {
            // Seçilen öğenin metnini al
            string selectedText = listView1.SelectedItems[0].SubItems[2].Text;

            // Mesaj kutusunda seçilen öğenin metnini göster
            MessageBox.Show(selectedText);
        }
        #endregion

        #region btnYeniNotEkle_Click
        private void btnYeniNotEkle_Click(object sender, EventArgs e)
        {
            YeniNotEkle();
        }
        #endregion

        #region NotuSilBtn_Click
        private void NotuSilBtn_Click(object sender, EventArgs e)
        {
            NotuSil();
        }        
        #endregion

        #region listView1_SelectedIndexChanged
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                NotuSilBtn.Visible = NotuGoruntuleBtn.Visible = notuDuzenleBtn.Visible = true;
            }
            else
            {
                NotuSilBtn.Visible = NotuGoruntuleBtn.Visible = notuDuzenleBtn.Visible = false;
            }
        }
        #endregion

        private void notuDuzenleBtn_Click(object sender, EventArgs e)
        {            
            if (listView1.SelectedItems.Count == 1)
            {
                
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string detaylar = selectedItem.SubItems[2].Text;
                string baslik = selectedItem.SubItems[1].Text;

                // Yeni bir form aç
                Form notuDuzenleForm = new Form();
                notuDuzenleForm.Text = "Notu Düzenle";

                // Not başlığı için metin kutusu oluştur
                Label lblBaslik = new Label();
                lblBaslik.Text = "Başlık:";
                lblBaslik.Location = new Point(10, 10);
                notuDuzenleForm.Controls.Add(lblBaslik);

                TextBox txtBaslik = new TextBox();
                txtBaslik.Text = baslik;
                txtBaslik.Location = new Point(10, 30);
                notuDuzenleForm.Controls.Add(txtBaslik);


                // Not detayları için metin alanı oluştur
                Label lblDetaylar = new Label();
                lblDetaylar.Text = "Detaylar:";
                lblDetaylar.Location = new Point(10, 60);
                notuDuzenleForm.Controls.Add(lblDetaylar);

                TextBox txtDetaylar = new TextBox();
                txtDetaylar.Multiline = true;
                txtDetaylar.Text = detaylar;
                txtDetaylar.Size = new Size(200, 100);
                txtDetaylar.Location = new Point(10, 80);
                notuDuzenleForm.Controls.Add(txtDetaylar);



                // Kaydet butonu oluştur
                Button btnKaydet = new Button();
                btnKaydet.Text = "Kaydet";
                btnKaydet.Location = new Point(10, 190);
                notuDuzenleForm.Controls.Add(btnKaydet);

                // Kaydet butonuyla notu listview'e ekle
                btnKaydet.Click += (sender2, e2) =>
                {
                    NotuSil();
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




                //if (form.ShowDialog() == DialogResult.OK)
                //{
                //    selectedItem.SubItems[2].Text = form.textBox1.Text;
                //    // Kayıt dosyasını güncelle
                //    string[] lines = File.ReadAllLines("notlar.txt");
                //    for (int i = 0; i < lines.Length; i++)
                //    {
                //        if (lines[i].StartsWith("$" + selectedItem.SubItems[0].Text))
                //        {
                //            lines[i] = "$" + selectedItem.SubItems[0].Text + ";" + selectedItem.SubItems[1].Text + ";" + selectedItem.SubItems[2].Text + ";" + selectedItem.SubItems[3].Text + ";";
                //            break;
                //        }
                //    }
                //    File.WriteAllLines("notlar.txt", lines);
                //}

                notuDuzenleForm.ShowDialog(); // Formu göster
            }
        }

        private void NotuGoruntuleBtn_Click(object sender, EventArgs e)
        {
            // Seçilen öğenin metnini al
            string selectedText = listView1.SelectedItems[0].SubItems[2].Text;

            // Mesaj kutusunda seçilen öğenin metnini göster
            MessageBox.Show(selectedText);
        }
    }
}
