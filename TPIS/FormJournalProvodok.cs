using System;
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
    public partial class FormJournalProvodok : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private static string sPath = Path.Combine(Application.StartupPath, "mydatabase.db");
        string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
        public int Id { set { id = value; } }
        private int? id;

        public FormJournalProvodok()
        {
            InitializeComponent();
        }

        public void selectTable(string ConnectionString)
        {
            SQLiteConnection connect = new SQLiteConnection(ConnectionString);
            connect.Open();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("Select idProvodki, DateOperation, ShetDT, Subkonto1Dt, Subkonto2Dt,Subkonto3Dt, ShetKT, Subkonto1Kt, Subkonto2Kt, Subkonto3Kt, Count, Sum, JournalOperationKod from Journal_Provodok where JournalOperationKod =" + id, connect);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].ToString();
            connect.Close();
            dataGridView1.Columns["idProvodki"].DisplayIndex = 0;
          //  dataGridView1.Columns["DateOperation"].DisplayIndex = 1;
          //  dataGridView1.Columns["ShetDT"].DisplayIndex = 2;
          //  dataGridView1.Columns["Subkonto1Dt"].DisplayIndex = 3;
          //  dataGridView1.Columns["Subkonto2Dt"].DisplayIndex = 4;
           // dataGridView1.Columns["Subkonto3Dt"].DisplayIndex = 5;
          //  dataGridView1.Columns["ShetKT"].DisplayIndex = 6;
          //  dataGridView1.Columns["Subkonto1Kt"].DisplayIndex = 7;
          //  dataGridView1.Columns["Subkonto2Kt"].DisplayIndex = 8;
          //  dataGridView1.Columns["Subkonto3Kt"].DisplayIndex = 9;
          //  dataGridView1.Columns["Count"].DisplayIndex = 10;
          //  dataGridView1.Columns["Sum"].DisplayIndex = 11;
          //  dataGridView1.Columns["JournalOperationKod"].DisplayIndex = 12;
        }

        private void FormJournalProvodok_Load(object sender, EventArgs e)
        {
            selectTable(ConnectionString);
        }
    }
}
