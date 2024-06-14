using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainPanel : BasePanel
{
    public Button btnExt;

    public Slider sliderHp;
    private Character character;
    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        character = GameObject.Find("Player").GetComponent<Character>();
        sliderHp.value = character.currentHP;
        GetControl<Button>("btnRole").onClick.AddListener(() =>
        {
            UIManager.GetInstance().ShowPanel<BagPanel>("BagPanel");
            UIManager.GetInstance().ShowPanel<RolePanel>("RolePanel");
        });

        //监听商店按钮事件 点击后 打开商店面板
        GetControl<Button>("btnShop").onClick.AddListener(() =>
        {
            UIManager.GetInstance().ShowPanel<ShopPanel>("ShopPanel");
        });

        //监听添加金钱按钮
        GetControl<Button>("btnAddMoney").onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger("MoneyChange", 1000);
        });

        //监听添加宝石按钮
        GetControl<Button>("btnAddGem").onClick.AddListener(() =>
        {
            EventCenter.GetInstance().EventTrigger("GemChange", 1000);
        });
        btnExt.onClick.AddListener(() =>
        {
            Debug.Log("11");
            Application.Quit();
        });
    }

    public override void ShowMe()
    {
        base.ShowMe();
        //更新名字 等级 钱等等基础信息
        GetControl<Text>("txtName").text = GameDataMgr.GetInstance().playerInfo.name;
        GetControl<Text>("txtLev").text = GameDataMgr.GetInstance().playerInfo.lev.ToString();
        GetControl<Text>("txtMoney").text = GameDataMgr.GetInstance().playerInfo.money.ToString();
        GetControl<Text>("txtGem").text = GameDataMgr.GetInstance().playerInfo.gem.ToString();
        GetControl<Text>("txtPro").text = GameDataMgr.GetInstance().playerInfo.pro.ToString();

        EventCenter.GetInstance().AddEventListener<int>("MoneyChange", UpdatePanel);
        EventCenter.GetInstance().AddEventListener<int>("GemChange", UpdatePanel);
    }

    public override void HideMe()
    {
        base.HideMe();
        EventCenter.GetInstance().RemoveEventListener<int>("MoneyChange", UpdatePanel);
        EventCenter.GetInstance().RemoveEventListener<int>("GemChange", UpdatePanel);
    }

    //当货币发生改变时 用来监听 更新的函数
    private void UpdatePanel(int money)
    {
        GetControl<Text>("txtMoney").text = GameDataMgr.GetInstance().playerInfo.money.ToString();
        GetControl<Text>("txtGem").text = GameDataMgr.GetInstance().playerInfo.gem.ToString();
    }

    private void Update()
    {
        sliderHp.value = character.currentHP;
        if (character.currentHP == 0)
        {
            UIManager.GetInstance().ShowPanel<GameOverPanel>("GameOverPanel");
        }
    }
}
