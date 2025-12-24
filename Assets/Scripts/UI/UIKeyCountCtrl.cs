using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKeyCountCtrl : MonoBehaviour
{
    public Image[] keys;
    public Color got;
    public Color none;

    // Start is called before the first frame update
    void Start()
    {
        UpdateKeyUI();
        //功能託管
        GameData.updateKey = UpdateKeyUI;
        //UI提示(開始)
        UICutInCtrl.instance.StartInfo();
    }

    public void UpdateKeyUI()
    {
        //起始；終點；增值
        for (int i = 0; i < GameData.keyMax; i++)
        {
            if (i < GameData.keyCount) keys[i].color = got;
            else keys[i].color = none;
        }
        //檢查鑰匙是否滿足過關條件
        if (GameData.keyCount >= 3)
        {//UI提示(任務完成)
            UICutInCtrl.instance.EndInfo();
        }
    }
}
