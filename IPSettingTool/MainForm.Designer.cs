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
            currentIPLbl = new Label();
            newIPLbl = new Label();
            currentIPTxt = new TextBox();
            newIPTxt = new TextBox();
            setNewIPBtn = new Button();
            newIPSettingsGroup = new GroupBox();
            adapterNameCombo = new ComboBox();
            adapterNameLbl = new Label();
            currentGatewayLbl = new Label();
            currentGatewayTxt = new TextBox();
            newGatewayTxt = new TextBox();
            label2 = new Label();
            newIPSettingsGroup.SuspendLayout();
            SuspendLayout();
            // 
            // currentIPLbl
            // 
            currentIPLbl.AutoSize = true;
            currentIPLbl.Location = new Point(7, 33);
            currentIPLbl.Margin = new Padding(4, 0, 4, 0);
            currentIPLbl.Name = "currentIPLbl";
            currentIPLbl.Size = new Size(75, 15);
            currentIPLbl.TabIndex = 0;
            currentIPLbl.Text = "Current IPv4:";
            // 
            // newIPLbl
            // 
            newIPLbl.AutoSize = true;
            newIPLbl.Location = new Point(7, 67);
            newIPLbl.Margin = new Padding(4, 0, 4, 0);
            newIPLbl.Name = "newIPLbl";
            newIPLbl.Size = new Size(59, 15);
            newIPLbl.TabIndex = 1;
            newIPLbl.Text = "New IPv4:";
            // 
            // currentIPTxt
            // 
            currentIPTxt.Location = new Point(114, 30);
            currentIPTxt.Margin = new Padding(4, 3, 4, 3);
            currentIPTxt.Name = "currentIPTxt";
            currentIPTxt.ReadOnly = true;
            currentIPTxt.Size = new Size(160, 23);
            currentIPTxt.TabIndex = 2;
            // 
            // newIPTxt
            // 
            newIPTxt.Location = new Point(114, 63);
            newIPTxt.Margin = new Padding(4, 3, 4, 3);
            newIPTxt.Name = "newIPTxt";
            newIPTxt.Size = new Size(160, 23);
            newIPTxt.TabIndex = 3;
            // 
            // setNewIPBtn
            // 
            setNewIPBtn.Location = new Point(91, 170);
            setNewIPBtn.Margin = new Padding(4, 3, 4, 3);
            setNewIPBtn.Name = "setNewIPBtn";
            setNewIPBtn.Size = new Size(88, 25);
            setNewIPBtn.TabIndex = 4;
            setNewIPBtn.Text = "Set New Configurations";
            setNewIPBtn.UseVisualStyleBackColor = true;
            setNewIPBtn.Click += setNewIPBtn_Click;
            // 
            // newIPSettingsGroup
            // 
            newIPSettingsGroup.Controls.Add(currentGatewayLbl);
            newIPSettingsGroup.Controls.Add(currentIPLbl);
            newIPSettingsGroup.Controls.Add(currentGatewayTxt);
            newIPSettingsGroup.Controls.Add(newGatewayTxt);
            newIPSettingsGroup.Controls.Add(setNewIPBtn);
            newIPSettingsGroup.Controls.Add(label2);
            newIPSettingsGroup.Controls.Add(currentIPTxt);
            newIPSettingsGroup.Controls.Add(newIPTxt);
            newIPSettingsGroup.Controls.Add(newIPLbl);
            newIPSettingsGroup.Location = new Point(4, 62);
            newIPSettingsGroup.Margin = new Padding(4, 3, 4, 3);
            newIPSettingsGroup.Name = "newIPSettingsGroup";
            newIPSettingsGroup.Padding = new Padding(4, 3, 4, 3);
            newIPSettingsGroup.Size = new Size(278, 210);
            newIPSettingsGroup.TabIndex = 5;
            newIPSettingsGroup.TabStop = false;
            newIPSettingsGroup.Text = "New Static IP Setting";
            // 
            // adapterNameCombo
            // 
            adapterNameCombo.FormattingEnabled = true;
            adapterNameCombo.Location = new Point(95, 21);
            adapterNameCombo.Margin = new Padding(4, 3, 4, 3);
            adapterNameCombo.Name = "adapterNameCombo";
            adapterNameCombo.Size = new Size(186, 23);
            adapterNameCombo.TabIndex = 6;
            adapterNameCombo.SelectedIndexChanged += adapterNameCombo_SelectedIndexChanged;
            // 
            // adapterNameLbl
            // 
            adapterNameLbl.AutoSize = true;
            adapterNameLbl.Location = new Point(4, 24);
            adapterNameLbl.Margin = new Padding(4, 0, 4, 0);
            adapterNameLbl.Name = "adapterNameLbl";
            adapterNameLbl.Size = new Size(87, 15);
            adapterNameLbl.TabIndex = 7;
            adapterNameLbl.Text = "Adapter Name:";
            // 
            // currentGatewayLbl
            // 
            currentGatewayLbl.AutoSize = true;
            currentGatewayLbl.Location = new Point(8, 98);
            currentGatewayLbl.Margin = new Padding(4, 0, 4, 0);
            currentGatewayLbl.Name = "currentGatewayLbl";
            currentGatewayLbl.Size = new Size(98, 15);
            currentGatewayLbl.TabIndex = 8;
            currentGatewayLbl.Text = "Current Gateway:";
            // 
            // currentGatewayTxt
            // 
            currentGatewayTxt.Location = new Point(114, 95);
            currentGatewayTxt.Margin = new Padding(4, 3, 4, 3);
            currentGatewayTxt.Name = "currentGatewayTxt";
            currentGatewayTxt.ReadOnly = true;
            currentGatewayTxt.Size = new Size(160, 23);
            currentGatewayTxt.TabIndex = 10;
            // 
            // newGatewayTxt
            // 
            newGatewayTxt.Location = new Point(114, 128);
            newGatewayTxt.Margin = new Padding(4, 3, 4, 3);
            newGatewayTxt.Name = "newGatewayTxt";
            newGatewayTxt.Size = new Size(160, 23);
            newGatewayTxt.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 132);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 9;
            label2.Text = "New Gateway:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 277);
            Controls.Add(adapterNameLbl);
            Controls.Add(adapterNameCombo);
            Controls.Add(newIPSettingsGroup);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IP Setting Tool";
            Load += MainForm_Load;
            newIPSettingsGroup.ResumeLayout(false);
            newIPSettingsGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label currentIPLbl;
        private Label newIPLbl;
        private TextBox currentIPTxt;
        private TextBox newIPTxt;
        private Button setNewIPBtn;
        private GroupBox newIPSettingsGroup;
        private ComboBox adapterNameCombo;
        private Label adapterNameLbl;
        private Label currentGatewayLbl;
        private TextBox currentGatewayTxt;
        private TextBox newGatewayTxt;
        private Label label2;
    }
}

