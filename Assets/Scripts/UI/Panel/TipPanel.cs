using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipPanel : BasePanel
{
    public Text txtTip;

    public Button btnColse;


    protected override void Init()
    {
        Registration();
    }

    public override void ShowMe(string txtTips)
    {
        base.ShowMe(txtTips);
        txtTip.text = txtTips;
    }

    private void Registration()
    {
        btnColse.onClick.AddListener(() =>
        {
            UIManager.GetInstance().HidePanel("TipPanel");

        });
    }
}

