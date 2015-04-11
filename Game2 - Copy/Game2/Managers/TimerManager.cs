using System;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Game2
{
	public class TimeManager
	{
		private Timer time;
		private int t;
		
		public TimeManager ()
		{
			StartTimer();
		}
		public void StartTimer()
		{
			time = new Timer();
		}
		public void ResetTimer()
		{
			time.Reset();
		}
		
		public bool CheckTime()
		{
			t = (int)time.Seconds();
			if(t == 1)
			{
				ResetTimer();
				return true;
			}
			else
				return false;
		}
	}
}

