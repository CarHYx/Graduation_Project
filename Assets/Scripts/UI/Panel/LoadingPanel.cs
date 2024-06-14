using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
namespace UIManinPanel
{
    public class LoadingPanel : BasePanel
    {
        private Slider progressbar;

        private float value = 1f;

        protected override void Init()
        {
            progressbar = this.transform.Find("Progressbar").GetComponent<Slider>();
            StartCoroutine(StartTimerCoroutine(value));

        }
        protected override void Awake()
        {
            base.Awake();
            AudioData();
        }


        //初始化当前音效相关
        private void AudioData()
        {
            AudioManager.GetInstanceMon().PlayMusic("BGM");
            AudioManager.GetInstanceMon().PlayEfftSources("monster", false);

        }




        private IEnumerator StartTimerCoroutine(float value)
        {
            while (value <= 5)
            {

                value++;
                progressbar.value += 0.2f;
                if (progressbar.value == 1)
                {
                    UIManager.GetInstance().HidePanel("LoadingPanel");
                    UIManager.GetInstance().ShowPanel<BeginPanel>("BeginPanel", E_UI_Layer.Top);
                }
                yield return new WaitForSeconds(1);
            }
        }
    }
}
