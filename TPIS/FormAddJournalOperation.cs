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
        private string sPath = Path.Combine(Application.StartupPath, "mydatabaselab5.db");
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

                String selectDate = "Select Date_operation from Journal_Operation where idOperation=" + id;
                object date_operation = selectValue(ConnectionString, selectDate);
                dateTimePicker1.Text = Convert.ToString(date_operation);
                String selectComment = "Select Comment from Journal_Operation where idOperation=" + id;
                object comment = selectValue(ConnectionString, selectComment);
                textBoxComment.Text = Convert.ToString(comment);
                String selectCount = "Select Count from Journal_Operation where idOperation=" + id;
                object count = selectValue(ConnectionString, selectCount);
                textBoxCount.Text = Convert.ToString(count);
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

                String selectMaterialsId = "SELECT MaterialsId FROM Journal_Operation where idOperation=" + id;
                object MaterialsId = selectValue(ConnectionString, selectMaterialsId);
                if (Convert.ToString(MOLId1) == "")
                {
                    comboBoxMaterial.SelectedIndex = -1;
                }
                else
                {
                    comboBoxMaterial.SelectedValue = Convert.ToInt32(MaterialsId);
                }
            }
            else
            {
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

        private void ExecuteQuery(string txtQuery)
        {
            sql_con = new SQLiteConnection("Data Source=" + sPath + ";Version=3;New=False;Compress=True;");
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int idProvodki = 0;
            int countMaterialDebet = 0;
            int countMaterialKredit = 0;
            string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
            string add = "";
            string addProvodki = "";
            string dateOperation = Convert.ToString(dateTimePicker1.Text);
            String journalProvodokId = "select MAX(idProvodki) from Journal_Provodok";
            object journalProvodokIdmaxValue = selectValue(ConnectionString, journalProvodokId);
            if (Convert.ToString(journalProvodokIdmaxValue) == "") journalProvodokIdmaxValue = 0;
            idProvodki = Convert.ToInt32(journalProvodokIdmaxValue) + 1;

            //подсчет стоимости материалов
            String selectpriceMaterial = "select Price from Materials where idMaterials =" + (Convert.ToInt32(comboBoxMaterial.SelectedValue.ToString()));
            object priceMaterial = selectValue(ConnectionString, selectpriceMaterial);
            double sum = Convert.ToDouble(priceMaterial) * Convert.ToInt32(textBoxCount.Text);
            textBoxSumOperation.Text = sum.ToString();

            //подсчет количества материала по дебету
            String selectCountDebet = "select sum(Count) from Journal_Provodok where Subkonto1Dt LIKE '%"+ comboBoxMaterial.Text.ToString() + "%' and Subkonto2Dt LIKE '%" + comboBoxStock1.Text.ToString() + "%'";
            object countMaterialDebetObject = selectValue(ConnectionString, selectCountDebet);
            if (Convert.ToString(countMaterialDebetObject) == "") countMaterialDebetObject = 0;
            countMaterialDebet = Convert.ToInt32(countMaterialDebetObject);

            //подсчет количества материала по кредиту
            String selectCountKredit = "select sum(Count) from Journal_Provodok where Subkonto1Kt LIKE '%" + comboBoxMaterial.Text.ToString() + "%' and Subkonto2Kt LIKE '%" + comboBoxStock1.Text.ToString() + "%'";
            object countMaterialKreditObject = selectValue(ConnectionString, selectCountKredit);
            if (Convert.ToString(countMaterialKreditObject) == "") countMaterialKreditObject = 0;
            countMaterialKredit = Convert.ToInt32(countMaterialKreditObject);

            int differenceMaterialCount = countMaterialDebet - countMaterialKredit;

            if (((comboBoxTypeOperation.Text == "Перемещение материалов" || comboBoxTypeOperation.Text == "Отпуск материалов") && differenceMaterialCount > Convert.ToInt32(textBoxCount.Text.ToString())) || comboBoxTypeOperation.Text == "Поступление материалов")
            {
                if (upd)
                {
                    if (comboBoxTypeOperation.Text == "Поступление материалов")
                    {
                        add = "update Journal_Operation set Type_operation='" + comboBoxTypeOperation.Text.ToString() + "', Date_operation='" + dateOperation + "',StoreId1=" + (Convert.ToInt32(comboBoxStock1.SelectedValue.ToString())) + ", MOLId1=" + (Convert.ToInt32(comboBoxMOL.SelectedValue.ToString())) + ", ProviderId=" + (Convert.ToInt32(comboBoxProvider.SelectedValue.ToString())) + ", Sum_operation ='" + textBoxSumOperation.Text.ToString() + "', Comment='" + textBoxComment.Text.ToString() + "', MaterialsId=" + (Convert.ToInt32(comboBoxMaterial.SelectedValue.ToString())) + ", Count='" + textBoxCount.Text.ToString() + "' where idOperation=" + id;
                    }
                    if (comboBoxTypeOperation.Text == "Перемещение материалов")
                    {
                        add = "update Journal_Operation set Type_operation='" + comboBoxTypeOperation.Text.ToString() + "', Date_operation='" + dateOperation + "',StoreId1=" + (Convert.ToInt32(comboBoxStock1.SelectedValue.ToString())) + ", StoreId2=" + (Convert.ToInt32(comboBoxStock2.SelectedValue.ToString())) + ", MOLId1=" + (Convert.ToInt32(comboBoxMOL.SelectedValue.ToString())) + ", MOLId2=" + (Convert.ToInt32(comboBoxMOL2.SelectedValue.ToString())) + ", Sum_operation ='" + textBoxSumOperation.Text.ToString() + "', Comment='" + textBoxComment.Text.ToString() + "', MaterialsId=" + (Convert.ToInt32(comboBoxMaterial.SelectedValue.ToString())) + ", Count='" + textBoxCount.Text.ToString() + "' where idOperation=" + id;
                    }
                    if (comboBoxTypeOperation.Text == "Отпуск материалов")
                    {
                        add = "update Journal_Operation set Type_operation='" + comboBoxTypeOperation.Text.ToString() + "', Date_operation='" + dateOperation + "',StoreId1=" + (Convert.ToInt32(comboBoxStock1.SelectedValue.ToString())) + ", MOLId1=" + (Convert.ToInt32(comboBoxMOL.SelectedValue.ToString())) + ", Podrazdel=" + (Convert.ToInt32(comboBoxPodrazdel.SelectedValue.ToString())) + ", Sum_operation ='" + textBoxSumOperation.Text.ToString() + "', Comment='" + textBoxComment.Text.ToString() + "', MaterialsId=" + (Convert.ToInt32(comboBoxMaterial.SelectedValue.ToString())) + ", Count='" + textBoxCount.Text.ToString() + "' where idOperation=" + id;
                    }
                    changeValue(ConnectionString, add);
                }
                else
                {
                    if (comboBoxTypeOperation.Text == "Поступление материалов")
                    {
                        add = "INSERT INTO Journal_Operation (idOperation, Type_operation, Date_operation, StoreId1, MOLId1, ProviderId, Sum_operation, Comment, MaterialsId, Count) VALUES (" + id + ",'" + comboBoxTypeOperation.Text.ToString() + "','" + dateOperation + "'," + (Convert.ToInt32(comboBoxStock1.SelectedValue.ToString()) + "," + Convert.ToInt32(comboBoxMOL.SelectedValue.ToString()) + "," + Convert.ToInt32(comboBoxProvider.SelectedValue.ToString()) + ",'" + textBoxSumOperation.Text.ToString() + "', '" + textBoxComment.Text.ToString() + "'," + Convert.ToInt32(comboBoxMaterial.SelectedValue.ToString()) + ", '" + textBoxCount.Text.ToString() + "')");
                        addProvodki = "INSERT INTO Journal_Provodok (idProvodki, DateOperation, ShetDT, Subkonto1Dt, Subkonto2Dt,Subkonto3Dt, ShetKT, Subkonto1Kt, Count, Sum, JournalOperationKod) VALUES (" + idProvodki + ",'" + dateOperation + "'," + 10 + ",'" + comboBoxMaterial.Text.ToString() + "','" + comboBoxStock1.Text.ToString() + "','" + comboBoxMOL.Text.ToString() + "'," + 60 + ",'" + comboBoxProvider.Text.ToString() + "','" + textBoxCount.Text.ToString() + "','" + textBoxSumOperation.Text.ToString() + "'," + id + ")";
                    }
                    if (comboBoxTypeOperation.Text == "Перемещение материалов" && differenceMaterialCount > Convert.ToInt32(textBoxCount.Text.ToString()))
                    {
                        add = "INSERT INTO Journal_Operation (idOperation, Type_operation, Date_operation, StoreId1, StoreId2, MOLId1, MOLId2, Sum_operation, Comment, MaterialsId, Count) VALUES (" + id + ",'" + comboBoxTypeOperation.Text.ToString() + "','" + dateOperation + "'," + (Convert.ToInt32(comboBoxStock1.SelectedValue.ToString()) + "," + Convert.ToInt32(comboBoxStock2.SelectedValue.ToString()) + "," + Convert.ToInt32(comboBoxMOL.SelectedValue.ToString()) + "," + Convert.ToInt32(comboBoxMOL2.SelectedValue.ToString()) + ",'" + textBoxSumOperation.Text.ToString() + "','" + textBoxComment.Text.ToString() + "'," + Convert.ToInt32(comboBoxMaterial.SelectedValue.ToString()) + ", '" + textBoxCount.Text.ToString() + "')");
                        addProvodki = "INSERT INTO Journal_Provodok (idProvodki, DateOperation, ShetDT, Subkonto1Dt, Subkonto2Dt,Subkonto3Dt, ShetKT, Subkonto1Kt, Subkonto2Kt, Subkonto3Kt, Count, Sum, JournalOperationKod) VALUES (" + idProvodki + ",'" + dateOperation + "'," + 10 + ",'" + comboBoxMaterial.Text.ToString() + "','" + comboBoxStock2.Text.ToString() + "','" + comboBoxMOL2.Text.ToString() + "'," + 10 + ",'" + comboBoxMaterial.Text.ToString() + "','" + comboBoxStock1.Text.ToString() + "','" + comboBoxMOL.Text.ToString() + "','" + textBoxCount.Text.ToString() + "','" + textBoxSumOperation.Text.ToString() + "'," + id + ")";
                    }
                    if (comboBoxTypeOperation.Text == "Отпуск материалов")
                    {
                        add = "INSERT INTO Journal_Operation (idOperation, Type_operation, Date_operation, StoreId1, MOLId1, Podrazdel, Sum_operation, Comment, MaterialsId, Count) VALUES (" + id + ",'" + comboBoxTypeOperation.Text.ToString() + "','" + dateOperation + "'," + (Convert.ToInt32(comboBoxStock1.SelectedValue.ToString()) + "," + Convert.ToInt32(comboBoxMOL.SelectedValue.ToString()) + "," + Convert.ToInt32(comboBoxPodrazdel.SelectedValue.ToString()) + ",'" + textBoxSumOperation.Text.ToString() + "','" + textBoxComment.Text.ToString() + "'," + Convert.ToInt32(comboBoxMaterial.SelectedValue.ToString()) + ", '" + textBoxCount.Text.ToString() + "')");
                        addProvodki = "INSERT INTO Journal_Provodok (idProvodki, DateOperation, ShetDT, Subkonto1Dt, ShetKT, Subkonto1Kt, Subkonto2Kt, Subkonto3Kt, Count, Sum, JournalOperationKod) VALUES (" + idProvodki + ",'" + dateOperation + "'," + 20 + ",'" + comboBoxPodrazdel.Text.ToString() + "'," + 10 + ",'" + comboBoxMaterial.Text.ToString() + "','" + comboBoxStock1.Text.ToString() + "','" + comboBoxMOL.Text.ToString() + "','" + textBoxCount.Text.ToString() + "','" + textBoxSumOperation.Text.ToString() + "'," + id + ")";
                    }
                    ExecuteQuery(add);
                    ExecuteQuery(addProvodki);
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Не хватает материалов на складе. На складе доступно "+differenceMaterialCount+" ед. материала ", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBoxMaterial.SelectedIndex = -1;
            comboBoxPodrazdel.SelectedIndex = -1;
            comboBoxStock1.SelectedIndex = -1;
            comboBoxMOL.SelectedIndex = -1;
            comboBoxStock2.SelectedIndex = -1;
            comboBoxMOL2.SelectedIndex = -1;
            comboBoxProvider.SelectedIndex = -1;
            comboBoxTypeOperation.SelectedIndex = -1;
            textBoxSumOperation.Text = "";
            textBoxComment.Text = "";
            textBoxCount.Text = "";
        }
    }
}
