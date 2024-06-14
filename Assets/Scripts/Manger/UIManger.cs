﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  enum E_UI_Layer
{
    Bot,
    Mid,
    Top,
    System,
}



//UI管理器
public class UIManger : SingleManger<UIManger>
{       
    private Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();            //存储面板
    private Transform bot;
    private Transform mid;
    private Transform top;          
    private Transform system;
    private RectTransform canvas;           //记录父对象



    public UIManger()
    {
        //加载预设体
        GameObject obj = ResourcesManger.GetInstanceMon().Load<GameObject>("UI/Canvas");
        obj.name = "Canvas";
        canvas = obj.transform as RectTransform;

        bot = canvas.Find("Bot").GetComponent<Transform>();
        mid = canvas.Find("Mid").GetComponent<Transform>();
        top = canvas.Find("Top").GetComponent<Transform>();
        system = canvas.Find("System").GetComponent<Transform>();

        //创建EventSystem
        GameObject.DontDestroyOnLoad(obj);
        //加载EventSytem
        obj = ResourcesManger.GetInstanceMon().Load<GameObject>("UI/EventSystem");
        GameObject.DontDestroyOnLoad(obj);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="panelName"></param>
    /// <param name="layer"></param>
    /// <param name="callBackc"></param>
    public void ShowPanel<T> (string panelName , E_UI_Layer layer = E_UI_Layer.Top,UnityAction<T> callBackc = null) where T: BasePanel
    {
        if(panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].ShowPanel();
            if (callBackc != null)
                callBackc(panelDic[panelName] as T);
            return;
        }
        //加载

        ResourcesManger.GetInstanceMon().LoadAsync<GameObject>("UI/" + panelName, (obj) =>
        {
            Transform father = bot;
            switch (layer)
            {
                case E_UI_Layer.Top:
                    father = top;
                    break;
                case E_UI_Layer.Mid:
                    father = mid;
                    break;
                case E_UI_Layer.System:
                    father = system;
                    break;
            }
            //设置父对象
            obj.name = typeof(T).Name;
            obj.transform.SetParent(father);
            obj.transform.localScale = Vector3.one;
            obj.transform.localPosition = Vector3.one;

            (obj.transform as RectTransform).offsetMax = Vector2.zero;
            (obj.transform as RectTransform).offsetMin = Vector2.zero;
            T panel = obj.GetComponent<T>();
            if (callBackc != null)
                callBackc(panel);
            panelDic.Add(panelName, panel);

            panel.ShowPanel();
        }); 




    }
    
    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <param name="panelName"></param>
    public void HidPanel(string panelName)
    {
        Debug.Log(panelDic[panelName]);
        if (panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].HidPenl(()=>
            {
                GameObject.Destroy(panelDic[panelName].gameObject);
                panelDic.Remove(panelName);
                Debug.Log("12");
            });
        }
        Debug.Log("11");
    }
    /// <summary>
    /// 得到面板的脚本
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="panelName"></param>
    /// <returns></returns>
    public T GetPanel<T>(string panelName) where T:BasePanel
    {

        if (panelDic[panelName] != null)
            return panelDic[panelName] as T;
        return null;
    }




}
