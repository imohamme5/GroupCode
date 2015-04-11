using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Game2
{
	public class Player
	{
		public SpriteUV sprite;
		private TextureInfo textureInfo;
		private bool alive;
		public bool isJumping;
		private bool grounded;
		private float yBefore;
		public float life = 1.0f;
		public int jumpCount;
		private int jumpAmount = 85;
		bool canPlayerMoveLeft;
		bool canPlayerMoveRight;
		bool isOnPlatform = false;
		bool gravity = true;

		public bool Gravity {
			get {
				return this.gravity;
			}
			set {
				gravity = value;
			}
		}
		public bool CanPlayerMoveLeft {
			get {
				return this.canPlayerMoveLeft;
			}
			set {
				canPlayerMoveLeft = value;
			}
		}

		public bool CanPlayerMoveRight {
			get {
				return this.canPlayerMoveRight;
			}
			set {
				canPlayerMoveRight = value;
			}
		}

		public bool IsOnPlatform {
			get {
				return this.isOnPlatform;
			}
			set {
				isOnPlatform = value;
			}
		}

		Rectangle playerBoundingBox;

		public Rectangle PlayerBoundingBox {
			get {
				return this.playerBoundingBox;
			}
			set {
				playerBoundingBox = value;
			}
		}		
		
		//Float to control the speed/height of the jump
		private float _jumpSpeed;
		
		//Int that determines how much time the player goes upwards for after jump is pressed
		private int _maxJumpTime;
		
		//Int to be used as a timer for the jump, set to whatever _maxJumpTime is set to
		private int _jumpTimer;
		
		//Float to store how much the score should be multiplied by
		private float _scoreMultiplier;
		
		public bool Alive
		{
			get{return alive;}
			set{alive = value;}
		}
		
		public float Life
		{
			get{return life;}
			set{life = value;}
		}
		
		public bool gIsJumping
		{
			get{return isJumping;}
		}
		
		public Player (Scene scene)
		{
			textureInfo = new TextureInfo("/Application/assests/Textures/playerALTERED.png");
			sprite = new SpriteUV(textureInfo);
			sprite.Quad.S = textureInfo.TextureSizef;
			sprite.Position = new Vector2(50.0f, 0.0f);
			playerBoundingBox = new Rectangle(sprite.Position.X, sprite.Position.Y, sprite.TextureInfo.Texture.Width, sprite.TextureInfo.Texture.Height);
			
			//Setting up the jump values
			_jumpSpeed = 5.0f;
			_maxJumpTime = 40;
			_jumpTimer = _maxJumpTime;
			
			//Set score multiplier
			_scoreMultiplier = 1.0f;
			
			jumpCount = 0;
			isJumping = false;
			alive = true;
			scene.AddChild(sprite);
		}
		
		public void Dispose()
		{
			textureInfo.Dispose();
		}
		
		public void Update()
		{
			PlayerControls();
			ScreenCollision();
			if(isJumping && _jumpTimer > 0)
			{
				_jumpTimer--;
				sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y + _jumpSpeed);
				if(isJumping && _jumpTimer <= 0)
				{
					Console.WriteLine ("jumping set to false");
					isJumping = false;
					_jumpTimer = _maxJumpTime;
					sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y - _jumpSpeed);
				}
				
			}
			else
			{
				sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y - _jumpSpeed);
			}
			playerBoundingBox = new Rectangle(sprite.Position.X, sprite.Position.Y, sprite.TextureInfo.Texture.Width, sprite.TextureInfo.Texture.Height);
		}
		
		public bool GetGrounded()
		{
			return grounded;
		}
		
		public float GetJumpSpeed()
		{
			return _jumpSpeed;
		}
		
		public float GetMultiplier()
		{
			return _scoreMultiplier;
		}
		
		public void AddToMultiplier()
		{
			_scoreMultiplier += 0.1f;
		}
		
		public void SetGrounded(bool gr)
		{
			grounded = gr;
		}
		
		private void Jumped()
		{
			if(isJumping == false)
			{
				isJumping = true;
				grounded = false;
				jumpCount++;
				yBefore = sprite.Position.Y;
			}
		}
		
		public void PlayerControls()
		{
			var gamePadData = GamePad.GetData(0);
			if((gamePadData.Buttons & GamePadButtons.R) != 0)
			{
				if(jumpCount ==0)
				{
					Jumped();
				}
			}
		}
		
		public void ScreenCollision()
		{
			if(sprite.Position.X < 1 )
			{
				sprite.Position = new Vector2(1, sprite.Position.Y);
			}
			if(sprite.Position.Y < 1)
			{
				sprite.Position = new Vector2(sprite.Position.X, 1);
				jumpCount = 0;
			}
		}
	}
}

