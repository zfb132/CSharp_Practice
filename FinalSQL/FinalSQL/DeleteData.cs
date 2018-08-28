using MySql.Data.MySqlClient;
using System;
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
    public partial class DeleteData : Form
    {
        public DeleteData()
        {
            InitializeComponent();
        }
        private string[] tablesName = { "stock", "stock_company", "stock_purchase_time", "company_analysis", "company_build", "company_leader" };

        private void DeleteData_Load(object sender, EventArgs e)
        {
            this.comboBox_selectable.DataSource = tablesName;
        }

        public void showData(string table)
        {
            this.listView1.Columns.Clear();
            this.listView1.Items.Clear();
            MySqlHelper myhelper = new MySqlHelper();
            MySqlDataReader dr = myhelper.ExecuteReader("select * from " + table + ";");
            int width = (this.listView1.Width - 5) / dr.FieldCount;
            for (int i = 0; i < dr.FieldCount; i++)
            {
                this.listView1.Columns.Add(dr.GetName(i).ToString());
                this.listView1.Columns[i].Width = width;
            }
            int t = 0;
            while (dr.Read())
            {
                this.listView1.Items.Add(dr[0].ToString());
                for (int i = 1; i < dr.FieldCount; i++)
                {
                    this.listView1.Items[t].SubItems.Add(dr[i].ToString());
                }
                t++;
            }
            dr.Close();
        }

        private void contextMenuStrip_delete_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //MessageBox.Show(e.ClickedItem.Text);
            MySqlHelper myhelper = new MySqlHelper();
            //myhelper.DeleteData();
            switch (e.ClickedItem.Text)
            {
                case "删除本表此数据": break;
                case "删除所有表此数据": break;
                default:break;
            }
        }

        private void comboBox_selectable_SelectedValueChanged(object sender, EventArgs e)
        {
            showData(this.comboBox_selectable.SelectedItem.ToString());
            this.listView1.View = System.Windows.Forms.View.Details;
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            showData(this.comboBox_selectable.SelectedItem.ToString() + " order by " + this.listView1.Columns[e.Column].Text);
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && this.listView1.SelectedItems.Count > 0)
            {
                this.contextMenuStrip_delete.Show(listView1,e.Location);
            }
        }
    }
}
