namespace ARES_Preval
{
    partial class RoadAName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoadAName));
            this.btn_cncl = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.Prop_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.existing_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_cncl
            // 
            this.btn_cncl.Location = new System.Drawing.Point(132, 128);
            this.btn_cncl.Name = "btn_cncl";
            this.btn_cncl.Size = new System.Drawing.Size(64, 23);
            this.btn_cncl.TabIndex = 15;
            this.btn_cncl.Text = "Cancel";
            this.btn_cncl.UseVisualStyleBackColor = true;
            this.btn_cncl.Click += new System.EventHandler(this.btn_cncl_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Location = new System.Drawing.Point(31, 128);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(64, 23);
            this.btn_ok.TabIndex = 14;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // Prop_txt
            // 
            this.Prop_txt.Location = new System.Drawing.Point(116, 76);
            this.Prop_txt.Name = "Prop_txt";
            this.Prop_txt.Size = new System.Drawing.Size(100, 20);
            this.Prop_txt.TabIndex = 13;
            this.Prop_txt.TextChanged += new System.EventHandler(this.Prop_txt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Proposed Road";
            // 
            // existing_txt
            // 
            this.existing_txt.Location = new System.Drawing.Point(116, 43);
            this.existing_txt.Name = "existing_txt";
            this.existing_txt.Size = new System.Drawing.Size(100, 20);
            this.existing_txt.TabIndex = 11;
            this.existing_txt.TextChanged += new System.EventHandler(this.existing_txt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Existing Road";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Width";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "RoadName";
            // 
            // RoadAName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 163);
            this.Controls.Add(this.btn_cncl);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.Prop_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.existing_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoadAName";
            this.Text = "RoadAName";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cncl;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox Prop_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox existing_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}