using System;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace Game2
{
	public class SceneManager
	{
		private static SceneManager instance;
		
		public enum SceneTransitionType
		{
			CrossFade,
			DirectionalFade,
			SolidFade,
		}
		
		public SceneManager()
		{
			
		}
		
		public static SceneManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance =new SceneManager();
				}
				return instance;
			}
		}
		
		public void SendSceneToFront(Scene nextScene, SceneTransitionType sceneTransition, float duration)
		{
			Touch.GetData(0).Clear();
			switch(sceneTransition)
				{
					case SceneTransitionType.CrossFade:	
						TransitionCrossFade crossFade = new TransitionCrossFade(nextScene);
						crossFade.Duration = duration;
						crossFade.Tween = (x) => Sce.PlayStation.HighLevel.GameEngine2D.Base.Math.PowEaseOut(x, 3.0f);
						Director.Instance.ReplaceScene(crossFade);
						break;
					case SceneTransitionType.DirectionalFade:
						TransitionDirectionalFade directionalFade = new TransitionDirectionalFade(nextScene);
						directionalFade.Duration = duration;
						directionalFade.Width =  0.75f;
						directionalFade.Direction = new Sce.PlayStation.Core.Vector2(10f,10f);
						Director.Instance.ReplaceScene(directionalFade);
						break;
					case SceneTransitionType.SolidFade:
						TransitionSolidFade solidFade = new TransitionSolidFade(nextScene);
						solidFade.Duration = duration;
						Director.Instance.ReplaceScene(solidFade);
						break;
					default:	
						throw new Exception("Expected transition to scene - error. Check stack trace to SceneManager.SendSceneToFront()");
						break;
			}
		}
	}
}

