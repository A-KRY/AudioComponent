#define DEBUG
using AK.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



namespace AK {
	using AkOSChar = Char;

	using AkGameObjectID = UInt64;
	
	using AkBankID = UInt32;
	using AkUniqueID = UInt32;
	using AkPlayingID = UInt32;
	using AkUInt32 = UInt32;
	using AkRtpcID = UInt32;
	using AkTimeMs = UInt32;
	using AkStateGroupID = UInt32;
	using AkStateID = UInt32;
	using AkSwitchGroupID = UInt32;
	using AkSwitchStateID = UInt32;
	using AkTriggerID = UInt32;

	using AkUInt16 = UInt16;

	using AkReal32 = Single;
	using AkRtpcValue = Single;

	/// Positioning information for a sound.
	using AkSoundPosition = AkTransform;

	/// Positioning information for a listener.
	using AkListenerPosition = AkTransform;

	//using AkTransform = ref_AkTransform;
	//using AkVector = ref_AkVector;



	namespace Types {
		

		public enum AKRESULT {
			AK_NotImplemented = 0,  ///< This feature is not implemented.
			AK_Success = 1, ///< The operation was successful.
			AK_Fail = 2,    ///< The operation failed.
			AK_PartialSuccess = 3,  ///< The operation succeeded partially.
			AK_NotCompatible = 4,   ///< Incompatible formats
			AK_AlreadyConnected = 5,    ///< The stream is already connected to another node.
			AK_InvalidFile = 7, ///< An unexpected value causes the file to be invalid.
			AK_AudioFileHeaderTooLarge = 8, ///< The file header is too large.
			AK_MaxReached = 9,  ///< The maximum was reached.
			AK_InvalidID = 14,  ///< The ID is invalid.
			AK_IDNotFound = 15, ///< The ID was not found.
			AK_InvalidInstanceID = 16,  ///< The InstanceID is invalid.
			AK_NoMoreData = 17, ///< No more data is available from the source.
			AK_InvalidStateGroup = 20,  ///< The StateGroup is not a valid channel.
			AK_ChildAlreadyHasAParent = 21, ///< The child already has a parent.
			AK_InvalidLanguage = 22,    ///< The language is invalid (applies to the Low-Level I/O).
			AK_CannotAddItseflAsAChild = 23,    ///< It is not possible to add itself as its own child.
			AK_InvalidParameter = 31,   ///< Something is not within bounds.
			AK_ElementAlreadyInList = 35,   ///< The item could not be added because it was already in the list.
			AK_PathNotFound = 36,   ///< This path is not known.
			AK_PathNoVertices = 37, ///< Stuff in vertices before trying to start it
			AK_PathNotRunning = 38, ///< Only a running path can be paused.
			AK_PathNotPaused = 39,  ///< Only a paused path can be resumed.
			AK_PathNodeAlreadyInList = 40,  ///< This path is already there.
			AK_PathNodeNotInList = 41,  ///< This path is not there.
			AK_DataNeeded = 43, ///< The consumer needs more.
			AK_NoDataNeeded = 44,   ///< The consumer does not need more.
			AK_DataReady = 45,  ///< The provider has available data.
			AK_NoDataReady = 46,    ///< The provider does not have available data.
			AK_InsufficientMemory = 52, ///< Memory error.
			AK_Cancelled = 53,  ///< The requested action was cancelled (not an error).
			AK_UnknownBankID = 54,  ///< Trying to load a bank using an ID which is not defined.
			AK_BankReadError = 56,  ///< Error while reading a bank.
			AK_InvalidSwitchType = 57,  ///< Invalid switch type (used with the switch container)
			AK_FormatNotReady = 63,   ///< Source format not known yet.
			AK_WrongBankVersion = 64,   ///< The bank version is not compatible with the current bank reader.
			AK_FileNotFound = 66,   ///< File not found.
			AK_DeviceNotReady = 67,   ///< Specified ID doesn't match a valid hardware device: either the device doesn't exist or is disabled.
			AK_BankAlreadyLoaded = 69,  ///< The bank load failed because the bank is already loaded.
			AK_RenderedFX = 71, ///< The effect on the node is rendered.
			AK_ProcessNeeded = 72,  ///< A routine needs to be executed on some CPU.
			AK_ProcessDone = 73,    ///< The executed routine has finished its execution.
			AK_MemManagerNotInitialized = 74,   ///< The memory manager should have been initialized at this point.
			AK_StreamMgrNotInitialized = 75,    ///< The stream manager should have been initialized at this point.
			AK_SSEInstructionsNotSupported = 76,///< The machine does not support SSE instructions (required on PC).
			AK_Busy = 77,   ///< The system is busy and could not process the request.
			AK_UnsupportedChannelConfig = 78,   ///< Channel configuration is not supported in the current execution context.
			AK_PluginMediaNotAvailable = 79,    ///< Plugin media is not available for effect.
			AK_MustBeVirtualized = 80,  ///< Sound was Not Allowed to play.
			AK_CommandTooLarge = 81,    ///< SDK command is too large to fit in the command queue.
			AK_RejectedByFilter = 82,   ///< A play request was rejected due to the MIDI filter parameters.
			AK_InvalidCustomPlatformName = 83,  ///< Detecting incompatibility between Custom platform of banks and custom platform of connected application
			AK_DLLCannotLoad = 84,  ///< Plugin DLL could not be loaded, either because it is not found or one dependency is missing.
			AK_DLLPathNotFound = 85,    ///< Plugin DLL search path could not be found.
			AK_NoJavaVM = 86,   ///< No Java VM provided in AkInitSettings.
			AK_OpenSLError = 87,    ///< OpenSL returned an error.  Check error log for more details.
			AK_PluginNotRegistered = 88,    ///< Plugin is not registered.  Make sure to implement a AK::PluginRegistration class for it and use AK_STATIC_LINK_PLUGIN in the game binary.
			AK_DataAlignmentError = 89, ///< A pointer to audio data was not aligned to the platform's required alignment (check AkTypes.h in the platform-specific folder)
			AK_DeviceNotCompatible = 90,    ///< Incompatible Audio device.
			AK_DuplicateUniqueID = 91,  ///< Two Wwise objects share the same ID.
			AK_InitBankNotLoaded = 92,  ///< The Init bank was not loaded yet, the sound engine isn't completely ready yet.
			AK_DeviceNotFound = 93, ///< The specified device ID does not match with any of the output devices that the sound engine is currently using.
			AK_PlayingIDNotFound = 94,  ///< Calling a function with a playing ID that is not known.
			AK_InvalidFloatValue = 95,  ///< One parameter has a invalid float value such as NaN, INF or FLT_MAX.
			AK_FileFormatMismatch = 96,   ///< Media file format unexpected
			AK_NoDistinctListener = 97, ///< No distinct listener provided for AddOutput
			AK_ACP_Error = 98,  ///< Generic XMA decoder error.
			AK_ResourceInUse = 99,  ///< Resource is in use and cannot be released.
		};

