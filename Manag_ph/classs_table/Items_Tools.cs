using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;


namespace Manag_ph.classs_table
{
    class Items_Tools
    {




        public void insertItem(params object[] sum)
        {
            int num = Convert.ToInt32(sum[0]);
            SqlParameter[] param = new SqlParameter[num];
            DB_Add_delete_update_.Database m1 = new DB_Add_delete_update_.Database();
            int co = 0;
            for (int i = 2; i < num + 2; i++)
            {
                param[co] = new SqlParameter(sum[i].ToString(), (SqlDbType)sum[i + (num + num)]);
                param[co].Value = sum[i + num];

                co++;
            }
            m1.Execute(sum[1].ToString(), param);
        }

        //دالة لتوين اليبل الخاص بتكست الفاضي
        public void Check_Text_Empty(TextBox txt,LabelControl lbl)
        {
            if (txt.Text.Trim() != string.Empty)
            {


                lbl.ForeColor = Color.Black;

            }
            else
            {
                lbl.ForeColor = Color.Red;
            }
        }
    //دالة لتحقق من التكست بكس اذا كانت تحتوي علا رفم 
        public  bool CheackTextNumbers(TextBox txt)
        {
            bool b;
            string str = txt.Text.Trim();
            if (str.Contains("1") || str.Contains("2") || str.Contains("3") || str.Contains("4") || str.Contains("5") || str.Contains("6") || str.Contains("7") || str.Contains("8") || str.Contains("9"))
            {
                b = false;
            }
            else
            {
                b = true;
            }

            return b;
        }
    
    
        public double Calc_un(TextBox txt_Reslt,TextBox txt_num_Main)
        {
            double reslt = 0;
            if (txt_Reslt.Text.Trim()!=string.Empty && (!CheackTextNumbers(txt_Reslt)))
            {
                if (txt_num_Main.Text.Trim() != string.Empty && (!CheackTextNumbers(txt_num_Main)))
                {
                    double num1 = Convert.ToDouble(txt_Reslt.Text);
                    double num2 = Convert.ToDouble(txt_num_Main.Text);

                    reslt = num2 / num1;

                }
            }
            return reslt;
        }
    
       public string AutoNumberItem()
        {
            string str = "";
            int Auto = 1;
            if (DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Count > 0)
            {
                Auto = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Item"].Compute("max(Item_no)", "")) + 1;
                str = Auto.ToString();
            }
            else
            {
              str = Auto.ToString();
            }
            return str;
        }



            public void Fill_Combox(System.Windows.Forms.ComboBox combox, string nameTable)
        {
            combox.DataSource = DB_Add_delete_update_.Database.ds.Tables[nameTable];
            combox.DisplayMember = DB_Add_delete_update_.Database.ds.Tables[nameTable].Columns[1].ColumnName;
            combox.ValueMember = DB_Add_delete_update_.Database.ds.Tables[nameTable].Columns[0].ColumnName;


        }

  
    



    }
}
