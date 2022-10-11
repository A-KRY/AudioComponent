#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



namespace AK {
	using AkGameObjectID = UInt64;
	using AkOSChar = Char;
	using AkBankID = UInt32;

	public class AkConvert {

		public static AkOSChar[] ToAkCharArray(string str) {
			return str.ToCharArray();
		}

	}

	public class AudioComponent {

		private const string DllPath = @"G:\Visual Studio\source\repos\AkSDK\x64\Debug\AkSDK.dll";
		public AudioComponent() { }
		

		/* 
		[DllImport(DllPath, EntryPoint = "")]
		public static extern
		*/

		/*
		 * 初始化各模块
		 */

		// 初始化 Memory Manager
		[DllImport(DllPath, EntryPoint = "InitMemoryManager")]
		public static extern bool InitMemoryManager();

		// 初始化 Streaming Manager
		[DllImport(DllPath, EntryPoint = "InitStreamManager")]
		public static extern bool InitStreamManager();

		// 初始化 Sound Engine
		[DllImport(DllPath, EntryPoint = "InitSoundEngine")]
		public static extern bool InitSoundEngine();

		// 初始化 Music Engine
		[DllImport(DllPath, EntryPoint = "InitMusicEngine")]
		public static extern bool InitMusicEngine();

		// 初始化 Spatial Audio
		[DllImport(DllPath, EntryPoint = "InitSpatialAudio")]
		public static extern bool InitSpatialAudio();

#if (DEBUG)
		// 初始化通信模块
		[DllImport(DllPath, EntryPoint = "InitCommunication")]
		public static extern bool InitCommunication();
#endif

		/*
		 * 终止各模块
		 */

#if (DEBUG)
		// 终止通信模块
		[DllImport(DllPath, EntryPoint = "TermCommunication")]
		public static extern void TermCommunication();
#endif

		// 终止 Music Engine
		[DllImport(DllPath, EntryPoint = "TermMusicEngine")]
		public static extern void TermMusicEngine();

		// 终止 Sound Engine
		[DllImport(DllPath, EntryPoint = "TermSoundEngine")]
		public static extern void TermSoundEngine();

		// 终止 Streaming Manager
		[DllImport(DllPath, EntryPoint = "TermStreamManager")]
		public static extern void TermStreamManager();

		// 终止 Memory Manager
		[DllImport(DllPath, EntryPoint = "TermMemoryManager")]
		public static extern void TermMemoryManager();

		/*
		 * Wwise 元素集成
		 */

		[DllImport(DllPath, EntryPoint = "SetBankPath")]
		public static extern void SetBankPath(AkOSChar[] bankPath);

		[DllImport(DllPath, EntryPoint = "SetCurrLang")]
		public static extern void SetCurrLang(AkOSChar[] currLang);

		[DllImport(DllPath, EntryPoint = "LoadBank")]
		public static extern void LoadBank(char[] bankName, AkBankID bankID);

	}
}
