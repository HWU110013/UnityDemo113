using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICutInCtrl : MonoBehaviour
{
    /// <summary>
    /// 全域靜態欄位(唯一)
    /// </summary>
    public static UICutInCtrl instance;

    public Animator animator;

    public Text cutInText;
    public string startInfo;
    public string endInfo;

    private void Awake()
    {//一醒來就先設定(必須)
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    [ContextMenu("開始訊息")]
    public void StartInfo()
    {
        cutInText.text = startInfo;
        animator.SetTrigger("Start");
    }

    [ContextMenu("結束訊息")]
    public void EndInfo()
    {
        cutInText.text = endInfo;
        animator.SetTrigger("End");
    }
}
