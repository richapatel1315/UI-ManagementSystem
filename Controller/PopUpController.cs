using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Azure.BaseFramework
{
    [Serializable]
    public class PopUpScreen
    {
        public PopUpType popUpType;
        public UIScreenView screenView;
    }

    public enum PopUpType
    {
        None,
        Reset,
        Checkout
    }
    public class PopUpController : Singleton<PopUpController>
    {
        public List<PopUpScreen> popUps;
        public Canvas canvas;
	 #region Public_Methods        
        public void ShowNextScreen(PopUpType screenType, float Delay = 0.1f)
        {
            StartCoroutine(ExecuteAfterDelay(Delay, () =>
            {
                ShowScreen(screenType);
            }));
        }

        public void ShowScreen(PopUpType popUpType)
        {
            HideAllPopUps();
            getScreen(popUpType).Show();
        }

        public void HideScreen(PopUpType popUpType)
        {
            getScreen(popUpType).Hide();
        }

        public UIScreenView getScreen(PopUpType popUpType)
        {
            return popUps.Find(popUp => popUp.popUpType == popUpType).screenView;
        }

      
      public  void HideAllPopUps()
        {
            for (int i = 0; i < popUps.Count; i++)
            {
                PopUpType popUpType = popUps[i].popUpType;
                //OnScreenHideCalled();
                //ToggleCanvasState(false);
                HideScreen(popUpType);
            }
        }
	  #endregion

	#region Coroutine
  IEnumerator ExecuteAfterDelay(float Delay, Action CallbackAction)
        {
            yield return new WaitForSeconds(Delay);

            CallbackAction();
        }
	#endregion
    }
}