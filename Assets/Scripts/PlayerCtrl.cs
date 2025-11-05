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
    public Animator animator;
    /// <summary>
    /// 角色移動速度
    /// </summary>
    public float moveSpeed = 3f;
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
        animator.SetBool("IsMove", isMove);
        animator.SetFloat("BlendInput", input.magnitude);
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

        //有移動操作產生時
        if (isMove)
        {
            //角色控制框轉向操作方向
            transform.rotation = Quaternion.LookRotation(look);
            //角色控制器.移動(往前)
            charCtrl.SimpleMove(transform.forward * moveSpeed * input.magnitude);
        }
    }

    public void Move(CallbackContext callback)
    {
        input = callback.ReadValue<Vector2>();
        Debug.Log(input);
    }
    #endregion 操作設計
}