		public enum PreparationType {
			Preparation_Load,   ///< \c PrepareEvent() will load required information to play the specified event.
			Preparation_Unload, ///< \c PrepareEvent() will unload required information to play the specified event.
			Preparation_LoadAndDecode ///< Vorbis media is decoded when loading, and an uncompressed PCM version is used for playback.
		};

		public enum AkGroupType {
			// should stay set as Switch = 0 and State = 1
			AkGroupType_Switch = 0, ///< Type switch
			AkGroupType_State = 1  ///< Type state
		};

		public enum MultiPositionType {
			MultiPositionType_SingleSource,     ///< Used for normal sounds, not expected to pass to AK::SoundEngine::SetMultiplePosition() (if done, only the first position will be used).
			MultiPositionType_MultiSources,     ///< Simulate multiple sources in one sound playing, adding volumes. For instance, all the torches on your level emitting using only one sound.
			MultiPositionType_MultiDirections   ///< Simulate one sound coming from multiple directions. Useful for repositionning sounds based on wall openings or to simulate areas like forest or rivers ( in combination with spreading in the attenuation of the sounds ).
		};

		public enum AkActionOnEventType {
			AkActionOnEventType_Stop = 0,           ///< Stop
			AkActionOnEventType_Pause = 1,          ///< Pause
			AkActionOnEventType_Resume = 2,         ///< Resume
			AkActionOnEventType_Break = 3,          ///< Break
			AkActionOnEventType_ReleaseEnvelope = 4     ///< Release envelope
		};

