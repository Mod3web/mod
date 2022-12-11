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
using System.Data.SqlClient;

namespace Manag_ph
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        string Aoumn_befor;

        int num;

        string str_name_ar;
        string str_name_en;
        string str_name_tg;
        string str_not;
        int ch_drog;
        int ch_const;
        int ch_frig;
        int ch_w_d;


        int num_compny;
        int num_nature;
        int num_collection;
        int num_of_supply;
        int num_places_items;


        int num_sciehtific_collection;
        int num_effective_material;
        int num_reason;


        int num_sell_pric;
        int num_Max_DIsc;
        int num_disc_parc;
        int num_tax_pric;
        double num_product_price;


        int num_unit_coptl;



        int unit_avrg;
        int number_unit_avrg;
        int number_pric_unit_avrg;



        int unit_smoll;
        int number_unit_smoll;
        int number_pric_unit_smoll;


        string path = null;
        //تنسيقات الجدول
        void Style_DataGridView()
        {
            dgvm.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            //dgvm.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvm.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvm.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvm.Font = new Font("Arial", 12);
            dgvm.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvm.EnableHeadersVisualStyles = false;
            dgvm.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvm.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvm.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);

        }

        void foucs_key(KeyEventArgs e, Control control_name)
        {
            if (e.KeyCode == Keys.Enter)
            {
                control_name.Focus();

            }
        }
        classs_table.Items_Tools m2 = new classs_table.Items_Tools();
        classs_table.Items_Tools m3 = new classs_table.Items_Tools();
        classs_table.Items_Tools m4 = new classs_table.Items_Tools();
        DB_Add_delete_update_.Database m1 = new DB_Add_delete_update_.Database();
        void ClearData()
        {

            int numItem = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Item"].Compute("max(Item_no)", "")) + 1;
            txt_item_num.Text = numItem.ToString();
            txt_item_name_en.Clear();
            txt_item_nots.Clear();
            txt_Name_ar.Clear();
            txt_item_tr.Clear();

            sell_pric.Text = "0";
            Max_DIsc.Text = "0";
            disc_parc.Text = "0";
            tax_pric.Text = "0";
            product_price.Text = "0";
            num_unit_avrg.Text = "0";
            pric_unit_avrg.Text = "0";
            num_unit_smol.Text = "0";
            pric_unit_smol.Text = "0";
            Aoumn_befor = "";

            pic_itms.Image = Image.FromFile("unKnown.png");
            path = "unKnown.png";
            txt_Name_ar.Focus();
            txt_Name_ar.SelectAll();


        }
        public void Fill_All_Data()
        {

            int numItem = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["Item"].Compute("max(Item_no)", "")) + 1;
            txt_item_num.Text = numItem.ToString();
            m2.Fill_Combox(com_copny, "manufctur_company");
            m2.Fill_Combox(com_nature, "nature_of_Item");
            m2.Fill_Combox(com_collection, "collection_of_Item");
            m2.Fill_Combox(com_of_supply, "type_of_supply");
            m2.Fill_Combox(com_places_items, "places_of_items");
            m2.Fill_Combox(com_sciehtific_collection, "sciehtific_collection");
            m2.Fill_Combox(com_effective_material, "effective_material");
            m2.Fill_Combox(com_reason, "reason_for_user");
            m4.Fill_Combox(com_unit_smol, "therpeutic_unite");
            // دالة لجب بيانات الفيو الا الجدول لعرضها والبحث بها
            DB_Add_delete_update_.Database.view_Item();


            com_unit_avrg.DataSource = DB_Add_delete_update_.Database.unit;
            com_unit_avrg.ValueMember = DB_Add_delete_update_.Database.unit.Columns[1].ColumnName;
            com_unit_avrg.ValueMember = DB_Add_delete_update_.Database.unit.Columns[0].ColumnName;

            com_unit_Comtl.DataSource = DB_Add_delete_update_.Database.unit2;
            com_unit_Comtl.ValueMember = DB_Add_delete_update_.Database.unit2.Columns[1].ColumnName;
            com_unit_Comtl.ValueMember = DB_Add_delete_update_.Database.unit2.Columns[0].ColumnName;
            //جلب البيانات من الدادتا فيو الى الجدول 
            dgvm.DataSource = DB_Add_delete_update_.Database.dv;


            dgvm.Columns[3].Visible = false;
            dgvm.Columns[4].Visible = false;
            dgvm.Columns[5].Visible = false;
            dgvm.Columns[6].Visible = false;

            path = "unKnown.png";


        }
        /// <summary>
        /// مهم
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            DB_Add_delete_update_.Database.FillAll(new string[] { "collection_of_Item", "manufctur_company", "effective_material", "nature_of_Item", "places_of_items", "reason_for_user", "sciehtific_collection", "therpeutic_unite", "type_of_supply", "Item", "pric", "unite_items" });
            Fill_All_Data();
            Style_DataGridView();//دالة تنسيق الجدول
        }

        private void BarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.therpeutic_unite frm = new forms.therpeutic_unite();
            frm.ShowDialog();
        }

        private void BarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BarButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.sciehtific_collection frm = new forms.sciehtific_collection();
            frm.ShowDialog();
        }

        private void BarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.Compny_Frm frm = new forms.Compny_Frm();
            frm.ShowDialog();
        }

        private void BarButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Add_Item.Hide();
            View_And_serch.Show();
            lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
        }

        private void BarButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void Frm_Coll_Item_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.Type_supply_ m1 = new forms.Type_supply_();
            m1.ShowDialog();
        }

        private void BarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.places_of_items m1 = new forms.places_of_items();
            m1.ShowDialog();

        }

        private void BarButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.collection_of_Item m1 = new forms.collection_of_Item();
            m1.ShowDialog();
        }

        private void BarButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.nature_of_Item m1 = new forms.nature_of_Item();
            m1.ShowDialog();
        }

        private void GroupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GroupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        //اضافة الصنف
        private void Btn_Add_Click(object sender, EventArgs e)
        {




            //البيانات الاساسية
            num = Convert.ToInt32(txt_item_num.Text);//رقم الصنف
            str_name_ar = txt_Name_ar.Text;//الاسم العربي
            str_name_en = txt_item_name_en.Text;//الاسم الانجليزي
            str_name_tg = txt_item_tr.Text;//الاسم التجاري
            string str_not = txt_item_nots.Text;//
            ch_drog = ch_item_drog.Checked ? 1 : 0;//هل هو دوا
            ch_const = ch_item_const.Checked ? 1 : 0;//قبل للارجاع
            ch_frig = ch_item_frig.Checked ? 1 : 0;//صنف  ثلاجة
            ch_w_d = ch_item_w_d.Checked ? 1 : 0;//ايقاف التعامل معا الصنف


            //بيانات الاصناف
            num_compny = Convert.ToInt32(com_copny.SelectedValue);//الشركة
            num_nature = Convert.ToInt32(com_nature.SelectedValue);//طبيعة الصنف
            num_collection = Convert.ToInt32(com_collection.SelectedValue); //المجموعة
            num_of_supply = Convert.ToInt32(com_of_supply.SelectedValue);//منشا الصنف
            num_places_items = Convert.ToInt32(com_places_items.SelectedValue);//مكان تخزين الصنف

            //البيانات الطبية
            num_sciehtific_collection = Convert.ToInt32(com_sciehtific_collection.SelectedValue);//المجموعة العليمة
            num_effective_material = Convert.ToInt32(com_effective_material.SelectedValue);//المادة الفعالة
            num_reason = Convert.ToInt32(com_reason.SelectedValue);//سبب الاستخدام

            //التسعيرة
            num_sell_pric = sell_pric.Text.Trim() != string.Empty ? Convert.ToInt32(sell_pric.Text) : 0;//سعر الشر
            num_Max_DIsc = Max_DIsc.Text.Trim() != string.Empty ? Convert.ToInt32(Max_DIsc.Text) : 0;//اعلا خصم 
            num_disc_parc = disc_parc.Text.Trim() != string.Empty ? Convert.ToInt32(disc_parc.Text) : 0;// نسبة الخصم
            num_tax_pric = tax_pric.Text.Trim() != string.Empty ? Convert.ToInt32(tax_pric.Text) : 0; //الضريبة
            num_product_price = product_price.Text.Trim() != string.Empty ? Convert.ToDouble(product_price.Text) : 0; //سعر البيع


            //الوحدات
            num_unit_coptl = Convert.ToInt32(com_unit_Comtl.SelectedValue);//الوحدة الكبر


            unit_avrg = Convert.ToInt32(com_unit_avrg.SelectedValue);// الوحدة المتوسطة
            number_unit_avrg = num_unit_avrg.Text.Trim() != string.Empty ? Convert.ToInt32(num_unit_avrg.Text) : 0;//عدد الوحدات المتوسطة
            number_pric_unit_avrg = pric_unit_avrg.Text.Trim() != string.Empty ? Convert.ToInt32(pric_unit_avrg.Text) : 0;//سعر الوحدة المتوسطة


            unit_smoll = Convert.ToInt32(com_unit_smol.SelectedValue); // الوحدة الصغرا
            number_unit_smoll = num_unit_smol.Text.Trim() != string.Empty ? Convert.ToInt32(num_unit_smol.Text) : 0;//عدد الوحدات الصغرا
            number_pric_unit_smoll = pric_unit_smol.Text.Trim() != string.Empty ? Convert.ToInt32(pric_unit_smol.Text) : 0; //سعر الوحدة الصغرا



            //MemoryStream ms = new MemoryStream();

            //pic_itms.Image.Save(ms, pic_itms.Image.RawFormat);
            //IM_T = new byte[0];
            //IM_T = ms.ToArray();

            bool b_name = false;
            bool b_pric = false;
            bool b_unit = false;

            if (txt_Name_ar.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء ادخال الاسم العربي ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Name_ar.Focus();
                return;
            }
            else
            {
                b_name = true;
            }

            if ((sell_pric.Text.Trim() == string.Empty || m2.CheackTextNumbers(sell_pric)) || Max_DIsc.Text.Trim() == string.Empty || disc_parc.Text.Trim() == string.Empty ||
                 tax_pric.Text.Trim() == string.Empty || product_price.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء ادخال بيانات التسعيرة ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                b_pric = true;
            }

            if (num_unit_avrg.Text.Trim() == string.Empty || pric_unit_avrg.Text.Trim() == string.Empty || num_unit_smol.Text.Trim() == string.Empty ||
                pric_unit_smol.Text.Trim() == string.Empty)
            {
                MessageBox.Show("يرجاء ادخال بيانات الوحدات ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                b_unit = true;
            }


            if (b_name && b_pric && b_unit)
            {

                //اضاف بيانات الاصناف
                DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Add(num, str_name_en, str_name_ar, str_name_tg, File.ReadAllBytes(path), ch_frig, ch_drog, ch_const, ch_w_d, str_not, num_compny, num_collection, num_sciehtific_collection, num_places_items, num_of_supply, num_effective_material, num_nature, num_reason);
                //جلب الرقم التلقائي
                int num_price = Convert.ToInt32(DB_Add_delete_update_.Database.ds.Tables["pric"].Compute("max(pric_num)", "")) + 1;
                //ضفة بيانات التسعيرات
                DB_Add_delete_update_.Database.ds.Tables["pric"].Rows.Add(num_price, num_sell_pric, num_Max_DIsc, num_disc_parc, num_tax_pric, num_product_price, num);

                //اضافة بيانات الوحدات
                DB_Add_delete_update_.Database.ds.Tables["unite_items"].Rows.Add(num, num_unit_coptl, unit_avrg, unit_smoll, number_unit_avrg, number_unit_smoll, number_pric_unit_avrg, number_pric_unit_smoll);
                MessageBox.Show("تم الاضافة بنجاح", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                DB_Add_delete_update_.Database.update("Item");
                DB_Add_delete_update_.Database.update("pric");
                DB_Add_delete_update_.Database.update("unite_items");

                ///test
                DB_Add_delete_update_.Database.dt_View_Item.Rows.Add(num, str_name_ar, str_name_en, ch_frig, ch_drog, ch_const, ch_w_d, com_copny.Text, com_nature.Text, com_effective_material.Text, num_sell_pric, com_places_items.Text, com_sciehtific_collection.Text); ;
                ClearData();
            }
        }

        private void BarButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.effective_material frm = new forms.effective_material();
            frm.ShowDialog();

        }

        private void BarButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            forms.reason_for_user frm = new forms.reason_for_user();
            frm.ShowDialog();
        }

        private void Com_nature_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Ch_item_drog_CheckedChanged(object sender, EventArgs e)
        {
            if (!ch_item_drog.Checked)
            {
                grop_inf_ph.Enabled = false;
            }
            else
            {
                grop_inf_ph.Enabled = true;
            }
        }

        private void Pic_itms_Click(object sender, EventArgs e)
        {
            path = pic_itms.ImageLocation;
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                pic_itms.Image = Image.FromFile(ofd.FileName);
                if (path == null || string.IsNullOrEmpty(path))
                {
                    path = pic_itms.ImageLocation;
                }
            }
        }

        private void Txt_Name_ar_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, txt_item_tr);
        }

        private void Txt_item_tr_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, txt_item_name_en);
        }

        private void Txt_item_name_en_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, txt_item_nots);
        }

        private void Sell_pric_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, Max_DIsc);
        }

        private void Sell_pric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void Max_DIsc_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, disc_parc);

        }

        private void Max_DIsc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
        //دالة لحساب نسبة الخصم
        private void Col_Discount()
        {
            if (disc_parc.Text.Trim() != string.Empty && sell_pric.Text.Trim() != string.Empty)
            {
                lbl_disc.ForeColor = Color.Black;

                double sell = Convert.ToDouble(sell_pric.Text.Trim());

                double pric_ns = Convert.ToDouble(disc_parc.Text.Trim()) / 100;
                double reslt = sell * pric_ns;

                double reslt2 = sell - reslt;
                product_price.Text = reslt2.ToString();
                Aoumn_befor = reslt2.ToString();
            }
        }
        private void Disc_parc_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, tax_pric);
            Col_Discount();
        }

        private void Disc_parc_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }
            if (char.IsDigit(e.KeyChar))
            {
                int max = Convert.ToInt32(Max_DIsc.Text.Trim());
                string str = disc_parc.Text.Trim() + e.KeyChar.ToString();
                int pric = Convert.ToInt32(str);
                if (pric > max)
                {
                    e.Handled = true;
                }
            }

        }

        private void Tax_pric_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, product_price);

        }

        private void Tax_pric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }

        }

        private void Disc_parc_KeyUp(object sender, KeyEventArgs e)
        {
            if (disc_parc.Text.Trim() != string.Empty)
            {
                Col_Discount();
            }
            m2.Check_Text_Empty(disc_parc, lbl_disc);
        }

        private void Max_DIsc_KeyUp(object sender, KeyEventArgs e)
        {
            if (Max_DIsc.Text.Trim() != string.Empty)
            {
                disc_parc.Text = "0";
                Col_Discount();
            }
            m2.Check_Text_Empty(Max_DIsc, lbl_max);
        }

        private void Sell_pric_KeyUp(object sender, KeyEventArgs e)
        {
            product_price.Text = sell_pric.Text;
            m2.Check_Text_Empty(sell_pric, lbl_sall);
            pric_unit_avrg.Text = sell_pric.Text;
            pric_unit_smol.Text = sell_pric.Text;
        }

        private void Txt_Name_ar_KeyUp(object sender, KeyEventArgs e)
        {
            m2.Check_Text_Empty(txt_Name_ar, lbl_ar);
        }
        //دالة لحساب الضريبة
        private void Auom()
        {
            if (tax_pric.Text.Trim() != string.Empty)
            {
                double tax = Convert.ToDouble(tax_pric.Text.Trim()) / 100;
                double prodect = Convert.ToDouble(Aoumn_befor);

                double reslt = prodect * tax;

                double reslt2 = prodect - reslt;
                product_price.Text = reslt2.ToString();

                lbl_tex.ForeColor = Color.Black;

            }
        }
        private void Tax_pric_KeyUp(object sender, KeyEventArgs e)
        {
            Auom();
            m2.Check_Text_Empty(tax_pric, lbl_tex);
        }

        private void Sell_pric_MouseDown(object sender, MouseEventArgs e)
        {
            ContextMenu m3 = new ContextMenu();
            if (e.Button == MouseButtons.Right)
            {
                sell_pric.ContextMenu = m3;
            }
        }

        private void Max_DIsc_MouseDown(object sender, MouseEventArgs e)
        {
            ContextMenu m3 = new ContextMenu();
            if (e.Button == MouseButtons.Right)
            {
                Max_DIsc.ContextMenu = m3;
            }
        }

        private void Disc_parc_MouseDown(object sender, MouseEventArgs e)
        {
            ContextMenu m3 = new ContextMenu();
            if (e.Button == MouseButtons.Right)
            {
                disc_parc.ContextMenu = m3;
            }
        }

        private void Tax_pric_MouseDown(object sender, MouseEventArgs e)
        {
            ContextMenu m3 = new ContextMenu();
            if (e.Button == MouseButtons.Right)
            {
                tax_pric.ContextMenu = m3;
            }
        }

        private void Product_price_MouseDown(object sender, MouseEventArgs e)
        {
            ContextMenu m3 = new ContextMenu();
            if (e.Button == MouseButtons.Right)
            {
                product_price.ContextMenu = m3;
            }
        }

        private void Product_price_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == 8))
            {
                e.Handled = true;
            }

        }

        private void Num_unit_avrg_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, pric_unit_avrg);
        }

        private void Num_unit_smol_KeyDown(object sender, KeyEventArgs e)
        {
            foucs_key(e, pric_unit_smol);
        }

        private void Num_unit_avrg_KeyUp(object sender, KeyEventArgs e)
        {
            m2.Check_Text_Empty(num_unit_avrg, lbl_avrg);

            double num = m2.Calc_un(num_unit_avrg, sell_pric);
            int num2 = Convert.ToInt32(num);
            if (num == num2)
            {
                pric_unit_avrg.Text = num.ToString();
            }
            else
            {
                pric_unit_avrg.Text = num.ToString("N");
            }


        }

        private void Num_unit_smol_KeyUp(object sender, KeyEventArgs e)
        {
            m2.Check_Text_Empty(num_unit_smol, lbl_smoll);

            double num = m2.Calc_un(num_unit_smol, sell_pric);
            int num2 = Convert.ToInt32(num);
            if (num == num2)
            {
                pric_unit_smol.Text = num.ToString();
            }
            else
            {
                pric_unit_smol.Text = num.ToString("N");
            }
        }

        private void BarButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Main_Form.SelectedPage = frm_Coll_Item;
            View_And_serch.Hide();
            Add_Item.Show();

        }


        private void BarButtonItem14_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Test().ShowDialog();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string str = txt_Serch_Item.Text;
            // الكل الكل
            string All = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%'";
            //الكل وموقف
            string All_stop = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 1;
            //الكل ومش موقف
            string All_Nostop = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 0;
            //الكل ودواء
            string All_Dow = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [صنف دواء] = " + 1;
            //الكل ومش دواء
            string All_NoDow = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [صنف دواء] = " + 0;

            //دوا وموقف
            string stop_Dow = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 1 + " And[صنف دواء] = " + 1;
            //دواء ومش موقف
            string Dow_Nostop = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 0 + " And[صنف دواء] = " + 1;
            //مش دواء وموقف
            string NoDow_stop = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 1 + " And[صنف دواء] = " + 0;
            //مش دواء ومش موقف
            string Nodow_Nostop = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + str + "%' And [ايقاف الصنف] = " + 0 + " And[صنف دواء] = " + 0;
       


            if (ch_All.Checked && ch_Sp_All.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = All;
                lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
            }
            else if (ch_All.Checked && ch_Stop.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = All_stop;
                lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
            }
            else if (ch_All.Checked && ch_NoStop.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = All_Nostop;
                lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
            }
            else if (ch_Sp_All.Checked && ch_Dow.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = All_Dow;
                lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
            }
            else if (ch_Sp_All.Checked && ch_NoDow.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = All_NoDow;
                lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
            }
            else if (ch_Dow.Checked && ch_Stop.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = stop_Dow;
                lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();

            }
            else if (ch_Dow.Checked && ch_NoStop.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = Dow_Nostop;
                lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();

            }
            else if (ch_NoDow.Checked && ch_Stop.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = NoDow_stop;
                lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();

            }
            else if (ch_NoDow.Checked && ch_NoStop.Checked)
            {
                DB_Add_delete_update_.Database.dv.RowFilter = Nodow_Nostop;
                lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();

            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //  DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Add(num, str_name_en,str_name_ar, str_name_tg, File.ReadAllBytes(path), ch_frig, ch_drog, ch_const, ch_w_d, str_not, num_compny, num_collection, num_sciehtific_collection, num_places_items, num_of_supply, num_effective_material, num_nature, num_reason);
            //   DB_Add_delete_update_.Database.FillAll(new string[] {"collection_of_Item", "manufctur_company", "effective_material", "nature_of_Item", "places_of_items", "reason_for_user", "sciehtific_collection", "therpeutic_unite", "type_of_supply", "Item", "pric",  "unite_items" });
            try
            {
                Test t = new Test();
                if (dgvm.CurrentRow != null)
                {
                    int id = Convert.ToInt32(dgvm.CurrentRow.Cells[0].Value);
                    object[] dr;
                    dr = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(id).ItemArray;


                    //لجب بيانات الشركات الخ..
                    object[] type_of_supply;
                    int[] Arr_combpx = {14, 17, 16, 11 };
                    string[] name_table = { "type_of_supply", "reason_for_user", "nature_of_Item", "collection_of_Item" };
                    Label[] lbl = { t.lbl_supply, t.lbl_reason, t.lbl_coll_Item, t.lbl_colltion };

                    for (int i = 0; i < Arr_combpx.Length; i++)
                    {
                        type_of_supply = DB_Add_delete_update_.Database.ds.Tables[name_table[i]].Rows.Find(dr[Arr_combpx[i]]).ItemArray;
                        lbl[i].Text = type_of_supply[1].ToString();
                    }
                    //لجلب بيانات التسعيرات
                    DataView dv = new DataView(DB_Add_delete_update_.Database.ds.Tables["pric"]);
                    dv.RowFilter = "Item_no =" + id;

                    t.lbl_sell_pric.Text = dv[0].Row[5].ToString();
                    t.lbl_pris_max.Text = dv[0].Row[2].ToString();
                    t.lbl_disc_parc.Text = dv[0].Row[3].ToString();
                    t.lbl_tax_price.Text = dv[0].Row[4].ToString();

                    DataView unit = new DataView(DB_Add_delete_update_.Database.ds.Tables["unite_items"]);
                    unit.RowFilter = "Item_no = " + id;
                    object[] Arry_unit = unit[0].Row.ItemArray;
                    // جلب الوحدات الكبيرة والوسط والصغيرة
                    t.lbl_unit_cabtl.Text = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows[(int)Arry_unit[1]][1].ToString();
                    t.lbl_unit_avrg.Text = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows[(int)Arry_unit[2]][1].ToString();
                    t.lbl_unit_smll.Text = DB_Add_delete_update_.Database.ds.Tables["therpeutic_unite"].Rows[(int)Arry_unit[3]][1].ToString();
                    // جلب عدد الوحدات الوسطا والصغيرة
                    t.lbl_num_avrg.Text = Arry_unit[4].ToString();
                    t.lbl_num_smoll.Text = Arry_unit[5].ToString();
                    t.lbl_pris_avrg.Text = Arry_unit[6].ToString();
                    t.lbl_pris_smoll.Text = Arry_unit[7].ToString();





                    t.lbl_name_tg.Text = dr[3].ToString();
                    t.lbl_not.Text = dr[9].ToString();
                    if (!File.Exists(id + "My,jpg"))
                    {
                        File.WriteAllBytes(id + "My.jpg", (byte[])dr[4]);
                        FileStream fs = File.Open(id + "My.jpg", FileMode.Open);


                        Bitmap bt = new Bitmap(fs);
                        fs.Close();
                        t.pictureBox1.Image = bt;
                        t.ShowDialog();

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Txt_Serch_Item_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Txt_Serch_Item_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsSymbol(e.KeyChar) || e.KeyChar == '[' || e.KeyChar == ']')
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Ch_Dow_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_Stop.Checked)
            {

                if (ch_Dow.Checked)
                {

                    DB_Add_delete_update_.Database.dv.RowFilter = "[صنف دواء]=" + 1;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else if (ch_NoDow.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[صنف دواء]=" + 0;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "";
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
            }
            else
            {

            }



        }

        private void Ch_Stop_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Ch_Dow_CheckedChanged_1(object sender, EventArgs e)
        {
            // جاهز
            if (ch_Dow.Checked)
            {
                if (ch_Stop.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1 + "  And   [ايقاف الصنف]=" + 1;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else if (ch_NoStop.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1 + "  And   [ايقاف الصنف]=" + 0;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }

            }

        }

        private void Ch_NoDow_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void Ch_All_CheckedChanged_1(object sender, EventArgs e)
        {
           
        }

        private void Ch_NoDow_CheckedChanged_1(object sender, EventArgs e)
        {
            ch_All.Checked = false;

            if (ch_Stop.Checked)
            {
                if (ch_NoDow.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[صنف دواء]=" + 0 + "And [ايقاف الصنف] = " + 1;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[صنف دواء]=" + 0 + "And [ايقاف الصنف] = " + 0;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
            }
        }

        private void Ch_NoDow_CheckedChanged_2(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Ch_Stop_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void Ch_NoStop_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Ch_NoDow_CheckedChanged_3(object sender, EventArgs e)
        {
            // جاهز
            if (ch_NoDow.Checked)
            {
                if (ch_Stop.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0 + "  And   [ايقاف الصنف]=" + 1;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else if (ch_NoStop.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0 + "  And   [ايقاف الصنف]=" + 0;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }

            }
        }

        private void Ch_All_CheckedChanged(object sender, EventArgs e)
        {
            // جاهز
            if (ch_All.Checked)
            {
                if (ch_Stop.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%' " + " And [ايقاف الصنف]=" + 1;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else if (ch_NoStop.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%' And [ايقاف الصنف]=" + 0;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'";
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }

            }
        }

        private void Ch_Stop_CheckedChanged_2(object sender, EventArgs e)
        {
            //جاهز
            if (ch_Stop.Checked)
            {
                if (ch_Dow.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1 + "  And   [ايقاف الصنف]=" + 1;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else if (ch_NoDow.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0 + "  And   [ايقاف الصنف]=" + 1;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'" + "  And   [ايقاف الصنف]=" + 1;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }

            }


        }

        private void Ch_NoStop_CheckedChanged_1(object sender, EventArgs e)
        {
            //جاهز
            if (ch_NoStop.Checked)
            {
                if (ch_Dow.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1 + "  And   [ايقاف الصنف]=" + 0;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else if (ch_NoDow.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0 + "  And   [ايقاف الصنف]=" + 0;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'" + "  And   [ايقاف الصنف]=" + 0;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
            }
        }

        private void Ch_Sp_All_CheckedChanged(object sender, EventArgs e)
        {
            //جاهز
            if (ch_Sp_All.Checked)
            {
                if (ch_Dow.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 1;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else if (ch_NoDow.Checked)
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'  And   [صنف دواء]=" + 0;
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
                else
                {
                    DB_Add_delete_update_.Database.dv.RowFilter = "[الاسم العربي] + [الاسم الانجليزي] + [الشركة المصنعة] + [طبيعة الصنف] + [مكان الصنف] + [المجموعة العلمية]+[المادة الفعالة] +[كود الصنف] like '%" + txt_Serch_Item.Text + "%'";
                    lbl_count.Text = DB_Add_delete_update_.Database.dv.Count.ToString();
                }
            }
        }

        private void Bt_new_Item_Click(object sender, EventArgs e)
        {
            bt_Add_Item.PerformClick();
        }

        private void Btn_update_Item_Click(object sender, EventArgs e)
        {


            View_And_serch.Hide();
            Add_Item.Hide();
            update_Item.Show();

            m2.Fill_Combox(com_copny_update, "manufctur_company");
            m2.Fill_Combox(com_nature_update, "nature_of_Item");
            m2.Fill_Combox(com_collection_update, "collection_of_Item");
            m2.Fill_Combox(com_of_supply_update, "type_of_supply");
            m2.Fill_Combox(com_places_items_update, "places_of_items");
            m2.Fill_Combox(com_sciehtific_collection_update, "sciehtific_collection");
            m2.Fill_Combox(com_effective_material_update, "effective_material");
            m2.Fill_Combox(com_reason_update, "reason_for_user");
            m4.Fill_Combox(com_unit_smol_update, "therpeutic_unite");
            com_unit_avrg_update.DataSource = DB_Add_delete_update_.Database.unit;
            com_unit_avrg_update.ValueMember = DB_Add_delete_update_.Database.unit.Columns[1].ColumnName;
            com_unit_avrg_update.ValueMember = DB_Add_delete_update_.Database.unit.Columns[0].ColumnName;
            com_unit_Comtl_update.DataSource = DB_Add_delete_update_.Database.unit2;
            com_unit_Comtl_update.ValueMember = DB_Add_delete_update_.Database.unit2.Columns[1].ColumnName;
            com_unit_Comtl_update.ValueMember = DB_Add_delete_update_.Database.unit2.Columns[0].ColumnName;


            if (dgvm.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvm.CurrentRow.Cells[0].Value);
                object[] dr;
                dr = DB_Add_delete_update_.Database.ds.Tables["Item"].Rows.Find(id).ItemArray;

                //txt_item_num_update.Text = dr[0].ToString();
                //txt_Name_ar_update.Text = dr[1].ToString();
                //txt_item_tr_update.Text = dr[2].ToString();
                // txt_item_name_en_update.Text = dr[3].Tostring();
                //    ch_item_drog_update.Text = dr[4].Tostring();
                //ch_item_const_update.Text = dr[5].ToString();
                //ch_item_frig_update.Text = dr[].ToString();
                //    ch_item_w_d_update
                //    txt_item_nots_updatete.Text = 
                //    pic_itms_update




            }
        }
    }
}

