using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPIS
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void журналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormJournalOperation();
            form.dateTime = Convert.ToString(dateTimePicker1.Value);
            form.ShowDialog();
        }

        private void планСчетовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormChartOfAccounts();
            form.ShowDialog();
        }

        private void материальноотвнтственныеЛицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormMOL();
            form.ShowDialog();
        }

        private void поставщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormProviders();
            form.ShowDialog();
        }

        private void складыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormStocks();
            form.ShowDialog();
        }

        private void материалыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormMaterials();
            form.ShowDialog();
        }

        private void журналПроводокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormJournalProvodok();
            form.ShowDialog();
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormReport();
            form.dateTime = Convert.ToString(dateTimePicker1.Value);
            form.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }
    }
}