		public enum AkCurveInterpolation {
			//DONT GO BEYOND 15! (see below for details)
			//Curves from 0 to LastFadeCurve NEED TO BE A MIRROR IMAGE AROUND LINEAR (eg. Log3 is the inverse of Exp3)
			AkCurveInterpolation_Log3 = 0, ///< Log3
			AkCurveInterpolation_Sine = 1, ///< Sine
			AkCurveInterpolation_Log1 = 2, ///< Log1
			AkCurveInterpolation_InvSCurve = 3, ///< Inversed S Curve
			AkCurveInterpolation_Linear = 4, ///< Linear (Default)
			AkCurveInterpolation_SCurve = 5, ///< S Curve
			AkCurveInterpolation_Exp1 = 6, ///< Exp1
			AkCurveInterpolation_SineRecip = 7, ///< Reciprocal of sine curve
			AkCurveInterpolation_Exp3 = 8, ///< Exp3
			AkCurveInterpolation_LastFadeCurve = 8, ///< Update this value to reflect last curve available for fades
			AkCurveInterpolation_Constant = 9  ///< Constant ( not valid for fading values )
			//DONT GO BEYOND 15! The value is stored on 5 bits,
			//but we can use only 4 bits for the actual values, keeping
			//the 5th bit at 0 to void problems when the value is
			//expanded to 32 bits.
		};

		/// 3D vector.
		public class AkVector {

			public AkReal32 X; ///< X Position
			public AkReal32 Y; ///< Y Position
			public AkReal32 Z; ///< Z Position

			public AkVector() {
				X = 0.0f;
				Y = 0.0f;
				Z = 0.0f;
			}

			public AkVector(AkReal32 x, AkReal32 y, AkReal32 z) {
				X = x;
				Y = y;
				Z = z;
			}

			public AkVector(AkVector vec) {
				X = vec.X;
				Y = vec.Y;
				Z = vec.Z;
			}

			public static AkVector operator +(AkVector a, AkVector b)
			{
				AkVector v = new AkVector();
				v.X = a.X + b.X;
				v.Y = a.Y + b.Y;
				v.Z = a.Z + b.Z;
				return v;
			}

			public void Zero() {
				X = 0.0f; Y = 0.0f; Z = 0.0f;
			}
		};

		/// Position and orientation of game objects.
		public class AkTransform {

			private AkVector orientationFront;  ///< Orientation of the listener
			private AkVector orientationTop;        ///< Top orientation of the listener
			private AkVector position;          ///< Position of the listener

			public AkTransform (AkTransform transform) {
				orientationFront = new AkVector(transform.orientationFront);
				orientationTop = new AkVector(transform.orientationTop);
				position = new AkVector(transform.position);
			}

			//
			// Getters.
			//

			/// Get position vector.
			public AkVector Position()
			{
				return position;
			}

			/// Get orientation front vector.
			public AkVector OrientationFront()
			{
				return orientationFront;
			}

			/// Get orientation top vector.
			public AkVector OrientationTop()
			{
				return orientationTop;
			}

			//
			// Setters.
			//

			/// Set position and orientation. Orientation front and top should be orthogonal and normalized.
			public void Set(
				AkVector in_position,           ///< Position vector.
				AkVector in_orientationFront,   ///< Orientation front
				AkVector in_orientationTop     ///< Orientation top
				)
			{
				position = in_position;
				orientationFront = in_orientationFront;
				orientationTop = in_orientationTop;
			}

