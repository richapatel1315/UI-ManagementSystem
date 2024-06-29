using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Azure.BaseFramework;
using UnityEngine.SceneManagement;
using Azure.Data;
using Azure.BaseFramework.Interaction;

namespace Azure.UI
{
    public class ThankYouPopUp : UIScreenView
    {

        #region Variables

        #endregion
        #region OverRide_Methods
        private void OnEnable()
        {
            
         
        }
        private void OnDisable()
        {
           
            
        }
        public override void OnScreenShowCalled()
        {
            base.OnScreenShowCalled();

        }

        public override void OnScreenShowAnimationCompleted()
        {
            base.OnScreenShowAnimationCompleted();
        }

        public override void OnScreenHideCalled()
        {
            base.OnScreenHideCalled();

        }
        #endregion

        #region Public_Methods

        public void OnCloseTap()
        {
         //   PopUpController.Instance.HideScreen(PopUpType.ThankYou);
         
       
        }
        #endregion
        #region Private_Method

        #endregion
    }
}


