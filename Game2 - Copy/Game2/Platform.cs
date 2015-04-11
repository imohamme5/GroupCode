using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Game2
{
	public class Platform
	{
		public SpriteUV sprite;
		private TextureInfo textureInfo;
		
		Rectangle top;
		Rectangle left;
		Rectangle right;
		Rectangle bottom;
		
		private const int PLATFORM_OFFSET = 2;
		private const int BB_OFFSET = 10;
		private const int Left_OFFSET = 5;
		
		public Platform(Scene scene, float x, float y)
		{
			textureInfo = new TextureInfo("/Application/assests/Textures/Platform.png");
			sprite = new SpriteUV(textureInfo);
			sprite.Quad.S = textureInfo.TextureSizef;
			sprite.Position = new Vector2(x, y);
			
			top = new Rectangle(sprite.Position.X + BB_OFFSET, sprite.Position.Y +  sprite.TextureInfo.Texture.Height, sprite.TextureInfo.Texture.Width - (BB_OFFSET * 2),
			                     PLATFORM_OFFSET);
			left = new Rectangle(sprite.Position.X, sprite.Position.Y - Left_OFFSET, sprite.TextureInfo.Texture.Width , sprite.TextureInfo.Texture.Height - (Left_OFFSET * 2)); 
			bottom = new Rectangle(sprite.Position.X, sprite.Position.Y, sprite.TextureInfo.Texture.Width - (BB_OFFSET * 2), 1);
			right = new Rectangle(sprite.Position.X + sprite.TextureInfo.Texture.Width, sprite.Position.Y - Left_OFFSET, Left_OFFSET, sprite.TextureInfo.Texture.Height - (Left_OFFSET * 2)); 
			

			scene.AddChild(sprite);
		}
		
		public void Dispose()
		{
			textureInfo.Dispose();
		}
		
		public void Update()
		{
//			if(sprite.Position.X+sprite.CalcSizeInPixels().X < 0)
//			{
//				sprite.Position = new Vector2(1060, sprite.Position.Y);
//			}
//			else
			sprite.Position = new Vector2(sprite.Position.X - 3.0f, sprite.Position.Y);
			
			top = new Rectangle(sprite.Position.X + BB_OFFSET, sprite.Position.Y +  sprite.TextureInfo.Texture.Height, sprite.TextureInfo.Texture.Width - (BB_OFFSET * 2),
			                     PLATFORM_OFFSET);
			left = new Rectangle(sprite.Position.X, sprite.Position.Y - Left_OFFSET, sprite.TextureInfo.Texture.Width , sprite.TextureInfo.Texture.Height - (Left_OFFSET * 2)); 
			bottom = new Rectangle(sprite.Position.X, sprite.Position.Y, sprite.TextureInfo.Texture.Width - (BB_OFFSET * 2), 1);
			right = new Rectangle(sprite.Position.X + sprite.TextureInfo.Texture.Width, sprite.Position.Y - Left_OFFSET, Left_OFFSET, sprite.TextureInfo.Texture.Height - (Left_OFFSET * 2)); 
		}
		
		public void RespawnToMusic(float y)
		{
			sprite.Position = new Vector2(1060, y);
		}
		
		public float GetX()
		{
			return sprite.Position.X;
		}
		
		public void DoTopEdgesIntersect(Player player)
		{
			if (player.PlayerBoundingBox.X < top.X + top.Width && 
			    player.PlayerBoundingBox.X + player.PlayerBoundingBox.Width > top.X && 
			    player.PlayerBoundingBox.Y < top.Y + top.Height && 
			    player.PlayerBoundingBox.Height + player.PlayerBoundingBox.Y > top.Y) 
			{
				player.IsOnPlatform = true;
    			Console.WriteLine("Collision Detected - TOP");
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
		/*
		private void DoLeftEdgesIntersect(Rectangle a, List<Rectangle> boxList)
		{
			foreach(Rectangle b in boxList)
			{
				
				if (a.X < b.X + b.Width && 
				    a.X + a.Width > b.X && 
				    a.Y < b.Y + b.Height && 
				    a.Height + a.Y > b.Y) 
				{
	    			Console.WriteLine("Collision Detected - LEFT");
					gravity = false;
					canPlayerMoveLeft = true;
					canPlayerMoveRight = false;
					return;
				}
				else
				{
					if(!isOnPlatform)
					{
						gravity = true;
					}
					canPlayerMoveLeft = true;
					canPlayerMoveRight = true;
					//Console.WriteLine("No Collision");	
				}
			}
		}
		
		private void DoBottomEdgesIntersect(Rectangle a, List<Rectangle> boxList)
		{
			foreach(Rectangle b in boxList)
			{
				
				if (a.X < b.X + b.Width && 
				    a.X + a.Width > b.X && 
				    a.Y < b.Y + b.Height && 
				    a.Height + a.Y > b.Y) 
				{
	    			Console.WriteLine("Collision Detected - Bottom");
					gravity = true;
					canPlayerMoveLeft = true;
					canPlayerMoveRight = false;
					return;
				}
				else
				{
					if(!isOnPlatform)
					{
						gravity = true;
					}
					canPlayerMoveLeft = true;
					canPlayerMoveRight = true;
					//Console.WriteLine("No Collision");	
				}
			}
		}
		
		private void DoRightEdgesIntersect(Rectangle a, List<Rectangle> boxList)
		{
			foreach(Rectangle b in boxList)
			{
				
				if (a.X < b.X + b.Width && 
				    a.X + a.Width > b.X && 
				    a.Y < b.Y + b.Height && 
				    a.Height + a.Y > b.Y) 
				{
	    			Console.WriteLine("Collision Detected - Right");
					gravity = true;
					canPlayerMoveLeft = false;
					canPlayerMoveRight = true;
					return;
				}
				else
				{
					if(!isOnPlatform)
					{
						gravity = true;
					}
					canPlayerMoveLeft = true;
					canPlayerMoveRight = true;
					//Console.WriteLine("No Collision");	
				}
			}
		}*/
		
//		public bool HasCollidedWithTop(SpriteUV spriteP)
//		{
//            if((spriteP.Position.X + (spriteP.CalcSizeInPixels().X/2)) >= sprite.Position.X 
//			   && (spriteP.Position.X + (spriteP.CalcSizeInPixels().X/2)) <= sprite.Position.X+sprite.CalcSizeInPixels().X
//			   && spriteP.Position.Y <= sprite.Position.Y+sprite.CalcSizeInPixels().Y
//			   && spriteP.Position.Y > sprite.Position.Y)
//                return true;
//			
//            else
//                return false;
//		}
		
//		public bool HasCollidedWithBottom(SpriteUV spriteP)
//		{
//			if((spriteP.Position.X + (spriteP.CalcSizeInPixels().X/2)) >= sprite.Position.X
//			   && spriteP.Position.Y + (spriteP.CalcSizeInPixels().Y/2) >= sprite.Position.Y )
//			{
//				return true;
//				Console.WriteLine("Collision with bottom?");
//			}
//			else
//				return false;
//		}
	}
}

