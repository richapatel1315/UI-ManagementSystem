using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Azure.UI
{
    public class PreventMultipleClicksButton : MonoBehaviour
    {

        protected Button button;

        protected virtual void Start()
        {
            button = GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(OnButtonClick);
            }
        }

        public virtual void OnButtonClick()
        {
            button.enabled = false;
            Invoke("EnableButton", 1.0f);

        }
        void EnableButton()
        {
            button.enabled = true;
        }

    }
}