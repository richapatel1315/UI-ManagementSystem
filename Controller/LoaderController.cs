using Azure.BaseFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Azure.UI
{
    public class LoaderController : Singleton<LoaderController>
    {
        public Canvas canvas;
        public GraphicRaycaster graphicRaycaster;
        public Animator loadingAnimator;
             
        private int requestLoaderCounter;

        private void Start()
        {
            requestLoaderCounter = 0;
        }

        public void showLoader()
        {
            Debug.Log("Loader Show Called");
            loadingAnimator.Play("Base Layer.Loading_Animation");
            requestLoaderCounter++;
            canvas.enabled = true;
            graphicRaycaster.enabled = true;

            Events.OnToggleRaycastBlocker(true);
        }

        public void HideLoader()
        {
            Debug.Log("Loader Hide Called");
            loadingAnimator.StopPlayback();

            requestLoaderCounter--;
            if (requestLoaderCounter <= 0)
            {
                requestLoaderCounter = 0;
                canvas.enabled = false;
                graphicRaycaster.enabled = false;
                Events.OnToggleRaycastBlocker(false);
            }
        }
        
        public bool IsActive()
        {
            return canvas.enabled;
        }
    }
}