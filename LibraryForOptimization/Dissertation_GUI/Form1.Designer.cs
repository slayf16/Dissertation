namespace Dissertation_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьИзExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ограниченияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.характеристикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.stationLimitModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gesNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodStartDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodFinishDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limitNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limitTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limitValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stationLimitModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(36, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Исходные параметры ГЭС";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(534, 177);
            this.dataGridView1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(39, 236);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(807, 224);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Исходные параметры по ограничениям ГЭС";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gesNameDataGridViewTextBoxColumn,
            this.periodStartDataGridViewTextBoxColumn,
            this.periodFinishDataGridViewTextBoxColumn,
            this.limitNameDataGridViewTextBoxColumn,
            this.limitTypeDataGridViewTextBoxColumn,
            this.limitValueDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.stationLimitModelBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 18);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(801, 203);
            this.dataGridView2.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new System.Drawing.Point(777, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(162, 189);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры расчета";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 155);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 22);
            this.textBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Количество ГЭС";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 102);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название каскада";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 58);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(106, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Каскад ГЭС";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 31);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(94, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Одна ГЭС";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(864, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(989, 30);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьИзExcelToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // загрузитьИзExcelToolStripMenuItem
            // 
            this.загрузитьИзExcelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ограниченияToolStripMenuItem,
            this.характеристикиToolStripMenuItem});
            this.загрузитьИзExcelToolStripMenuItem.Name = "загрузитьИзExcelToolStripMenuItem";
            this.загрузитьИзExcelToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.загрузитьИзExcelToolStripMenuItem.Text = "Загрузить из Excel";
            // 
            // ограниченияToolStripMenuItem
            // 
            this.ограниченияToolStripMenuItem.Name = "ограниченияToolStripMenuItem";
            this.ограниченияToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.ограниченияToolStripMenuItem.Text = "Ограничения";
            this.ограниченияToolStripMenuItem.Click += new System.EventHandler(this.ограниченияToolStripMenuItem_Click);
            // 
            // характеристикиToolStripMenuItem
            // 
            this.характеристикиToolStripMenuItem.Name = "характеристикиToolStripMenuItem";
            this.характеристикиToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.характеристикиToolStripMenuItem.Text = "Характеристики";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // stationLimitModelBindingSource
            // 
            this.stationLimitModelBindingSource.DataSource = typeof(LibraryForOptimization.Excel.structureForExcel.StationLimitModel);
            // 
            // gesNameDataGridViewTextBoxColumn
            // 
            this.gesNameDataGridViewTextBoxColumn.DataPropertyName = "GesName";
            this.gesNameDataGridViewTextBoxColumn.HeaderText = "ГЭС";
            this.gesNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.gesNameDataGridViewTextBoxColumn.Name = "gesNameDataGridViewTextBoxColumn";
            this.gesNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // periodStartDataGridViewTextBoxColumn
            // 
            this.periodStartDataGridViewTextBoxColumn.DataPropertyName = "PeriodStart";
            this.periodStartDataGridViewTextBoxColumn.HeaderText = "Начало периода";
            this.periodStartDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.periodStartDataGridViewTextBoxColumn.Name = "periodStartDataGridViewTextBoxColumn";
            this.periodStartDataGridViewTextBoxColumn.Width = 125;
            // 
            // periodFinishDataGridViewTextBoxColumn
            // 
            this.periodFinishDataGridViewTextBoxColumn.DataPropertyName = "PeriodFinish";
            this.periodFinishDataGridViewTextBoxColumn.HeaderText = "Конец периода";
            this.periodFinishDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.periodFinishDataGridViewTextBoxColumn.Name = "periodFinishDataGridViewTextBoxColumn";
            this.periodFinishDataGridViewTextBoxColumn.Width = 125;
            // 
            // limitNameDataGridViewTextBoxColumn
            // 
            this.limitNameDataGridViewTextBoxColumn.DataPropertyName = "LimitName";
            this.limitNameDataGridViewTextBoxColumn.HeaderText = "Ограничение";
            this.limitNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.limitNameDataGridViewTextBoxColumn.Name = "limitNameDataGridViewTextBoxColumn";
            this.limitNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // limitTypeDataGridViewTextBoxColumn
            // 
            this.limitTypeDataGridViewTextBoxColumn.DataPropertyName = "LimitType";
            this.limitTypeDataGridViewTextBoxColumn.HeaderText = "Тип ограничения";
            this.limitTypeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.limitTypeDataGridViewTextBoxColumn.Name = "limitTypeDataGridViewTextBoxColumn";
            this.limitTypeDataGridViewTextBoxColumn.Width = 125;
            // 
            // limitValueDataGridViewTextBoxColumn
            // 
            this.limitValueDataGridViewTextBoxColumn.DataPropertyName = "LimitValue";
            this.limitValueDataGridViewTextBoxColumn.HeaderText = "Значение";
            this.limitValueDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.limitValueDataGridViewTextBoxColumn.Name = "limitValueDataGridViewTextBoxColumn";
            this.limitValueDataGridViewTextBoxColumn.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 540);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stationLimitModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьИзExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ограниченияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem характеристикиToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.BindingSource stationLimitModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn gesNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodStartDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodFinishDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn limitNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn limitTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn limitValueDataGridViewTextBoxColumn;
    }
}

