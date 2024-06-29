using Azure.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Azure.BaseFramework
{
    [Serializable]
    public class UIScreen
    {
        public ScreenType screenType;
        public UIScreenView screenView;
    }

    public enum ScreenType
    {
        None,
        Auth,
        Home
    }
    public class UIController : Singleton<UIController>
    {
	#region Variables
        public ScreenType StartScreen;
        public List<UIScreen> Screens;
        public string screenName;
        [SerializeField]
        public List<ScreenType> currentScreens;

        [Header("References")]
        public SidePanelDisplayUI sidePanelDisplayUI;
	#endregion

        private IEnumerator Start()
        {
            currentScreens = new List<ScreenType>();

            yield return null;
            ShowScreen(StartScreen);

            yield return new WaitForSeconds(1f);

        }

        private void OnApplicationQuit()
        {
            Debug.Log("application quit");

            DataHandler.Instance.LocationScreenSession(false);
        }

        #region Public_Methods
        public void ShowNextScreen(ScreenType screenType, float Delay = 0.2f)
        {
            if (currentScreens.Count > 0)
            {
                HideScreen(currentScreens.Last());
            }
            else
            {
                Delay = 0;
            }

            StartCoroutine(ExecuteAfterDelay(Delay, () =>
            {
                ShowScreen(screenType);
            }));

        }

        public void ShowScreen(ScreenType screenType)
        {
            getScreen(screenType).Show();

            currentScreens.Add(screenType);
        }

        public void HideScreen(ScreenType screenType)
        {
            getScreen(screenType).Hide();

            currentScreens.Remove(screenType);
        }

        public UIScreenView getScreen(ScreenType screenType)
        {
            return Screens.Find(screen => screen.screenType == screenType).screenView;
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