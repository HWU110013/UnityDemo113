using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHpBarCtrl : MonoBehaviour
{
    [Header("¦å±øUI¤¸¥ó")]
    public Image hpBarImg;

    // Update is called once per frame
    void Update()
    {
        hpBarImg.fillAmount = GameData.hpFillAmount;
    }
}
