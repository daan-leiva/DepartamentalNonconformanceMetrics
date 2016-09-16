namespace Departamental_non_conformance_metrics
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ncCountChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.monthlyDPPM_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.wc_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.printButton = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.CausedByYouDataGridview = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.totalDPPM = new System.Windows.Forms.Label();
            this.previousOpDatagridview = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.departmentListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ownerLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.leadLabel = new System.Windows.Forms.Label();
            this.owner2Label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.printFormButton = new System.Windows.Forms.Button();
            this.printNCButton = new System.Windows.Forms.Button();
            this.setGoalsButton = new System.Windows.Forms.Button();
            this.printWCDPPMMonthlyButton = new System.Windows.Forms.Button();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.workCenterListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.ncCountChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyDPPM_Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wc_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CausedByYouDataGridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previousOpDatagridview)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ncCountChart
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX2.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.ncCountChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ncCountChart.Legends.Add(legend1);
            this.ncCountChart.Location = new System.Drawing.Point(927, 142);
            this.ncCountChart.Name = "ncCountChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ncCountChart.Series.Add(series1);
            this.ncCountChart.Size = new System.Drawing.Size(692, 371);
            this.ncCountChart.TabIndex = 11;
            this.ncCountChart.Text = "chart3";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(643, 21);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.startDateTimePicker.TabIndex = 12;
            // 
            // monthlyDPPM_Chart
            // 
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX2.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY2.MajorGrid.Enabled = false;
            chartArea2.Name = "ChartArea1";
            this.monthlyDPPM_Chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.monthlyDPPM_Chart.Legends.Add(legend2);
            this.monthlyDPPM_Chart.Location = new System.Drawing.Point(927, 544);
            this.monthlyDPPM_Chart.Name = "monthlyDPPM_Chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.monthlyDPPM_Chart.Series.Add(series2);
            this.monthlyDPPM_Chart.Size = new System.Drawing.Size(692, 365);
            this.monthlyDPPM_Chart.TabIndex = 14;
            this.monthlyDPPM_Chart.Text = "chart4";
            // 
            // wc_chart
            // 
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX2.MajorGrid.Enabled = false;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.AxisY2.MajorGrid.Enabled = false;
            chartArea3.Name = "ChartArea1";
            this.wc_chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.wc_chart.Legends.Add(legend3);
            this.wc_chart.Location = new System.Drawing.Point(23, 628);
            this.wc_chart.Name = "wc_chart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.wc_chart.Series.Add(series3);
            this.wc_chart.Size = new System.Drawing.Size(876, 281);
            this.wc_chart.TabIndex = 17;
            this.wc_chart.Text = "chart1";
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(1271, 22);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(75, 23);
            this.printButton.TabIndex = 18;
            this.printButton.Text = "Print";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // CausedByYouDataGridview
            // 
            this.CausedByYouDataGridview.AllowUserToAddRows = false;
            this.CausedByYouDataGridview.AllowUserToDeleteRows = false;
            this.CausedByYouDataGridview.AllowUserToResizeColumns = false;
            this.CausedByYouDataGridview.AllowUserToResizeRows = false;
            this.CausedByYouDataGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CausedByYouDataGridview.DefaultCellStyle = dataGridViewCellStyle1;
            this.CausedByYouDataGridview.Location = new System.Drawing.Point(134, 149);
            this.CausedByYouDataGridview.MultiSelect = false;
            this.CausedByYouDataGridview.Name = "CausedByYouDataGridview";
            this.CausedByYouDataGridview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.CausedByYouDataGridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.CausedByYouDataGridview.Size = new System.Drawing.Size(765, 328);
            this.CausedByYouDataGridview.TabIndex = 19;
            this.CausedByYouDataGridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DPPMDataGridview_CellDoubleClick);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(665, 476);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 23);
            this.label3.TabIndex = 20;
            this.label3.Text = "Overall DPPM:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalDPPM
            // 
            this.totalDPPM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalDPPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDPPM.Location = new System.Drawing.Point(799, 476);
            this.totalDPPM.Name = "totalDPPM";
            this.totalDPPM.Size = new System.Drawing.Size(100, 23);
            this.totalDPPM.TabIndex = 21;
            // 
            // previousOpDatagridview
            // 
            this.previousOpDatagridview.AllowUserToAddRows = false;
            this.previousOpDatagridview.AllowUserToDeleteRows = false;
            this.previousOpDatagridview.AllowUserToResizeColumns = false;
            this.previousOpDatagridview.AllowUserToResizeRows = false;
            this.previousOpDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.previousOpDatagridview.DefaultCellStyle = dataGridViewCellStyle2;
            this.previousOpDatagridview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.previousOpDatagridview.Location = new System.Drawing.Point(134, 517);
            this.previousOpDatagridview.MultiSelect = false;
            this.previousOpDatagridview.Name = "previousOpDatagridview";
            this.previousOpDatagridview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.previousOpDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.previousOpDatagridview.Size = new System.Drawing.Size(765, 84);
            this.previousOpDatagridview.TabIndex = 22;
            this.previousOpDatagridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.previousOpDatagridview_CellDoubleClick);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 66);
            this.label6.TabIndex = 29;
            this.label6.Text = "Found At Subsequent Op";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 66);
            this.label4.TabIndex = 30;
            this.label4.Text = "Found By You";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 66);
            this.label5.TabIndex = 31;
            this.label5.Text = "Found At Customer";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 66);
            this.label7.TabIndex = 32;
            this.label7.Text = "Found At Quality";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 544);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 45);
            this.label1.TabIndex = 33;
            this.label1.Text = "Caused At Previous OP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // departmentListBox
            // 
            this.departmentListBox.FormattingEnabled = true;
            this.departmentListBox.Location = new System.Drawing.Point(23, 21);
            this.departmentListBox.Name = "departmentListBox";
            this.departmentListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.departmentListBox.Size = new System.Drawing.Size(137, 108);
            this.departmentListBox.TabIndex = 34;
            this.departmentListBox.SelectedIndexChanged += new System.EventHandler(this.departmentListBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Owner";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 20);
            this.label8.TabIndex = 37;
            this.label8.Text = "Lead";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 38;
            this.label9.Text = "Owner2";
            // 
            // ownerLabel
            // 
            this.ownerLabel.AutoSize = true;
            this.ownerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ownerLabel.Location = new System.Drawing.Point(159, 19);
            this.ownerLabel.Name = "ownerLabel";
            this.ownerLabel.Size = new System.Drawing.Size(19, 20);
            this.ownerLabel.TabIndex = 39;
            this.ownerLabel.Text = "--";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.leadLabel);
            this.groupBox1.Controls.Add(this.owner2Label);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.ownerLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(361, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 107);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process Info";
            // 
            // leadLabel
            // 
            this.leadLabel.AutoSize = true;
            this.leadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leadLabel.Location = new System.Drawing.Point(159, 79);
            this.leadLabel.Name = "leadLabel";
            this.leadLabel.Size = new System.Drawing.Size(19, 20);
            this.leadLabel.TabIndex = 41;
            this.leadLabel.Text = "--";
            // 
            // owner2Label
            // 
            this.owner2Label.AutoSize = true;
            this.owner2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.owner2Label.Location = new System.Drawing.Point(159, 49);
            this.owner2Label.Name = "owner2Label";
            this.owner2Label.Size = new System.Drawing.Size(19, 20);
            this.owner2Label.TabIndex = 40;
            this.owner2Label.Text = "--";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1500, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // printFormButton
            // 
            this.printFormButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printFormButton.Location = new System.Drawing.Point(643, 90);
            this.printFormButton.Name = "printFormButton";
            this.printFormButton.Size = new System.Drawing.Size(164, 36);
            this.printFormButton.TabIndex = 41;
            this.printFormButton.Text = "Print DPPM Form";
            this.printFormButton.UseVisualStyleBackColor = true;
            this.printFormButton.Click += new System.EventHandler(this.printFormButton_Click);
            // 
            // printNCButton
            // 
            this.printNCButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printNCButton.Location = new System.Drawing.Point(824, 90);
            this.printNCButton.Name = "printNCButton";
            this.printNCButton.Size = new System.Drawing.Size(164, 36);
            this.printNCButton.TabIndex = 42;
            this.printNCButton.Text = "Print NC Form";
            this.printNCButton.UseVisualStyleBackColor = true;
            this.printNCButton.Click += new System.EventHandler(this.printNCFormButton_Click);
            // 
            // setGoalsButton
            // 
            this.setGoalsButton.Location = new System.Drawing.Point(913, 21);
            this.setGoalsButton.Name = "setGoalsButton";
            this.setGoalsButton.Size = new System.Drawing.Size(75, 23);
            this.setGoalsButton.TabIndex = 43;
            this.setGoalsButton.Text = "Set Goals";
            this.setGoalsButton.UseVisualStyleBackColor = true;
            this.setGoalsButton.Click += new System.EventHandler(this.setGoalsButton_Click);
            // 
            // printWCDPPMMonthlyButton
            // 
            this.printWCDPPMMonthlyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printWCDPPMMonthlyButton.Location = new System.Drawing.Point(1006, 90);
            this.printWCDPPMMonthlyButton.Name = "printWCDPPMMonthlyButton";
            this.printWCDPPMMonthlyButton.Size = new System.Drawing.Size(202, 36);
            this.printWCDPPMMonthlyButton.TabIndex = 44;
            this.printWCDPPMMonthlyButton.Text = "Print WC Monthly DPPM";
            this.printWCDPPMMonthlyButton.UseVisualStyleBackColor = true;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(643, 48);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endDateTimePicker.TabIndex = 45;
            // 
            // workCenterListBox
            // 
            this.workCenterListBox.FormattingEnabled = true;
            this.workCenterListBox.Location = new System.Drawing.Point(185, 21);
            this.workCenterListBox.Name = "workCenterListBox";
            this.workCenterListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.workCenterListBox.Size = new System.Drawing.Size(154, 108);
            this.workCenterListBox.TabIndex = 46;
            this.workCenterListBox.SelectedIndexChanged += new System.EventHandler(this.workCenterListBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1631, 930);
            this.Controls.Add(this.workCenterListBox);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.printWCDPPMMonthlyButton);
            this.Controls.Add(this.setGoalsButton);
            this.Controls.Add(this.printNCButton);
            this.Controls.Add(this.printFormButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.departmentListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.previousOpDatagridview);
            this.Controls.Add(this.totalDPPM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CausedByYouDataGridview);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.wc_chart);
            this.Controls.Add(this.monthlyDPPM_Chart);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.ncCountChart);
            this.Name = "MainForm";
            this.Text = "DPPM";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ncCountChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyDPPM_Chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wc_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CausedByYouDataGridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previousOpDatagridview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ncCountChart;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DataVisualization.Charting.Chart monthlyDPPM_Chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart wc_chart;
        private System.Windows.Forms.Button printButton;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridView CausedByYouDataGridview;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalDPPM;
        private System.Windows.Forms.DataGridView previousOpDatagridview;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox departmentListBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label ownerLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label leadLabel;
        private System.Windows.Forms.Label owner2Label;
        private System.Windows.Forms.Button printFormButton;
        private System.Windows.Forms.Button printNCButton;
        private System.Windows.Forms.Button setGoalsButton;
        private System.Windows.Forms.Button printWCDPPMMonthlyButton;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.ListBox workCenterListBox;
    }
}