			/// Set position and orientation. Orientation front and top should be orthogonal and normalized.
			public void Set(
				AkReal32 in_positionX,                  ///< Position x
				AkReal32 in_positionY,                  ///< Position y
				AkReal32 in_positionZ,                  ///< Position z
				AkReal32 in_orientFrontX,               ///< Orientation front x
				AkReal32 in_orientFrontY,               ///< Orientation front y
				AkReal32 in_orientFrontZ,               ///< Orientation front z
				AkReal32 in_orientTopX,                 ///< Orientation top x
				AkReal32 in_orientTopY,                 ///< Orientation top y
				AkReal32 in_orientTopZ                  ///< Orientation top z
				) 
			{
				position.X = in_positionX;
				position.Y = in_positionY;
				position.Z = in_positionZ;
				orientationFront.X = in_orientFrontX;
				orientationFront.Y = in_orientFrontY;
				orientationFront.Z = in_orientFrontZ;
				orientationTop.X = in_orientTopX;
				orientationTop.Y = in_orientTopY;
				orientationTop.Z = in_orientTopZ;
			}

			/// Set position.
			public void SetPosition(AkVector in_position)            ///< Position vector.
			{
				position = in_position;
			}

			/// Set position.
			public void SetPosition(
				AkReal32 in_x,                          ///< x
				AkReal32 in_y,                          ///< y
				AkReal32 in_z                           ///< z
				) 
			{
				position.X = in_x;
				position.Y = in_y;
				position.Z = in_z;
			}

			/// Set orientation. Orientation front and top should be orthogonal and normalized.
			public void SetOrientation(
				AkVector in_orientationFront,   ///< Orientation front
				AkVector in_orientationTop      ///< Orientation top
				) 
			{
				orientationFront = in_orientationFront;
				orientationTop = in_orientationTop;
			}

			/// Set orientation. Orientation front and top should be orthogonal and normalized.
			public void SetOrientation(
				AkReal32 in_orientFrontX,               ///< Orientation front x
				AkReal32 in_orientFrontY,               ///< Orientation front y
				AkReal32 in_orientFrontZ,               ///< Orientation front z
				AkReal32 in_orientTopX,                 ///< Orientation top x
				AkReal32 in_orientTopY,                 ///< Orientation top y
				AkReal32 in_orientTopZ                  ///< Orientation top z
				) {
				orientationFront.X = in_orientFrontX;
				orientationFront.Y = in_orientFrontY;
				orientationFront.Z = in_orientFrontZ;
				orientationTop.X = in_orientTopX;
				orientationTop.Y = in_orientTopY;
				orientationTop.Z = in_orientTopZ;
			}
			
	};

	}


	public class AkConvert {

		public static AkOSChar[] TEXT(string str) {
			return str.ToCharArray();
		}

	}

	public class AudioComponent {

		private const string DllPath = @"G:\Visual Studio\source\repos\AkSDK\x64\Debug\AkSDK.dll";

		const AkUInt32 AK_INVALID_PLAYING_ID = 0;

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

		// 设置 Sound Bank 路径
		[DllImport(DllPath, EntryPoint = "SetBankPath")]
		public static extern void SetBankPath(AkOSChar[] bankPath);

		// 选择 Sound Bank 语言
		[DllImport(DllPath, EntryPoint = "SetCurrLang")]
		public static extern void SetCurrLang(AkOSChar[] currLang);

		/* 加载 Sound Bank */
		// 以 ID 加载 Sound Bank
		[DllImport(DllPath, EntryPoint = "LoadBankID")]
		public static extern AKRESULT LoadBank(AkBankID bankID);

		// 以名称加载并获得散列 ID
		[DllImport(DllPath, EntryPoint = "LoadBankName")]
		public static extern AKRESULT LoadBank(char[] bankName, out AkBankID bankID);
		
