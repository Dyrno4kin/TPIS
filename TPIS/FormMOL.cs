﻿using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TPIS
{
    public partial class FormMOL : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private string sPath = Path.Combine(Application.StartupPath, "mydatabaselab5.db");
        public FormMOL()
        {
            InitializeComponent();
        }

        private void ExecuteQuery(string txtQuery)
        {
            sql_con = new SQLiteConnection("Data Source=" + sPath + ";Version=3;New=False;Compress=True;");
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        public void refreshForm(string ConnectionString, String selectCommand)
        {
            selectTable(ConnectionString, selectCommand);
            dataGridView1.Update();
            dataGridView1.Refresh();
            toolStripTextBox.Text = "";
        }

        public void selectTable(string ConnectionString, String selectCommand)
        {
            SQLiteConnection connect = new SQLiteConnection(ConnectionString);
            connect.Open();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectCommand, connect);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].ToString();
            connect.Close();
        }

        private void FormMOL_Load(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            String selectCommand = "Select * from MOL";
            selectTable(ConnectionString, selectCommand);
        }  


        public void changeValue(string ConnectionString, String selectCommand)
        {
            SQLiteConnection connect = new SQLiteConnection(ConnectionString);
            connect.Open();
            SQLiteTransaction trans;
            SQLiteCommand cmd = new SQLiteCommand();
            trans = connect.BeginTransaction();
            cmd.Connection = connect;
            cmd.CommandText = selectCommand;
            cmd.ExecuteNonQuery();
            trans.Commit();
            connect.Close();
        }

        public object selectValue(string ConnectionString, String selectCommand)
        {
            SQLiteConnection connect = new SQLiteConnection(ConnectionString);
            connect.Open();
            SQLiteCommand command = new SQLiteCommand(selectCommand, connect);
            SQLiteDataReader reader = command.ExecuteReader();
            object value = "";
            while (reader.Read())
            {
                value = reader[0];
            }
            connect.Close(); return value;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            //получить значение Name выбранной строки
            string valueId = dataGridView1[0, CurrentRow].Value.ToString();
            string changeName = toolStripTextBox.Text;
            string pattern = @"^[a-zA-Z\D]{5,80}$";
            if (Regex.IsMatch(changeName, pattern, RegexOptions.IgnoreCase))
            {
                String selectCommand = "update MOL set FIO='" + changeName + "' where idMOL=" + valueId;
                string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
                changeValue(ConnectionString, selectCommand);
                //обновление dataGridView1 
                selectCommand = "select * from MOL";
                refreshForm(ConnectionString, selectCommand);
                toolStripTextBox.Text = "";
                MessageBox.Show("Успешно");
            }
            else
            {
                MessageBox.Show("ФИО должно быть длиннее 5 и не более 80 символов");
            }                   
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //выбрана строка CurrentRow
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            //получить значение Name выбранной строки 
            string nameId = dataGridView1[1, CurrentRow].Value.ToString();
            toolStripTextBox.Text = nameId;
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            //Для правильной записи нового кода необходимо запросить максимальное значение idMOL из таблицы MOL 
            string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            String selectCommand = "select MAX(idMOL) from MOL";
            object maxValue = selectValue(ConnectionString, selectCommand);
            if (Convert.ToString(maxValue) == "") maxValue = 0;
            string pattern = @"^[a-zA-Z\D]{5,80}$";
            if (Regex.IsMatch(toolStripTextBox.Text, pattern, RegexOptions.IgnoreCase))
            {
                string txtSQLQuery = "insert into MOL (idMOL, FIO) values (" + (Convert.ToInt32(maxValue) + 1) + ", '" + toolStripTextBox.Text + "')";
                ExecuteQuery(txtSQLQuery);
                MessageBox.Show("Успешно");
            }
            else
            {
                MessageBox.Show("ФИО должно быть длиннее 5 и не более 80 символов");
            } 
            
            //обновление dataGridView1 
            selectCommand = "select * from MOL";
            refreshForm(ConnectionString, selectCommand);
            toolStripTextBox.Text = "";
        }

        private void toolStripButtonDell_Click(object sender, EventArgs e)
        {
            //выбрана строка CurrentRow 
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            //получить значение idMOL выбранной строки 
            string valueId = dataGridView1[0, CurrentRow].Value.ToString();
            String selectCommand = "delete from MOL where idMOL=" + valueId;
            string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            changeValue(ConnectionString, selectCommand);
            //обновление dataGridView1
            selectCommand = "select * from MOL";
            refreshForm(ConnectionString, selectCommand);
            toolStripTextBox.Text = "";
        }
    }
}
