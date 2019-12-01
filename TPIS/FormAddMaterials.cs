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
    public partial class FormAddMaterials : Form
    {
        private SQLiteCommand sql_cmd;
        private SQLiteConnection sql_con;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private string sPath = Path.Combine(Application.StartupPath, "mydatabaselab5.db");


        public FormAddMaterials()
        {
            InitializeComponent();
        }

        private void FormAddMaterials_Load(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            //selectTable(ConnectionString);
            //выбрать значения из справочников для отображения в comboBox 
            String selectMaterials = "Select idMaterials, Name from Materials";
            selectCombo(ConnectionString, selectMaterials, comboBoxMaterial, "Name", "idMaterials");
            comboBoxMaterial.SelectedIndex = -1;
        }
        //метод отображения в ComboBox значений из базы данных 
        public void selectCombo(string ConnectionString, String selectCommand, ComboBox comboBox, string displayMember, string valueMember)
        {
            SQLiteConnection connect = new SQLiteConnection(ConnectionString);
            connect.Open();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectCommand, connect);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            comboBox.DataSource = ds.Tables[0];
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            connect.Close();
        }

        public object selectValue(string ConnectionString, String selectMaterialPrice)
        {
            SQLiteConnection connect = new SQLiteConnection(ConnectionString);
            connect.Open();
            SQLiteCommand command = new SQLiteCommand(selectMaterialPrice, connect);
            SQLiteDataReader reader = command.ExecuteReader();
            object value = "";
            while (reader.Read())
            {
                value = reader[0];
            }
            connect.Close(); return value;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxMaterial.SelectedValue != null && textBoxCount.Text != "")
            {
                if (Convert.ToInt32(textBoxCount.Text) < 101)
                {
                    string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
                    String idMaterial = comboBoxMaterial.SelectedValue.ToString();
                    String selectMaterialPrice = "Select Price from Materials where idMaterials=" + idMaterial;
                    object materialPrice = selectValue(ConnectionString, selectMaterialPrice);
                    textBoxSum.Text = Convert.ToString(Convert.ToDouble(materialPrice) * Convert.ToInt32(textBoxCount.Text));
                }
                else MessageBox.Show("Количество не может быть больше 100");
            }
            else MessageBox.Show("Выберите материал или введите количество");
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            if (comboBoxMaterial.SelectedValue != null && textBoxCount.Text != "")
            {
                if (Convert.ToInt32(textBoxCount.Text) < 101)
                {
                    string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
                    String idMaterial = comboBoxMaterial.SelectedValue.ToString();
                    String selectMaterialPrice = "Select Price from Materials where idMaterials=" + idMaterial;
                    object materialPrice = selectValue(ConnectionString, selectMaterialPrice);
                    textBoxSum.Text = Convert.ToString(Convert.ToDouble(materialPrice) * Convert.ToInt32(textBoxCount.Text));
                }
                else MessageBox.Show("Количество не может быть больше 100");
            }
            else MessageBox.Show("Выберите материал или введите количество");
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void comboBoxMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSum_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
