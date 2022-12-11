namespace Manag_ph.forms
{
    partial class Compny_Frm
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
            this.dgv_Compny = new System.Windows.Forms.DataGridView();
            this.lan = new DevExpress.XtraEditors.LabelControl();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.bt_Add = new System.Windows.Forms.Button();
            this.txt_sech = new System.Windows.Forms.TextBox();
            this.txt_com = new System.Windows.Forms.TextBox();
            this.txt_num = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Compny)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Compny
            // 
            this.dgv_Compny.AllowUserToAddRows = false;
            this.dgv_Compny.AllowUserToDeleteRows = false;
            this.dgv_Compny.AllowUserToResizeColumns = false;
            this.dgv_Compny.AllowUserToResizeRows = false;
            this.dgv_Compny.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Compny.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Compny.Location = new System.Drawing.Point(12, 116);
            this.dgv_Compny.Name = "dgv_Compny";
            this.dgv_Compny.ReadOnly = true;
            this.dgv_Compny.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Compny.Size = new System.Drawing.Size(324, 150);
            this.dgv_Compny.TabIndex = 19;
            this.dgv_Compny.SelectionChanged += new System.EventHandler(this.Dgv_Compny_SelectionChanged);
            // 
            // lan
            // 
            this.lan.Appearance.Font = new System.Drawing.Font("AGA Arabesque Desktop", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lan.Appearance.Options.UseFont = true;
            this.lan.Location = new System.Drawing.Point(12, 86);
            this.lan.Name = "lan";
            this.lan.Size = new System.Drawing.Size(60, 19);
            this.lan.TabIndex = 12;
            this.lan.Text = "الشركــــة :";
            // 
            // btn_new
            // 
            this.btn_new.BackColor = System.Drawing.Color.Silver;
            this.btn_new.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_new.FlatAppearance.BorderSize = 2;
            this.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_new.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new.Image = global::Manag_ph.Properties.Resources.add;
            this.btn_new.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_new.Location = new System.Drawing.Point(163, 295);
            this.btn_new.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(173, 23);
            this.btn_new.TabIndex = 20;
            this.btn_new.Text = "جـــديد";
            this.btn_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_new.UseVisualStyleBackColor = false;
            this.btn_new.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.Silver;
            this.btn_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_delete.FlatAppearance.BorderSize = 2;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_delete.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Image = global::Manag_ph.Properties.Resources.delet2;
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_delete.Location = new System.Drawing.Point(163, 334);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(174, 23);
            this.btn_delete.TabIndex = 18;
            this.btn_delete.Text = "حـــــذف";
            this.btn_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.Btn_delete_Click);
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.Silver;
            this.btn_update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_update.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_update.FlatAppearance.BorderSize = 2;
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_update.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Image = global::Manag_ph.Properties.Resources.up;
            this.btn_update.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_update.Location = new System.Drawing.Point(8, 334);
            this.btn_update.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(151, 23);
            this.btn_update.TabIndex = 17;
            this.btn_update.Text = "تــعـــديـــل";
            this.btn_update.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.Btn_update_Click);
            // 
            // bt_Add
            // 
            this.bt_Add.BackColor = System.Drawing.Color.Silver;
            this.bt_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Add.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.bt_Add.FlatAppearance.BorderSize = 2;
            this.bt_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Add.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Add.Image = global::Manag_ph.Properties.Resources.sa;
            this.bt_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Add.Location = new System.Drawing.Point(8, 295);
            this.bt_Add.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(151, 23);
            this.bt_Add.TabIndex = 16;
            this.bt_Add.Text = "اظــــــــــــافة";
            this.bt_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bt_Add.UseVisualStyleBackColor = false;
            this.bt_Add.Click += new System.EventHandler(this.Bt_Add_Click);
            // 
            // txt_sech
            // 
            this.txt_sech.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sech.Location = new System.Drawing.Point(77, 12);
            this.txt_sech.Name = "txt_sech";
            this.txt_sech.Size = new System.Drawing.Size(257, 26);
            this.txt_sech.TabIndex = 21;
            this.txt_sech.TextChanged += new System.EventHandler(this.Txt_sech_TextChanged);
            // 
            // txt_com
            // 
            this.txt_com.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_com.Location = new System.Drawing.Point(78, 79);
            this.txt_com.Name = "txt_com";
            this.txt_com.Size = new System.Drawing.Size(256, 26);
            this.txt_com.TabIndex = 22;
            this.txt_com.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_com_KeyDown);
            // 
            // txt_num
            // 
            this.txt_num.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_num.Location = new System.Drawing.Point(78, 49);
            this.txt_num.Name = "txt_num";
            this.txt_num.ReadOnly = true;
            this.txt_num.Size = new System.Drawing.Size(257, 26);
            this.txt_num.TabIndex = 24;
            this.txt_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("AGA Arabesque Desktop", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(8, 56);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 19);
            this.labelControl1.TabIndex = 25;
            this.labelControl1.Text = "الرقم :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("AGA Arabesque Desktop", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(22, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 19);
            this.labelControl2.TabIndex = 26;
            this.labelControl2.Text = "البحث :";
            // 
            // Compny_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(348, 378);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_num);
            this.Controls.Add(this.txt_com);
            this.Controls.Add(this.txt_sech);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.dgv_Compny);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.bt_Add);
            this.Controls.Add(this.lan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Compny_Frm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الشركات";
            this.Load += new System.EventHandler(this.Compny_Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Compny)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Compny;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button bt_Add;
        private DevExpress.XtraEditors.LabelControl lan;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.TextBox txt_sech;
        private System.Windows.Forms.TextBox txt_com;
        private System.Windows.Forms.TextBox txt_num;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}