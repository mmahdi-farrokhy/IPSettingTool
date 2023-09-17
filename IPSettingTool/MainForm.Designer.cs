namespace IPSettingTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.currentIPLbl = new System.Windows.Forms.Label();
            this.newIPLbl = new System.Windows.Forms.Label();
            this.currentIPTxt = new System.Windows.Forms.TextBox();
            this.newIPTxt = new System.Windows.Forms.TextBox();
            this.setNewIPBtn = new System.Windows.Forms.Button();
            this.newIPSettingsGroup = new System.Windows.Forms.GroupBox();
            this.adapterNameCombo = new System.Windows.Forms.ComboBox();
            this.adapterNameLbl = new System.Windows.Forms.Label();
            this.newIPSettingsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // currentIPLbl
            // 
            this.currentIPLbl.AutoSize = true;
            this.currentIPLbl.Location = new System.Drawing.Point(6, 29);
            this.currentIPLbl.Name = "currentIPLbl";
            this.currentIPLbl.Size = new System.Drawing.Size(69, 13);
            this.currentIPLbl.TabIndex = 0;
            this.currentIPLbl.Text = "Current IPv4:";
            // 
            // newIPLbl
            // 
            this.newIPLbl.AutoSize = true;
            this.newIPLbl.Location = new System.Drawing.Point(6, 58);
            this.newIPLbl.Name = "newIPLbl";
            this.newIPLbl.Size = new System.Drawing.Size(57, 13);
            this.newIPLbl.TabIndex = 1;
            this.newIPLbl.Text = "New IPv4:";
            // 
            // currentIPTxt
            // 
            this.currentIPTxt.Location = new System.Drawing.Point(75, 26);
            this.currentIPTxt.Name = "currentIPTxt";
            this.currentIPTxt.ReadOnly = true;
            this.currentIPTxt.Size = new System.Drawing.Size(160, 20);
            this.currentIPTxt.TabIndex = 2;
            // 
            // newIPTxt
            // 
            this.newIPTxt.Location = new System.Drawing.Point(75, 55);
            this.newIPTxt.Name = "newIPTxt";
            this.newIPTxt.Size = new System.Drawing.Size(160, 20);
            this.newIPTxt.TabIndex = 3;
            // 
            // setNewIPBtn
            // 
            this.setNewIPBtn.Location = new System.Drawing.Point(86, 94);
            this.setNewIPBtn.Name = "setNewIPBtn";
            this.setNewIPBtn.Size = new System.Drawing.Size(75, 22);
            this.setNewIPBtn.TabIndex = 4;
            this.setNewIPBtn.Text = "Set New IP";
            this.setNewIPBtn.UseVisualStyleBackColor = true;
            this.setNewIPBtn.Click += new System.EventHandler(this.setNewIPBtn_Click);
            // 
            // newIPSettingsGroup
            // 
            this.newIPSettingsGroup.Controls.Add(this.currentIPLbl);
            this.newIPSettingsGroup.Controls.Add(this.setNewIPBtn);
            this.newIPSettingsGroup.Controls.Add(this.currentIPTxt);
            this.newIPSettingsGroup.Controls.Add(this.newIPTxt);
            this.newIPSettingsGroup.Controls.Add(this.newIPLbl);
            this.newIPSettingsGroup.Location = new System.Drawing.Point(3, 54);
            this.newIPSettingsGroup.Name = "newIPSettingsGroup";
            this.newIPSettingsGroup.Size = new System.Drawing.Size(238, 132);
            this.newIPSettingsGroup.TabIndex = 5;
            this.newIPSettingsGroup.TabStop = false;
            this.newIPSettingsGroup.Text = "New Static IP Setting";
            // 
            // adapterNameCombo
            // 
            this.adapterNameCombo.FormattingEnabled = true;
            this.adapterNameCombo.Location = new System.Drawing.Point(78, 18);
            this.adapterNameCombo.Name = "adapterNameCombo";
            this.adapterNameCombo.Size = new System.Drawing.Size(160, 21);
            this.adapterNameCombo.TabIndex = 6;
            this.adapterNameCombo.SelectedIndexChanged += new System.EventHandler(this.adapterNameCombo_SelectedIndexChanged);
            // 
            // adapterNameLbl
            // 
            this.adapterNameLbl.AutoSize = true;
            this.adapterNameLbl.Location = new System.Drawing.Point(0, 21);
            this.adapterNameLbl.Name = "adapterNameLbl";
            this.adapterNameLbl.Size = new System.Drawing.Size(78, 13);
            this.adapterNameLbl.TabIndex = 7;
            this.adapterNameLbl.Text = "Adapter Name:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 187);
            this.Controls.Add(this.adapterNameLbl);
            this.Controls.Add(this.adapterNameCombo);
            this.Controls.Add(this.newIPSettingsGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IP Setting Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.newIPSettingsGroup.ResumeLayout(false);
            this.newIPSettingsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label currentIPLbl;
        private System.Windows.Forms.Label newIPLbl;
        private System.Windows.Forms.TextBox currentIPTxt;
        private System.Windows.Forms.TextBox newIPTxt;
        private System.Windows.Forms.Button setNewIPBtn;
        private System.Windows.Forms.GroupBox newIPSettingsGroup;
        private System.Windows.Forms.ComboBox adapterNameCombo;
        private System.Windows.Forms.Label adapterNameLbl;
    }
}

