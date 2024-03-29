﻿namespace TPIS
{
    partial class FormReport
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonPDF = new System.Windows.Forms.Button();
            this.comboBoxTypeOperation = new System.Windows.Forms.ComboBox();
            this.labelNumberOperation = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxStock = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSaveDoc = new System.Windows.Forms.Button();
            this.buttonSaveXls = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранениеВАрхивToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(143, 66);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(160, 20);
            this.dateTimePicker1.TabIndex = 26;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(336, 66);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(160, 20);
            this.dateTimePicker2.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 28;
            this.label1.Text = "Выберите период  с";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "по";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(514, 63);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(115, 23);
            this.buttonCreate.TabIndex = 30;
            this.buttonCreate.Text = "Сформировать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonPDF
            // 
            this.buttonPDF.Location = new System.Drawing.Point(656, 28);
            this.buttonPDF.Name = "buttonPDF";
            this.buttonPDF.Size = new System.Drawing.Size(115, 23);
            this.buttonPDF.TabIndex = 31;
            this.buttonPDF.Text = "Сохранить в PDF";
            this.buttonPDF.UseVisualStyleBackColor = true;
            this.buttonPDF.Click += new System.EventHandler(this.buttonPDF_Click);
            // 
            // comboBoxTypeOperation
            // 
            this.comboBoxTypeOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeOperation.FormattingEnabled = true;
            this.comboBoxTypeOperation.Items.AddRange(new object[] {
            "Поступление материалов",
            "Остатки материалов на складе",
            "Отпуск материалов"});
            this.comboBoxTypeOperation.Location = new System.Drawing.Point(95, 33);
            this.comboBoxTypeOperation.Name = "comboBoxTypeOperation";
            this.comboBoxTypeOperation.Size = new System.Drawing.Size(176, 21);
            this.comboBoxTypeOperation.TabIndex = 33;
            // 
            // labelNumberOperation
            // 
            this.labelNumberOperation.AutoSize = true;
            this.labelNumberOperation.Location = new System.Drawing.Point(14, 36);
            this.labelNumberOperation.Name = "labelNumberOperation";
            this.labelNumberOperation.Size = new System.Drawing.Size(75, 15);
            this.labelNumberOperation.TabIndex = 32;
            this.labelNumberOperation.Text = "Тип отчета:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "Склад/подразделение:";
            // 
            // comboBoxStock
            // 
            this.comboBoxStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStock.FormattingEnabled = true;
            this.comboBoxStock.Location = new System.Drawing.Point(444, 33);
            this.comboBoxStock.Name = "comboBoxStock";
            this.comboBoxStock.Size = new System.Drawing.Size(160, 21);
            this.comboBoxStock.TabIndex = 35;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(776, 265);
            this.dataGridView1.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(509, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 25);
            this.label4.TabIndex = 37;
            this.label4.Text = "Итого:";
            // 
            // buttonSaveDoc
            // 
            this.buttonSaveDoc.Location = new System.Drawing.Point(656, 57);
            this.buttonSaveDoc.Name = "buttonSaveDoc";
            this.buttonSaveDoc.Size = new System.Drawing.Size(115, 23);
            this.buttonSaveDoc.TabIndex = 38;
            this.buttonSaveDoc.Text = "Сохранить в doc";
            this.buttonSaveDoc.UseVisualStyleBackColor = true;
            this.buttonSaveDoc.Click += new System.EventHandler(this.buttonSaveDoc_Click);
            // 
            // buttonSaveXls
            // 
            this.buttonSaveXls.Location = new System.Drawing.Point(656, 86);
            this.buttonSaveXls.Name = "buttonSaveXls";
            this.buttonSaveXls.Size = new System.Drawing.Size(115, 23);
            this.buttonSaveXls.TabIndex = 39;
            this.buttonSaveXls.Text = "Сохранить в xls";
            this.buttonSaveXls.UseVisualStyleBackColor = true;
            this.buttonSaveXls.Click += new System.EventHandler(this.buttonSaveXls_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранениеВАрхивToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 40;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сохранениеВАрхивToolStripMenuItem
            // 
            this.сохранениеВАрхивToolStripMenuItem.Name = "сохранениеВАрхивToolStripMenuItem";
            this.сохранениеВАрхивToolStripMenuItem.Size = new System.Drawing.Size(148, 23);
            this.сохранениеВАрхивToolStripMenuItem.Text = "Сохранение в архив";
            this.сохранениеВАрхивToolStripMenuItem.Click += new System.EventHandler(this.сохранениеВАрхивToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 41;
            this.label5.Text = "Email:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(62, 397);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(176, 20);
            this.textBoxEmail.TabIndex = 42;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 424);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonSaveXls);
            this.Controls.Add(this.buttonSaveDoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBoxStock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxTypeOperation);
            this.Controls.Add(this.labelNumberOperation);
            this.Controls.Add(this.buttonPDF);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormReport";
            this.Text = "Отчеты";
            this.Load += new System.EventHandler(this.FormReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonPDF;
        private System.Windows.Forms.ComboBox comboBoxTypeOperation;
        private System.Windows.Forms.Label labelNumberOperation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxStock;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSaveDoc;
        private System.Windows.Forms.Button buttonSaveXls;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранениеВАрхивToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEmail;
    }
}