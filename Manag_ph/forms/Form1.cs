using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manag_ph.forms
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        DB_Add_delete_update_.Database db = new DB_Add_delete_update_.Database();
        classs_table.Items_Tools m1 = new classs_table.Items_Tools();
        private void Compny_Frm_Load(object sender, EventArgs e)
        {
            bt_Add.Enabled = false;
            dgv_Compny.DataSource = db.view_All("All_compny");
        }

        private void Dgv_Compny_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Compny.CurrentRow != null)
            {
                txt_num.Text = dgv_Compny.CurrentRow.Cells[0].Value.ToString();
                txt_com.Text = dgv_Compny.CurrentRow.Cells[1].Value.ToString();
                bt_Add.Enabled = false;
                btn_update.Enabled = true;
                btn_delete.Enabled = true;
            }

        }
        public void ClareData()
        {
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
            bt_Add.Enabled = true;

            foreach (Control co in Controls)
            {
                if (co is TextBox)
                {

                    ((TextBox)co).Clear();
                }
            }
            txt_num.Text = db.AutoNumber("manufctur_company", "comp_num").ToString();
            txt_com.Focus();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            ClareData();
        }
        ErrorProvider er = new ErrorProvider();
        private void Bt_Add_Click(object sender, EventArgs e)
        {
            er.Clear();
            if (txt_com.Text.Trim() != string.Empty)
            {
                m1.insertItem(2, "insert_Compny", "@comp_num", "@comp_name", Convert.ToInt32(txt_num.Text), txt_com.Text, SqlDbType.Int, SqlDbType.NVarChar);
                dgv_Compny.DataSource = db.view_All("All_compny");
                btn_new.PerformClick();
            }
            else
            {
                er.SetError(txt_com, "يرجا ملا الحقل");
            }
        }

        private void Txt_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (char.IsLetterOrDigit((char)e.KeyValue))
            {
                er.Clear();


            }
        }

        private void Btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("هل تريد الحذف ", "حذف", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    m1.insertItem(1, "Delete_Compny", "@com_num", Convert.ToInt32(txt_num.Text), SqlDbType.Int);
                    ClareData();
                    dgv_Compny.DataSource = db.view_All("All_compny");
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                if (str.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    MessageBox.Show("الصف الذي تريد حذفة مربوط بجدول اخر" + "\n" + "يرجا  حذف الصف من جدول الاصناف", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_update_Click(object sender, EventArgs e)
        {
            if (txt_com.Text.Trim() != string.Empty)
            {
                m1.insertItem(2, "update_Compny", "@com_num", "@comp_name", Convert.ToInt32(txt_num.Text), txt_com.Text, SqlDbType.Int, SqlDbType.NVarChar);
                dgv_Compny.DataSource = db.view_All("All_compny");
            }
            else
            {
                er.SetError(txt_com, "يرجا ملا الحقل");
            }
        }



        private void Txt_sech_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(db.view_All("All_compny"));
            string str = txt_sech.Text;
            dv.RowFilter = "الاسم+الرقم like '%" + str + "%'";
            dgv_Compny.DataSource = dv;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

