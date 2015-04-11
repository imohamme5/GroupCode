using System;
using Sce.PlayStation.Core.Audio;

namespace Game2
{
	public class AudioManager
	{
		//private Sound sound; actual sound
		//private SPlayer winamp; soundplayer or mediaplayer
		private static AudioManager instance;
		private Bgm levelBgm;
		private BgmPlayer levelBgmPlayer;
		
		public static AudioManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new AudioManager();
				}
				return instance;
			}
		}
		
		public AudioManager (){}
		public void Dispose()	
		{
			//if(SPlayer != null) //Example of dispose
			//{
			//	  SPlayer.Dispose();
			//}
			if(levelBgm != null)
				levelBgm.Dispose();
		}
		
		public void Update()
		{
			UpdateMusicVol(GameManager.Instance.MusicVol);
			UpdateSfxVol(GameManager.Instance.SoundFXVol);
		}
		
		public void UpdateMusicVol(float v)
		{
			levelBgmPlayer.Volume = v;
		}
		
		public void UpdateSfxVol(float v)
		{
			
		}
		
		//example method for playing bgm
		public void PlayLevelBgm()
		{
			if(levelBgm == null)
			{
				levelBgm = new Bgm("/Application/assests/Audio/Club_Diver.mp3");
			}
			if(levelBgmPlayer == null)
			{
				levelBgmPlayer = levelBgm.CreatePlayer();
				levelBgmPlayer.Volume = GameManager.Instance.MusicVol;
				levelBgmPlayer.Loop = true;
			}
			levelBgmPlayer.Play();
		}
		
		public void StopLevelBgm()
		{
			levelBgmPlayer.Stop();
		}
		
		public bool BgmPlaying()
		{
			if(levelBgmPlayer != null)
			{
				return true;
			}
			return false;	
		}
		//example for playing normal sound
		/*public void PlayRocketPickup()
		{
			if(winampRocketPickUP == null)
			{
				rocketPickupSound = new Sound("/Application/Audio/rocketPickupSound.wav");
				winampRocketPickUP = rocketPickupSound.CreatePlayer();
				winampRocketPickUP.Volume = GameManager.Instance.SoundFXVol;
				winampRocketPickUP.PlaybackRate = 2.0f;
			}
			winampRocketPickUP.Play();
		}*/
		
		//example of stop method(if playing sound like a lazer being fired)
		/*public void StopSound()
		{
			winamp.Stop();
			
		}*/
	}
}

