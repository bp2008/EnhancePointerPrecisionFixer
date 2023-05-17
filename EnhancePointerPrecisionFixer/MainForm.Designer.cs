
namespace EnhancePointerPrecisionFixer
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
			this.nudEPPPollingRate = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.cbNotifyEPPChanged = new System.Windows.Forms.CheckBox();
			this.rbEPPFixDisabled = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbEPPAlwaysOn = new System.Windows.Forms.RadioButton();
			this.rbEPPAlwaysOff = new System.Windows.Forms.RadioButton();
			this.btnOpenDataFolder = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnExitProgram = new System.Windows.Forms.Button();
			this.lblEppStatus = new System.Windows.Forms.Label();
			this.cbStartAutomatically = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.nudEPPPollingRate)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// nudEPPPollingRate
			// 
			this.nudEPPPollingRate.Location = new System.Drawing.Point(12, 43);
			this.nudEPPPollingRate.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
			this.nudEPPPollingRate.Minimum = new decimal(new int[] {
            33,
            0,
            0,
            0});
			this.nudEPPPollingRate.Name = "nudEPPPollingRate";
			this.nudEPPPollingRate.Size = new System.Drawing.Size(74, 20);
			this.nudEPPPollingRate.TabIndex = 1;
			this.nudEPPPollingRate.Value = new decimal(new int[] {
            33,
            0,
            0,
            0});
			this.nudEPPPollingRate.ValueChanged += new System.EventHandler(this.nudEPPPollingRate_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(92, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(307, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "milliseconds polling rate for \"Enhance Pointer Precision\" setting.";
			// 
			// cbNotifyEPPChanged
			// 
			this.cbNotifyEPPChanged.AutoSize = true;
			this.cbNotifyEPPChanged.Location = new System.Drawing.Point(12, 74);
			this.cbNotifyEPPChanged.Name = "cbNotifyEPPChanged";
			this.cbNotifyEPPChanged.Size = new System.Drawing.Size(322, 17);
			this.cbNotifyEPPChanged.TabIndex = 2;
			this.cbNotifyEPPChanged.Text = "Notify when \"Enhance Pointer Precision\" setting has changed.";
			this.cbNotifyEPPChanged.UseVisualStyleBackColor = true;
			this.cbNotifyEPPChanged.CheckedChanged += new System.EventHandler(this.cbNotifyEPPChanged_CheckedChanged);
			// 
			// rbEPPFixDisabled
			// 
			this.rbEPPFixDisabled.AutoSize = true;
			this.rbEPPFixDisabled.Location = new System.Drawing.Point(19, 19);
			this.rbEPPFixDisabled.Name = "rbEPPFixDisabled";
			this.rbEPPFixDisabled.Size = new System.Drawing.Size(107, 17);
			this.rbEPPFixDisabled.TabIndex = 4;
			this.rbEPPFixDisabled.TabStop = true;
			this.rbEPPFixDisabled.Text = "Auto-Fix Disabled";
			this.rbEPPFixDisabled.UseVisualStyleBackColor = true;
			this.rbEPPFixDisabled.CheckedChanged += new System.EventHandler(this.rbEPPFixDisabled_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.rbEPPAlwaysOn);
			this.groupBox1.Controls.Add(this.rbEPPAlwaysOff);
			this.groupBox1.Controls.Add(this.rbEPPFixDisabled);
			this.groupBox1.Location = new System.Drawing.Point(12, 107);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(410, 95);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Auto-Fix";
			// 
			// rbEPPAlwaysOn
			// 
			this.rbEPPAlwaysOn.AutoSize = true;
			this.rbEPPAlwaysOn.Location = new System.Drawing.Point(19, 65);
			this.rbEPPAlwaysOn.Name = "rbEPPAlwaysOn";
			this.rbEPPAlwaysOn.Size = new System.Drawing.Size(243, 17);
			this.rbEPPAlwaysOn.TabIndex = 6;
			this.rbEPPAlwaysOn.TabStop = true;
			this.rbEPPAlwaysOn.Text = "Keep \"Enhance Pointer Precision\" Always ON";
			this.rbEPPAlwaysOn.UseVisualStyleBackColor = true;
			this.rbEPPAlwaysOn.CheckedChanged += new System.EventHandler(this.rbEPPAlwaysOn_CheckedChanged);
			// 
			// rbEPPAlwaysOff
			// 
			this.rbEPPAlwaysOff.AutoSize = true;
			this.rbEPPAlwaysOff.Location = new System.Drawing.Point(19, 42);
			this.rbEPPAlwaysOff.Name = "rbEPPAlwaysOff";
			this.rbEPPAlwaysOff.Size = new System.Drawing.Size(247, 17);
			this.rbEPPAlwaysOff.TabIndex = 5;
			this.rbEPPAlwaysOff.TabStop = true;
			this.rbEPPAlwaysOff.Text = "Keep \"Enhance Pointer Precision\" Always OFF";
			this.rbEPPAlwaysOff.UseVisualStyleBackColor = true;
			this.rbEPPAlwaysOff.CheckedChanged += new System.EventHandler(this.rbEPPAlwaysOff_CheckedChanged);
			// 
			// btnOpenDataFolder
			// 
			this.btnOpenDataFolder.Location = new System.Drawing.Point(12, 208);
			this.btnOpenDataFolder.Name = "btnOpenDataFolder";
			this.btnOpenDataFolder.Size = new System.Drawing.Size(174, 23);
			this.btnOpenDataFolder.TabIndex = 7;
			this.btnOpenDataFolder.Text = "Open Data Folder";
			this.btnOpenDataFolder.UseVisualStyleBackColor = true;
			this.btnOpenDataFolder.Click += new System.EventHandler(this.btnOpenDataFolder_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(276, 237);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(146, 23);
			this.btnOK.TabIndex = 9;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnExitProgram
			// 
			this.btnExitProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btnExitProgram.Location = new System.Drawing.Point(276, 208);
			this.btnExitProgram.Name = "btnExitProgram";
			this.btnExitProgram.Size = new System.Drawing.Size(146, 23);
			this.btnExitProgram.TabIndex = 8;
			this.btnExitProgram.Text = "Exit Program";
			this.btnExitProgram.UseVisualStyleBackColor = false;
			this.btnExitProgram.Click += new System.EventHandler(this.btnExitProgram_Click);
			// 
			// lblEppStatus
			// 
			this.lblEppStatus.AutoSize = true;
			this.lblEppStatus.Location = new System.Drawing.Point(12, 242);
			this.lblEppStatus.Name = "lblEppStatus";
			this.lblEppStatus.Size = new System.Drawing.Size(207, 13);
			this.lblEppStatus.TabIndex = 8;
			this.lblEppStatus.Text = "\"Enhance Pointer Precision\" is currently ...";
			// 
			// cbStartAutomatically
			// 
			this.cbStartAutomatically.AutoSize = true;
			this.cbStartAutomatically.Location = new System.Drawing.Point(12, 12);
			this.cbStartAutomatically.Name = "cbStartAutomatically";
			this.cbStartAutomatically.Size = new System.Drawing.Size(155, 17);
			this.cbStartAutomatically.TabIndex = 0;
			this.cbStartAutomatically.Text = "Start Program Automatically";
			this.cbStartAutomatically.UseVisualStyleBackColor = true;
			this.cbStartAutomatically.CheckedChanged += new System.EventHandler(this.cbStartAutomatically_CheckedChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 272);
			this.Controls.Add(this.cbStartAutomatically);
			this.Controls.Add(this.lblEppStatus);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnExitProgram);
			this.Controls.Add(this.btnOpenDataFolder);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cbNotifyEPPChanged);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nudEPPPollingRate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Enhance Pointer Precision Fixer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.nudEPPPollingRate)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown nudEPPPollingRate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox cbNotifyEPPChanged;
		private System.Windows.Forms.RadioButton rbEPPFixDisabled;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbEPPAlwaysOn;
		private System.Windows.Forms.RadioButton rbEPPAlwaysOff;
		private System.Windows.Forms.Button btnOpenDataFolder;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnExitProgram;
		private System.Windows.Forms.Label lblEppStatus;
		private System.Windows.Forms.CheckBox cbStartAutomatically;
	}
}

