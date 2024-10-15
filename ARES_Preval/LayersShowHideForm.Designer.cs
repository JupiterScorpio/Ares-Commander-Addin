namespace ARES_Preval
{
    partial class LayersShowHideForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayersShowHideForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.all_chk = new System.Windows.Forms.CheckBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 402);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Displayed Layers";
            // 
            // all_chk
            // 
            this.all_chk.AutoSize = true;
            this.all_chk.Location = new System.Drawing.Point(248, 11);
            this.all_chk.Name = "all_chk";
            this.all_chk.Size = new System.Drawing.Size(71, 17);
            this.all_chk.TabIndex = 6;
            this.all_chk.Text = "Check All";
            this.all_chk.UseVisualStyleBackColor = true;
            this.all_chk.CheckedChanged += new System.EventHandler(this.all_chk_CheckedChanged_1);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(256, 442);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(78, 36);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Location = new System.Drawing.Point(172, 442);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(78, 36);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // LayersShowHideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 483);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.all_chk);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayersShowHideForm";
            this.Text = "LayersShow&Hide";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LayersShowHideForm_FormClosing);
            this.Load += new System.EventHandler(this.LayersShowHideForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox all_chk;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
    }
}