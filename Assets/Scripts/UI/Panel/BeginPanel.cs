using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Principal;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginPanel : BasePanel
{
    private Button btnLogin;
    private Button btnRes;

    public InputField inputAccount;
    public InputField inputPassword;

    private Toggle togAuto;
    private Toggle togPassword;

    public Button btnSet;
    public Button btnQuite;
    protected override void Awake()
    {

        base.Awake();

        //Ѱ�һ����ؼ�
        btnLogin = this.transform.Find("RawImgBk/btnLogin").GetComponent<Button>();
        btnRes = this.transform.Find("RawImgBk/btnRegs").GetComponent<Button>();
        togAuto = this.transform.Find("RawImgBk/TogAuto").GetComponent<Toggle>();
        togPassword = this.transform.Find("RawImgBk/TogPassword").GetComponent<Toggle>();
    }


    protected override void Init()
    {
        base.Init();
        //��ȡ��ǰ�Ƿ���Ҫ��������
        togAuto.isOn = JsonMgr.Instance.LoadData<PlayerInformation>("PlayerInformation").isAuto;
        togPassword.isOn = JsonMgr.Instance.LoadData<PlayerInformation>("PlayerInformation").isPassword;

        if (togPassword.isOn)
        {
            inputAccount.text = JsonMgr.Instance.LoadData<PlayerInformation>("PlayerInformation").Account;
            inputPassword.text = JsonMgr.Instance.LoadData<PlayerInformation>("PlayerInformation").Passwrod;
        }
        if (togAuto.isOn && inputAccount.text == JsonMgr.Instance.LoadData<PlayerInformation>("PlayerInformation").Account && inputPassword.text == JsonMgr.Instance.LoadData<PlayerInformation>("PlayerInformation").Passwrod)
        {
            UIManager.GetInstance().HidePanel("BeginPanel");
            PlayerManger.GetInstance().SaveData();
            SceneManager.LoadScene("GameScenes");
        }
        Registration();
    }

    /// <summary>
    /// UI��صĿؼ�����
    /// </summary>
    private void Registration()
    {
        btnLogin.onClick.AddListener(() =>
        {
            //�жϵ�ǰ��ҵ�����������˺��Ƿ��ע��ʱ���˺ź�����һ��
            if (inputAccount.text == JsonMgr.Instance.LoadData<PlayerInformation>("PlayerInformation").Account &&
            inputPassword.text == JsonMgr.Instance.LoadData<PlayerInformation>("PlayerInformation").Passwrod)
            {
                UIManager.GetInstance().HidePanel("BeginPanel");
                PlayerManger.GetInstance().SaveData();
                //��ʾ�����
                UIManager.GetInstance().ShowPanel<MainPanel>("MainPanel", E_UI_Layer.Bot);
                SceneManager.LoadScene("GameScenes");


            }
            else
            {
                UIManager.GetInstance().ShowPanel<TipPanel>("TipPanel",E_UI_Layer.System, (tip) =>
                {
                    if (tip != null)
                        tip.ShowMe("�˺��������");
                    else
                        tip.AddComponent<TipPanel>().ShowMe("�˺�����");
                });
            }

        });
        btnRes.onClick.AddListener(() =>
        {
            //��ע����������Լ�
            UIManager.GetInstance().HidePanel("BeginPanel");
            UIManager.GetInstance().ShowPanel<RegistrationPanel>("RegistrationPanel", E_UI_Layer.System);
        });

        togAuto.onValueChanged.AddListener((isAuto) =>
        {
            if (togAuto.isOn)
                togPassword.isOn = togAuto.isOn;
            //��¼��ǰ�Ƿ�����Զ���¼
            PlayerManger.GetInstance().IsAutoPassword(E_PlayerAutoType.Auto, isAuto);
        });

        togPassword.onValueChanged.AddListener((isPassword) =>
        {
            PlayerManger.GetInstance().IsAutoPassword(E_PlayerAutoType.Password, isPassword);
        });


        inputAccount.onValueChanged.AddListener((Account) =>
        {
            inputAccount.text = Account;
        });
        inputPassword.onValueChanged.AddListener((Password) =>
        {
            inputPassword.text = Password;
        });
        btnSet.onClick.AddListener(() =>
        {
            AudioManager.GetInstanceMon().PlayEfftSources("monster", false);
            UIManager.GetInstance().ShowPanel<SettingPanel>("SettingPanel", E_UI_Layer.Top);

        });

        btnQuite.onClick.AddListener(() => { Application.Quit(); });

    }
}

