using BPUtil;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace EnhancePointerPrecisionFixer
{
	public class EPPFixService
	{
		volatile bool abort = false;
		Thread thrEppPoll;
		/// <summary>
		/// Gets a value indicating if the "Enhance Pointer Precision" setting is enabled.
		/// </summary>
		public bool EnhancePointerPrecision { get; private set; }
		/// <summary>
		/// Event raised when the "Enhance Pointer Precision" setting has changed. The event argument is a boolean indicating whether the setting is enabled.
		/// </summary>
		public event EventHandler<bool> OnEPPChange = delegate { };
		public void Start()
		{
			thrEppPoll = new Thread(doEppPolling);
			thrEppPoll.IsBackground = true;
			thrEppPoll.Name = "EppPoll";
			thrEppPoll.Start();
		}

		public void Stop()
		{
			abort = true;
		}

		private void doEppPolling()
		{
			try
			{
				IntervalSleeper sleeper = new IntervalSleeper(100);
				EnhancePointerPrecision = IsMouseEnhanced();
				while (!abort)
				{
					try
					{
						bool state = IsMouseEnhanced();
						if (Program.settings.eppAutoFix)
						{
							if (state != Program.settings.eppPreferredEnabled)
							{
								state = Program.settings.eppPreferredEnabled;
								SetMouseEnhanced(state);
								EnhancePointerPrecision = state;
								OnEPPChange.Invoke(this, state);
								if (Program.settings.notifyOnChange)
									NotifyOfFix(state);
							}
						}
						else
						{
							if (EnhancePointerPrecision != state)
							{
								EnhancePointerPrecision = state;
								OnEPPChange.Invoke(this, state);
								if (Program.settings.notifyOnChange)
									NotifyOfChange(!state, state);
							}
						}
					}
					catch (Exception ex)
					{
						Logger.Debug(ex);
					}
					sleeper.SleepUntil(Program.settings.pollIntervalMs.Clamp(33, 60000), shouldAbort);
				}
			}
			catch (Exception ex)
			{
				Logger.Debug(ex, "Critical failure. Program is now exiting.");
				Program.Exit();
			}
		}

		private void NotifyOfChange(bool prevState, bool state)
		{
			Notify("\"Enhance Pointer Precision\" change was detected at " + DateTime.Now.ToString(), (prevState ? "ON" : "OFF") + " -> " + (state ? "ON" : "OFF"));
		}
		private void NotifyOfFix(bool state)
		{
			Notify("\"Enhance Pointer Precision\" change was detected at " + DateTime.Now.ToString(), "According to your settings, EPP was reset to " + (state ? "ON" : "OFF") + ".");
		}
		private void Notify(params string[] texts)
		{
			if (texts.Length == 0)
				return;

			ToastContentBuilder builder = new ToastContentBuilder();
			foreach (string text in texts)
				builder = builder.AddText(text);

			builder.SetToastDuration(ToastDuration.Short)
				.Show();
		}
		private bool shouldAbort()
		{
			return abort;
		}

		#region Native Windows API
		[DllImport("user32.dll")]
		public static extern int SystemParametersInfo(int uAction, int uParam, ref int lpvParam, int fuWinIni);

		public const int SPI_GETMOUSE = 0x0003;
		public const int SPI_SETMOUSE = 0x0004;
		public const int SPIF_UPDATEINIFILE = 0x01;
		public const int SPIF_SENDCHANGE = 0x02;

		/// <summary>
		/// Polls the "Enhance Pointer Precision" setting, returning true if it is enabled.
		/// </summary>
		/// <returns></returns>
		public static bool IsMouseEnhanced()
		{
			int[] mouseParams = new int[3];
			SystemParametersInfo(SPI_GETMOUSE, 0, ref mouseParams[0], 0);
			return mouseParams[2] != 0;
		}
		/// <summary>
		/// Sets the "Enhance Pointer Precision" setting.
		/// </summary>
		/// <param name="enable">True to enable "Enhance Pointer Precision", false to disable.</param>
		public static void SetMouseEnhanced(bool enable)
		{
			int[] mouseParams = new int[3];
			SystemParametersInfo(SPI_GETMOUSE, 0, ref mouseParams[0], 0);
			mouseParams[2] = enable ? 1 : 0;
			SystemParametersInfo(SPI_SETMOUSE, 0, ref mouseParams[0], SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
		}
		#endregion
	}
}