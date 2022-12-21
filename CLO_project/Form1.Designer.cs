using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System;
using System.ComponentModel;
namespace CLO_project
{
    partial class Form1
    {
        public List<TextBox> listText;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            ChartArea chartArea1 = new ChartArea();
            Series series1 = new Series();
            this.components = new Container();
            this.CellsButton = new Button();
            this.label1 = new Label();
            this.MadeBy = new Label();
            this.chart1 = new Chart();
            this.saveFileDialog1 = new SaveFileDialog();
            this.openFileDialog1 = new OpenFileDialog();
            listText = new List<TextBox>();
            this.btn = new Button();
            this.Division = new Label();
            this.toolTip1 = new ToolTip(this.components);
            this.Instruction = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            //
            // Instruction
            //
            this.Instruction.BackColor = SystemColors.Window;
            this.Instruction.FlatStyle = FlatStyle.Popup;
            this.Instruction.Font = new Font("Liberation Mono", 8.25F, FontStyle.Bold);
            this.Instruction.Location = new Point(1380, 54);
            this.Instruction.Name = "Instruction";
            this.Instruction.Size = new Size(250, 45);
            this.Instruction.TabIndex = 0;
            this.Instruction.Text = "Руководство";
            this.Instruction.UseVisualStyleBackColor = false;
            this.Instruction.Click += new EventHandler(this.Instruction_Click);
            // 
            // CellsButton
            // 
            this.CellsButton.BackColor = SystemColors.Window;
            this.CellsButton.FlatStyle = FlatStyle.Popup;
            this.CellsButton.Font = new Font("Liberation Mono", 8.25F, FontStyle.Bold);
            this.CellsButton.Location = new Point(12, 54);
            this.CellsButton.Name = "CellsButton";
            this.CellsButton.Size = new Size(308, 45);
            this.CellsButton.TabIndex = 0;
            this.CellsButton.Text = "Выбрать файл и загрузить данные в таблицу";
            this.CellsButton.UseVisualStyleBackColor = false;
            this.CellsButton.Click += new EventHandler(this.CellsButton_Click);
            this.CellsButton.MouseHover += new EventHandler(this.ShowHelp1);
            //
            //btn
            //
            this.btn.FlatStyle = FlatStyle.Popup;
            this.btn.BackColor = SystemColors.Window;
            this.btn.Size = new Size(208, 45);
            this.btn.Location = new Point(860, 54);
            this.btn.TabIndex = 2;
            this.btn.Name = "btn_SaveNewFile";
            this.btn.Text = "Сохранить файл";
            this.btn.Font = new Font("Liberation Mono", 8.25F, FontStyle.Bold);
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new EventHandler(this.btn_SaveNewFile_Click);
            this.btn.MouseHover += new EventHandler(this.ShowHelp2);
            //
            //listText
            //
            int k = 0;
            for (int i = 0; i < 100; i++)
            {
                var tb = new TextBox();
                tb.Name = "textBox" + i;
                tb.Size = new Size(56, 20);

                int y = 80 + i / 10 * 39;
                if (k % 10 == 0)
                {
                    k = 0;
                }
                int x = 80 + k * (74 + 5);
                tb.Location = new Point(x + 780, y + 32);
                tb.TabIndex = i + 3;

                listText.Add(tb);
                this.Controls.Add(tb);
                k++;
                tb.KeyDown += new KeyEventHandler(TB_PressEnter);
                tb.MaxLength = 4;
            }
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Liberation Mono", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(255, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Конфигуратор CLO";
            // 
            // MadeBy
            // 
            this.MadeBy.AutoSize = true;
            this.MadeBy.Font = new System.Drawing.Font("Liberation Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MadeBy.ForeColor = System.Drawing.Color.Black;
            this.MadeBy.Location = new System.Drawing.Point(12, 500);
            this.MadeBy.Name = "MadeBy";
            this.MadeBy.Size = new System.Drawing.Size(200, 20);
            this.MadeBy.TabIndex = 1;
            this.MadeBy.Text = "Разработано лабораторией";
            // 
            // Division
            // 
            this.Division.AutoSize = true;
            this.Division.Font = new System.Drawing.Font("Liberation Mono", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Division.ForeColor = System.Drawing.Color.Black;
            this.Division.Location = new System.Drawing.Point(243, 500);
            this.Division.Name = "Division";
            this.Division.Size = new System.Drawing.Size(50, 20);
            this.Division.TabIndex = 1;
            this.Division.Text = "DIVISION";
            // 
            // chart1
            // 
            chartArea1.AxisX.Maximum = 100D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX2.Maximum = 100D;
            chartArea1.AxisX2.Minimum = 0D;
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.AxisY.Minimum = 0.2D;
            chartArea1.AxisY2.Maximum = 1D;
            chartArea1.AxisY2.Minimum = 0.2D;
            chartArea1.Name = "ChartArea1";
            chartArea1.AxisX.Title = "Время эксплуатации (месяцы)";
            chartArea1.AxisY.Title = "Коээфициент";
            chartArea1.AxisY.Interval = 0.2;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(12, 112);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            series1.MarkerStep = 2;
            series1.Name = "Series1";
            series1.ToolTip = "#VALX{N1} #VAL{N3}";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(776, 371);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1657, 545);
            this.MinimumSize = new Size(1657, 575);
            this.MaximumSize = new Size(1657, 575);
            this.MaximizeBox = false;
            this.MouseClick += new MouseEventHandler(this.Form1_MouseClick);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MadeBy);
            this.Controls.Add(this.CellsButton);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.Division);
            this.Controls.Add(this.Instruction);
            this.Name = "ConfigCLO";
            this.Text = "Конфигуратор CLO";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion

        private Button CellsButton;
        private Button Instruction;
        private Label label1;
        private Chart chart1;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private Button btn;
        private ToolTip toolTip1;
        private Label MadeBy;
        private Label Division;
    }
}

