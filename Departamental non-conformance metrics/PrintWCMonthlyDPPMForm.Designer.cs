namespace Departamental_non_conformance_metrics
{
    partial class PrintWCMonthlyDPPMForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.printButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.departmentsLabel = new System.Windows.Forms.Label();
            this.dppmSummaryDataGridview = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dppmSummaryDataGridview)).BeginInit();
            this.SuspendLayout();
            // 
            // printButton
            // 
            this.printButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printButton.Location = new System.Drawing.Point(706, 69);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(106, 35);
            this.printButton.TabIndex = 12;
            this.printButton.Text = "Print";
            this.printButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 25);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(381, 33);
            this.label1.TabIndex = 11;
            this.label1.Text = "Monthly WC DPPM Report";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(25, 77);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(46, 18);
            this.dateLabel.TabIndex = 13;
            this.dateLabel.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(183, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Departments:";
            // 
            // departmentsLabel
            // 
            this.departmentsLabel.AutoSize = true;
            this.departmentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmentsLabel.Location = new System.Drawing.Point(295, 77);
            this.departmentsLabel.Name = "departmentsLabel";
            this.departmentsLabel.Size = new System.Drawing.Size(46, 18);
            this.departmentsLabel.TabIndex = 15;
            this.departmentsLabel.Text = "label4";
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dppmSummaryDataGridview.DefaultCellStyle = dataGridViewCellStyle3;
            this.dppmSummaryDataGridview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dppmSummaryDataGridview.Location = new System.Drawing.Point(73, 138);
            this.dppmSummaryDataGridview.Name = "dppmSummaryDataGridview";
            this.dppmSummaryDataGridview.ReadOnly = true;
            this.dppmSummaryDataGridview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dppmSummaryDataGridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dppmSummaryDataGridview.Size = new System.Drawing.Size(668, 737);
            this.dppmSummaryDataGridview.TabIndex = 17;
            // 
            // PrintWCMonthlyDPPMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(858, 959);
            this.Controls.Add(this.dppmSummaryDataGridview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.departmentsLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.label1);
            this.Name = "PrintWCMonthlyDPPMForm";
            this.Text = "PrintWCMonthlyDPPMForm";
            this.Load += new System.EventHandler(this.PrintWCMonthlyDPPMForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dppmSummaryDataGridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label departmentsLabel;
        private System.Windows.Forms.DataGridView dppmSummaryDataGridview;
    }
}