		/* 卸载 Sound Bank */
		// 以 ID 卸载 Sound Bank
		[DllImport(DllPath, EntryPoint = "UnloadBankID")]
		public static extern unsafe AKRESULT UnloadBank(AkBankID bankID, void* pInMemoryBankPtr = null);

		// 以名称卸载 Sound Bank
		[DllImport(DllPath, EntryPoint = "UnloadBankName")]
		public static extern unsafe AKRESULT UnloadBank(char[] bankName, void* pInMemoryBankPtr = null);

		/* 注册 Game Object */
		// 以 ID 注册 Game Object
		[DllImport(DllPath, EntryPoint = "RegisterGameObj")]
		public static extern AKRESULT RegisterGameObj(AkGameObjectID objID);

		// 以 ID 注册 Game Object 并命名
		[DllImport(DllPath, EntryPoint = "RegisterNamedGameObj")]
		public static extern AKRESULT RegisterGameObj(AkGameObjectID objID, char[] objName);

		// 注销 Game Object
		[DllImport(DllPath, EntryPoint = "UnregisterGameObj")]
		public static extern AKRESULT UnregisterGameObj(AkGameObjectID objID);

		// 注销所有 Game Object
		[DllImport(DllPath, EntryPoint = "UnregisterAllGameObj")]
		public static extern AKRESULT UnregisterAllGameObj();

		/* 发送 Event */
		// 以 Event ID 发送 Event
		[DllImport(DllPath, EntryPoint = "PostEventID")]
		public static extern unsafe AkPlayingID PostEvent(AkUniqueID eventID,
			AkGameObjectID objectID,
			AkUInt32 uFlags = 0,
			//AkCallbackFunc pCallback = nullptr,
			void* pCookie = null,
			AkUInt32 cExternals = 0,
			//AkExternalSourceInfo* pExternalSources = null,
			AkPlayingID playingID = AK_INVALID_PLAYING_ID);

		// 以名称发送 Event
		[DllImport(DllPath, EntryPoint = "PostEventName")]
		public static extern unsafe AkPlayingID PostEvent(char[] eventName,
			AkGameObjectID objectID,
			AkUInt32 uFlags = 0,
			//AkCallbackFunc pCallback = nullptr,
			void* pCookie = null,
			AkUInt32 cExternals = 0,
			//AkExternalSourceInfo* pExternalSources = nullptr,
			AkPlayingID playingID = AK_INVALID_PLAYING_ID);

		// Executes an action on all nodes that are referenced in the specified event in an action of type play.
		// Using ID
		[DllImport(DllPath, EntryPoint = "ExecuteActionOnEvent_ID")]
		public static extern AKRESULT ExecuteActionOnEvent(
			AkUniqueID eventID, AkActionOnEventType eActonType,
			AkGameObjectID objID, AkTimeMs transitionDuration,
			AkCurveInterpolation eFadeCurve, AkPlayingID playingID);

		// Executes an action on all nodes that are referenced in the specified event in an action of type play.
		// Using Name
		[DllImport(DllPath, EntryPoint = "ExecuteActionOnEvent_Name")]
		public static extern AKRESULT ExecuteActionOnEvent(
			char[] eventName, AkActionOnEventType eActonType,
			AkGameObjectID objID, AkTimeMs transitionDuration,
			AkCurveInterpolation eFadeCurve, AkPlayingID playingID);

		// 渲染音频
		[DllImport(DllPath, EntryPoint = "RenderAudio")]
		public static extern AKRESULT RenderAudio();

		// 准备事件
		[DllImport(DllPath, EntryPoint = "PrepareEvent_ID")]
		public static extern AKRESULT PrepareEvent(PreparationType preparationType, 
			AkUniqueID[] eventIDs, AkUInt32 numOfEvents);

		[DllImport(DllPath, EntryPoint = "PrepareEvent_Name")]
		public static extern AKRESULT PrepareEvent(PreparationType preparationType, 
			char[][] eventNames, AkUInt32 numOfEvents);

