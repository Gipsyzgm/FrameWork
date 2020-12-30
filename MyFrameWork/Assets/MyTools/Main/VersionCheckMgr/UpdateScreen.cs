using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyFrameWork
{
    public class UpdateScreen : MonoBehaviour, IUpdater
    {
        public Button buttonStart;
        public Slider progressBar;
        public Text progressText;
        public Text version;

        private void Start()
        {
            try
            {
                version.text =  "资源版本号: v"+Application.version+"res"+Versions.LoadVersion(Application.persistentDataPath + '/' + Versions.Filename);
            }
            catch(Exception e)
            {
                version.text =  "初始版本";
            }
            var updater = FindObjectOfType<Updater>();
            updater.listener = this;
        }

        #region IUpdateManager implementation

        public void OnStart()
        {
            buttonStart.gameObject.SetActive(false);
        }

        public void OnMessage(string msg)
        {
            progressText.text = msg;
        }

        public void OnProgress(float progress)
        {
            progressBar.value = progress;
        }

        public void OnVersion(string ver)
        {
            version.text = ver;
        }


        public void OnClear()
        {
            buttonStart.gameObject.SetActive(true);
        }

        #endregion
    }
}