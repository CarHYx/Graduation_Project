using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RegistrationPanel : BasePanel
{
    private Button btnSure;
    private Button btnCancel;

    private InputField inputAccount;
    private InputField inputPassword;

    protected override void Awake()
    {
        base.Awake();
        //Ñ°ÕÒ»ù´¡¿Ø¼þ
        btnSure = this.transform.Find("RawImgBk/btnSure").GetComponent<Button>();
        btnCancel = this.transform.Find("RawImgBk/btnCancel").GetComponent<Button>();
        inputAccount = this.transform.Find("RawImgBk/inputAccountObj/inputAccount").GetComponent<InputField>();
        inputPassword = this.transform.Find("RawImgBk/inputPasswordObj/inputPassword").GetComponent<InputField>();
    }


    protected override void Init()
    {
        Registration();
    }
    private void Registration()
    {
        btnSure.onClick.AddListener(() =>
        {

            if (PlayerManger.GetInstance()._playerInfo.Account != null && PlayerManger.GetInstance()._playerInfo.Passwrod != null)
            {
                UIManager.GetInstance().HidePanel("RegistrationPanel");
                UIManager.GetInstance().ShowPanel<BeginPanel>("BeginPanel", E_UI_Layer.Top);

                Debug.Log(PlayerManger.GetInstance()._playerInfo.Account);
                Debug.Log(PlayerManger.GetInstance()._playerInfo.Passwrod);

                PlayerManger.GetInstance().SaveData();
            }
            else
            {
                UIManager.GetInstance().ShowPanel<TipPanel>("TipPanel", E_UI_Layer.System, (tip) =>
                {
                    if (tip != null)
                        tip.ShowMe("ÕËºÅÃÜÂë´íÎó");
                    else
                        tip.AddComponent<TipPanel>().ShowMe("ÇëÊäÈëÕËºÅÃÜÂë");
                });
            }
        });
        btnCancel.onClick.AddListener(() =>
        {
            UIManager.GetInstance().HidePanel("RegistrationPanel");
            UIManager.GetInstance().ShowPanel<BeginPanel>("BeginPanel", E_UI_Layer.Top);
        });

        inputAccount.onValueChanged.AddListener((Account) =>
        {
            PlayerManger.GetInstance()._playerInfo.Account = Account;
        });
        inputPassword.onValueChanged.AddListener((Password) =>
        {
            PlayerManger.GetInstance()._playerInfo.Passwrod = Password;
        });

    }
}

