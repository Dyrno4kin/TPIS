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
    public partial class FormJournalOperation : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private static string sPath = Path.Combine(Application.StartupPath, "mydatabaselab5.db");
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
            int countMaterialDebet = 0;
            int countMaterialKredit = 0;
            string Subkonto1Dt = "";
            string Subkonto2Dt = "";
            string Subkonto1Kt = "";
            string Subkonto2Kt = "";
            string typeoperation = "";

            // string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            string valueId = dataGridView1[0, CurrentRow].Value.ToString();

            String selectSubkonto1Dt = "Select Subkonto1Dt from Journal_Provodok where JournalOperationKod=" + valueId;
            object subkonto1DtObject = selectValue(ConnectionString, selectSubkonto1Dt);
            if (Convert.ToString(subkonto1DtObject) == "") subkonto1DtObject = 0;
            Subkonto1Dt = subkonto1DtObject.ToString();
            String selectSubkonto2Dt = "Select Subkonto2Dt from Journal_Provodok where JournalOperationKod=" + valueId;
            object subkonto2DtObject = selectValue(ConnectionString, selectSubkonto2Dt);
            if (Convert.ToString(subkonto2DtObject) == "") subkonto2DtObject = 0;
            Subkonto2Dt = subkonto2DtObject.ToString();
            String selectSubkonto1Kt = "Select Subkonto1Kt from Journal_Provodok where JournalOperationKod=" + valueId;
            object subkonto1KtObject = selectValue(ConnectionString, selectSubkonto1Kt);
            if (Convert.ToString(subkonto1KtObject) == "") subkonto1KtObject = 0;
            Subkonto1Kt = subkonto1KtObject.ToString();
            String selectSubkonto2Kt = "Select Subkonto2Kt from Journal_Provodok where JournalOperationKod=" + valueId;
            object subkonto2KtObject = selectValue(ConnectionString, selectSubkonto2Kt);
            if (Convert.ToString(subkonto2KtObject) == "") subkonto2KtObject = 0;
            Subkonto2Kt = subkonto2KtObject.ToString();
            String selectTypeOperation = "Select Type_operation from Journal_Operation where idOperation=" + valueId;
            object typeOperationObject = selectValue(ConnectionString, selectTypeOperation);
            if (Convert.ToString(typeOperationObject) == "") typeOperationObject = "";
            typeoperation = typeOperationObject.ToString();

            String selectCount = "Select Count from Journal_Provodok where JournalOperationKod=" + valueId;
            object countObject = selectValue(ConnectionString, selectCount);
            if (Convert.ToString(countObject) == "") countObject = 0;
            int count = Convert.ToInt32(countObject);

            //подсчет количества материала по дебету
            String selectCountDebet = "select sum(Count) from Journal_Provodok where Subkonto1Dt LIKE '%" +Subkonto1Dt + "%' and Subkonto2Dt LIKE '%" + Subkonto2Dt + "%'";
            object countMaterialDebetObject = selectValue(ConnectionString, selectCountDebet);
            if (Convert.ToString(countMaterialDebetObject) == "") countMaterialDebetObject = 0;
            countMaterialDebet = Convert.ToInt32(countMaterialDebetObject);

            //подсчет количества материала по кредиту
            String selectCountKredit = "select sum(Count) from Journal_Provodok where Subkonto1Kt LIKE '%" + Subkonto1Dt + "%' and Subkonto2Kt LIKE '%" + Subkonto2Dt + "%'";
            object countMaterialKreditObject = selectValue(ConnectionString, selectCountKredit);
            if (Convert.ToString(countMaterialKreditObject) == "") countMaterialKreditObject = 0;
            countMaterialKredit = Convert.ToInt32(countMaterialKreditObject);

            int differenceMaterialCount = countMaterialDebet - countMaterialKredit - count;

            if (typeoperation == "Поступление материалов")
            {
                if (differenceMaterialCount >= 0)
                {
                    String deleteJournalOperation = "delete from Journal_Operation where idOperation=" + valueId;
                    String deleteJournalProvodok = "delete from Journal_Provodok where JournalOperationKod=" + valueId;
                    changeValue(ConnectionString, deleteJournalOperation);
                    changeValue(ConnectionString, deleteJournalProvodok);
                }
                else
                {
                    MessageBox.Show("Невозможно удалить операцию, удалите операции после данной ", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                String deleteJournalOperation = "delete from Journal_Operation where idOperation=" + valueId;
                String deleteJournalProvodok = "delete from Journal_Provodok where JournalOperationKod=" + valueId;
                changeValue(ConnectionString, deleteJournalOperation);
                changeValue(ConnectionString, deleteJournalProvodok);
            }

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
