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
    public partial class UpdateData : Form
    {
        public UpdateData()
        {
            InitializeComponent();
        }
        private string[] tablesName = { "stock", "stock_company", "stock_purchase_time", "company_analysis", "company_build", "company_leader" };
        public string old = "";
        public bool flag = true;
        private void UpdateData_Load(object sender, EventArgs e)
        {
            this.comboBox_selectable.DataSource = tablesName;
        }

        private void comboBox_selectable_SelectedValueChanged(object sender, EventArgs e)
        {
            setData(this.comboBox_selectable.SelectedItem.ToString());
        }

        public void setData(string table)
        {
            MySqlHelper myhelper = new MySqlHelper();
            MySqlDataAdapter adapter = myhelper.ExecuteAdapter("select * from "+table+";");
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

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (flag)
            {
                flag = false;
                string newstr = this.dataGridView1.CurrentCell.Value.ToString();
                //+this.dataGridView1.CurrentCell.OwningColumn.Name,  + "!" + e.RowIndex
                DialogResult dr = MessageBox.Show(@"是否要保存修改", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.OK)
                {
                    MySqlHelper my = new MySqlHelper();
                    string table = this.comboBox_selectable.SelectedItem.ToString();
                    int column = e.ColumnIndex;
                    string columnName = this.dataGridView1.CurrentCell.OwningColumn.Name;
                    if(!my.UpdateData(table, column, columnName, newstr, old))
                    {
                        //修改数据到数据库时发生错误
                        this.dataGridView1.CurrentCell.Value = old;
                    }
                }
                else
                {
                    this.dataGridView1.CurrentCell.Value = old;
                }
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            old = this.dataGridView1.CurrentCell.Value.ToString();
            flag = true;
        }
    }
}
