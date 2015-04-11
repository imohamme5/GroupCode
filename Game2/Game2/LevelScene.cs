using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using System.IO;
using Sce.PlayStation.Core.Audio;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using Sce.PlayStation.HighLevel.UI;

namespace Game2
{
	public class LevelScene : Sce.PlayStation.HighLevel.GameEngine2D.Scene
	{
		private Sce.PlayStation.HighLevel.UI.Scene scene;
		private UiScene ui;
		private static Background background;
		private Player player;
		private Platform[] platform;
		private Collectable collectable;
		List<Rectangle> topEdges;
		List<Rectangle> bottomEdges;
		List<Rectangle> rightEdges;
		List<Rectangle> leftEdges;
		
		
		
		//Music reading variables section
		private static string directory = "Application/assests/Audio/ROCK_YOU.wav";
		private static Sound music = new Sound(directory);
        private static SoundPlayer sp = music.CreatePlayer();
        private static FileStream fs = System.IO.File.OpenRead(directory);
        private static BinaryReader br;

        //Wav file variables
        private static bool IsWavFileStereo = true; 
        private static double WavSamplesPerSecond;
        private static double WavSamplesPer10Mil;
        private static double WavBytesPerSample;
        private static long bytes = 36;

        //Randomness
        private static Random rndseed = new Random();
        private static Random rnd;
		
        //These integers are for the MusicLoop method to use for analysing the track to decide upon different things
        private static int musicInt1, musicInt2, musicInt3, musicInt4, musicInt5, musicInt6, musicInt7, musicInt8, musicInt9;
 		
		
        private static bool SongIsReady = false;

        //Bool to tell when this is the second time going through the wav file
        private static bool SecondRun = false;
		
		//Bool to tell us the difference in bytes and thus the samplerate
        private static int byteDifference = 0;
		
		//Instance of a tone struct
        private static Tone t = Tone.lesser;
		
		//Bools to manage when certain actions are processed during the first run
        private static bool firstrun2 = true;
		private static bool firstrun3 = true;
		
		
		//Variables to control when the music is read from, thus dictating how often the platforms are given new heights
        private static int platformControlValue = 20;
        private static double platformHeightConstant = 0.40;
        private static int millisecondWaitTime = 75;
        private static int platformLimit = 3;
        private static int GenerationTriggerValue = 40;
		
		//Various timers to assist in timing the music/reading operations
        private static Timer currentTime = new Timer();
        private static Timer timer = new Timer();
        private static long TotalGameTime = 0;
        private static Timer RTS = new Timer();
       
		
		//bools to control whether the next platforms height can be altered yet
        private static bool Waiting = false;
        private static bool AllowPlatformHeightChange = true;
		
		//Timer for waiting...
        private static Timer WaitTime = new Timer();
		
		//Bool to tell us if we need to time our waiting
        private static bool NeedToTimeWait = true;
		
		//Variables used for deciding whether or not to update platform height/read from song in more depth
        private static int mi = 0;
        private static int pvc = 0;
        private static bool PlatformHeightMadeAlready = false;
        private static double PFirst = 0, PSec = 0;
        private static double fms = 0;
		private static bool BREnded;


        private static int score = 0;
        private static int multiplier = 1;
        private static int streak = 0;
		
		
		private static float nextPlatformHeight;
		
		
		private static COLLECTABLES nextCollectable;
		
		
		public LevelScene()
		{
			Initialise();
			
			this.Camera.SetViewFromViewport();
			Scheduler.Instance.ScheduleUpdateForTarget(this,0,false);
			this.RegisterDisposeOnExitRecursive();
			//AudioManager.Instance.PlayLevelBgm();
		}
		
		public void Initialise()
		{
			
			
			//InitialiseFiles();
			scene = new Sce.PlayStation.HighLevel.UI.Scene();
			
			background = new Background(this);
			platform = new Platform[3];
			
			platform[0] = new Platform(this, 100.0f, 60.0f);
			
			platform[1] = new Platform(this, 600.0f, 130.0f);
			platform[2] = new Platform(this, 1100.0f, 210.0f);
			
			TextureInfo collectTexture = new TextureInfo("/Application/assests/Textures/collectableTEMP.png"); 
			nextPlatformHeight = 100.0f;
			collectable = new Collectable(COLLECTABLES.SCORE_MULTIPLIER, this, collectTexture);
			collectable.ResetCollectable(nextPlatformHeight);
			player = new Player(this);
			ui = new UiScene(scene, this, ref player);
			UISystem.SetScene(scene);
			
			InitialiseMusic();
		}
		
