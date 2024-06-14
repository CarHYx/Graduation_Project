


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourcesManger :  SingleMonManger<ResourcesManger>
{
    /// <summary>
    /// 同步加载
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="resName">资源路径名称</param>
    /// <returns></returns>
    public T Load<T>(string resName) where T:Object            
    {
        T res = Resources.Load<T>(resName);
        if (res is GameObject)
            return GameObject.Instantiate(res);
        else
            return res;                 //除了需要实例化的物体
    }
    //执行下面的携程函数代码
    public void LoadAsync<T>(string resName, UnityAction<T> callback) where T : Object { SingleMonManger<ResourcesManger>.GetInstanceMon().StartCoroutine(ReallyLoadAsyns(resName, callback)); }

    /// <summary>
    /// 异步加载资源
    /// </summary>s
    /// <typeparam name="T"></typeparam>
    /// <param name="resName"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    private IEnumerator ReallyLoadAsyns<T>(string resName ,UnityAction<T> callback) where T:Object
    {
        ResourceRequest res = Resources.LoadAsync<T>(resName);
        yield return res;
        if (res.asset is GameObject)
            callback(GameObject.Instantiate(res.asset) as T);         //res.asset通常指的是对一个资源文件（Asset）的引用。资源文件可以是任何类型的游戏对象，比如纹理、模型、音频、预制体（Prefab）等
        else
            callback(res.asset as T);
            
    
    }





}
