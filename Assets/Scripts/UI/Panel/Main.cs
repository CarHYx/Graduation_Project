using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UIManinPanel
{
    public class Main : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GameDataMgr.GetInstance().Init();
            BagMgr.GetInstance().Init();

            Debug.Log(GameDataMgr.GetInstance().GetItemInfo(1).name);
            UIManager.GetInstance().ShowPanel<LoadingPanel>("LoadingPanel", E_UI_Layer.Bot);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


