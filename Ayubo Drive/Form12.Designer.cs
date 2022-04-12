namespace Ayubo_Drive
{
    partial class Form12
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form12));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comReturnDate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comRentedDate = new System.Windows.Forms.ComboBox();
            this.dataGV = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.CadetBlue;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comReturnDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comRentedDate);
            this.groupBox1.Controls.Add(this.dataGV);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(16, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 360);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Long Tour History";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "ReturnDate";
            // 
            // comReturnDate
            // 
            this.comReturnDate.FormattingEnabled = true;
            this.comReturnDate.Location = new System.Drawing.Point(464, 27);
            this.comReturnDate.Name = "comReturnDate";
            this.comReturnDate.Size = new System.Drawing.Size(169, 27);
            this.comReturnDate.TabIndex = 3;
            this.comReturnDate.SelectedIndexChanged += new System.EventHandler(this.comReturnDate_SelectedIndexChanged);
            this.comReturnDate.SelectionChangeCommitted += new System.EventHandler(this.comReturnDate_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rented Date";
            // 
            // comRentedDate
            // 
            this.comRentedDate.FormattingEnabled = true;
            this.comRentedDate.Location = new System.Drawing.Point(131, 27);
            this.comRentedDate.Name = "comRentedDate";
            this.comRentedDate.Size = new System.Drawing.Size(169, 27);
            this.comRentedDate.TabIndex = 1;
            this.comRentedDate.SelectionChangeCommitted += new System.EventHandler(this.comRentedDate_SelectionChangeCommitted);
            this.comRentedDate.SelectedValueChanged += new System.EventHandler(this.comRentedDate_SelectedValueChanged);
            // 
            // dataGV
            // 
            this.dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV.Location = new System.Drawing.Point(6, 66);
            this.dataGV.Name = "dataGV";
            this.dataGV.RowTemplate.Height = 25;
            this.dataGV.Size = new System.Drawing.Size(627, 288);
            this.dataGV.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Source Sans Pro", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(459, 583);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Solution by mayura_andrew";
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(670, 611);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Source Code Pro", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form12";
            this.Text = "Long Tour Calculation Hisotry";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private ComboBox comReturnDate;
        private Label label1;
        private ComboBox comRentedDate;
        private DataGridView dataGV;
        private Label label4;
    }
}