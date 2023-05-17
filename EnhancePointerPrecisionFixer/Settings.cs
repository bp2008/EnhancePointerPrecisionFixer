using BPUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnhancePointerPrecisionFixer
{
	public class Settings : SerializableObjectBase
	{
		/// <summary>
		/// Number of milliseconds to sleep between checking the value of the "Enhance Pointer Precision" setting. [33-60000]
		/// </summary>
		public int pollIntervalMs = 1000;
		/// <summary>
		/// Show a Windows notification when the "Enhance Pointer Precision" setting changes.
		/// </summary>
		public bool notifyOnChange = false;
		/// <summary>
		/// If true, the Automatic Fix function will be activated.
		/// </summary>
		public bool eppAutoFix = true;
		/// <summary>
		/// If true, the Automatic Fix function will enable "Enhance Pointer Precision".  If false, the Automatic Fix function will disable "Enhance Pointer Precision".
		/// </summary>
		public bool eppPreferredEnabled = false;
	}
}
