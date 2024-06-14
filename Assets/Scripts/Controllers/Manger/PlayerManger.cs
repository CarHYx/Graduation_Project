using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_PlayerAutoType
{
    Auto,
    Password,
}

/// <summary>
/// ��ҹ�����
/// </summary>
public class PlayerManger : SingleManger<PlayerManger>
{
    public PlayerInformation _playerInfo = new PlayerInformation();

    //����������
    public PlayerData _playerData = new PlayerData();


    public E_PlayerAutoType autoType = new E_PlayerAutoType(); 

    public PlayerManger()
    {
        _playerData = JsonMgr.Instance.LoadData<PlayerData>("PlayerData",JsonType.JsonUtlity);
    }




    public void SaveData()
    {
        //�������
        JsonMgr.Instance.SaveData(_playerInfo, "PlayerInformation");

        //�������
        JsonMgr.Instance.SaveData(_playerData, "PlayerData");


    }

    public void LoadData()
    {
        JsonMgr.Instance.LoadData<PlayerInformation>("PlayerInformation");

        JsonMgr.Instance.LoadData<PlayerData>("PlayerData");

    }
    /// <summary>
    /// �жϵ�ǰ�Ƿ��Զ���¼ �����ѡ��ס���� ���Զ���ѡ�Զ���¼
    /// </summary>
    /// <param name="isOk"></param>
    /// <param name=""></param>
    public void IsAutoPassword(E_PlayerAutoType autoType , bool isOk)
    {
        switch (autoType)
        {
            case E_PlayerAutoType.Auto:
                _playerInfo.isAuto = isOk;
                if(isOk)
                    _playerInfo.isPassword = isOk;
                break;
            case E_PlayerAutoType.Password:
                _playerInfo.isPassword = isOk;
                break;
        }
        SaveData();
    }

}
