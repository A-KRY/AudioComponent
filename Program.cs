#define DEBUG
using System;

namespace AK {
	public class Program {
		public static void Main(string[] args) {
			AudioComponent.InitMemoryManager();
			AudioComponent.InitStreamManager(); 
			AudioComponent.InitSoundEngine();
			AudioComponent.InitMusicEngine();
			AudioComponent.InitSpatialAudio();
#if (DEBUG)
			AudioComponent.InitCommunication();
			AudioComponent.TermCommunication();
#endif

			AudioComponent.TermMusicEngine();
			AudioComponent.TermSoundEngine();
			AudioComponent.TermStreamManager();
			AudioComponent.TermMemoryManager();

		}
	}
}