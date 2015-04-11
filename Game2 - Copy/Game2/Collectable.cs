using System;


using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Game2
{
	public class Collectable
	{
		COLLECTABLES _type;
		TextureInfo _tex;
		SpriteUV _sprite;
		Vector2 _position;
		
		public Collectable (COLLECTABLES type, Scene scene, TextureInfo tex)
		{
			_type = type;
			_tex = tex;
			_sprite = new SpriteUV(tex);
			_sprite.Position = new Vector2(1060, 0);
			_sprite.Quad.S = _tex.TextureSizef;
			
			scene.AddChild(_sprite);
			_position = _sprite.Position;
		}
		
		public void Update()
		{
			if(_sprite.Position.X+_sprite.CalcSizeInPixels().X < 0)
			{
				_sprite.Position = new Vector2(1060, _sprite.Position.Y);
			}
			else
				_sprite.Position = new Vector2(_sprite.Position.X - 3.0f, _sprite.Position.Y);
		}
		
		public Vector2 GetPos()
		{
			return _sprite.Position;
		}
		
		public int GetWidth()
		{
			return _sprite.TextureInfo.Texture.Width;
		}
		
		public int GetHeight()
		{
			return _sprite.TextureInfo.Texture.Height;
		}
		
		public SpriteUV GetSprite()
		{
			return _sprite;
		}
		
		public COLLECTABLES GetPowerupType()
		{
			return _type;
		}
		
		public void ResetCollectable(float y)
		{
			_sprite.Position = new Vector2(1360, y);
		}
	}
}

