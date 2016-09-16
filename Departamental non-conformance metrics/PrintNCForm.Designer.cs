namespace Departamental_non_conformance_metrics
{
    partial class PrintNCForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.ncSummaryDataGridview = new System.Windows.Forms.DataGridView();
            this.printButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ncSummaryDataGridview)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(346, 26);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(138, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "NC Summary";
            // 
            // ncSummaryDataGridview
            // 
            this.ncSummaryDataGridview.AllowUserToAddRows = false;
            this.ncSummaryDataGridview.AllowUserToDeleteRows = false;
            this.ncSummaryDataGridview.AllowUserToResizeColumns = false;
            this.ncSummaryDataGridview.AllowUserToResizeRows = false;
            this.ncSummaryDataGridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ncSummaryDataGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ncSummaryDataGridview.Location = new System.Drawing.Point(35, 76);
            this.ncSummaryDataGridview.Name = "ncSummaryDataGridview";
            this.ncSummaryDataGridview.ReadOnly = true;
            this.ncSummaryDataGridview.RowHeadersVisible = false;
            this.ncSummaryDataGridview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.ncSummaryDataGridview.Size = new System.Drawing.Size(780, 833);
            this.ncSummaryDataGridview.TabIndex = 8;
            // 
            // printButton
            // 
            this.printButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printButton.Location = new System.Drawing.Point(675, 23);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(106, 35);
            this.printButton.TabIndex = 11;
            this.printButton.Text = "Print";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click_1);
            // 
            // PrintNCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 935);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ncSummaryDataGridview);
            this.Name = "PrintNCForm";
            this.Text = "PrintNCForm";
            this.Load += new System.EventHandler(this.PrintNCForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ncSummaryDataGridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView ncSummaryDataGridview;
        private System.Windows.Forms.Button printButton;
    }
}