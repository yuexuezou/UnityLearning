using UnityEngine;

/// <summary>
/// 基础移动示例脚本
/// 演示Transform的基本操作和输入控制
/// </summary>
public class BasicMovement : MonoBehaviour
{
    [Header("移动设置")]
    [Tooltip("移动速度")]
    public float moveSpeed = 5f;
    
    [Tooltip("旋转速度")]
    public float rotateSpeed = 45f;

    private void Update()
    {
        // 获取输入
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        // 计算移动向量
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        
        // 应用移动
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        
        // 如果有移动输入，进行旋转
        if (movement != Vector3.zero)
        {
            // 计算目标旋转
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            
            // 平滑旋转
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotateSpeed * Time.deltaTime
            );
        }
    }

    private void OnDrawGizmos()
    {
        // 绘制移动方向指示器
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 2f);
    }
} 