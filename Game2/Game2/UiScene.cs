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
	public class UiScene : Sce.PlayStation.HighLevel.UI.Scene
	{
		private TimeManager timeManaged;
		private TextureInfo	textureInfoLifeBack, textureInfoLifeFront;
		private SpriteUV lifeBack, lifeFront;
		//private Player playerUi;
		private Sce.PlayStation.HighLevel.UI.Label ScoreLabel;
		private int score = 0;
		private float life;
		
		public UiScene (Sce.PlayStation.HighLevel.UI.Scene scene, 
		                Sce.PlayStation.HighLevel.GameEngine2D.Scene scene2D,ref Player player)
		{
			timeManaged = new TimeManager();
			
			Panel panel  = new Panel();
			panel.Width  = Director.Instance.GL.Context.GetViewport().Width;
			panel.Height = Director.Instance.GL.Context.GetViewport().Height;
			
			ScoreLabel = new Sce.PlayStation.HighLevel.UI.Label();
			ScoreLabel.SetPosition(825.0f, 0.0f);
			ScoreLabel.Text ="Score: "+ score.ToString();
			panel.AddChildLast(ScoreLabel);
			
			textureInfoLifeBack = new TextureInfo("/Application/assests/Textures/healthbarBack.png");
			lifeBack = new SpriteUV(textureInfoLifeBack);
			lifeBack.Quad.S = textureInfoLifeBack.TextureSizef;
			lifeBack.Position = new Vector2(0.0f,Director.Instance.GL.Context.GetViewport().Height - lifeBack.CalcSizeInPixels().Y);
			scene2D.AddChild(lifeBack);
			
			textureInfoLifeFront = new TextureInfo("/Application/assests/Textures/healthbarFront.png");
			lifeFront = new SpriteUV(textureInfoLifeFront);
			lifeFront.Quad.S = textureInfoLifeFront.TextureSizef;
			lifeFront.Position = new Vector2(0.0f,Director.Instance.GL.Context.GetViewport().Height - lifeFront.CalcSizeInPixels().Y);
			scene2D.AddChild(lifeFront);
			
			life = player.Life;
			
			scene.RootWidget.AddChildLast(panel);
		}
		
		public void Dispose()
		{
		}
		
		public void Update(float life)
		{
			UpdateLife(life);
			ManageScore();
		}
		
		public void ManageScore()
		{
			if(timeManaged.CheckTime() == true)
			{
				//score += 100;
			}
			else if(score >= 10000)
			{
				ScoreLabel.SetPosition(815f, 0f);
			}
			else if(score >= 100000)
			{
				ScoreLabel.SetPosition(805f, 0f);
			}
			else if(score >= 1000000)
			{
				ScoreLabel.SetPosition(805f, 0f);
			}
			
			ScoreLabel.Text ="Score: "+ score.ToString();
		}
		
		public int GetScore()
		{
			return score;
		}
		
		public void AddScore(float sc)
		{
			score += (int)sc;
		}
		
		public void UpdateLife(float life)
		{
			lifeFront.Scale = new Vector2(life, 1.0f);
		}
	}
}

