using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using Sce.PlayStation.HighLevel.UI;

namespace Game2
{
	public class LevelSelectScene : Sce.PlayStation.HighLevel.GameEngine2D.Scene
	{
		private float screenWidth;
		private float screenHeight;
		
		private TouchStatus touchStatus, lastTouchStatus;
		
		private Rectangle playRect;
		
		public LevelSelectScene ()
		{
			var screenSize = Director.Instance.GL.Context.GetViewport();
			screenWidth = screenSize.Width;
			screenHeight = screenSize.Height;
			
			Sce.PlayStation.HighLevel.UI.Scene scene = new Sce.PlayStation.HighLevel.UI.Scene();
			
			ImageBox play = new ImageBox();
			play.Image = new ImageAsset("/Application/assests/Textures/OptionsButton.png");
			play.ImageScaleType = ImageScaleType.AspectInside;
			play.Width = 602;
			play.Height = 143;
			play.X = 179;
			play.Y = 366;
			playRect = new Rectangle(play.X, play.Y, play.Width, play.Height);
			scene.RootWidget.AddChildLast(play);
			
			Game2.LevelSelect window = new Game2.LevelSelect();
			
			UISystem.SetScene(window);
			
			this.Camera.SetViewFromViewport();
			Scheduler.Instance.ScheduleUpdateForTarget(this,0,false);
			this.RegisterDisposeOnExitRecursive();
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
			
			UISystem.Update(touches);
			
			foreach(TouchData data in touches)
			{
				touchStatus = data.Status;
				float xPos = (data.X + 0.5f) * screenWidth;
				float yPos = (data.Y + 0.5f) * screenHeight;
				
				if(data.Status  == TouchStatus.Down)
				{
					if(ButtonHit(xPos, yPos, playRect))
					{
						Touch.GetData(0).Clear();
						SceneManager.Instance.SendSceneToFront(new LevelScene(), SceneManager.SceneTransitionType.SolidFade, 0.0f);
					}
					
					lastTouchStatus = touchStatus;
					
				}
			}
			
			if(AudioManager.Instance.BgmPlaying() == true)
				AudioManager.Instance.Update();
		}
		
		public override void Draw()
		{
			base.Draw();
		}
		
		private static bool ButtonHit(float pixelX, float pixelY, Rectangle button)
		{
			if(button.X <= pixelX && button.X + button.Width >= pixelX &&
			   button.Y <= pixelY && button.Y + button.Height >= pixelY)
			{
				return true;
			}
			return false;
		}
	}
}

