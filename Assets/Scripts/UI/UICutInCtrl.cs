using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICutInCtrl : MonoBehaviour
{
    public Animator animator;

    public Text cutInText;
    public string startInfo;
    public string endInfo;

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
