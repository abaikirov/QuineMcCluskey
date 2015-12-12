namespace QM
{
    partial class countForm
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
            this.textBoxNumbs = new System.Windows.Forms.TextBox();
            this.buttonKPI = new System.Windows.Forms.Button();
            this.buttonMinTable = new System.Windows.Forms.Button();
            this.buttonCount = new System.Windows.Forms.Button();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.richTextBoxResult = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBoxNumbs
            // 
            this.textBoxNumbs.Location = new System.Drawing.Point(339, 57);
            this.textBoxNumbs.Name = "textBoxNumbs";
            this.textBoxNumbs.Size = new System.Drawing.Size(203, 20);
            this.textBoxNumbs.TabIndex = 0;
            // 
            // buttonKPI
            // 
            this.buttonKPI.Location = new System.Drawing.Point(39, 134);
            this.buttonKPI.Name = "buttonKPI";
            this.buttonKPI.Size = new System.Drawing.Size(75, 23);
            this.buttonKPI.TabIndex = 1;
            this.buttonKPI.Text = "buttonKPI";
            this.buttonKPI.UseVisualStyleBackColor = true;
            // 
            // buttonMinTable
            // 
            this.buttonMinTable.Location = new System.Drawing.Point(120, 134);
            this.buttonMinTable.Name = "buttonMinTable";
            this.buttonMinTable.Size = new System.Drawing.Size(75, 23);
            this.buttonMinTable.TabIndex = 2;
            this.buttonMinTable.Text = "buttonMinTable";
            this.buttonMinTable.UseVisualStyleBackColor = true;
            // 
            // buttonCount
            // 
            this.buttonCount.Location = new System.Drawing.Point(201, 134);
            this.buttonCount.Name = "buttonCount";
            this.buttonCount.Size = new System.Drawing.Size(75, 23);
            this.buttonCount.TabIndex = 3;
            this.buttonCount.Text = "buttonCount";
            this.buttonCount.UseVisualStyleBackColor = true;
            this.buttonCount.Click += new System.EventHandler(this.buttonCount_Click);
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(251, 60);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(51, 13);
            this.labelStart.TabIndex = 7;
            this.labelStart.Text = "labelStart";
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Location = new System.Drawing.Point(573, 60);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(48, 13);
            this.labelEnd.TabIndex = 8;
            this.labelEnd.Text = "labelEnd";
            // 
            // richTextBoxResult
            // 
            this.richTextBoxResult.Location = new System.Drawing.Point(39, 178);
            this.richTextBoxResult.Name = "richTextBoxResult";
            this.richTextBoxResult.Size = new System.Drawing.Size(682, 149);
            this.richTextBoxResult.TabIndex = 9;
            this.richTextBoxResult.Text = "";
            // 
            // countForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 353);
            this.Controls.Add(this.richTextBoxResult);
            this.Controls.Add(this.labelEnd);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.buttonCount);
            this.Controls.Add(this.buttonMinTable);
            this.Controls.Add(this.buttonKPI);
            this.Controls.Add(this.textBoxNumbs);
            this.Name = "countForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNumbs;
        private System.Windows.Forms.Button buttonKPI;
        private System.Windows.Forms.Button buttonMinTable;
        private System.Windows.Forms.Button buttonCount;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.RichTextBox richTextBoxResult;
    }
}

