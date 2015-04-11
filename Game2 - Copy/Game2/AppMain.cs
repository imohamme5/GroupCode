using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.UI;

namespace Game2
{
	public enum COLLECTABLES
		{
			SCORE_MULTIPLIER = 0,
			HEALTH_PICKUP = 1
		};
	
	public enum Tone
    {
        upper, //above previous noise
        lesser, //lower then previous noise
        similar,// Roughly the same as the noise before
        veryhigh, //very high/shrill noise
        verylow, //very low/deep noise
        nullified,//incredibly quiet, alsmot silent noise
        explosion,//very loud noice
        dualnote //used when a continuing pattern is found
    }

	
	
	public class AppMain
	{
		
		public static void Main(string [] args)
		{
			Initialise();
			while(true)			///Game Loop
			{
				SystemEvents.CheckEvents();
				Director.Instance.Update();
				Director.Instance.Render();
				UISystem.Render();
				Director.Instance.GL.Context.SwapBuffers();
				Director.Instance.PostSwap();
			}
			Director.Terminate();
		}
		public static void Initialise()
		{
			Director.Initialize();
			UISystem.Initialize(Director.Instance.GL.Context);
			Profile profile = new Profile();
			profile.Load();
			MenuScene scnMenu = new MenuScene();
			Director.Instance.RunWithScene(scnMenu, true);
		}
	}
}
