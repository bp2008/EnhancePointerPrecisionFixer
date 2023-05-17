using BPUtil;
using BPUtil.NativeWin;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnhancePointerPrecisionFixer
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			this.Text += " " + Globals.AssemblyVersion;

			cbStartAutomatically.Checked = CheckAutomaticStartup();
			nudEPPPollingRate.Value = Program.settings.pollIntervalMs;
			cbNotifyEPPChanged.Checked = Program.settings.notifyOnChange;
			if (Program.settings.eppAutoFix)
			{
				if (Program.settings.eppPreferredEnabled)
					rbEPPAlwaysOn.Checked = true;
				else
					rbEPPAlwaysOff.Checked = true;
			}
			else
			{
				rbEPPFixDisabled.Checked = true;
			}

			UpdateEPPStatusText();

			Program.service.OnEPPChange += EPP_OnChange;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Program.service.OnEPPChange -= EPP_OnChange;
		}

		private void EPP_OnChange(object sender, bool enabled)
		{
			UpdateEPPStatusText();
		}

		private void UpdateEPPStatusText()
		{
			if (lblEppStatus.InvokeRequired)
				lblEppStatus.Invoke((System.Action)UpdateEPPStatusText);
			else
				lblEppStatus.Text = "\"Enhance Pointer Precision\" is currently " + (Program.service.EnhancePointerPrecision ? "ON" : "OFF");
		}

		private void cbStartAutomatically_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (cbStartAutomatically.Checked)
				{
					if (Admin.IsRunningAsAdmin())
						CreateStartupTask();
					else
						Admin.StartSelfAsAdmin("AddStartupTask");
				}
				else
				{
					if (Admin.IsRunningAsAdmin())
						DeleteStartupTask();
					else
						Admin.StartSelfAsAdmin("RemoveStartupTask");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private const string TaskName = "Enhance Pointer Precision Fixer Automatic Startup";
		public static void CreateStartupTask()
		{
			if (CheckAutomaticStartup())
				DeleteStartupTask();
			using (TaskService ts = new TaskService())
			{
				TaskDefinition td = ts.NewTask();
				td.RegistrationInfo.Description = "Start the Enhance Pointer Precision Fixer tray application.";
				td.Triggers.Add(new LogonTrigger());
				td.Actions.Add(new ExecAction(Globals.ApplicationDirectoryBase + Globals.ExecutableNameWithExtension, null, Globals.ApplicationRoot));
				td.Principal.RunLevel = TaskRunLevel.LUA;
				td.Settings.AllowDemandStart = true;
				td.Settings.DisallowStartIfOnBatteries = false;
				td.Settings.ExecutionTimeLimit = TimeSpan.Zero;
				td.Settings.Hidden = false;
				td.Settings.RestartCount = 1440;
				td.Settings.RestartInterval = TimeSpan.FromMinutes(1);
				td.Settings.RunOnlyIfIdle = false;
				td.Settings.RunOnlyIfNetworkAvailable = false;
				td.Settings.StartWhenAvailable = true;
				td.Settings.StopIfGoingOnBatteries = false;
				td.Settings.Volatile = false;

				ts.RootFolder.RegisterTaskDefinition(TaskName, td);
			}
		}
		public static void DeleteStartupTask()
		{
			using (TaskService ts = new TaskService())
			{
				if (ts.RootFolder.Tasks.Any(t => t.Name == TaskName))
					ts.RootFolder.DeleteTask(TaskName);
			}
		}
		/// <summary>
		/// Returns true if the program is configured to start automatically.
		/// </summary>
		/// <returns></returns>
		private static bool CheckAutomaticStartup()
		{
			using (TaskService ts = new TaskService())
			{
				return ts.RootFolder.Tasks.Any(t => t.Name == TaskName);
			}
		}

		private void nudEPPPollingRate_ValueChanged(object sender, EventArgs e)
		{
			Program.settings.pollIntervalMs = ((int)nudEPPPollingRate.Value).Clamp(33, 60000);
			Program.settings.Save();
		}

		private void cbNotifyEPPChanged_CheckedChanged(object sender, EventArgs e)
		{
			Program.settings.notifyOnChange = cbNotifyEPPChanged.Checked;
			Program.settings.Save();
		}

		private void rbEPPFixDisabled_CheckedChanged(object sender, EventArgs e)
		{
			SaveEPPAutoFixSettings();
		}

		private void rbEPPAlwaysOff_CheckedChanged(object sender, EventArgs e)
		{
			SaveEPPAutoFixSettings();
		}

		private void rbEPPAlwaysOn_CheckedChanged(object sender, EventArgs e)
		{
			SaveEPPAutoFixSettings();
		}

		private void SaveEPPAutoFixSettings()
		{
			if (rbEPPFixDisabled.Checked)
			{
				Program.settings.eppAutoFix = false;
				Program.settings.eppPreferredEnabled = false;
				Program.settings.Save();
			}
			else if (rbEPPAlwaysOff.Checked)
			{
				Program.settings.eppAutoFix = true;
				Program.settings.eppPreferredEnabled = false;
				Program.settings.Save();
			}
			else if (rbEPPAlwaysOn.Checked)
			{
				Program.settings.eppAutoFix = true;
				Program.settings.eppPreferredEnabled = true;
				Program.settings.Save();
			}
			else
			{
				rbEPPAlwaysOff.Checked = true;
			}
		}

		private void btnOpenDataFolder_Click(object sender, EventArgs e)
		{
			Process.Start(Globals.WritableDirectoryBase);
		}

		private void btnExitProgram_Click(object sender, EventArgs e)
		{
			Program.Exit();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
