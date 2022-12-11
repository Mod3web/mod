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
    public partial class therpeutic_unite : Form
    {
        public therpeutic_unite()
        {
            InitializeComponent();

        }
        DB_Add_delete_update_.Database db = new DB_Add_delete_update_.Database();
        classs_table.Items_Tools m1 = new classs_table.Items_Tools();
        private void Therpeutic_unite_Load(object sender, EventArgs e)
        {
            bt_Add.Enabled = false;
            dgv_Compny.DataSource = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"];
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
                    txt_com.Focus();
                    txt_com.SelectAll();

                }
            }
            int Auto = 1;
            if (DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Count > 0)
            {
                Auto = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Compute("max(unit_num)", "")) + 1;
                txt_num.Text = Auto.ToString();
            }
            else
            {
                txt_num.Text = Auto.ToString();
            }
        }


        ErrorProvider er = new ErrorProvider();
        private void Bt_Add_Click(object sender, EventArgs e)
        {
            er.Clear();
            if (txt_com.Text.Trim() != string.Empty)
            {
                //DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Add(Convert.ToInt32(txt_num.Text), txt_com.Text);


                DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.Add(Convert.ToInt32(txt_num.Text),txt_com.Text);
                DB_Add_delete_update_.Database.unit.Rows.Add(Convert.ToInt32(txt_num.Text), txt_com.Text);
                DB_Add_delete_update_.Database.unit2.Rows.Add(Convert.ToInt32(txt_num.Text), txt_com.Text);



                btn_new.PerformClick();
                dgv_Compny.DataSource = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"];
                DB_Add_delete_update_.Database.update("therpeutic_unite");
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
                    m1.insertItem(1, "delete_unit", "@unit_num", Convert.ToInt32(txt_num.Text), SqlDbType.Int);
                    ClareData();
                    int i = Convert.ToInt32(dgv_Compny.CurrentRow.Cells[0].Value);
               
                    DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows.RemoveAt(dgv_Compny.CurrentRow.Index);
                   
                    DB_Add_delete_update_.Database.unit.Rows.Remove(DB_Add_delete_update_.Database.unit.Rows.Find(i));
                    DB_Add_delete_update_.Database.unit2.Rows.Remove(DB_Add_delete_update_.Database.unit2.Rows.Find(i));
                    dgv_Compny.DataSource = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"];
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
                DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows[dgv_Compny.CurrentRow.Index][1] = txt_com.Text;
                DB_Add_delete_update_.Database.unit.Rows[dgv_Compny.CurrentRow.Index][1] = txt_com.Text;
                DB_Add_delete_update_.Database.unit2.Rows[dgv_Compny.CurrentRow.Index][1] = txt_com.Text;
                DB_Add_delete_update_.Database.update("therpeutic_unite");
            }
            else
            {
                er.SetError(txt_com, "يرجا ملا الحقل");
            }
        }



        private void Txt_sech_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"]);
            string str = txt_sech.Text;
            dv.RowFilter = "الاسم+الرقم like '%" + str + "%'";
            dgv_Compny.DataSource = dv;
        }

        private void Btn_new_Click(object sender, EventArgs e)
        {
            ClareData();
        }

   
    }
}

