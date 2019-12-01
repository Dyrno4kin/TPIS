using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace TPIS
{
    public partial class FormAddJournalOperation : Form
    {
        private SQLiteCommand sql_cmd;
        private SQLiteConnection sql_con;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private string sPath = Path.Combine(Application.StartupPath, "mydatabase.db");
        public int Id { set { id = value; } }
        private int? id;
        private bool upd = true;

        public FormAddJournalOperation()
        {
            InitializeComponent();
        }

        private void FormJournalOperation_Load(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            if (!id.HasValue)
            {
                String journalOperationId = "select MAX(idOperation) from Journal_Operation";
                object journalOperationIdmaxValue = selectValue(ConnectionString, journalOperationId);
                if (Convert.ToString(journalOperationIdmaxValue) == "") journalOperationIdmaxValue = 0;
                id = Convert.ToInt32(journalOperationIdmaxValue)+1;
                upd = false;
            } 
            //выбрать значения из справочников для отображения в comboBox 
            String selectStore = "Select idStore, Name from Store";
            selectCombo(ConnectionString, selectStore, comboBoxStock1, "Name", "idStore");
            String selectProvider = "SELECT idProvider, NameProvider FROM Provider";
            selectCombo(ConnectionString, selectProvider, comboBoxProvider, "NameProvider", "idProvider");
            String selectMOL = "SELECT idMOL, FIO FROM MOL";
            selectCombo(ConnectionString, selectMOL, comboBoxMOL, "FIO", "idMOL");
            String selectPodrazdel = "Select idStore, Name from Store";
            selectCombo(ConnectionString, selectPodrazdel, comboBoxPodrazdel, "Name", "idStore");
            String selectMOL2 = "SELECT idMOL, FIO FROM MOL";
            selectCombo(ConnectionString, selectMOL2, comboBoxMOL2, "FIO", "idMOL");
            String selectStore2 = "Select idStore, Name from Store";
            selectCombo(ConnectionString, selectStore2, comboBoxStock2, "Name", "idStore");
            String selectMaterials = "Select idMaterials, Name from Materials";
            selectCombo(ConnectionString, selectMaterials, comboBoxMaterial, "Name", "idMaterials");
            if (upd)
            {
                String selectCommand = "Select ID, MaterialId, JournalOperationId, Count, Sum from Materials_JournalOperation where JournalOperationId =" + id;
                refreshForm(ConnectionString, selectCommand);

                String selectDate = "Select Date_operation from Journal_Operation where idOperation=" + id;
                object date_operation = selectValue(ConnectionString, selectDate);
                dateTimePicker1.Text = Convert.ToString(date_operation);
                comboBoxMaterial.SelectedIndex = -1;
                String selectComment = "Select Comment from Journal_Operation where idOperation=" + id;
                object comment = selectValue(ConnectionString, selectComment);
                textBoxComment.Text = Convert.ToString(comment);
                textBoxNumberOperation.Text = Convert.ToString(id);



                String selectTypeOperation = "Select Type_operation from Journal_Operation where idOperation=" + id;
                object type_operation = selectValue(ConnectionString, selectTypeOperation);
                if (Convert.ToString(type_operation) == "")
                {
                    comboBoxTypeOperation.SelectedIndex = -1;
                }
                else
                {
                    comboBoxTypeOperation.Text = Convert.ToString(type_operation);
                }

                String selectStoreId1 = "Select StoreId1 from Journal_Operation where idOperation=" + id;
                object storeId1 = selectValue(ConnectionString, selectStoreId1);
                if (Convert.ToString(storeId1) == "")
                {
                    comboBoxStock1.SelectedIndex = -1;
                }
                else
                {
                    comboBoxStock1.SelectedValue = Convert.ToInt32(storeId1);
                }

                String selectProviderId = "SELECT ProviderId FROM Journal_Operation where idOperation=" + id;
                object providerId = selectValue(ConnectionString, selectProviderId);
                if (Convert.ToString(providerId) == "")
                {
                    comboBoxProvider.SelectedIndex = -1;
                }
                else
                {
                    comboBoxProvider.SelectedValue = Convert.ToInt32(providerId);
                }

                String selectMOLId1 = "SELECT MOLId1 FROM Journal_Operation where idOperation=" + id;
                object MOLId1 = selectValue(ConnectionString, selectMOLId1);
                if (Convert.ToString(MOLId1) == "")
                {
                    comboBoxMOL.SelectedIndex = -1;
                }
                else
                {
                    comboBoxMOL.SelectedValue = Convert.ToInt32(MOLId1);
                }

                String selectPodrazdelId = "Select Podrazdel from Journal_Operation where idOperation=" + id;
                object podrazdelId = selectValue(ConnectionString, selectPodrazdelId);
                if (Convert.ToString(podrazdelId) == "")
                {
                    comboBoxPodrazdel.SelectedIndex = -1;
                }
                else
                {
                    comboBoxPodrazdel.SelectedValue = Convert.ToInt32(podrazdelId);
                }

                String selectMOLId2 = "SELECT MOLId2 FROM Journal_Operation where idOperation=" + id;
                object MOLId2 = selectValue(ConnectionString, selectMOLId2);
                if (Convert.ToString(MOLId2) == "")
                {
                    comboBoxMOL2.SelectedIndex = -1;
                }
                else
                {
                    comboBoxMOL2.SelectedValue = Convert.ToInt32(MOLId2);
                }

                String selectStoreId2 = "Select StoreId2 from Journal_Operation where idOperation=" + id;
                object storeId2 = selectValue(ConnectionString, selectStoreId2);
                if (Convert.ToString(storeId2) == "")
                {
                    comboBoxStock2.SelectedIndex = -1;
                }
                else
                {
                    comboBoxStock2.SelectedValue = Convert.ToInt32(storeId2);
                }
            }
            else
            {
                String selectCommand = "Select ID, MaterialId, JournalOperationId, Count, Sum from Materials_JournalOperation where JournalOperationId =" + id;
                refreshForm(ConnectionString, selectCommand);
                textBoxNumberOperation.Text = Convert.ToString(id);
                comboBoxMaterial.SelectedIndex = -1;
                comboBoxPodrazdel.SelectedIndex = -1;
                comboBoxStock1.SelectedIndex = -1;
                comboBoxMOL.SelectedIndex = -1;
                comboBoxStock2.SelectedIndex = -1;
                comboBoxMOL2.SelectedIndex = -1;
                comboBoxProvider.SelectedIndex = -1;
            }
        }

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
            int count = 0;
            double sum = 0;
            while (count <= (Convert.ToInt32(dataGridView1.RowCount.ToString()) - 1))
            {
                sum += Convert.ToDouble(dataGridView1[4, count].Value);
                count++;
            }
            textBoxSumOperation.Text = Convert.ToString(sum);
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void comboBoxTypeOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTypeOperation.SelectedIndex == -1)
            {
                comboBoxStock2.Enabled = true;
                comboBoxMOL2.Enabled = true;
                comboBoxPodrazdel.Enabled = true;
                comboBoxProvider.Enabled = true;
                comboBoxMOL.Enabled = true;
                comboBoxStock1.Enabled = true;
            }

            if ( comboBoxTypeOperation.SelectedItem != null && comboBoxTypeOperation.SelectedItem.ToString() == "Поступление материалов")
            {
                comboBoxProvider.Enabled = true;
                comboBoxStock2.Enabled = false;
                comboBoxMOL2.Enabled = false;
                comboBoxPodrazdel.Enabled = false;
                comboBoxPodrazdel.SelectedIndex = -1;
                comboBoxStock1.SelectedIndex = -1;
                comboBoxMOL.SelectedIndex = -1;
                comboBoxStock2.SelectedIndex = -1;
                comboBoxMOL2.SelectedIndex = -1;
                comboBoxProvider.SelectedIndex = -1;
            }

            if (comboBoxTypeOperation.SelectedItem != null && comboBoxTypeOperation.SelectedItem.ToString() == "Перемещение материалов")
            {
                comboBoxStock2.Enabled = true;
                comboBoxMOL2.Enabled = true;
                comboBoxPodrazdel.Enabled = false;
                comboBoxProvider.Enabled = false;
                comboBoxPodrazdel.SelectedIndex = -1;
                comboBoxStock1.SelectedIndex = -1;
                comboBoxMOL.SelectedIndex = -1;
                comboBoxStock2.SelectedIndex = -1;
                comboBoxMOL2.SelectedIndex = -1;
                comboBoxProvider.SelectedIndex = -1;
            }

            if (comboBoxTypeOperation.SelectedItem != null && comboBoxTypeOperation.SelectedItem.ToString() == "Отпуск материалов")
            {
                comboBoxStock2.Enabled = false;
                comboBoxMOL2.Enabled = false;
                comboBoxPodrazdel.Enabled = true;
                comboBoxProvider.Enabled = false;
                comboBoxPodrazdel.SelectedIndex = -1;
                comboBoxStock1.SelectedIndex = -1;
                comboBoxMOL.SelectedIndex = -1;
                comboBoxStock2.SelectedIndex = -1;
                comboBoxMOL2.SelectedIndex = -1;
                comboBoxProvider.SelectedIndex = -1;
            }
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

        public void delMaterials()
        {
            string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            String selectCommand = "delete from Materials_JournalOperation where JournalOperationId=" + id;
            changeValue(ConnectionString, selectCommand);
            String selectCommand1 = "Select ID, MaterialId, JournalOperationId, Count, Sum from Materials_JournalOperation where JournalOperationId =" + id;
            selectTable(ConnectionString, selectCommand1);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //выбрана строка CurrentRow
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            //получить значение выбранной строки 
            string valueId = dataGridView1[0, CurrentRow].Value.ToString();
            string changeMaterial = dataGridView1[1, CurrentRow].Value.ToString();
            string changeCount = dataGridView1[3, CurrentRow].Value.ToString();
            string changePrice = dataGridView1[4, CurrentRow].Value.ToString();

            comboBoxMaterial.SelectedValue = Convert.ToInt32(changeMaterial);
            textBoxCount.Text = changeCount;
            textBoxSum.Text = changePrice;
        }

        private void buttonAddMaterial_Click(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            if (comboBoxMaterial.SelectedValue != null && textBoxCount.Text != "")
            {
                if (Convert.ToInt32(textBoxCount.Text) < 101)
                { 
                    String selectMaterialPrice = "Select Price from Materials where idMaterials=" + comboBoxMaterial.SelectedValue.ToString();
                    object materialPrice = selectValue(ConnectionString, selectMaterialPrice);
                    textBoxSum.Text = Convert.ToString(Convert.ToDouble(materialPrice) * Convert.ToInt32(textBoxCount.Text));

                    String mValue = "select MAX(id) from Materials_JournalOperation";
                    object maxValue = selectValue(ConnectionString, mValue);
                    if (Convert.ToString(maxValue) == "") maxValue = 0;
                    string add = "INSERT INTO Materials_JournalOperation (ID, MaterialId, JournalOperationId, Count, Sum) VALUES (" + (Convert.ToInt32(maxValue) + 1) + "," + Convert.ToInt32(comboBoxMaterial.SelectedValue) + "," + id + "," + Convert.ToInt32(textBoxCount.Text) + ",'" + textBoxSum.Text.ToString() + "')";
                    ExecuteQuery(add);
                }
                else MessageBox.Show("Количество не может быть больше 100");
            }
            else MessageBox.Show("Выберите материал или введите количество");
  
            String selectCommand = "Select ID, MaterialId, JournalOperationId, Count, Sum from Materials_JournalOperation where JournalOperationId =" + id;
            refreshForm(ConnectionString,selectCommand);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            //получить значение Name выбранной строки
            string valueId = dataGridView1[0, CurrentRow].Value.ToString();
            string changeMaterial = Convert.ToString(comboBoxMaterial.SelectedValue);
            string changeCount = textBoxCount.Text;
            string changePrice = textBoxSum.Text;
            string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            if (comboBoxMaterial.SelectedValue != null && textBoxCount.Text != "")
            {
                if (Convert.ToInt32(textBoxCount.Text) < 101)
                {
                    String selectMaterialPrice = "Select Price from Materials where idMaterials=" + comboBoxMaterial.SelectedValue.ToString();
                    object materialPrice = selectValue(ConnectionString, selectMaterialPrice);
                    textBoxSum.Text = Convert.ToString(Convert.ToDouble(materialPrice) * Convert.ToInt32(textBoxCount.Text));

                    String mValue = "select MAX(id) from Materials_JournalOperation";
                    object maxValue = selectValue(ConnectionString, mValue);
                    if (Convert.ToString(maxValue) == "") maxValue = 0;
                    //обновление
                    String selectCommand = "update Materials_JournalOperation set MaterialId=" + Convert.ToInt32(comboBoxMaterial.SelectedValue) + ", Count=" + Convert.ToInt32(textBoxCount.Text) + ",Sum='" + textBoxSum.Text + "' where ID=" + valueId;
                    changeValue(ConnectionString, selectCommand);
                }
                else MessageBox.Show("Количество не может быть больше 100");
            }
            else MessageBox.Show("Выберите материал или введите количество");
            
            //обновление dataGridView1 
            String selectCommand1 = "Select ID, MaterialId, JournalOperationId, Count, Sum from Materials_JournalOperation where JournalOperationId =" + id;
            refreshForm(ConnectionString, selectCommand1);
            comboBoxMaterial.SelectedIndex = -1;
            textBoxCount.Text = "";
            textBoxSum.Text = "";
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            string valueId = dataGridView1[0, CurrentRow].Value.ToString();
            String selectCommand = "delete from Materials_JournalOperation where ID=" + valueId;
            changeValue(ConnectionString, selectCommand);

            String selectCommand1 = "Select ID, MaterialId, JournalOperationId, Count, Sum from Materials_JournalOperation where JournalOperationId =" + id;
            selectTable(ConnectionString, selectCommand1);
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int idProvodki = 0;
            string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            string add = "";
            string addProvodki = "";
            string dateOperation = Convert.ToString(dateTimePicker1.Text);
            String journalProvodokId = "select MAX(idProvodki) from Journal_Provodok";
            object journalProvodokIdmaxValue = selectValue(ConnectionString, journalProvodokId);
            if (Convert.ToString(journalProvodokIdmaxValue) == "") journalProvodokIdmaxValue = 0;
            idProvodki = Convert.ToInt32(journalProvodokIdmaxValue) + 1;
            if (upd)
            {
                if (comboBoxTypeOperation.Text == "Поступление материалов")
                {
                    add = "update Journal_Operation set Type_operation='" + comboBoxTypeOperation.Text.ToString() + "', Date_operation='" + dateOperation + "',StoreId1=" + (Convert.ToInt32(comboBoxStock1.SelectedValue.ToString())) + ", MOLId1=" + (Convert.ToInt32(comboBoxMOL.SelectedValue.ToString())) + ", ProviderId=" + (Convert.ToInt32(comboBoxProvider.SelectedValue.ToString())) + ", Sum_operation ='" + textBoxSumOperation.Text.ToString() + "', Comment='" + textBoxComment.Text.ToString() + "' where idOperation=" + id;
                }
                if (comboBoxTypeOperation.Text == "Перемещение материалов")
                {
                    add = "update Journal_Operation set Type_operation='" + comboBoxTypeOperation.Text.ToString() + "', Date_operation='" + dateOperation + "',StoreId1=" + (Convert.ToInt32(comboBoxStock1.SelectedValue.ToString())) + ", StoreId2=" + (Convert.ToInt32(comboBoxStock2.SelectedValue.ToString())) + ", MOLId1=" + (Convert.ToInt32(comboBoxMOL.SelectedValue.ToString())) + ", MOLId2=" + (Convert.ToInt32(comboBoxMOL2.SelectedValue.ToString())) + ", Sum_operation ='" + textBoxSumOperation.Text.ToString() + "', Comment='" + textBoxComment.Text.ToString() + "' where idOperation=" + id;
                }
                if (comboBoxTypeOperation.Text == "Отпуск материалов")
                {
                    add = "update Journal_Operation set Type_operation='" + comboBoxTypeOperation.Text.ToString() + "', Date_operation='" + dateOperation + "',StoreId1=" + (Convert.ToInt32(comboBoxStock1.SelectedValue.ToString())) + ", MOLId1=" + (Convert.ToInt32(comboBoxMOL.SelectedValue.ToString())) + ", Podrazdel=" + (Convert.ToInt32(comboBoxPodrazdel.SelectedValue.ToString())) + ", Sum_operation ='" + textBoxSumOperation.Text.ToString() + "', Comment='" + textBoxComment.Text.ToString() + "' where idOperation=" + id;
                }
                changeValue(ConnectionString, add);
            }
            else
            {
                if (comboBoxTypeOperation.Text == "Поступление материалов") {
                    add = "INSERT INTO Journal_Operation (idOperation, Type_operation, Date_operation, StoreId1, MOLId1, ProviderId, Sum_operation, Comment) VALUES (" + id + ",'" + comboBoxTypeOperation.Text.ToString() + "','" + dateOperation + "'," + (Convert.ToInt32(comboBoxStock1.SelectedValue.ToString()) + "," + Convert.ToInt32(comboBoxMOL.SelectedValue.ToString()) + "," + Convert.ToInt32(comboBoxProvider.SelectedValue.ToString()) + ",'" + textBoxSumOperation.Text.ToString() + "', '" + textBoxComment.Text.ToString() + "')");
                    addProvodki = "INSERT INTO Journal_Provodok (idProvodki, DateOperation, ShetDT, Subkonto1Dt, Subkonto2Dt,Subkonto3Dt, ShetKT, Subkonto1Kt, Count, Sum, JournalOperationKod) VALUES (" + idProvodki + ",'" + dateOperation + "'," + 1 + ",'" + comboBoxStock1.Text.ToString() + "','" + comboBoxStock1.Text.ToString() + "','" + comboBoxMOL.Text.ToString() + "'," + 5 + ",'" + comboBoxProvider.Text.ToString() + "','" + textBoxSumOperation.Text.ToString() + "','" + textBoxSumOperation.Text.ToString() + "'," + id + ")";
                }
                if (comboBoxTypeOperation.Text == "Перемещение материалов")
                {
                    add = "INSERT INTO Journal_Operation (idOperation, Type_operation, Date_operation, StoreId1, StoreId2, MOLId1, MOLId2, Sum_operation, Comment) VALUES (" + id + ",'" + comboBoxTypeOperation.Text.ToString() + "','" + dateOperation + "'," + (Convert.ToInt32(comboBoxStock1.SelectedValue.ToString()) + "," + Convert.ToInt32(comboBoxStock2.SelectedValue.ToString()) + "," + Convert.ToInt32(comboBoxMOL.SelectedValue.ToString()) + "," + Convert.ToInt32(comboBoxMOL2.SelectedValue.ToString()) + ",'" + textBoxSumOperation.Text.ToString() + "','" + textBoxComment.Text.ToString() + "')");
                }
                if (comboBoxTypeOperation.Text == "Отпуск материалов")
                {
                    add = "INSERT INTO Journal_Operation (idOperation, Type_operation, Date_operation, StoreId1, MOLId1, Podrazdel, Sum_operation, Comment) VALUES (" + id + ",'" + comboBoxTypeOperation.Text.ToString() + "','" + dateOperation + "'," + (Convert.ToInt32(comboBoxStock1.SelectedValue.ToString()) + "," + Convert.ToInt32(comboBoxMOL.SelectedValue.ToString()) + "," + Convert.ToInt32(comboBoxPodrazdel.SelectedValue.ToString()) + ",'" + textBoxSumOperation.Text.ToString() + "','" + textBoxComment.Text.ToString() + "')");
                }
                ExecuteQuery(add);
                ExecuteQuery(addProvodki);
            }
            MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            delMaterials();
            comboBoxMaterial.SelectedIndex = -1;
            comboBoxPodrazdel.SelectedIndex = -1;
            comboBoxStock1.SelectedIndex = -1;
            comboBoxMOL.SelectedIndex = -1;
            comboBoxStock2.SelectedIndex = -1;
            comboBoxMOL2.SelectedIndex = -1;
            comboBoxProvider.SelectedIndex = -1;
            comboBoxTypeOperation.SelectedIndex = -1;
            textBoxSum.Text = "";
            textBoxSumOperation.Text = "";
            textBoxComment.Text = "";
            textBoxCount.Text = "";
        }
    }
}
