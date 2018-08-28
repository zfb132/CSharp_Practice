using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

//.sql文件建表语句与插入语句冲突，name字段的容量6不够

namespace FinalSQL
{
    public partial class FormMain : Form
    {
        public ArrayList initCommandList = new ArrayList();
        public FormMain()
        {
            InitializeComponent();
            if (MySqlHelper.isFirst())
            {
                getSQLCommand("../../final.sql");
                MySqlHelper myhelper = new MySqlHelper(initCommandList);
            }

        }

        public void getSQLCommand(String filename)
        {
            try
            {
                StreamReader sr = new StreamReader(filename, Encoding.UTF8);
                String m = sr.ReadToEnd();
                string[] a = m.Split(';');
                for (int i = 0; i < a.Length - 1; i++)
                {
                    Console.WriteLine(a[i] + ";");
                    initCommandList.Add(a[i] + ";");
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            //MySqlHelper myhelper = new MySqlHelper();
            //MySqlDataReader dr = myhelper.ExecuteReader("select * from stock where number > 3;");
            //while (dr.Read())
            //{
            //    Console.WriteLine("number:"+dr[0].ToString());
            //    Console.WriteLine("max:"+dr[1].ToString());
            //    Console.WriteLine("min:" + dr[2].ToString());
            //    Console.WriteLine("storage:" + dr[3].ToString());
            //    Console.WriteLine("profit:" + dr[4].ToString());
            //    Console.WriteLine();
            //}
            AddData a = new AddData();
            this.Visible = false;
            a.ShowDialog();
            this.Visible = true;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            DeleteData a = new DeleteData();
            this.Visible = false; 
            a.ShowDialog();
            this.Visible = true;
            //MySqlHelper myhelper = new MySqlHelper();
            //Console.WriteLine("FFFFFF:"+myhelper.ExecuteSQL("insert into  stock_company values('000005', 'peach', 'grocery')"));
        }

        private void button_modify_Click(object sender, EventArgs e)
        {
            UpdateData a = new UpdateData();
            this.Visible = false;
            a.ShowDialog();
            this.Visible = true;
        }

        private void button_query_Click(object sender, EventArgs e)
        {
            QueryData a = new QueryData();
            this.Visible = false;
            a.ShowDialog();
            this.Visible = true;
        }
    }
}
