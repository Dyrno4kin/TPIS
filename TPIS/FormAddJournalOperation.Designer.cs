namespace TPIS
{
    partial class FormAddJournalOperation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddJournalOperation));
            this.labelDateOperation = new System.Windows.Forms.Label();
            this.labelNumberOperation = new System.Windows.Forms.Label();
            this.labelMOL1 = new System.Windows.Forms.Label();
            this.labelProvider = new System.Windows.Forms.Label();
            this.labelStock = new System.Windows.Forms.Label();
            this.labelPodrazdel = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxMOL = new System.Windows.Forms.ComboBox();
            this.comboBoxProvider = new System.Windows.Forms.ComboBox();
            this.comboBoxStock1 = new System.Windows.Forms.ComboBox();
            this.comboBoxPodrazdel = new System.Windows.Forms.ComboBox();
            this.comboBoxTypeOperation = new System.Windows.Forms.ComboBox();
            this.labelComment = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.labelMOL2 = new System.Windows.Forms.Label();
            this.comboBoxMOL2 = new System.Windows.Forms.ComboBox();
            this.comboBoxStock2 = new System.Windows.Forms.ComboBox();
            this.labelStock2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRef = new System.Windows.Forms.Button();
            this.comboBoxMaterial = new System.Windows.Forms.ComboBox();
            this.buttonAddMaterial = new System.Windows.Forms.Button();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSumOperation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNumberOperation = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDateOperation
            // 
            this.labelDateOperation.AutoSize = true;
            this.labelDateOperation.Location = new System.Drawing.Point(12, 40);
            this.labelDateOperation.Name = "labelDateOperation";
            this.labelDateOperation.Size = new System.Drawing.Size(99, 15);
            this.labelDateOperation.TabIndex = 0;
            this.labelDateOperation.Text = "Дата операции:";
            // 
            // labelNumberOperation
            // 
            this.labelNumberOperation.AutoSize = true;
            this.labelNumberOperation.Location = new System.Drawing.Point(12, 71);
            this.labelNumberOperation.Name = "labelNumberOperation";
            this.labelNumberOperation.Size = new System.Drawing.Size(90, 15);
            this.labelNumberOperation.TabIndex = 1;
            this.labelNumberOperation.Text = "Тип операции:";
            // 
            // labelMOL1
            // 
            this.labelMOL1.AutoSize = true;
            this.labelMOL1.Location = new System.Drawing.Point(294, 40);
            this.labelMOL1.Name = "labelMOL1";
            this.labelMOL1.Size = new System.Drawing.Size(48, 15);
            this.labelMOL1.TabIndex = 2;
            this.labelMOL1.Text = "МОЛ 1:";
            // 
            // labelProvider
            // 
            this.labelProvider.AutoSize = true;
            this.labelProvider.Location = new System.Drawing.Point(294, 107);
            this.labelProvider.Name = "labelProvider";
            this.labelProvider.Size = new System.Drawing.Size(75, 15);
            this.labelProvider.TabIndex = 3;
            this.labelProvider.Text = "Поставщик:";
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.Location = new System.Drawing.Point(294, 71);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(55, 15);
            this.labelStock.TabIndex = 4;
            this.labelStock.Text = "Склад 1:";
            // 
            // labelPodrazdel
            // 
            this.labelPodrazdel.AutoSize = true;
            this.labelPodrazdel.Location = new System.Drawing.Point(572, 107);
            this.labelPodrazdel.Name = "labelPodrazdel";
            this.labelPodrazdel.Size = new System.Drawing.Size(102, 15);
            this.labelPodrazdel.TabIndex = 5;
            this.labelPodrazdel.Text = "Подразделение:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(744, 398);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(109, 29);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxMOL
            // 
            this.comboBoxMOL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMOL.FormattingEnabled = true;
            this.comboBoxMOL.Location = new System.Drawing.Point(373, 37);
            this.comboBoxMOL.Name = "comboBoxMOL";
            this.comboBoxMOL.Size = new System.Drawing.Size(175, 21);
            this.comboBoxMOL.TabIndex = 10;
            // 
            // comboBoxProvider
            // 
            this.comboBoxProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProvider.FormattingEnabled = true;
            this.comboBoxProvider.Location = new System.Drawing.Point(373, 104);
            this.comboBoxProvider.Name = "comboBoxProvider";
            this.comboBoxProvider.Size = new System.Drawing.Size(175, 21);
            this.comboBoxProvider.TabIndex = 11;
            // 
            // comboBoxStock1
            // 
            this.comboBoxStock1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStock1.FormattingEnabled = true;
            this.comboBoxStock1.Location = new System.Drawing.Point(373, 68);
            this.comboBoxStock1.Name = "comboBoxStock1";
            this.comboBoxStock1.Size = new System.Drawing.Size(175, 21);
            this.comboBoxStock1.TabIndex = 12;
            // 
            // comboBoxPodrazdel
            // 
            this.comboBoxPodrazdel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPodrazdel.FormattingEnabled = true;
            this.comboBoxPodrazdel.Location = new System.Drawing.Point(678, 104);
            this.comboBoxPodrazdel.Name = "comboBoxPodrazdel";
            this.comboBoxPodrazdel.Size = new System.Drawing.Size(175, 21);
            this.comboBoxPodrazdel.TabIndex = 13;
            // 
            // comboBoxTypeOperation
            // 
            this.comboBoxTypeOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeOperation.FormattingEnabled = true;
            this.comboBoxTypeOperation.Items.AddRange(new object[] {
            "Поступление материалов",
            "Перемещение материалов",
            "Отпуск материалов"});
            this.comboBoxTypeOperation.Location = new System.Drawing.Point(128, 71);
            this.comboBoxTypeOperation.Name = "comboBoxTypeOperation";
            this.comboBoxTypeOperation.Size = new System.Drawing.Size(160, 21);
            this.comboBoxTypeOperation.TabIndex = 14;
            this.comboBoxTypeOperation.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypeOperation_SelectedIndexChanged);
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Location = new System.Drawing.Point(1, 406);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(92, 15);
            this.labelComment.TabIndex = 15;
            this.labelComment.Text = "Комментарий:";
            // 
            // textBoxComment
            // 
            this.textBoxComment.Location = new System.Drawing.Point(99, 406);
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(627, 20);
            this.textBoxComment.TabIndex = 16;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(410, 216);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(531, 148);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(113, 23);
            this.buttonUpdate.TabIndex = 19;
            this.buttonUpdate.Text = "Редактировать";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(531, 177);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(113, 23);
            this.buttonDel.TabIndex = 20;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // labelMOL2
            // 
            this.labelMOL2.AutoSize = true;
            this.labelMOL2.Location = new System.Drawing.Point(574, 40);
            this.labelMOL2.Name = "labelMOL2";
            this.labelMOL2.Size = new System.Drawing.Size(48, 15);
            this.labelMOL2.TabIndex = 21;
            this.labelMOL2.Text = "МОЛ 2:";
            // 
            // comboBoxMOL2
            // 
            this.comboBoxMOL2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMOL2.FormattingEnabled = true;
            this.comboBoxMOL2.Location = new System.Drawing.Point(678, 37);
            this.comboBoxMOL2.Name = "comboBoxMOL2";
            this.comboBoxMOL2.Size = new System.Drawing.Size(175, 21);
            this.comboBoxMOL2.TabIndex = 22;
            // 
            // comboBoxStock2
            // 
            this.comboBoxStock2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStock2.FormattingEnabled = true;
            this.comboBoxStock2.Location = new System.Drawing.Point(678, 71);
            this.comboBoxStock2.Name = "comboBoxStock2";
            this.comboBoxStock2.Size = new System.Drawing.Size(175, 21);
            this.comboBoxStock2.TabIndex = 23;
            // 
            // labelStock2
            // 
            this.labelStock2.AutoSize = true;
            this.labelStock2.Location = new System.Drawing.Point(574, 71);
            this.labelStock2.Name = "labelStock2";
            this.labelStock2.Size = new System.Drawing.Size(55, 15);
            this.labelStock2.TabIndex = 24;
            this.labelStock2.Text = "Склад 2:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(128, 40);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(160, 20);
            this.dateTimePicker1.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(734, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 47);
            this.button1.TabIndex = 26;
            this.button1.Text = "Отчистить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonRef);
            this.groupBox1.Controls.Add(this.comboBoxMaterial);
            this.groupBox1.Controls.Add(this.buttonAddMaterial);
            this.groupBox1.Controls.Add(this.textBoxSum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxCount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonDel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonUpdate);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(15, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 246);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Табличная часть";
            // 
            // buttonRef
            // 
            this.buttonRef.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRef.BackgroundImage")));
            this.buttonRef.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRef.Location = new System.Drawing.Point(650, 79);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(40, 34);
            this.buttonRef.TabIndex = 26;
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // comboBoxMaterial
            // 
            this.comboBoxMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaterial.FormattingEnabled = true;
            this.comboBoxMaterial.Location = new System.Drawing.Point(506, 18);
            this.comboBoxMaterial.Name = "comboBoxMaterial";
            this.comboBoxMaterial.Size = new System.Drawing.Size(138, 21);
            this.comboBoxMaterial.TabIndex = 25;
            // 
            // buttonAddMaterial
            // 
            this.buttonAddMaterial.Location = new System.Drawing.Point(531, 119);
            this.buttonAddMaterial.Name = "buttonAddMaterial";
            this.buttonAddMaterial.Size = new System.Drawing.Size(113, 23);
            this.buttonAddMaterial.TabIndex = 23;
            this.buttonAddMaterial.Text = "Добавить";
            this.buttonAddMaterial.UseVisualStyleBackColor = true;
            this.buttonAddMaterial.Click += new System.EventHandler(this.buttonAddMaterial_Click);
            // 
            // textBoxSum
            // 
            this.textBoxSum.Enabled = false;
            this.textBoxSum.Location = new System.Drawing.Point(506, 87);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(138, 20);
            this.textBoxSum.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Сумма:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(506, 51);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(138, 20);
            this.textBoxCount.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Количество:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(427, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Материалы:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "Сумма операции:";
            // 
            // textBoxSumOperation
            // 
            this.textBoxSumOperation.Enabled = false;
            this.textBoxSumOperation.Location = new System.Drawing.Point(128, 107);
            this.textBoxSumOperation.Name = "textBoxSumOperation";
            this.textBoxSumOperation.Size = new System.Drawing.Size(138, 20);
            this.textBoxSumOperation.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "Номер операции:";
            // 
            // textBoxNumberOperation
            // 
            this.textBoxNumberOperation.Enabled = false;
            this.textBoxNumberOperation.Location = new System.Drawing.Point(126, 6);
            this.textBoxNumberOperation.Name = "textBoxNumberOperation";
            this.textBoxNumberOperation.Size = new System.Drawing.Size(40, 20);
            this.textBoxNumberOperation.TabIndex = 31;
            // 
            // FormAddJournalOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 441);
            this.Controls.Add(this.textBoxNumberOperation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxSumOperation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.labelStock2);
            this.Controls.Add(this.comboBoxStock2);
            this.Controls.Add(this.comboBoxMOL2);
            this.Controls.Add(this.labelMOL2);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.labelComment);
            this.Controls.Add(this.comboBoxTypeOperation);
            this.Controls.Add(this.comboBoxPodrazdel);
            this.Controls.Add(this.comboBoxStock1);
            this.Controls.Add(this.comboBoxProvider);
            this.Controls.Add(this.comboBoxMOL);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelPodrazdel);
            this.Controls.Add(this.labelStock);
            this.Controls.Add(this.labelProvider);
            this.Controls.Add(this.labelMOL1);
            this.Controls.Add(this.labelNumberOperation);
            this.Controls.Add(this.labelDateOperation);
            this.Name = "FormAddJournalOperation";
            this.Text = "Журнал операций";
            this.Load += new System.EventHandler(this.FormJournalOperation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDateOperation;
        private System.Windows.Forms.Label labelNumberOperation;
        private System.Windows.Forms.Label labelMOL1;
        private System.Windows.Forms.Label labelProvider;
        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.Label labelPodrazdel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxMOL;
        private System.Windows.Forms.ComboBox comboBoxProvider;
        private System.Windows.Forms.ComboBox comboBoxStock1;
        private System.Windows.Forms.ComboBox comboBoxPodrazdel;
        private System.Windows.Forms.ComboBox comboBoxTypeOperation;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Label labelMOL2;
        private System.Windows.Forms.ComboBox comboBoxMOL2;
        private System.Windows.Forms.ComboBox comboBoxStock2;
        private System.Windows.Forms.Label labelStock2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.ComboBox comboBoxMaterial;
        private System.Windows.Forms.Button buttonAddMaterial;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSumOperation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNumberOperation;
    }
}