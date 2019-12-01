﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPIS
{
    public partial class FormJournalOperation : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private static string sPath = Path.Combine(Application.StartupPath, "mydatabase.db");
        string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";

        public FormJournalOperation()
        {
            InitializeComponent();
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

        private void FormJournalOperation_Load(object sender, EventArgs e)
        {
            //string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            String selectCommand = "Select idOperation, Type_operation, Sum_operation, Date_operation, Comment from Journal_Operation";
            selectTable(ConnectionString, selectCommand);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            var form = new FormAddJournalOperation();
            form.ShowDialog();
            String selectCommand = "Select idOperation, Type_operation, Sum_operation, Date_operation, Comment from Journal_Operation";
            selectTable(ConnectionString, selectCommand);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
          //  string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            var form = new FormAddJournalOperation();
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            form.Id = Convert.ToInt32(dataGridView1[0, CurrentRow].Value);
            form.ShowDialog();
            String selectCommand = "Select idOperation, Type_operation, Sum_operation, Date_operation, Comment from Journal_Operation";
            selectTable(ConnectionString, selectCommand);
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
           // string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            string valueId = dataGridView1[0, CurrentRow].Value.ToString();
            String deleteJournalOperation = "delete from Journal_Operation where idOperation=" + valueId;
            changeValue(ConnectionString, deleteJournalOperation);
            String deleteMaterialsJournal = "delete from Materials_JournalOperation where JournalOperationId=" + valueId;
            changeValue(ConnectionString, deleteMaterialsJournal);

            String selectCommand1 = "Select idOperation, Type_operation, Sum_operation, Date_operation, Comment from Journal_Operation";
            selectTable(ConnectionString, selectCommand1);
        }

        private void buttonProvodki_Click(object sender, EventArgs e)
        {
            var form = new FormJournalProvodok();
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            form.Id = Convert.ToInt32(dataGridView1[0, CurrentRow].Value);
            form.ShowDialog();
        }
    }
}