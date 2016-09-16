namespace Departamental_non_conformance_metrics
{
    partial class PrintDPPMForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dppmChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.dppmSummaryDataGridview = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.wcChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateLabel = new System.Windows.Forms.Label();
            this.printButton = new System.Windows.Forms.Button();
            this.departmentsLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.totalDPPMLabel = new System.Windows.Forms.Label();
            this.dppmTitleLabel = new System.Windows.Forms.Label();
            this.goalDppmLabel = new System.Windows.Forms.Label();
            this.goalDPPMTitleLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dppmChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dppmSummaryDataGridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wcChart)).BeginInit();
            this.SuspendLayout();
            // 
            // dppmChart
            // 
            this.dppmChart.BorderlineColor = System.Drawing.Color.Black;
            this.dppmChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.dppmChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.dppmChart.Legends.Add(legend1);
            this.dppmChart.Location = new System.Drawing.Point(25, 128);
            this.dppmChart.Name = "dppmChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.dppmChart.Series.Add(series1);
            this.dppmChart.Size = new System.Drawing.Size(793, 304);
            this.dppmChart.TabIndex = 0;
            this.dppmChart.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(309, 18);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(204, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "DPPM Report";
            // 
            // dppmSummaryDataGridview
            // 
            this.dppmSummaryDataGridview.AllowUserToAddRows = false;
            this.dppmSummaryDataGridview.AllowUserToDeleteRows = false;
            this.dppmSummaryDataGridview.AllowUserToResizeColumns = false;
            this.dppmSummaryDataGridview.AllowUserToResizeRows = false;
            this.dppmSummaryDataGridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dppmSummaryDataGridview.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dppmSummaryDataGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dppmSummaryDataGridview.DefaultCellStyle = dataGridViewCellStyle1;
            this.dppmSummaryDataGridview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dppmSummaryDataGridview.Location = new System.Drawing.Point(200, 783);
            this.dppmSummaryDataGridview.Name = "dppmSummaryDataGridview";
            this.dppmSummaryDataGridview.ReadOnly = true;
            this.dppmSummaryDataGridview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dppmSummaryDataGridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dppmSummaryDataGridview.Size = new System.Drawing.Size(470, 125);
            this.dppmSummaryDataGridview.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(334, 752);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(169, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "DPPM Summary";
            // 
            // wcChart
            // 
            this.wcChart.BorderlineColor = System.Drawing.Color.Black;
            this.wcChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.wcChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.wcChart.Legends.Add(legend2);
            this.wcChart.Location = new System.Drawing.Point(25, 440);
            this.wcChart.Name = "wcChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.wcChart.Series.Add(series2);
            this.wcChart.Size = new System.Drawing.Size(793, 304);
            this.wcChart.TabIndex = 8;
            this.wcChart.Text = "chart2";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(38, 69);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(46, 18);
            this.dateLabel.TabIndex = 9;
            this.dateLabel.Text = "label4";
            // 
            // printButton
            // 
            this.printButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printButton.Location = new System.Drawing.Point(667, 42);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(106, 35);
            this.printButton.TabIndex = 10;
            this.printButton.Text = "Print";
            this.printButton.UseVisualStyleBackColor = true;
            // 
            // departmentsLabel
            // 
            this.departmentsLabel.AutoSize = true;
            this.departmentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmentsLabel.Location = new System.Drawing.Point(382, 69);
            this.departmentsLabel.Name = "departmentsLabel";
            this.departmentsLabel.Size = new System.Drawing.Size(46, 18);
            this.departmentsLabel.TabIndex = 11;
            this.departmentsLabel.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(270, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Departments:";
            // 
            // totalDPPMLabel
            // 
            this.totalDPPMLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalDPPMLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDPPMLabel.Location = new System.Drawing.Point(570, 907);
            this.totalDPPMLabel.Name = "totalDPPMLabel";
            this.totalDPPMLabel.Size = new System.Drawing.Size(100, 23);
            this.totalDPPMLabel.TabIndex = 23;
            // 
            // dppmTitleLabel
            // 
            this.dppmTitleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dppmTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dppmTitleLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dppmTitleLabel.Location = new System.Drawing.Point(436, 907);
            this.dppmTitleLabel.Name = "dppmTitleLabel";
            this.dppmTitleLabel.Size = new System.Drawing.Size(135, 23);
            this.dppmTitleLabel.TabIndex = 22;
            this.dppmTitleLabel.Text = "Total DPPM:";
            this.dppmTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // goalDppmLabel
            // 
            this.goalDppmLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.goalDppmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goalDppmLabel.Location = new System.Drawing.Point(570, 929);
            this.goalDppmLabel.Name = "goalDppmLabel";
            this.goalDppmLabel.Size = new System.Drawing.Size(100, 23);
            this.goalDppmLabel.TabIndex = 25;
            // 
            // goalDPPMTitleLabel
            // 
            this.goalDPPMTitleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.goalDPPMTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goalDPPMTitleLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.goalDPPMTitleLabel.Location = new System.Drawing.Point(436, 929);
            this.goalDPPMTitleLabel.Name = "goalDPPMTitleLabel";
            this.goalDPPMTitleLabel.Size = new System.Drawing.Size(135, 23);
            this.goalDPPMTitleLabel.TabIndex = 24;
            this.goalDPPMTitleLabel.Text = "Goal DPPM:";
            this.goalDPPMTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(406, 470);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "label4";
            // 
            // PrintDPPMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(858, 959);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.goalDppmLabel);
            this.Controls.Add(this.goalDPPMTitleLabel);
            this.Controls.Add(this.totalDPPMLabel);
            this.Controls.Add(this.dppmTitleLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.departmentsLabel);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.wcChart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dppmSummaryDataGridview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dppmChart);
            this.Name = "PrintDPPMForm";
            this.Text = "PrintForm";
            this.Load += new System.EventHandler(this.PrintForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dppmChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dppmSummaryDataGridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wcChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart dppmChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dppmSummaryDataGridview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart wcChart;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Label departmentsLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalDPPMLabel;
        private System.Windows.Forms.Label dppmTitleLabel;
        private System.Windows.Forms.Label goalDppmLabel;
        private System.Windows.Forms.Label goalDPPMTitleLabel;
        private System.Windows.Forms.Label label4;
    }
}