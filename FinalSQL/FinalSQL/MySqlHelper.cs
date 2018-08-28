using System;
using System.Collections;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FinalSQL
{
    /// <summary>
    ///MYSQLHelper 的摘要说明
    /// </summary>
    public class MySqlHelper 
    {
        public MySqlDataAdapter adapter;
        /// <summary>
        /// 连接数据库需要的配置参数
        /// </summary>
        public static string conParams = "Database=final;Data Source='localhost';User Id='root';Password='123456';charset='utf8';pooling=true";
        
        /// <summary>
        /// 用于执行从.sql文件中读取到的MySQL命令
        /// </summary>
        public MySqlHelper(ArrayList cmdText)
        {
            for (int i = 0; i < cmdText.Count; i++)
            {
                if (i < 2)
                {
                    ExecuteSQL((string)cmdText[i], true);
                }
                else
                {
                    ExecuteSQL((string)cmdText[i]);
                }
            }
        }

        public MySqlHelper()
        {
            //
        }

        /// <summary>
        /// 根据数据库final是否存在判断首次运行
        /// </summary>
        /// <returns></returns>
        public static bool isFirst()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(conParams);
                connection.Open();
                connection.Close();
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("首次运行");
            }
            return true;
        }

        /// <summary>
        /// 返回执行命令所影响的行数，可选参数只在初次建数据库使用
        /// </summary>
        public  int ExecuteSQL(string cmdText,bool init=false)
        {
            string param = conParams;
            if (init)
                param= param.Replace("Database=final;", "");
            MySqlConnection connection = new MySqlConnection(param);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(cmdText, connection);
            int val = cmd.ExecuteNonQuery();
            //解除它对其它对象的引用
            cmd.Parameters.Clear();
            cmd.Dispose();
            connection.Close();
            connection.Dispose();
            return val;
        }

        /// <summary>
        /// 参数为要执行的命令，返回DataReader
        /// </summary>
        public MySqlDataReader ExecuteReader(string cmdText)
        {
            //创建一个MySqlConnection对象
            MySqlConnection connection = new MySqlConnection(conParams);
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand(cmdText,connection);
            //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，
            //因此commandBehaviour.CloseConnection 就不会执行
            try
            {
                connection.Open();
                //调用 MySqlCommand的ExecuteReader 方法
                MySqlDataReader reader = cmd.ExecuteReader();
                //清除参数
                //cmd.Parameters.Clear();
                //cmd.Dispose();
                //connection.Close();
                return reader;
            }
            catch
            {
                //关闭连接，抛出异常
                cmd.Dispose();
                connection.Close();
                throw;
            }
        }

        /// <summary>
        /// 参数为要执行的命令，返回DataAdapter
        /// </summary>
        public MySqlDataAdapter ExecuteAdapter(string cmdText)
        {
            //创建一个MySqlConnection对象
            MySqlConnection connection = new MySqlConnection(conParams);
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand(cmdText, connection);
            //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，
            //因此commandBehaviour.CloseConnection 就不会执行
            try
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                //清除参数
                //cmd.Parameters.Clear();
                //cmd.Dispose();
                //connection.Close();
                return adapter;
            }
            catch
            {
                //关闭连接，抛出异常
                cmd.Dispose();
                connection.Close();
                throw;
            }
        }

        /// <summary>
        /// 为表table插入一组数据（count要与m.Count一致才会执行）
        /// </summary>
        public bool InsertData(string table,int count,string[] m)
        {
            MySqlDataReader dr = ExecuteReader("show full columns from " + table + ";");
            ArrayList flag = new ArrayList();
            while (dr.Read())
            {
                if (dr[1].ToString().Contains("int") || dr[1].ToString().Contains("float"))
                {
                    flag.Add(true);
                }
                else
                {
                    flag.Add(false);
                }
            }
            dr.Close();
            if (m.Count() == count)
            {
                string cmd = "insert into " + table + " values(";
                string temp = "";
                for (int i = 0; i < count; i++)
                {
                    if ((bool)flag[i])
                        temp = temp + m[i] + ",";
                    else
                        temp = temp + "'" + m[i] + "',";
                }
                cmd = (cmd + temp + ");").Replace(",)", ")");
                try
                {
                    if (ExecuteSQL(cmd) > 0)
                    {
                        MessageBox.Show("成功插入数据", "成功");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("插入数据异常", "警告");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "失败");
                }
            }
            else
            {
                MessageBox.Show("数据个数错误", "警告");
            }
            return false;
        }

        /// <summary>
        /// 待实现
        /// </summary>
        public bool DeleteData(string table,string m)
        {

            return true;
        }

        /// <summary>
        /// 无法查询浮点数
        /// </summary>
        public bool UpdateData(string table,int column,string columnName,string content,string old)
        {
            MySqlDataReader dr = ExecuteReader("show full columns from " + table + ";");
            ArrayList flag = new ArrayList();
            while (dr.Read())
            {
                if (dr[1].ToString().Contains("int") || dr[1].ToString().Contains("float"))
                {
                    flag.Add(true);
                }
                else
                {
                    flag.Add(false);
                }
            }
            dr.Close();
            if (!(bool)flag[column])
            {
                content = "'" + content + "'";
                old= "'" + old + "'";
            }
            string cmd = "update " + table + " set " + columnName;
            cmd += " = "+content+" where "+columnName+" = "+old+";";
            try
            {
                if (ExecuteSQL(cmd) > 0)
                {
                    MessageBox.Show("成功修改数据", "成功");
                    return true;
                }
                else
                {
                    MessageBox.Show("修改数据异常", "警告");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            return false;
        }

        public void SelectData(string[] columns,string condition)
        {

        }
    }

}
