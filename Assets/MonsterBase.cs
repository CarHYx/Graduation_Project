using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponentsInChildren<Transform>().Length <= 1)
        {
            UIManager.GetInstance().ShowPanel<GameVictoryPanel>("GameVictoryPanel", E_UI_Layer.System);
        }
        
    }
}
