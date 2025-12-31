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
    /// 角色跳躍高度
    /// </summary>
    public float jumpHeight = 2f;
    /// <summary>
    /// 角色的血量
    /// </summary>
    public int HP;
    /// <summary>
    /// 搖桿外部輸入
    /// </summary>
    Vector2 input;
    Vector3 look;
    float speedV;
    #endregion 基本參數

    #region 角色公開狀態
    /// <summary>
    /// 角色是否有接收輸入操作
    /// </summary>
    public bool isMove => input != Vector2.zero;
    /// <summary>
    /// 是否接觸地面
    /// </summary>
    public bool isGrounded => charCtrl.isGrounded;
    /// <summary>
    /// 重力常數
    /// </summary>
    public float G => 9.8f;
    /// <summary>
    /// 角色動能包含：水平和垂直重力
    /// </summary>
    public Vector3 Velocity => transform.forward * moveSpeed * input.magnitude + Vector3.up * speedV;

    public float VelocityY => charCtrl.velocity.y;
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
        if (animator != null)
        {
            animator.SetBool("IsMove", isMove);
            animator.SetBool("IsGround", isGrounded);
            animator.SetFloat("BlendInput", input.magnitude);
            animator.SetFloat("VelocityY", VelocityY);
        }
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
        //有移動操作時角色控制框轉向操作方向
        if (isMove) transform.rotation = Quaternion.LookRotation(look);
        //角色控制器.移動(往前) + 地心引力(標準化 1/FPS)
        speedV -= G * Time.deltaTime;
        charCtrl.Move(Velocity * Time.deltaTime);
    }

    public void Move(CallbackContext callback)
    {
        input = callback.ReadValue<Vector2>();
        Debug.Log(input);
    }

    public void Jump(CallbackContext callback)
    {
        //從地面起跳
        if (isGrounded && callback.performed)
        {
            Debug.Log("從地面起跳");
            speedV = Mathf.Sqrt(2 * jumpHeight * G);
            //觸發動畫
            if (animator != null)
            {
                animator.SetTrigger("Jump");
            }
        }
    }
    #endregion 操作設計
}
