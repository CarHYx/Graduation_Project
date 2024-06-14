using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel
{
    public Button btn;
    public override void Init()
    {
        Debug.Log("111");

        btn = btn.GetComponent<Button>();
        ButtonO();
    }

    public void ButtonO()
    {
        btn.onClick.AddListener(() =>
        {
            UIManger.GetInstance().HidPanel("GamePanel");
        });
    }
   
        
}
