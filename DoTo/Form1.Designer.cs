
namespace DoTo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.todoPanel = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.controlPanel = new System.Windows.Forms.Panel();
            this.notuDuzenleBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.NotuSilBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnYeniNotEkle = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.NotuGoruntuleBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.todoPanel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // todoPanel
            // 
            this.todoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.todoPanel.BackColor = System.Drawing.Color.Red;
            this.todoPanel.Controls.Add(this.listView1);
            this.todoPanel.Controls.Add(this.controlPanel);
            this.todoPanel.Location = new System.Drawing.Point(12, 91);
            this.todoPanel.Name = "todoPanel";
            this.todoPanel.Size = new System.Drawing.Size(855, 461);
            this.todoPanel.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.listView1.Font = new System.Drawing.Font("LEMON MILK Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(544, 461);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate_1);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 600;
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.Yellow;
            this.controlPanel.Controls.Add(this.NotuGoruntuleBtn);
            this.controlPanel.Controls.Add(this.notuDuzenleBtn);
            this.controlPanel.Controls.Add(this.NotuSilBtn);
            this.controlPanel.Controls.Add(this.btnYeniNotEkle);
            this.controlPanel.Controls.Add(this.dtp);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlPanel.Location = new System.Drawing.Point(550, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(305, 461);
            this.controlPanel.TabIndex = 0;
            // 
            // notuDuzenleBtn
            // 
            this.notuDuzenleBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notuDuzenleBtn.Depth = 0;
            this.notuDuzenleBtn.Location = new System.Drawing.Point(38, 304);
            this.notuDuzenleBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.notuDuzenleBtn.Name = "notuDuzenleBtn";
            this.notuDuzenleBtn.Primary = true;
            this.notuDuzenleBtn.Size = new System.Drawing.Size(140, 23);
            this.notuDuzenleBtn.TabIndex = 3;
            this.notuDuzenleBtn.Text = "Notu Düzenle";
            this.notuDuzenleBtn.UseVisualStyleBackColor = true;
            this.notuDuzenleBtn.Click += new System.EventHandler(this.notuDuzenleBtn_Click);
            // 
            // NotuSilBtn
            // 
            this.NotuSilBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NotuSilBtn.Depth = 0;
            this.NotuSilBtn.Location = new System.Drawing.Point(38, 333);
            this.NotuSilBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.NotuSilBtn.Name = "NotuSilBtn";
            this.NotuSilBtn.Primary = true;
            this.NotuSilBtn.Size = new System.Drawing.Size(140, 23);
            this.NotuSilBtn.TabIndex = 2;
            this.NotuSilBtn.Text = "Notu Sil";
            this.NotuSilBtn.UseVisualStyleBackColor = true;
            this.NotuSilBtn.Click += new System.EventHandler(this.NotuSilBtn_Click);
            // 
            // btnYeniNotEkle
            // 
            this.btnYeniNotEkle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYeniNotEkle.Depth = 0;
            this.btnYeniNotEkle.Location = new System.Drawing.Point(38, 246);
            this.btnYeniNotEkle.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnYeniNotEkle.Name = "btnYeniNotEkle";
            this.btnYeniNotEkle.Primary = true;
            this.btnYeniNotEkle.Size = new System.Drawing.Size(140, 23);
            this.btnYeniNotEkle.TabIndex = 1;
            this.btnYeniNotEkle.Text = "Yeni Not";
            this.btnYeniNotEkle.UseVisualStyleBackColor = true;
            this.btnYeniNotEkle.Click += new System.EventHandler(this.btnYeniNotEkle_Click);
            // 
            // dtp
            // 
            this.dtp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtp.Location = new System.Drawing.Point(17, 19);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(276, 22);
            this.dtp.TabIndex = 0;
            // 
            // NotuGoruntuleBtn
            // 
            this.NotuGoruntuleBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NotuGoruntuleBtn.Depth = 0;
            this.NotuGoruntuleBtn.Location = new System.Drawing.Point(38, 275);
            this.NotuGoruntuleBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.NotuGoruntuleBtn.Name = "NotuGoruntuleBtn";
            this.NotuGoruntuleBtn.Primary = true;
            this.NotuGoruntuleBtn.Size = new System.Drawing.Size(140, 23);
            this.NotuGoruntuleBtn.TabIndex = 4;
            this.NotuGoruntuleBtn.Text = "Notu Görüntüle";
            this.NotuGoruntuleBtn.UseVisualStyleBackColor = true;
            this.NotuGoruntuleBtn.Click += new System.EventHandler(this.NotuGoruntuleBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(879, 564);
            this.Controls.Add(this.todoPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.todoPanel.ResumeLayout(false);
            this.controlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel todoPanel;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private MaterialSkin.Controls.MaterialRaisedButton btnYeniNotEkle;
        private MaterialSkin.Controls.MaterialRaisedButton NotuSilBtn;
        private MaterialSkin.Controls.MaterialRaisedButton notuDuzenleBtn;
        private MaterialSkin.Controls.MaterialRaisedButton NotuGoruntuleBtn;
    }
}