		// 准备 Game Sync
		[DllImport(DllPath, EntryPoint = "PrepareGameSyncs_ID")]
		public static extern AKRESULT PrepareGameSyncs(PreparationType preparationType, 
			AkGroupType gameSyncType, AkUInt32 groupID, AkUInt32[] gameSyncIDs, AkUInt32 numOfSyncs);

		[DllImport(DllPath, EntryPoint = "PrepareGameSyncs_Name")]
		public static extern AKRESULT PrepareGameSyncs(PreparationType preparationType, 
			AkGroupType gameSyncType, char[] groupName, char[][] gameSyncNames, AkUInt32 numOfSyncs);

		// 设置默认 Listener
		[DllImport(DllPath, EntryPoint = "SetDefaultListeners")]
		public static extern AKRESULT SetDefaultListeners(AkGameObjectID[] listenerObjs, AkUInt32 numOfListeners);

		// 为 Emitter 设置 Listener
		[DllImport(DllPath, EntryPoint = "SetListeners")]
		public static extern AKRESULT SetListeners(AkGameObjectID emitterObj, 
			AkGameObjectID[] listenerObjs, AkUInt32 numOfListener);

		/* 为 GameObject 设置 Position */
		// C 标识版本
		[DllImport(DllPath, EntryPoint = "SetPosition")]
		private static extern AKRESULT __SetObjPosition(AkGameObjectID objID,
			AkReal32 posX, AkReal32 posY, AkReal32 posZ,
			AkReal32 oriFrontX, AkReal32 oriFrontY, AkReal32 oriFrontZ,
			AkReal32 oriTopX, AkReal32 oriTopY, AkReal32 oriTopZ);
		// C# 重载
		public static AKRESULT SetPosition(AkGameObjectID objID, AkTransform objPos) {
			return __SetObjPosition(objID,
				objPos.Position().X, objPos.Position().Y, objPos.Position().Z,
				objPos.OrientationFront().X, objPos.OrientationFront().Y, objPos.OrientationFront().Z,
				objPos.OrientationTop().X, objPos.OrientationTop().Y, objPos.OrientationTop().Z);
		}

		// 为 Game Object 设置多个位置
		public static AKRESULT SetMultiplePositions(AkGameObjectID objID, 
			AkSoundPosition[] pPositions, AkUInt16 numOfPos, MultiPositionType eMultiPosType)
		{
			//	检查数量是否合法
			if (numOfPos <= 0)
			{
				return AKRESULT.AK_InvalidParameter;
			}

			// 创建 CLI 类实例
			CLI_SetMultiPosition SMP = new CLI_SetMultiPosition();
			// 初始化
			SMP.Init(objID, numOfPos, (int)eMultiPosType);
			// 迭代为数组元素赋值
			for (UInt16 i = 0; i < numOfPos; ++i)
			{
				SMP.SetGridVal(i,
					pPositions[i].Position().X, pPositions[i].Position().Y, pPositions[i].Position().Z,
					pPositions[i].OrientationFront().X, pPositions[i].OrientationFront().Y, pPositions[i].OrientationFront().Z,
					pPositions[i].OrientationTop().X, pPositions[i].OrientationTop().Y, pPositions[i].OrientationTop().Z);
			}
			// 应用设置
			return (AKRESULT)SMP.Set();
		}

		// 以 RTPC ID 设置 RTPC 值
		[DllImport(DllPath, EntryPoint = "SetRTPCValue_ID")]
		public static extern AKRESULT SetRTPCValue(AkRtpcID rtpcID, AkRtpcValue rtpcVal,
			AkGameObjectID objID, AkTimeMs valChangeDuration = 0,
			AkCurveInterpolation eFadeCurve = AkCurveInterpolation.AkCurveInterpolation_Linear,
			bool bBypassInternalValueInterpolation = false);

