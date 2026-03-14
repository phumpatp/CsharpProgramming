namespace WindowsFormsApp2
{
    partial class frmMain
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
            this.txtBasePath = new System.Windows.Forms.TextBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBasePath
            // 
            this.txtBasePath.Location = new System.Drawing.Point(28, 25);
            this.txtBasePath.Name = "txtBasePath";
            this.txtBasePath.Size = new System.Drawing.Size(302, 20);
            this.txtBasePath.TabIndex = 0;
            this.txtBasePath.Text = "D:\\@Work\\@Other Project\\rename_folder_bat\\OUTPUT";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(28, 71);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(302, 20);
            this.txtFind.TabIndex = 1;
            this.txtFind.Text = "H:\\STATEMENT";
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(28, 111);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(302, 20);
            this.txtReplace.TabIndex = 2;
            this.txtReplace.Text = "nfs://FS_TESTAFP2PDF_ESTATEMENT_MASTER/STATEMENT";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(355, 25);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 148);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtReplace);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.txtBasePath);
            this.Name = "frmMain";
            this.Text = "RenameBatchJob";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBasePath;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.Button btnProcess;
    }
}

