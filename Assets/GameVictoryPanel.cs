using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameVictoryPanel : BasePanel
{
    public Button btnQuite;

    protected override void Start()
    {
        //GameOver Quite
        btnQuite.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }




}
