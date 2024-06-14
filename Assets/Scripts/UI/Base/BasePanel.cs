using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;                //显示隐藏
    private float alphaSpeed = 10;                      //速度
    private UnityAction hidCallback = null;
    // Start is called before the first frame update
    
    //判断当前是否显示还是隐藏
    private bool isShow = false;

    protected virtual void Awake()
    {
        
        canvasGroup = this.gameObject.GetComponent<CanvasGroup>();                                                          //获得Canvas上的CanvasGroup
        if (canvasGroup == null)
            canvasGroup = this.gameObject.AddComponent<CanvasGroup>();                                              //添加Canvas上的CanvasGroup
    }
    protected virtual void Start()
    {
        Init();
    }
    public abstract void Init();
    /// <summary>
    /// 显示
    /// </summary>
    public virtual void ShowPanel()
    {
        canvasGroup.alpha = 0;
        isShow = true;

    }
    /// <summary>
    /// 隐藏
    /// </summary>
    /// <param name="hidCallback"></param>
    public virtual void HidPenl(UnityAction callback)
    {
        canvasGroup.alpha = 1;
        isShow = false;
        hidCallback = callback;
    }
    // Update is called once per frame
    void Update()
    {
        //显示
        if(isShow && canvasGroup.alpha != 1)
        {
            canvasGroup.alpha += alphaSpeed * Time.deltaTime;
            if (canvasGroup.alpha >= 1)
                canvasGroup.alpha = 1;
        }
        else if(!isShow && canvasGroup.alpha != 0)
        {
            canvasGroup.alpha -= alphaSpeed * Time.deltaTime;
            if (canvasGroup.alpha <= 0)
            {
                canvasGroup.alpha = 0;
                hidCallback?.Invoke();

            }    
        }
    }
}