		public override void OnEnter()
		{
			base.OnEnter();
		}
		
		public override void Update(float dt)
		{
			
			base.Update(dt);
			var gamePadData = GamePad.GetData(0);
			List<TouchData> touches = Touch.GetData(0);
			MusicLoop ();
			//Console.WriteLine(nextPlatformHeight);
			if(player.Alive == true)
			{
				background.Update();
				for(int i = 0; i < 3; i++)
				{
					if(platform[i].GetX () < 0 - platform[i].sprite.TextureInfo.Texture.Width)
					{
						platform[i].RespawnToMusic(nextPlatformHeight);
					}
					platform[i].Update();
					
					/*
					if(CheckSpriteCollisions(platform[i].sprite, player.sprite))
					{
						if(!player.gIsJumping)
						{
							player.sprite.Position = new Vector2(player.sprite.Position.X, platform[i].sprite.Position.Y+platform[i].sprite.CalcSizeInPixels().Y);
							player.jumpCount = 0;
							if(player.GetGrounded() == false)
							{
								ui.AddScore(5000*player.GetMultiplier());
								player.SetGrounded(true);
							}
						}else if (player.gIsJumping)
						{
//							if(player.sprite.Position.Y < platform[i].sprite.Position.Y + platform[i].sprite.TextureInfo.Texture.Height)
//							{
//								player.sprite.Position = new Vector2(player.sprite.Position.X, player.sprite.Position.Y - player.GetJumpSpeed());
//							}
							player.sprite.Position = new Vector2(player.sprite.Position.X, player.sprite.Position.Y - player.GetJumpSpeed());
						}
					}*/
					
//					else if(platform[i].HasCollidedWithBottom(player.sprite) == true)
//					{
//						player.isJumping = false;
//					}
				}
				/*
				if(CheckSpriteCollisions(player.sprite, collectable.GetSprite()))
				{
					if(collectable.GetPowerupType() == COLLECTABLES.SCORE_MULTIPLIER)
					{
						player.AddToMultiplier();
						collectable.ResetCollectable(nextPlatformHeight + 50.0f);
					}
				}
				*/
				collectable.Update();
				player.Update();
				
				topEdges = new List<Rectangle>();
				topEdges.Add(platform[0].Top);
				topEdges.Add(platform[1].Top);
				topEdges.Add(platform[2].Top);
				
				bottomEdges = new List<Rectangle>();
				bottomEdges.Add(platform[0].Bottom);
				bottomEdges.Add(platform[1].Bottom);
				bottomEdges.Add(platform[2].Bottom);
				
				leftEdges = new List<Rectangle>();
				leftEdges.Add(platform[0].Left);
				leftEdges.Add(platform[1].Left);
				leftEdges.Add(platform[2].Left);
				
				rightEdges = new List<Rectangle>();
				rightEdges.Add(platform[0].Right);
				rightEdges.Add(platform[1].Right);
				rightEdges.Add(platform[2].Right);
				
				DoTopEdgesIntersect(player, topEdges);	
				DoBottomEdgesIntersect(player, bottomEdges);
				DoLeftEdgesIntersect(player, leftEdges);
				DoRightEdgesIntersect(player, rightEdges);
				
				ui.Update(player.life);
			}
		}
		
		public bool CheckSpriteCollisions(SpriteUV sp1, SpriteUV sp2)
		{
			float x1 = sp1.Position.X, x2 = sp2.Position.X;
			float y1 = sp1.Position.Y, y2 = sp2.Position.Y;
			
			int height1 = sp1.TextureInfo.Texture.Height;
			int height2 = sp2.TextureInfo.Texture.Height;
			
			int width1 = sp1.TextureInfo.Texture.Width;
			int width2 = sp2.TextureInfo.Texture.Width;
			
			if(x1 < x2 + width2 && x1+width1 > x2 && y1 < y2 + height2 && y1 + height1 > y2)
			{
				return true;
			} else 
			{
				return false;
			}
		}
		
		public override void Draw()
		{
			base.Draw();
		}
		
