using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPIS
{
    public partial class FormMaterials : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private string sPath = Path.Combine(Application.StartupPath, "mydatabaselab5.db");

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
            toolStripTextBoxName.Text = "";
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
        public FormMaterials()
        {
            InitializeComponent();
        }

        private void FormMaterials_Load(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            String selectCommand = "Select * from Materials";
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //выбрана строка CurrentRow
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            //получить значение Name выбранной строки 
            string nameId = dataGridView1[1, CurrentRow].Value.ToString();
            string typeId = dataGridView1[2, CurrentRow].Value.ToString();
            string priceId = dataGridView1[3, CurrentRow].Value.ToString();
            toolStripTextBoxName.Text = nameId;
            toolStripComboBoxType.Text = typeId;
            toolStripTextBoxPrice.Text = priceId;
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            //Для правильной записи нового кода необходимо запросить максимальное значение idMaterials из таблицы Materials 
            string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            String selectCommand = "select MAX(idMaterials) from Materials";
            object maxValue = selectValue(ConnectionString, selectCommand);
            if (Convert.ToString(maxValue) == "") maxValue = 0;
            string pattern1 = @"\d$";
            if (Regex.IsMatch(toolStripTextBoxPrice.Text, pattern1, RegexOptions.IgnoreCase))
            {
                decimal Price = Convert.ToDecimal(toolStripTextBoxPrice.Text);
                Price = Math.Round(Price, 2);
                string ConvertPrice = Convert.ToString(Price);
                string pattern = @"\d{1,15},\d{0,2}$";
                if (Regex.IsMatch(toolStripTextBoxPrice.Text, pattern, RegexOptions.IgnoreCase) && Price > 0)
                {
                    MessageBox.Show("Успешно");
                    //вставка в таблицу Materials 
                    string txtSQLQuery = "insert into Materials (idMaterials, Name, Type, Price) values (" + (Convert.ToInt32(maxValue) + 1) + ", '" + toolStripTextBoxName.Text + "','" + toolStripComboBoxType.Text + "','" + ConvertPrice + "')";
                    ExecuteQuery(txtSQLQuery);
                    //обновление dataGridView1 
                    selectCommand = "select * from Materials";
                    refreshForm(ConnectionString, selectCommand);
                    toolStripTextBoxName.Text = "";
                    toolStripComboBoxType.Text = "";
                    toolStripTextBoxPrice.Text = "";
                }
                else
                {
                    MessageBox.Show("Цена должна быть не более 15 символов и иметь не более 2-ух знаков после запятой");
                }
            }
            else
            {
                MessageBox.Show("Цена имеет неверный формат");
            }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            //получить значение Name выбранной строки
            string valueId = dataGridView1[0, CurrentRow].Value.ToString();
            string changeName = toolStripTextBoxName.Text;
            string changeType = toolStripComboBoxType.Text;
            string changePrice = toolStripTextBoxPrice.Text;
            decimal Price = Convert.ToDecimal(changePrice);
            string pattern = @"\d{1,15},\d{0,2}$";
            if (Regex.IsMatch(toolStripTextBoxPrice.Text, pattern, RegexOptions.IgnoreCase) && Price > 0)
            {
                //обновление Name 
                String selectCommand = "update Materials set Name='" + changeName + "', Type='" + changeType + "',Price='" + changePrice + "' where idMaterials=" + valueId;
                string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
                changeValue(ConnectionString, selectCommand);
                //обновление dataGridView1 
                selectCommand = "select * from Materials";
                refreshForm(ConnectionString, selectCommand);
                toolStripTextBoxName.Text = "";
                toolStripComboBoxType.Text = "";
                toolStripTextBoxPrice.Text = "";
                MessageBox.Show("Успешно");
            }
            else
            {
                MessageBox.Show("Цена должна быть не более 15 символов и иметь не более 2-ух знаков после запятой");
            }
            
        }

        private void toolStripButtonDell_Click(object sender, EventArgs e)
        {
            //выбрана строка CurrentRow 
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            //получить значение idMOL выбранной строки 
            string valueId = dataGridView1[0, CurrentRow].Value.ToString();
            String selectCommand = "delete from Materials where idMaterials=" + valueId;
            string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            changeValue(ConnectionString, selectCommand);
            //обновление dataGridView1
            selectCommand = "select * from Materials";
            refreshForm(ConnectionString, selectCommand);
            toolStripTextBoxName.Text = "";
            toolStripComboBoxType.Text = "";
            toolStripTextBoxPrice.Text = "";
        }

        private void toolStripComboBoxType_Click(object sender, EventArgs e)
        {

        }
    }
}
