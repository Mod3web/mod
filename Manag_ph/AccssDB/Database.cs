﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Manag_ph.DB_Add_delete_update_
{

    class Database
    {

      static  SqlConnection cn = new SqlConnection(@"Data source=DESKTOP-AKVJ0FC\SQLEXPRESS;Database=Manag_Pharmacy;integrated security=true");



        public static void open()
        {
            if (cn.State != ConnectionState.Open)
            {
                cn.Open();
            }
        }

        public static void close()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }

        ///////////////////////////////////////////////////////////////


      public static DataTable unit = new DataTable();
      public static DataTable unit2 = new DataTable();

        ///////////////////////////////دالة خاصة بعرض البيانات من الفيو////////////////////////
      public static DataTable dt_View_Item = new DataTable();
      public static DataView dv = new DataView(dt_View_Item);
        public static void view_Item()
        {
            SqlCommand cmd = new SqlCommand("All_View", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt_View_Item);
            cmd.ExecuteNonQuery();
            close();
        }
        /// //////////////////////////////////////////////////////////////////////////
   


        public  DataTable view_All(string storg_procug)
        {
            SqlCommand cmd = new SqlCommand(storg_procug, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dta = new DataTable();
            da.Fill(dta);
            cmd.ExecuteNonQuery();
            close();
            return dta;
        }

        public void Execute(string storg_procug, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand(storg_procug, cn);

            open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(param);
            cmd.ExecuteNonQuery();
            close();
        }



        //دالة لجلب الرقم تلقائي
        public  int  AutoNumber(string TableName,string Id_Name)
        {
            open();
            SqlDataReader rd;
            
            int Aout = 0;
            SqlCommand cmd = new SqlCommand("select * from " + TableName, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count!=0) {
                cmd.CommandText = "select max(" + Id_Name + ") from " + TableName;
              rd =  cmd.ExecuteReader();
               
                    while (rd.Read())
                    {
                        Aout = Convert.ToInt32(rd[0]);
                    
                }
                rd.Close();
            }

            
            
       
           
            close();
            return Aout =Aout+1;
        }

        //دالة تعطيلها اسم الجدول اسم ترجع الادي
        public object setName_getid(string TableName,string column_name,string text_name,string column_id)
        {
            cn.Open();
            SqlDataReader red;
            string query = "select " + column_id + " from " + TableName + " where " + column_name + " = '" + text_name + "'";
            SqlCommand cmd = new SqlCommand(query, cn);
            object re = cmd.ExecuteScalar();
            cn.Close();
            return re;
        }

        public void Fill_Combox(ComboBox combox, string StorgProsegr)
        {
            DataTable dt = view_All(StorgProsegr);


            combox.DataSource = dt;
            combox.DisplayMember = dt.Columns[1].ColumnName;
            combox.ValueMember = dt.Columns[0].ColumnName;

        }



       public static DataSet ds = new DataSet();
        private static SqlDataAdapter sda;
     
        //Methode Fill Dataset
    
    public static void FillAll(string[] TableName)
        { 
            DataTable dt;
            SqlCommand cmd;
            foreach (string table in TableName)
            {
                open();
                dt = new DataTable();
                cmd = new SqlCommand("select * from "+table, cn);
               
                sda = new SqlDataAdapter(cmd);
               sda.FillSchema(dt, SchemaType.Mapped);
                sda.Fill(dt);
                if (table == "therpeutic_unite")
                {
                    sda.FillSchema(unit, SchemaType.Mapped);
                    sda.Fill(unit);

                    sda.FillSchema(unit2, SchemaType.Mapped);
                    sda.Fill(unit2);
                }
                cmd.ExecuteNonQuery();
                ds.Tables.Add(dt);

            }
            close();
          
        }


       //Methode Update Data To Database
    public static void update(string TableName) {
            sda.SelectCommand.CommandText = "Select * from " + TableName;
            SqlCommandBuilder scmdb = new SqlCommandBuilder(sda);
            sda.Update(ds.Tables[TableName]);
        }



   







        ///////////////////////////////////////////////////////////////









    }
}
