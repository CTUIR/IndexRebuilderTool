namespace IndexRebuilderTool
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
            this.rtxStep1 = new System.Windows.Forms.RichTextBox();
            this.rtxStep3 = new System.Windows.Forms.RichTextBox();
            this.rtxStep2 = new System.Windows.Forms.RichTextBox();
            this.btnRemoveDuplicates = new System.Windows.Forms.Button();
            this.lblSourceFile = new System.Windows.Forms.Label();
            this.txtSoureFile = new System.Windows.Forms.TextBox();
            this.btnBrowseForSourceFile = new System.Windows.Forms.Button();
            this.btnCopyInThresholds = new System.Windows.Forms.Button();
            this.txtMasterCopy = new System.Windows.Forms.TextBox();
            this.lblMasterCopy = new System.Windows.Forms.Label();
            this.btnBrowseForMasterCopy = new System.Windows.Forms.Button();
            this.btnBuildSqlScript = new System.Windows.Forms.Button();
            this.btnSelectScriptFileLocation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtxStep1
            // 
            this.rtxStep1.Location = new System.Drawing.Point(12, 44);
            this.rtxStep1.Name = "rtxStep1";
            this.rtxStep1.Size = new System.Drawing.Size(457, 55);
            this.rtxStep1.TabIndex = 1;
            this.rtxStep1.Text = "Step1:  See frmMain.OnLoad";
            // 
            // rtxStep3
            // 
            this.rtxStep3.Location = new System.Drawing.Point(12, 266);
            this.rtxStep3.Name = "rtxStep3";
            this.rtxStep3.Size = new System.Drawing.Size(457, 96);
            this.rtxStep3.TabIndex = 2;
            this.rtxStep3.Text = "Step3:  See frmMain_Load";
            // 
            // rtxStep2
            // 
            this.rtxStep2.Location = new System.Drawing.Point(12, 219);
            this.rtxStep2.Name = "rtxStep2";
            this.rtxStep2.Size = new System.Drawing.Size(457, 41);
            this.rtxStep2.TabIndex = 3;
            this.rtxStep2.Text = "Step2:  See frmMain_Load";
            // 
            // btnRemoveDuplicates
            // 
            this.btnRemoveDuplicates.Location = new System.Drawing.Point(475, 135);
            this.btnRemoveDuplicates.Name = "btnRemoveDuplicates";
            this.btnRemoveDuplicates.Size = new System.Drawing.Size(139, 23);
            this.btnRemoveDuplicates.TabIndex = 4;
            this.btnRemoveDuplicates.Text = "Remove Duplicates";
            this.btnRemoveDuplicates.UseVisualStyleBackColor = true;
            this.btnRemoveDuplicates.Click += new System.EventHandler(this.btnRemoveDuplicates_Click);
            // 
            // lblSourceFile
            // 
            this.lblSourceFile.AutoSize = true;
            this.lblSourceFile.Location = new System.Drawing.Point(12, 106);
            this.lblSourceFile.Name = "lblSourceFile";
            this.lblSourceFile.Size = new System.Drawing.Size(63, 13);
            this.lblSourceFile.TabIndex = 5;
            this.lblSourceFile.Text = "Source File:";
            // 
            // txtSoureFile
            // 
            this.txtSoureFile.Location = new System.Drawing.Point(82, 106);
            this.txtSoureFile.Name = "txtSoureFile";
            this.txtSoureFile.Size = new System.Drawing.Size(387, 20);
            this.txtSoureFile.TabIndex = 6;
            // 
            // btnBrowseForSourceFile
            // 
            this.btnBrowseForSourceFile.Location = new System.Drawing.Point(475, 106);
            this.btnBrowseForSourceFile.Name = "btnBrowseForSourceFile";
            this.btnBrowseForSourceFile.Size = new System.Drawing.Size(139, 23);
            this.btnBrowseForSourceFile.TabIndex = 7;
            this.btnBrowseForSourceFile.Text = "Browse for Source File";
            this.btnBrowseForSourceFile.UseVisualStyleBackColor = true;
            this.btnBrowseForSourceFile.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCopyInThresholds
            // 
            this.btnCopyInThresholds.Location = new System.Drawing.Point(475, 195);
            this.btnCopyInThresholds.Name = "btnCopyInThresholds";
            this.btnCopyInThresholds.Size = new System.Drawing.Size(139, 23);
            this.btnCopyInThresholds.TabIndex = 8;
            this.btnCopyInThresholds.Text = "Copy in Thresholds";
            this.btnCopyInThresholds.UseVisualStyleBackColor = true;
            this.btnCopyInThresholds.Click += new System.EventHandler(this.btnCopyInThresholds_Click);
            // 
            // txtMasterCopy
            // 
            this.txtMasterCopy.Location = new System.Drawing.Point(82, 167);
            this.txtMasterCopy.Name = "txtMasterCopy";
            this.txtMasterCopy.Size = new System.Drawing.Size(387, 20);
            this.txtMasterCopy.TabIndex = 10;
            // 
            // lblMasterCopy
            // 
            this.lblMasterCopy.AutoSize = true;
            this.lblMasterCopy.Location = new System.Drawing.Point(12, 167);
            this.lblMasterCopy.Name = "lblMasterCopy";
            this.lblMasterCopy.Size = new System.Drawing.Size(69, 13);
            this.lblMasterCopy.TabIndex = 9;
            this.lblMasterCopy.Text = "Master Copy:";
            // 
            // btnBrowseForMasterCopy
            // 
            this.btnBrowseForMasterCopy.Location = new System.Drawing.Point(475, 167);
            this.btnBrowseForMasterCopy.Name = "btnBrowseForMasterCopy";
            this.btnBrowseForMasterCopy.Size = new System.Drawing.Size(139, 23);
            this.btnBrowseForMasterCopy.TabIndex = 11;
            this.btnBrowseForMasterCopy.Text = "Browse for Master Copy";
            this.btnBrowseForMasterCopy.UseVisualStyleBackColor = true;
            this.btnBrowseForMasterCopy.Click += new System.EventHandler(this.btnBrowseForMasterCopy_Click);
            // 
            // btnBuildSqlScript
            // 
            this.btnBuildSqlScript.Location = new System.Drawing.Point(475, 311);
            this.btnBuildSqlScript.Name = "btnBuildSqlScript";
            this.btnBuildSqlScript.Size = new System.Drawing.Size(139, 23);
            this.btnBuildSqlScript.TabIndex = 12;
            this.btnBuildSqlScript.Text = "Build SQL Script";
            this.btnBuildSqlScript.UseVisualStyleBackColor = true;
            this.btnBuildSqlScript.Click += new System.EventHandler(this.btnBuildSqlScript_Click);
            // 
            // btnSelectScriptFileLocation
            // 
            this.btnSelectScriptFileLocation.Location = new System.Drawing.Point(475, 268);
            this.btnSelectScriptFileLocation.Name = "btnSelectScriptFileLocation";
            this.btnSelectScriptFileLocation.Size = new System.Drawing.Size(139, 37);
            this.btnSelectScriptFileLocation.TabIndex = 13;
            this.btnSelectScriptFileLocation.Text = "Select SQL Script File Location";
            this.btnSelectScriptFileLocation.UseVisualStyleBackColor = true;
            this.btnSelectScriptFileLocation.Click += new System.EventHandler(this.btnSelectScriptFileLocation_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 403);
            this.Controls.Add(this.btnSelectScriptFileLocation);
            this.Controls.Add(this.btnBuildSqlScript);
            this.Controls.Add(this.btnBrowseForMasterCopy);
            this.Controls.Add(this.txtMasterCopy);
            this.Controls.Add(this.lblMasterCopy);
            this.Controls.Add(this.btnCopyInThresholds);
            this.Controls.Add(this.btnBrowseForSourceFile);
            this.Controls.Add(this.txtSoureFile);
            this.Controls.Add(this.lblSourceFile);
            this.Controls.Add(this.btnRemoveDuplicates);
            this.Controls.Add(this.rtxStep2);
            this.Controls.Add(this.rtxStep3);
            this.Controls.Add(this.rtxStep1);
            this.Name = "frmMain";
            this.Text = "Index Rebuilder Tool";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxStep1;
        private System.Windows.Forms.RichTextBox rtxStep3;
        private System.Windows.Forms.RichTextBox rtxStep2;
        private System.Windows.Forms.Button btnRemoveDuplicates;
        private System.Windows.Forms.Label lblSourceFile;
        private System.Windows.Forms.TextBox txtSoureFile;
        private System.Windows.Forms.Button btnBrowseForSourceFile;
        private System.Windows.Forms.Button btnCopyInThresholds;
        private System.Windows.Forms.TextBox txtMasterCopy;
        private System.Windows.Forms.Label lblMasterCopy;
        private System.Windows.Forms.Button btnBrowseForMasterCopy;
        private System.Windows.Forms.Button btnBuildSqlScript;
        private System.Windows.Forms.Button btnSelectScriptFileLocation;
    }
}

