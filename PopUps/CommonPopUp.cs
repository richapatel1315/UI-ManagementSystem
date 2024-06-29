using Azure.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using Azure.BaseFramework;

namespace Azure.UI
{
    public class CommonPopUp : Singleton<CommonPopUp>
    {
        #region Variables
        public TextMeshProUGUI txtTitle;
        public TextMeshProUGUI txtAffirmativeButton;
        public TextMeshProUGUI txtNegativeButton;
        public TextMeshProUGUI txtOKButton;
        public Button btnAffirmativeAction;
        public Button btnNegativeAction;
        public Button btnOK;
        public Button backgroundOkButton;
        public Canvas _canvas;
        public GraphicRaycaster _raycaster;
        #endregion

	 #region Public_Methods
        public void DisplayConfirmationPanel(string message, string positiveButtonTitle, string negativeButtonTitle, UnityAction affirmativeAction, UnityAction negativeAction)
        {
            LoaderController.Instance.HideLoader();

            ToggleCanvasElements(true);
            txtTitle.text = message;

            txtAffirmativeButton.text = positiveButtonTitle;
            txtNegativeButton.text = negativeButtonTitle;

            btnAffirmativeAction.onClick.RemoveAllListeners();
            btnNegativeAction.onClick.RemoveAllListeners();
            btnAffirmativeAction.onClick.AddListener(affirmativeAction);
            btnNegativeAction.onClick.AddListener(negativeAction);

            btnAffirmativeAction.gameObject.SetActive(true);
            btnNegativeAction.gameObject.SetActive(true);
            btnOK.gameObject.SetActive(false);
            backgroundOkButton.gameObject.SetActive(false);

        }
        public void DisplayMessagePanel(string message, UnityAction playerAction=null)
        {
            LoaderController.Instance.HideLoader();

            ToggleCanvasElements(true);

            if (message == "")
                return;
            if (playerAction != null)
            {
                btnOK.onClick.AddListener(playerAction);
                backgroundOkButton.onClick.AddListener(playerAction);
            }
            else
            {
                btnOK.onClick.AddListener(HideToggleCanvasElements);
                backgroundOkButton.onClick.AddListener(HideToggleCanvasElements);
            }
            txtTitle.text = message;
            btnAffirmativeAction.gameObject.SetActive(false);
            btnNegativeAction.gameObject.SetActive(false);
            btnOK.gameObject.SetActive(true);
            backgroundOkButton.gameObject.SetActive(true);
            txtOKButton.text = "OK";
            gameObject.SetActive(true);
        }
     /*   public void DisplayMessagePanel(string message, UnityAction playerAction )
        {
            LoaderController.Instance.HideLoader();
            ToggleCanvasElements(true);

            if (message == "")
                return;

            if (playerAction != null)
                btnOK.onClick.AddListener(playerAction);
            else
                btnOK.onClick.AddListener(HideToggleCanvasElements);
            txtTitle.text = message;
            btnAffirmativeAction.gameObject.SetActive(false);
            btnNegativeAction.gameObject.SetActive(false);
            btnOK.gameObject.SetActive(true);
            txtOKButton.text ="OK";
            gameObject.SetActive(true);
        }
     */
        public void DisplayMessagePanelOnly(string message)
        {
            LoaderController.Instance.HideLoader();

            ToggleCanvasElements(true);
            txtTitle.text = message;
            btnOK.onClick.RemoveAllListeners();
            backgroundOkButton.onClick.RemoveAllListeners();
            btnAffirmativeAction.onClick.RemoveAllListeners();
            btnNegativeAction.onClick.RemoveAllListeners();
            btnAffirmativeAction.gameObject.SetActive(false);
            btnNegativeAction.gameObject.SetActive(false);
            btnOK.gameObject.SetActive(false);
            backgroundOkButton.gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
        public void ToggleCanvasElements(bool value)
        {
            _raycaster.enabled = value;
            _canvas.enabled = value;
        }
        public void HideToggleCanvasElements()
        {
            _raycaster.enabled = false;
            _canvas.enabled = false;
        }
	  #endregion
    }
}