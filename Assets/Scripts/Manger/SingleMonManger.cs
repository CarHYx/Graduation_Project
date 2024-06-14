using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMonManger<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instanceMon;
    public static T GetInstanceMon()
    {

        if(_instanceMon == null)
        {
            GameObject obj = new GameObject();         // 创建实例
            obj.name = typeof(T).Name;                //更改名称
            _instanceMon = obj.AddComponent<T>();    //添加脚本
            DontDestroyOnLoad(obj);                 //过场景不移除
        }
        return _instanceMon;

    }
    //写虚函数是为了外部方便重写Awake的方法 不会把父类的Awake顶掉
    protected virtual void Awake()
    {
        _instanceMon = this as T;
    }

}
