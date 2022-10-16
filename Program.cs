#define DEBUG
using AK.Types;
using System;

namespace AK {
	public class Program {
		public static unsafe void Main(string[] args) {
			AudioComponent.InitMemoryManager();
			AudioComponent.InitStreamManager(); 
			AudioComponent.InitSoundEngine();
			AudioComponent.InitMusicEngine();
			AudioComponent.InitSpatialAudio();
#if (DEBUG)
			AudioComponent.InitCommunication();
			AudioComponent.TermCommunication();
			AkTransform[] tf = new AkTransform[2];
			//fixed (AkTransform* pTf = tf);
			//CLI_SetMultiPosition instance = new CLI_SetMultiPosition();
			//AKRESULT aKRESULT = instance.SetMultiPosition(0, pTf, 2, (int)MultiPositionType.MultiPositionType_MultiSources);
#endif

			AudioComponent.TermMusicEngine();
			AudioComponent.TermSoundEngine();
			AudioComponent.TermStreamManager();
			AudioComponent.TermMemoryManager();

		}
	}
}