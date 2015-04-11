using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Game2
{
	public class Background
	{	
		//Private variables.
		private float width;
		private SpriteUV[] sprites;
		private TextureInfo	textureInfoBackL, textureInfoBackM, textureInfoBackR,textureInfoMid, textureInfoFore;
		private float foreSpeed = 5.0f;
		private float midSpeed = 2.5f;
		private float backSpeed = 0.2f;
		
		//Public functions.
		public Background (Scene scene)
		{
			sprites	= new SpriteUV[9];
			
			textureInfoBackL = new TextureInfo("/Application/assests/Textures/backgroundL.png");
			//Left
			sprites[0] = new SpriteUV(textureInfoBackL);
			sprites[0].Quad.S = textureInfoBackL.TextureSizef;
			
			textureInfoBackM = new TextureInfo("/Application/assests/Textures/backgroundR.png");
			//Middle
			sprites[1] = new SpriteUV(textureInfoBackM);
			sprites[1].Quad.S = textureInfoBackM.TextureSizef;
			
			textureInfoBackR = new TextureInfo("/Application/assests/Textures/backgroundEND.png");
			//Right
			sprites[2] = new SpriteUV(textureInfoBackR);
			sprites[2].Quad.S = textureInfoBackR.TextureSizef;
			
			textureInfoMid = new TextureInfo("/Application/assests/Textures/backgroundMist.png");
			
			sprites[3] = new SpriteUV(textureInfoMid);
			sprites[3].Quad.S = textureInfoMid.TextureSizef;

			sprites[4]	= new SpriteUV(textureInfoMid);
			sprites[4].Quad.S = textureInfoMid.TextureSizef;

			sprites[5] = new SpriteUV(textureInfoMid);
			sprites[5].Quad.S = textureInfoMid.TextureSizef;
			
			textureInfoFore = new TextureInfo("/Application/assests/Textures/cablesALTERED.png");
			
			sprites[6] = new SpriteUV(textureInfoFore);
			sprites[6].Quad.S = textureInfoFore.TextureSizef;

			sprites[7] = new SpriteUV(textureInfoFore);
			sprites[7].Quad.S = textureInfoFore.TextureSizef;

			sprites[8] = new SpriteUV(textureInfoFore);
			sprites[8].Quad.S = textureInfoFore.TextureSizef;
			
			//Get sprite bounds.
			Bounds2 b = sprites[0].Quad.Bounds2();
			
			
			
			
			width = b.Point10.X;
			
			//Position 
			sprites[0].Position = new Vector2(0.0f, 0.0f);
			sprites[3].Position = new Vector2(0.0f, 0.0f);
			sprites[6].Position = new Vector2(0.0f, 0.0f);
			
			sprites[1].Position = new Vector2(sprites[0].Position.X+width, 0.0f);
			sprites[4].Position = new Vector2(sprites[0].Position.X+width, 0.0f);
			sprites[7].Position = new Vector2(sprites[0].Position.X+width, 0.0f);
			
			sprites[2].Position = new Vector2(sprites[1].Position.X+width, 0.0f);
			sprites[5].Position = new Vector2(sprites[1].Position.X+width, 0.0f);
			sprites[8].Position = new Vector2(sprites[1].Position.X+width, 0.0f);
			
			//Add to the current scene.
			foreach(SpriteUV sprite in sprites)
				scene.AddChild(sprite);
		}	
		
		public void Dispose()
		{
			textureInfoBackL.Dispose();
		}
		
		public void Update()
		{			
			//Move the background.Organised by section, then back, middle and foreground
			//Left
			if(sprites[0].Position.X < -width)
				sprites[0].Position = new Vector2(sprites[2].Position.X+width-backSpeed, 0.0f);
			else
				sprites[0].Position = new Vector2(sprites[0].Position.X-backSpeed, 0.0f);

			if(sprites[3].Position.X < -width)
				sprites[3].Position = new Vector2(sprites[5].Position.X+width-midSpeed, 0.0f);
			else
				sprites[3].Position = new Vector2(sprites[3].Position.X-midSpeed, 0.0f);
			
			if(sprites[6].Position.X < -width)
				sprites[6].Position = new Vector2(sprites[8].Position.X+width-(foreSpeed), 0.0f);
			else
				sprites[6].Position = new Vector2(sprites[6].Position.X-foreSpeed, 0.0f);	
			
			
			//Middle
			if(sprites[1].Position.X < -width)
				sprites[1].Position = new Vector2(sprites[0].Position.X+width, 0.0f);
			else
				sprites[1].Position = new Vector2(sprites[1].Position.X-backSpeed, 0.0f);	
			
			if(sprites[4].Position.X < -width)
				sprites[4].Position = new Vector2(sprites[3].Position.X+width, 0.0f);
			else
				sprites[4].Position = new Vector2(sprites[4].Position.X-midSpeed, 0.0f);
			
			if(sprites[7].Position.X < -width)
				sprites[7].Position = new Vector2(sprites[6].Position.X+width, 0.0f);
			else
				sprites[7].Position = new Vector2(sprites[7].Position.X-foreSpeed, 0.0f);
			
			
			//Right
			if(sprites[2].Position.X < -width)
				sprites[2].Position = new Vector2(sprites[1].Position.X+width-backSpeed, 0.0f);
			else
				sprites[2].Position = new Vector2(sprites[2].Position.X-backSpeed, 0.0f);
			
			if(sprites[5].Position.X < -width)
				sprites[5].Position = new Vector2(sprites[4].Position.X+width, 0.0f);
			else
				sprites[5].Position = new Vector2(sprites[5].Position.X-midSpeed, 0.0f);	
			
			if(sprites[8].Position.X < -width)
				sprites[8].Position = new Vector2(sprites[7].Position.X+width/*-(foreSpeed+2.0f)*/, 0.0f);
			else
				sprites[8].Position = new Vector2(sprites[8].Position.X-foreSpeed, 0.0f);	
		}
	}
}

