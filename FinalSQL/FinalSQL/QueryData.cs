using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalSQL
{
    public partial class QueryData : Form
    {
        public QueryData()
        {
            InitializeComponent();
        }
        private string[] tablesName = { "stock", "stock_company", "stock_purchase_time", "company_analysis", "company_build", "company_leader" };
        private string[] alllist =
            {"stock.number", "stock.max", "stock.min", "stock.storage", "stock.profit",
            "stock_company.number", "stock_company.name", "stock_company.type",
            "stock_purchase_time.number","stock_purchase_time.name","stock_purchase_time.purchase_date",
            "company_analysis.number","company_analysis.name","company_analysis.analysis",
            "company_build.name","company_build.build_time","company_build.build_place",
            "company_leader.name","company_leader.leader"};
        private string[] alllists =
            {"stock.number", "stock.max", "stock.min", "stock.storage", "stock.profit",
            "stock_company.number", "stock_company.name", "stock_company.type",
            "stock_purchase_time.number","stock_purchase_time.name","stock_purchase_time.purchase_date",
            "company_analysis.number","company_analysis.name","company_analysis.analysis",
            "company_build.name","company_build.build_time","company_build.build_place",
            "company_leader.name","company_leader.leader"};
        private void QueryData_Load(object sender, EventArgs e)
        {
            this.comboBox_selectable.DataSource = tablesName;
            this.listBox1.DataSource = alllist;
            this.listBox2.DataSource = alllists;
            comboBox1.SelectedIndex = -1;
        }

        private void comboBox_selectable_SelectedValueChanged(object sender, EventArgs e)
        {
            setData(this.comboBox_selectable.SelectedItem.ToString());
        }

        public void setData(string table)
        {
            MySqlHelper myhelper = new MySqlHelper();
            MySqlDataAdapter adapter = myhelper.ExecuteAdapter("select * from " + table + ";");
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
            this.dataGridView1.RowTemplate.Height = (this.dataGridView1.Height - this.dataGridView1.ColumnHeadersHeight) / ds.Tables[0].Rows.Count;
            //只有计算后的行高大于25再设置
            if (this.dataGridView1.RowTemplate.Height > 25)
            {
                this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                this.dataGridView1.Update();
            }
            else
            {
                //正常时，自动行高
                this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = listBox1.SelectedItems.Count;
            string tmp = "";
            for (int i = 0; i < count; i++)
            {
                tmp = tmp + listBox1.SelectedItems[i].ToString()+",";
            }
            string cmd = "select " + tmp+" from stock ";
            string a=tmp;
            tmp = "";
            if (a.Contains("stock_company"))
                tmp = tmp + " inner join stock_company on stock.number=stock_company.number";
            if (a.Contains("stock_purchase_time.number"))
                tmp = tmp + " inner join stock_purchase_time on stock.number = stock_purchase_time.number";
            if (a.Contains("company_analysis"))
                tmp = tmp + " inner join company_analysis on stock.number = company_analysis.number";
            if (a.Contains("company_analysis"))
                tmp = tmp + " inner join company_analysis on stock.number = company_analysis.number";
            string condition = " where " + listBox2.SelectedItem.ToString() + comboBox1.SelectedItem.ToString() + textBox1.Text+";";
            Console.WriteLine(cmd);
            //select stock_purchase_time.purchase_date,stock_company.name,company_leader.leader from (stock,company_build) inner join stock_purchase_time on stock.number = stock_purchase_time.number inner join stock_company on stock.number=stock_company.number inner join company_leader on stock_company.name=company_leader.name  where stock.number=3;
        }
    }
}
