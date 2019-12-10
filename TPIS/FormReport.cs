using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace TPIS
{
    public partial class FormReport : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private DataSet DS = new DataSet();
        private System.Data.DataTable DT = new System.Data.DataTable();
        private static string sPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "mydatabaselab5.db");
        string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
        public FormReport()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;

            String selectStore = "Select idStore, Name from Store";
            selectCombo(ConnectionString, selectStore, comboBoxStock, "Name", "idStore");
            comboBoxStock.SelectedIndex = -1;
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

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date >= dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String selectCommand = "";
            string dateFrom = Convert.ToString(dateTimePicker1.Text);
            string dateTo = Convert.ToString(dateTimePicker2.Text);
            string stock = comboBoxStock.Text.ToString();

            if (comboBoxTypeOperation.SelectedItem.ToString() == "Поступление материалов")
            {
                selectCommand = "SELECT Subkonto1Dt, Count, Sum, DateOperation FROM Journal_Provodok WHERE ShetKT LIKE '%60%' AND DateOperation BETWEEN  '"+ dateFrom + "' and '" + dateTo + "' AND Subkonto2Dt = '" + stock + "'";
                selectTable(ConnectionString, selectCommand);
                dataGridView1.Columns[0].HeaderCell.Value = "Название материала";
                dataGridView1.Columns[1].HeaderCell.Value = "Количество поступления";
                dataGridView1.Columns[2].HeaderCell.Value = "Сумма поступления";
                dataGridView1.Columns[3].HeaderCell.Value = "Дата поступления";
            }
            if (comboBoxTypeOperation.SelectedItem.ToString() == "Остатки материалов на складе")
            {
                selectCommand = "SELECT Subkonto1Dt, SUM((CASE [Subkonto2Dt] WHEN '" + stock + "' THEN [Count] ELSE 0 END) + (CASE [Subkonto2Kt] WHEN '" + stock + "' THEN -[Count] ELSE 0 END)), SUM((CASE [Subkonto2Dt] WHEN '" + stock + "' THEN [Sum] ELSE 0 END) + (CASE [Subkonto2Kt] WHEN '" + stock + "' THEN -[Sum] ELSE 0 END)) FROM Journal_Provodok Where (Subkonto2Dt = '" + stock + "' OR (Subkonto2Kt = '" + stock + "'AND ShetDT != 20)) AND DateOperation <= '" + dateTo + "' GROUP BY Subkonto1Dt ";
                selectTable(ConnectionString, selectCommand);
                dataGridView1.Columns[0].HeaderCell.Value = "Название материала";
                dataGridView1.Columns[1].HeaderCell.Value = "Количество остатка";
                dataGridView1.Columns[2].HeaderCell.Value = "Сумма остатка";
            }
            if (comboBoxTypeOperation.SelectedItem.ToString() == "Отпуск материалов")
            {
                selectCommand = "SELECT Subkonto1Kt, Count, Sum, DateOperation FROM Journal_Provodok WHERE DateOperation >= '" + dateFrom + "' AND DateOperation <= '" + dateTo + "' AND ShetDT LIKE '%20%' AND Subkonto1Dt = '" + stock + "'";
                selectTable(ConnectionString, selectCommand);
                dataGridView1.Columns[0].HeaderCell.Value = "Название материала";
                dataGridView1.Columns[1].HeaderCell.Value = "Количество отпуска";
                dataGridView1.Columns[2].HeaderCell.Value = "Сумма отпуска";
                dataGridView1.Columns[3].HeaderCell.Value = "Дата отпуска";
            }

            int count = 0;
            double sum = 0;
            while (count <= (Convert.ToInt32(dataGridView1.RowCount.ToString()) - 1))
            {
                sum += Convert.ToDouble(dataGridView1[2, count].Value);
                count++;
            }
            label4.Text = "Итого: " + Convert.ToString(sum);
        }

        private void buttonPDF_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date >= dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "pdf|*.pdf"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    savePDF(sfd.FileName);
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSaveDoc_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date >= dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "doc|*.doc"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    saveDoc(sfd.FileName);
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSaveXls_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date >= dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "xls|*.xls|xlsx|*.xlsx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    saveXls(sfd.FileName);
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        public void saveDoc(string FileName)
        {
            var winword = new Microsoft.Office.Interop.Word.Application();
            try
            {
                object missing = System.Reflection.Missing.Value;
                //создаем документ
                Microsoft.Office.Interop.Word.Document document =
                winword.Documents.Add(ref missing, ref missing, ref missing, ref
               missing);
                //получаем ссылку на параграф
                var paragraph = document.Paragraphs.Add(missing);
                var range = paragraph.Range;
                string title = "";
                if (comboBoxTypeOperation.SelectedItem.ToString() == "Поступление материалов")
                {
                    title = "Поступление материалов на " + comboBoxStock.Text.ToString() + " с " + Convert.ToString(dateTimePicker1.Text) + " по " + Convert.ToString(dateTimePicker2.Text) + "";
                }
                if (comboBoxTypeOperation.SelectedItem.ToString() == "Остатки материалов на складе")
                {
                    title = "Остатки материалов на " + comboBoxStock.Text.ToString() + " на " + Convert.ToString(dateTimePicker2.Text) + "";
                }
                if (comboBoxTypeOperation.SelectedItem.ToString() == "Отпуск материалов")
                {
                    title = "Отпуск материалов в " + comboBoxStock.Text.ToString() + " с " + Convert.ToString(dateTimePicker1.Text) + " по " + Convert.ToString(dateTimePicker2.Text) + "";
                }
                //задаем текст
                range.Text = title;
                //задаем настройки шрифта
                var font = range.Font;
                font.Size = 16;
                font.Name = "Times New Roman";
                font.Bold = 1;
                //задаем настройки абзаца
                var paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 0;
                //добавляем абзац в документ
                range.InsertParagraphAfter();
                //создаем таблицу
                var paragraphTable = document.Paragraphs.Add(Type.Missing);
                var rangeTable = paragraphTable.Range;
                var table = document.Tables.Add(rangeTable, dataGridView1.Rows.Count + 1, dataGridView1.Columns.Count, ref
               missing, ref missing);
                font = table.Range.Font;
                font.Size = 14;
                font.Name = "Times New Roman";
                var paragraphTableFormat = table.Range.ParagraphFormat;
                paragraphTableFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphTableFormat.SpaceAfter = 0;
                paragraphTableFormat.SpaceBefore = 0;
                for (int i = 0; i < dataGridView1.Columns.Count; ++i)
                {
                    table.Cell(1, i + 1).Range.Text = dataGridView1.Columns[i].HeaderCell.Value.ToString();
                }
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; ++j)
                    {
                        table.Cell(i + 2, j + 1).Range.Text = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                //задаем границы таблицы
                table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleInset;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                paragraph = document.Paragraphs.Add(missing);
                range = paragraph.Range;
                range.Text = label4.Text.ToString();
                font = range.Font;
                font.Size = 12;
                font.Name = "Times New Roman";
                paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 10;
                range.InsertParagraphAfter();
                //сохраняем
                object fileFormat = WdSaveFormat.wdFormatXMLDocument;
                document.SaveAs(FileName, ref fileFormat, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing);
                document.Close(ref missing, ref missing, ref missing);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                winword.Quit();
            }
        }

        public void savePDF(string FileName)
        {
            string FONT_LOCATION = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.TTF"); //определяем В СИСТЕМЕ(чтобы не копировать файл) расположение шрифта arial.ttf
            BaseFont baseFont = BaseFont.CreateFont(FONT_LOCATION, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED); //создаем шрифт
            iTextSharp.text.Font fontParagraph = new iTextSharp.text.Font(baseFont, 17, iTextSharp.text.Font.NORMAL); //регистрируем + можно задать параметры для него(17 - размер, последний параметр - стиль)
            string title = "";
            if (comboBoxTypeOperation.SelectedItem.ToString() == "Поступление материалов")
            {
                title = "Поступление материалов на " + comboBoxStock.Text.ToString() + " с " + Convert.ToString(dateTimePicker1.Text) + " по " + Convert.ToString(dateTimePicker2.Text) + "\n\n";
            }
            if (comboBoxTypeOperation.SelectedItem.ToString() == "Остатки материалов на складе")
            {
                title = "Остатки материалов на " + comboBoxStock.Text.ToString() + " на " + Convert.ToString(dateTimePicker2.Text) + "\n\n";
            }
            if (comboBoxTypeOperation.SelectedItem.ToString() == "Отпуск материалов")
            {
                title = "Отпуск материалов в " + comboBoxStock.Text.ToString() + " с " + Convert.ToString(dateTimePicker1.Text) + " по " + Convert.ToString(dateTimePicker2.Text) + "\n\n";
            }

            var phraseTitle = new Phrase(title,
            new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Paragraph paragraph = new
           iTextSharp.text.Paragraph(phraseTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };

            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                table.AddCell(new Phrase(dataGridView1.Columns[i].HeaderCell.Value.ToString(), fontParagraph));
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    table.AddCell(new Phrase(dataGridView1.Rows[i].Cells[j].Value.ToString(), fontParagraph));
                }
            }

            var phraseSum = new Phrase(label4.Text.ToString(),
            new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Paragraph paragraphSum = new
           iTextSharp.text.Paragraph(phraseSum)
            {
                Alignment = Element.ALIGN_RIGHT - 1,
                SpacingAfter = 12,
            };
            using (FileStream stream = new FileStream(FileName, FileMode.Create))
            {
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(paragraph);
                pdfDoc.Add(table);
                pdfDoc.Add(paragraphSum);
                pdfDoc.Close();
                stream.Close();
            }
        }

        public void saveXls(string FileName)
        {
            var excel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                if (File.Exists(FileName))
                {
                    excel.Workbooks.Open(FileName, Type.Missing, Type.Missing,
                   Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                   Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                   Type.Missing,
                    Type.Missing);
                }
                else
                {
                    excel.SheetsInNewWorkbook = 1;
                    excel.Workbooks.Add(Type.Missing);
                    excel.Workbooks[1].SaveAs(FileName, XlFileFormat.xlExcel8,
                    Type.Missing,
                     Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange,
                    Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                Sheets excelsheets = excel.Workbooks[1].Worksheets;

                var excelworksheet = (Worksheet)excelsheets.get_Item(1);
                excelworksheet.Cells.Clear();
                Microsoft.Office.Interop.Excel.Range excelcells = excelworksheet.get_Range("A1", "H1");
                excelcells.Merge(Type.Missing);
                excelcells.Font.Bold = true;
                string title = "";
                if (comboBoxTypeOperation.SelectedItem.ToString() == "Поступление материалов")
                {
                    title = "Поступление материалов на " + comboBoxStock.Text.ToString() + " с " + Convert.ToString(dateTimePicker1.Text) + " по " + Convert.ToString(dateTimePicker2.Text) + "";
                }
                if (comboBoxTypeOperation.SelectedItem.ToString() == "Остатки материалов на складе")
                {
                    title = "Остатки материалов на " + comboBoxStock.Text.ToString() + " на " + Convert.ToString(dateTimePicker2.Text) + "";
                }
                if (comboBoxTypeOperation.SelectedItem.ToString() == "Отпуск материалов")
                {
                    title = "Отпуск материалов в " + comboBoxStock.Text.ToString() + " с " + Convert.ToString(dateTimePicker1.Text) + " по " + Convert.ToString(dateTimePicker2.Text) + "";
                }
                excelcells.Value2 = title;
                excelcells.RowHeight = 40;
                excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 14;

                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    excelcells = excelworksheet.get_Range("B3", "B3");
                    excelcells = excelcells.get_Offset(0, j);
                    excelcells.ColumnWidth = 15;
                    excelcells.Value2 = dataGridView1.Columns[j].HeaderCell.Value.ToString();
                    excelcells.Font.Bold = true;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        excelcells = excelworksheet.get_Range("B4", "B4");
                        excelcells = excelcells.get_Offset(i, j);
                        excelcells.ColumnWidth = 15;
                        excelcells.Value2 = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                excelcells = excelcells.get_Offset(1, 0);
                excelcells.Value2 = label4.Text.ToString();
                excelcells.Font.Bold = true;
                excel.Workbooks[1].Save();
            }
            catch (Exception)
            {
            }
            finally
            {
                excel.Quit();
            }
        }
    }
}