		public static void MusicLoop()
		{
			
			try
			{
			//Set PFirst to PSec
			  PFirst = PSec;
	            
	           //Reset the current time
	           currentTime.Reset();
	            
				 if (pvc == platformControlValue)
                    pvc = 0;
				// BaseStream setting
	            br.BaseStream.Position = bytes;
	            
				
	           //Check if enough time has passed to start reading the song
	            if (timer.Milliseconds() > 3000)
	            {
	                if (firstrun2)
	                {
	                    firstrun2 = false;
	                    SongIsReady = true;
	                    RTS.Reset();
	                    currentTime.Reset();
	                }
	            }
	            
	            //Check to see if enough time has passed to start playing the song
	            if (firstrun3 && timer.Milliseconds() > 4666)
	            {
	                sp.Play();
	                firstrun3 = false;
	            }
	            
	            //If the song is ready, start reading it
	            if (SongIsReady)
	            {
	                //check to see if the amount of time that has passed divided by 10 is over -7 and less then 7
	                if (timer.Milliseconds() % 10 < 7 && timer.Milliseconds() % 10 > -7)
	                {
						
						
	                    
	                    if (WavBytesPerSample == 1)
	                    {
							//Read in the firest four bytes of the wav file
	                        musicInt1 = br.ReadByte();
	                        musicInt2 = br.ReadByte();
	                        musicInt3 = br.ReadByte();
	                        musicInt4 = br.ReadByte();
							
							//Read in the samples per 10 milliseconds * bytes per sample - 4 and convert those to an Int32
	                        br.ReadBytes(Convert.ToInt32(WavSamplesPer10Mil * WavBytesPerSample - 4));
							
							//Check to see if this is the second run through the loop
	                        if (SecondRun)
	                        {
								
	                            //Checks to see what frequency the music is at currently by doing 
								//an absolute value calculation on various bytes previously read in
	                            if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference > 40)
	                                t = Tone.upper;
	                            if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference > 80)
	                                t = Tone.veryhigh;
	                            if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference < 40)
	                                t = Tone.lesser;
	                            if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference < 80)
	                                t = Tone.verylow;
	                            if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference < 20 && System.Math.Abs(musicInt1 - musicInt2) - byteDifference > -20)
	                                t = Tone.similar;
	                            if (musicInt1 < 4 || musicInt2 < 4 || musicInt3 < 4 || musicInt4 < 4)
	                                t = Tone.nullified;
	                            if (System.Math.Abs(musicInt1 - musicInt3) < 20 && System.Math.Abs(musicInt2 - musicInt4) < 20)
	                                t = Tone.dualnote;
	                            if (musicInt1 > 240 || musicInt2 > 240 || musicInt3 > 240 || musicInt4 > 240)
	                                t = Tone.explosion;
	                            
	                        }
	                        byteDifference = System.Math.Abs(musicInt1 - musicInt2);
	                        SecondRun = true;
	                    }
	                    
	                    
	                    else if (WavBytesPerSample == 2 && IsWavFileStereo == false)
	                    {
	                        //Read in 8 bytes
	                        musicInt1 = br.ReadByte();
	                        musicInt2 = br.ReadByte();
	                        musicInt3 = br.ReadByte();
	                        musicInt4 = br.ReadByte();
	                        musicInt5 = br.ReadByte();
	                        musicInt6 = br.ReadByte();
	                        musicInt7 = br.ReadByte();
	                        musicInt8 = br.ReadByte();
	                        
	                        // Compress the 8 ints read in previously down into 4 ints
	                        musicInt1 = musicInt1 + musicInt2 * 0x100;
	                        musicInt2 = musicInt3 + musicInt4 * 0x100;
	                        musicInt3 = musicInt5 + musicInt6 * 0x100;
	                        musicInt4 = musicInt7 + musicInt8 * 0x100;
	                        
							///Read in the samples per 10 milliseconds * bytes per sample - 8 and convert those to an Int32
	                        br.ReadBytes(Convert.ToInt32(WavSamplesPer10Mil * WavBytesPerSample - 8));
	                        if (SecondRun)
	                        {
								
	                            
	                            if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference > 10240)
	                                t = Tone.upper;
	                            if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference > 20480)
	                                t = Tone.veryhigh;
	                            if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference < 10240)
	                                t = Tone.lesser;
	                            if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference < 20480)
	                                t = Tone.verylow;
	                            if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference < 5120 && System.Math.Abs(musicInt1 - musicInt2) - byteDifference > -5120)
	                                t = Tone.similar;
	                            if (musicInt1 < 1024 || musicInt2 < 1024 || musicInt3 < 1024 || musicInt4 < 1024)
	                                t = Tone.nullified;
	                            if (System.Math.Abs(musicInt1 - musicInt3) < 5120 && System.Math.Abs(musicInt2 - musicInt4) < 5120)
	                                t = Tone.dualnote;
	                            if (musicInt1 > 61440 || musicInt2 > 61440 || musicInt3 > 61440 || musicInt4 > 61440)
	                                t = Tone.explosion;
	                            
	                        }
	                        byteDifference = System.Math.Abs(musicInt1 - musicInt2);
	                        SecondRun = true;
	                    }
	                    
	                    
	                    else if (WavBytesPerSample == 2 && IsWavFileStereo)
	                    {
							//Read in 4 bytes, but since this is stereo discard each other byte from being stored in an int
	                        musicInt1 = br.ReadByte();
	                        br.ReadByte();
	                        musicInt2 = br.ReadByte();
	                        br.ReadByte();
	                        musicInt3 = br.ReadByte();
	                        br.ReadByte();
	                        musicInt4 = br.ReadByte();
	                        br.ReadByte();
							
							
	                        br.ReadBytes(Convert.ToInt32(WavSamplesPer10Mil * WavBytesPerSample - 8));
	                        if (SecondRun)
	                        {
	                           
	                            if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference > 40)
	                                t = Tone.upper;
	                            if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference > 80)
	                                t = Tone.veryhigh;
	                            if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference < 40)
	                                t = Tone.lesser;
	                            if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference < 80)
	                                t = Tone.verylow;
	                            if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference < 20 && System.Math.Abs(musicInt1 - musicInt2) - byteDifference > -20)
	                                t = Tone.similar;
	                            if (musicInt1 < 4 || musicInt2 < 4 || musicInt3 < 4 || musicInt4 < 4)
	                                t = Tone.nullified;
	                            if (System.Math.Abs(musicInt1 - musicInt3) < 20 && System.Math.Abs(musicInt2 - musicInt4) < 20)
	                                t = Tone.dualnote;
	                            if (musicInt1 > 240 || musicInt2 > 240 || musicInt3 > 240 || musicInt4 > 240)
	                                t = Tone.explosion;
	                            
	                        }
	                        byteDifference = System.Math.Abs(musicInt1 - musicInt2);
	                        SecondRun = true;
	                    }
	                    
	                   
	                    else if (WavBytesPerSample == 4)
	                    {
	                       
	                        musicInt1 = br.ReadByte();
	                        musicInt2 = br.ReadByte();
	                        br.ReadBytes(2);
	                        musicInt3 = br.ReadByte();
	                        musicInt4 = br.ReadByte();
	                        br.ReadBytes(2);
	                        musicInt5 = br.ReadByte();
	                        musicInt6 = br.ReadByte();
	                        br.ReadBytes(2);
	                        musicInt7 = br.ReadByte();
	                        musicInt8 = br.ReadByte();
	                        br.ReadBytes(2);
	                        
	                        
	                        musicInt1 = musicInt1 + musicInt2 * 0x100;
	                        musicInt2 = musicInt3 + musicInt4 * 0x100;
	                        musicInt3 = musicInt5 + musicInt6 * 0x100;
	                        musicInt4 = musicInt7 + musicInt8 * 0x100;
	                        
	                        bytes += Convert.ToInt32(WavSamplesPer10Mil * WavBytesPerSample - 16);
	                        if (SecondRun)
	                        {
	                           
	                            if (System.Math.Abs(musicInt1 - musicInt3) < 5120 && System.Math.Abs(musicInt2 - musicInt4) < 5120)
	                                t = Tone.dualnote;
	                            else if (musicInt1 > 61440 || musicInt2 > 61440 || musicInt3 > 61440 || musicInt4 > 61440)
	                                t = Tone.explosion;
	                            else if (musicInt1 < 1024 || musicInt2 < 1024 || musicInt3 < 1024 || musicInt4 < 1024)
	                                t = Tone.nullified;
	                            else
	                            {
	                                if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference > 10240)
	                                    t = Tone.upper;
	                                else if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference > 20480)
	                                    t = Tone.veryhigh;
	                                else if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference < 10240)
	                                    t = Tone.lesser;
	                                else if (System.Math.Abs(musicInt1 - musicInt2) - byteDifference < 20480)
	                                    t = Tone.verylow;
	                                else if (System.Math.Abs(musicInt1 - musicInt3) - byteDifference < 5120 && System.Math.Abs(musicInt1 - musicInt3) - byteDifference > -5120)
	                                    t = Tone.similar;
	                            }
	
	                            
	                        }
	                        byteDifference = System.Math.Abs(musicInt1 - musicInt2);
	                        SecondRun = true;
	                    }
	                    
	                    else
	                    {
	                        Console.WriteLine("You're not using a wav file!!!");
	                    }
	                    pvc++;
						
						//calculate whether or not another platform should be allowed
	                    if (pvc == 1)
                            mi = (musicInt1 + mi * (platformControlValue - 3)) / platformControlValue;
                        else
                            mi += (musicInt1 - mi) / pvc;
						
	                    TotalGameTime += 10;
	                }
	                
	                // Fix potential skipping that may occur in the loop
	                if (RTS.Milliseconds() - TotalGameTime > 10)
	                {
	                    bytes += Convert.ToInt32(System.Math.Round((WavSamplesPerSecond * WavBytesPerSample * ((RTS.Milliseconds() - TotalGameTime) / 1000.0)), 0, MidpointRounding.AwayFromZero));
	                    TotalGameTime = (long)RTS.Milliseconds();
	                }
	                
	            }
	            
	            // PSec manipulation via using the current mi calculation / 256 * 100 or 65526 * 100 as neccesary
	            if ((WavBytesPerSample == 1 || (WavBytesPerSample == 2 && IsWavFileStereo)) && pvc > 3)
	                PSec = mi / 256.0 * 100.0;
	            if (WavBytesPerSample == 4 || (WavBytesPerSample == 2 && !IsWavFileStereo) && pvc > 3)
	                PSec = mi / 65536.0 * 100.0;
	            
				//calculate fms to decide whether or not it is time to allow the platform height to be updated
	            fms = ((PFirst - PSec) * 100 + fms) / 2;
				
				//check to see if the pvc is over the platform limit
	            if (pvc >= platformLimit & AllowPlatformHeightChange)
	            { 
	                // platform not made already
	                if (!PlatformHeightMadeAlready)
	                {
	                    // 256
	                    if (WavBytesPerSample == 1 || (WavBytesPerSample == 2 && IsWavFileStereo == true))
	                    {
	                        if (musicInt1 / 256.0 > 0.4)
	                        {
	                            Waiting = true;
	                            PlatformHeightMadeAlready = true;
	                        }
	                    }
	                    
	                    // 65536
	                    if (WavBytesPerSample == 4 || (WavBytesPerSample == 2 && IsWavFileStereo == false))
	                    {
	                        if (musicInt1 / 65536.0 > 0.4)
	                        {
	                            Waiting = true;
	                            PlatformHeightMadeAlready = true;
	                        }
	                    }
	                    
	                }
	                
	                // platform made already
	                if (PlatformHeightMadeAlready)
	                {
	                    // 256
	                    if (WavBytesPerSample == 1 || (WavBytesPerSample == 2 && IsWavFileStereo))
	                    {
	                        if ((PSec - PFirst) / 256.0 * 10000.0 > platformHeightConstant && AllowPlatformHeightChange)
	                        {
	                            // Frequencies
	                            if (t == Tone.upper)
	                                nextPlatformHeight = 100.0f;
	                            if (t == Tone.similar)
	                                nextPlatformHeight = 100.0f;
	                            if (t == Tone.lesser)
	                                nextPlatformHeight = 200.0f;
	                            if (t == Tone.veryhigh)
	                                nextPlatformHeight = 200.0f;
	                            if (t == Tone.verylow)
	                                nextPlatformHeight = 300.0f;
	                            if (t == Tone.explosion)
	                                nextPlatformHeight = 400.0f;
	                            if (t == Tone.nullified)
	                                nextPlatformHeight = 400.0f;
	                            
	                            // Dual note detected
	                            if (t == Tone.dualnote)
	                            {
	                                musicInt9 = rnd.Next(1, 4);
	                                if (musicInt9 == 1)
	                                {
	                                    nextPlatformHeight = 100.0f;
	                                    nextCollectable = COLLECTABLES.HEALTH_PICKUP; 
	                                }
	                                if (musicInt9 == 2)
	                                {
	                                   nextPlatformHeight = 200.0f;
	                                    nextCollectable = COLLECTABLES.SCORE_MULTIPLIER; 
	                                }
	                                if (musicInt9 == 3)
	                                {
	                                   nextPlatformHeight = 300.0f;
	                                    nextCollectable = COLLECTABLES.SCORE_MULTIPLIER; 
	                                }
	                            }
	                            
	                           
	                            Waiting = true;
	                            NeedToTimeWait = true;
	                        }
	                    }
	                    
	                    // 65536
	                    if (WavBytesPerSample == 4 || (WavBytesPerSample == 2 && !IsWavFileStereo))
	                    {
	                        if ((PSec - PFirst) / 65536.0 * 10000.0 > platformHeightConstant & AllowPlatformHeightChange)
	                        {
	                            // Frequencies
	                             if (t == Tone.upper)
	                                nextPlatformHeight = 100.0f;
	                            if (t == Tone.similar)
	                                nextPlatformHeight = 100.0f;
	                            if (t == Tone.lesser)
	                                nextPlatformHeight = 200.0f;
	                            if (t == Tone.veryhigh)
	                                nextPlatformHeight = 200.0f;
	                            if (t == Tone.verylow)
	                                nextPlatformHeight = 300.0f;
	                            if (t == Tone.explosion)
	                                nextPlatformHeight = 400.0f;
	                            if (t == Tone.nullified)
	                                nextPlatformHeight = 400.0f;
	                            
	                            // Dual note detected
	                            if (t == Tone.dualnote)
	                            {
	                                musicInt9 = rnd.Next(1, 4);
	                                if (musicInt9 == 1)
	                                {
	                                    nextPlatformHeight = 100.0f;
	                                    nextCollectable = COLLECTABLES.HEALTH_PICKUP; 
	                                }
	                                if (musicInt9 == 2)
	                                {
	                                   nextPlatformHeight = 200.0f;
	                                    nextCollectable = COLLECTABLES.SCORE_MULTIPLIER; 
	                                }
	                                if (musicInt9 == 3)
	                                {
	                                    nextPlatformHeight = 300.0f;
	                                    nextCollectable = COLLECTABLES.SCORE_MULTIPLIER; 
	                                }
	                            }
	                            
	                           
	                            Waiting = true;
	                            NeedToTimeWait = true;
	                        }
	                    }
	                    
	                }
	                
	            }
	            
	            // if waiting is true
	            if (Waiting)
	            {
	                AllowPlatformHeightChange = false;
	                // Need to time wait section
	                if (NeedToTimeWait)
	                {
	                    WaitTime.Reset();
	                    NeedToTimeWait = false;
	                }
	                
	                // To wait for another platform to be made
	                if (WaitTime.Milliseconds() > millisecondWaitTime)
	                {
	                    // 256
	                    if (WavBytesPerSample == 1 || (WavBytesPerSample == 2 && IsWavFileStereo == true))
	                    {
	                        if (fms > GenerationTriggerValue)
	                        {
	                            WaitTime.Reset();
	                            AllowPlatformHeightChange = true; NeedToTimeWait = true;
	                        }
	                    }
	                    
	                    // 65536
	                    if ((WavBytesPerSample == 2 && IsWavFileStereo == true) || WavBytesPerSample == 4)
	                    {
	                        if (fms > GenerationTriggerValue)
	                        {
	                            WaitTime.Reset();
	                            AllowPlatformHeightChange = true; NeedToTimeWait = true;
	                        }
	                    }
	                }
	            }
	        }
			
	        // CATCH!
	        catch (System.IO.EndOfStreamException)
	        {
	            BREnded = true;
	        }

		}
		
		public static void InitialiseMusic()
		{
			int it;
            br = new BinaryReader(fs);
            
            //Read Samples per second
            br.BaseStream.Position = 24;
            it = br.Read();
            if (it == 68)
                WavSamplesPerSecond = 44100;
            else if (it == 34)
                WavSamplesPerSecond = 22050;
            else if (it == 17)
                WavSamplesPerSecond = 11025;
            else
                Console.WriteLine("Not supported SampleFrequency...");
            Console.WriteLine("Samples/Second: " + WavSamplesPerSecond);

            //Samples per 10 milliseconds
            WavSamplesPer10Mil = WavSamplesPerSecond / 100.0;

            //Read stereoism
            br.BaseStream.Position = 22;
            it = br.Read();
            if (it == 1)
            {
                IsWavFileStereo = false; Console.WriteLine("Using mono");
            }
            if (it == 2)
            {
                IsWavFileStereo = true; Console.WriteLine("Using Stereo");
            }

            //Read Bytes per sample
            br.BaseStream.Position = 32;
            WavBytesPerSample = br.Read();
            Console.WriteLine("Bytes per sample: " + WavBytesPerSample);
            
            br.BaseStream.Position = 36;
            rnd = new Random(rndseed.Next());

            timer.Reset();
		}
		
		private void DoTopEdgesIntersect(Player player, List<Rectangle> boxList)
		{
			foreach(Rectangle top in boxList)
			{
				if (player.PlayerBoundingBox.X < top.X + top.Width && 
				    player.PlayerBoundingBox.X + player.PlayerBoundingBox.Width > top.X && 
				    player.PlayerBoundingBox.Y < top.Y + top.Height && 
				    player.PlayerBoundingBox.Height + player.PlayerBoundingBox.Y > top.Y) 
				{
					player.IsOnPlatform = true;
	    			//Console.WriteLine("Collision Detected - TOP");
					player.Gravity = false;
					player.CanPlayerMoveLeft = true;
					player.CanPlayerMoveRight = true;
					return;
				}
				else
				{
					player.IsOnPlatform = false;
					player.Gravity = true;
					player.CanPlayerMoveLeft = true;
					player.CanPlayerMoveRight = true;
					//Console.WriteLine("No Collision");	
				}
			}
		}
		
		private void DoBottomEdgesIntersect(Player player, List<Rectangle> boxList)
		{
			foreach(Rectangle bottom in boxList)
			{
				if (player.PlayerBoundingBox.X < bottom.X + bottom.Width && 
					    player.PlayerBoundingBox.X + player.PlayerBoundingBox.Width > bottom.X && 
					    player.PlayerBoundingBox.Y < bottom.Y + bottom.Height && 
					    player.PlayerBoundingBox.Height + player.PlayerBoundingBox.Y > bottom.Y) 
					{
		    			//Console.WriteLine("Collision Detected - Bottom");
						player.Gravity = true;
						//player.isJumping = false;
						player.CanPlayerMoveLeft = true;
						player.CanPlayerMoveRight = false;
						return;
					}
					else
					{
						if(!player.IsOnPlatform) // was supposed to be player.!IsOnPlatform <========
						{
							player.Gravity = true;
						}
						player.CanPlayerMoveLeft = true;
						player.CanPlayerMoveRight = true;
						//Console.WriteLine("No Collision");	
					}
			}
		}
		
		private void DoLeftEdgesIntersect(Player player, List<Rectangle> boxList)
		{
			foreach(Rectangle left in boxList)
			{
				if (player.PlayerBoundingBox.X < left.X + left.Width && 
					    player.PlayerBoundingBox.X + player.PlayerBoundingBox.Width > left.X && 
					    player.PlayerBoundingBox.Y < left.Y + left.Height && 
					    player.PlayerBoundingBox.Height + player.PlayerBoundingBox.Y > left.Y) 
					{
		    			//Console.WriteLine("Collision Detected - LEFT");
						player.Gravity = false;
						player.CanPlayerMoveLeft = true;
						player.CanPlayerMoveRight = false;
						return;
					}
					else
					{
						if(!player.IsOnPlatform) // was supposed to be player.!IsOnPlatform <========
						{
							player.Gravity = true;
						}
						player.CanPlayerMoveLeft = true;
						player.CanPlayerMoveRight = true;
						//Console.WriteLine("No Collision");	
					}
			}
		}
		
		private void DoRightEdgesIntersect(Player player, List<Rectangle> boxList)
		{
			foreach(Rectangle right in boxList)
			{
				
				if (player.PlayerBoundingBox.X < right.X + right.Width && 
				    player.PlayerBoundingBox.X + player.PlayerBoundingBox.Width > right.X && 
				    player.PlayerBoundingBox.Y < right.Y + right.Height && 
				    player.PlayerBoundingBox.Height + player.PlayerBoundingBox.Y > right.Y) 
				{
	    			//Console.WriteLine("Collision Detected - Right");
					player.Gravity = true;
					player.CanPlayerMoveLeft = false;
					player.CanPlayerMoveRight = true;
					return;
				}
				else
				{
					if(!player.IsOnPlatform)
					{
						player.Gravity = true;
					}
					player.CanPlayerMoveLeft = true;
					player.CanPlayerMoveRight = true;
					//Console.WriteLine("No Collision");	
				}
			}
		}
	}
}

