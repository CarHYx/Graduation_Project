using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单例模式
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingleManger<T> where T : new()
{
    private static T _instance = new T();

    public static readonly object _synRoot = new object();            //readonly 关键字表示这个对象引用一旦被赋值后就不能再被改变。通常与static一起使用，以确保静态成员只在类加载时被初始化一次。
    

    public static T GetInstance()                                      // 获得单列
    {
        if(_instance == null)
        {
            lock(_synRoot)
            {
                _instance = new T();
            }

        }
        return _instance;
    }
}
