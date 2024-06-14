using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_PlayerAutoType
{
    Auto,
    Password,
}

/// <summary>
/// 玩家管理器
/// </summary>
public class PlayerManger : SingleManger<PlayerManger>
{
    public PlayerInformation _playerInfo = new PlayerInformation();

    //玩家属性相关
    public PlayerData _playerData = new PlayerData();


    public E_PlayerAutoType autoType = new E_PlayerAutoType(); 

    public PlayerManger()
    {
        _playerData = JsonMgr.Instance.LoadData<PlayerData>("PlayerData",JsonType.JsonUtlity);
    }




    public void SaveData()
    {
        //玩家数据
        JsonMgr.Instance.SaveData(_playerInfo, "PlayerInformation");

        //玩家属性
        JsonMgr.Instance.SaveData(_playerData, "PlayerData");


    }

    public void LoadData()
    {
        JsonMgr.Instance.LoadData<PlayerInformation>("PlayerInformation");

        JsonMgr.Instance.LoadData<PlayerData>("PlayerData");

    }
    /// <summary>
    /// 判断当前是否自动登录 如果勾选记住密码 则自动勾选自动登录
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