		// 以 RTPC名称 设置 RTPC 值
		[DllImport(DllPath, EntryPoint = "SetRTPCValue_Name")]
		public static extern AKRESULT SetRTPCValue(char[] rtpcName, AkRtpcValue rtpcVal,
			AkGameObjectID objID, AkTimeMs valChangeDuration = 0,
			AkCurveInterpolation eFadeCurve = AkCurveInterpolation.AkCurveInterpolation_Linear,
			bool bBypassInternalValueInterpolation = false);

		// 以 RTPC ID 和 Playing ID 设置 RTPC 值
		[DllImport(DllPath, EntryPoint = "SetRTPCValuebyPlayingID_ID")]
		public static extern AKRESULT SetRTPCValueByPlayingID(AkRtpcID rtpcID, AkRtpcValue rtpcVal,
			AkPlayingID playingID, AkTimeMs valChangeDuration = 0,
			AkCurveInterpolation eFadeCurve = AkCurveInterpolation.AkCurveInterpolation_Linear,
			bool bBypassInternalValueInterpolation = false);

		// 以 RTPC名称 和 Playing ID 设置 RTPC 值
		[DllImport(DllPath, EntryPoint = "SetRTPCValuebyPlayingID_Name")]
		public static extern AKRESULT SetRTPCValuebyPlayingID(char[] rtpcName, AkRtpcValue rtpcVal,
			AkPlayingID playingID, AkTimeMs valChangeDuration = 0,
			AkCurveInterpolation eFadeCurve = AkCurveInterpolation.AkCurveInterpolation_Linear,
			bool bBypassInternalValueInterpolation = false);

		// 以 RTPC ID 重置 RTPC 值
		[DllImport(DllPath, EntryPoint = "ResetRTPCValue_ID")]
		public static extern AKRESULT ResetRTPCValue(AkRtpcID rtpcID, AkGameObjectID objID,
			AkTimeMs valChangeDuration = 0, AkCurveInterpolation eFadeCurve = AkCurveInterpolation.AkCurveInterpolation_Linear,
			bool bBypassInternalValueInterpolation = false);

		// 以 RTPC名称 重置 RTPC 值
		[DllImport(DllPath, EntryPoint = "ResetRTPCValue_Name")]
		public static extern AKRESULT ResetRTPCValue(char[] rtpcName, AkGameObjectID objID,
			AkTimeMs valChangeDuration = 0, AkCurveInterpolation eFadeCurve = AkCurveInterpolation.AkCurveInterpolation_Linear,
			bool bBypassInternalValueInterpolation = false);

		// 以 ID 为 State Group 设置 State
		[DllImport(DllPath, EntryPoint = "SetState_ID")]
		public static extern AKRESULT SetState(AkStateGroupID stateGroupID, AkStateID stateID);

		// 以 名称 为 State Group 设置 State
		[DllImport(DllPath, EntryPoint = "SetState_Name")]
		public static extern AKRESULT SetState(char[] stateGroupName, char[] stateName);

		// 以 ID 为 Game Object 的 Switch Group 设置 Switch State
		[DllImport(DllPath, EntryPoint = "SetSwitch_ID")]
		public static extern AKRESULT SetSwitch(AkSwitchGroupID switchGroupID,
			AkSwitchStateID switchStateID, AkGameObjectID objID);

		// 以 名称 为 Game Object 的 Switch Group 设置 Switch
		[DllImport(DllPath, EntryPoint = "SetSwitch_Name")]
		public static extern AKRESULT SetSwitch(char[] switchGroupName,
			char[] switchStateName, AkGameObjectID objID);

		// 以 ID 调用 触发器
		[DllImport(DllPath, EntryPoint = "PostTrigger_ID")]
		public static extern AKRESULT PostTrigger(AkTriggerID triggerID, AkGameObjectID objID);

		// 以 名称 调用 触发器
		[DllImport(DllPath, EntryPoint = "PostTrigger_Name")]
		public static extern AKRESULT PostTrigger(char[] triggerName, AkGameObjectID objID);


		/* 
		[DllImport(DllPath, EntryPoint = "")]
		public static extern 
		*/

	}
}
