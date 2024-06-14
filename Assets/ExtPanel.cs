using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExtPanel : BasePanel
{
    private Button btnExt;

    protected override void Awake()
    {
        base.Awake();
        btnExt = this.GetComponent<Button>();
    }
    private void Start()
    {
        Registration();

    }
    void Registration()
    {
        btnExt.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}


