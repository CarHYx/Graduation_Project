using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 一键提示面板
/// </summary>
public class OneBtnTipPanel : BasePanel 
{

	
	void Start () 
    {
        GetControl<Button>("btnSure").onClick.AddListener(() =>
        {
            UIManager.GetInstance().HidePanel("OneBtnTipPanel");
        });
	}
	
	public void InitInfo(string info)
    {
        GetControl<Text>("txtInfo").text = info;
    }

}
