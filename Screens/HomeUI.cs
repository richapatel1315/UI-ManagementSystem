using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Azure.BaseFramework;
using TMPro;
using SimpleJSON;
using Azure.BaseFramework.Interaction;
using System.Drawing;
using System.Threading.Tasks;

namespace Azure.UI
{
    public class HomeUI : UIScreenView
    {
        public TMP_Dropdown dropdownLocation;
        public TMP_Dropdown dropdownScreen;
        public Button submitButton;
        public Image progressfillImage;
        public GameObject progressbarObject;

        private void OnEnable()
        {

            progressbarObject.SetActive(false);
//            progressfillImage.fillAmount = 0;


        }
        public override void OnScreenShowCalled()
        {
            base.OnScreenShowCalled();
//            dropdownScreen.gameObject.SetActive(false);
//            submitButton.gameObject.SetActive(false);
//            SessionTouchManager.Instance.enabled = false;

        }

        public override void OnScreenShowAnimationCompleted()
        {
            base.OnScreenShowAnimationCompleted();
        }

        public override void OnScreenHideCalled()
        {
            base.OnScreenHideCalled();
        }
       
        void dropdownLocationSelected(TMP_Dropdown dropdown)
        {
        }
    }
}