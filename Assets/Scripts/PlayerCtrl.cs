using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerCtrl : MonoBehaviour
{
    #region 基本參數
    public CharacterController charCtrl;
    /// <summary>
    /// 角色的血量
    /// </summary>
    public int HP;
    /// <summary>
    /// 搖桿外部輸入
    /// </summary>
    Vector2 input;
    Vector3 look;
    #endregion 基本參數

    #region 角色公開狀態
    /// <summary>
    /// 角色是否有接收輸入操作
    /// </summary>
    public bool isMove => input != Vector2.zero;
    #endregion 角色公開狀態

    #region UNITY生命週期
    /// <summary>
    /// 初始化
    /// </summary>
    void Start()
    {
        HP = 100;
    }

    /// <summary>
    /// 更新：偵測操作
    /// </summary>
    void Update()
    {
        Action();
    }
    #endregion UNITY生命週期

    #region 操作設計
    /// <summary>
    /// 角色行動
    /// </summary>
    void Action()
    {
        //轉動角色
        look.z = input.y;
        look.x = input.x;
        transform.rotation = Quaternion.LookRotation(look);
        //角色控制器.移動(往前)
        if (isMove) charCtrl.SimpleMove(transform.forward);
    }

    public void Move(CallbackContext callback)
    {
        input = callback.ReadValue<Vector2>(); 
    }
    #endregion 操作設計
}
