# Scene视图锁定功能（Ctrl+Alt+F）应用场景

## 常见应用场景

### 1. 角色动画调试
- 调试角色动画时需要持续观察角色的动作
- 角色会在场景中移动到不同位置
- 锁定视图后摄像机会自动跟随，方便观察动画效果
- 特别适合调试：
  - 走路/跑步动画
  - 战斗动画
  - 交互动画

### 2. 粒子特效调试
- 调试移动类型的粒子特效
  - 魔法弹道效果
  - 追踪型导弹
  - 环绕型光效
- 特效会在场景中飞行或移动
- 锁定视图可以完整观察特效的生命周期

### 3. AI行为观察
- 调试AI角色的行为时：
  - 寻路系统测试
  - 巡逻行为观察
  - 追逐/逃跑行为分析
- 可以实时观察AI的决策和移动路径
- 有助于发现AI行为中的问题

### 4. 相机跟随系统开发
- 开发游戏相机系统时：
  - 研究相机跟随效果
  - 测试相机平滑移动
  - 调整相机跟随参数
- 可以参考Unity编辑器的相机跟随效果
- 帮助实现类似的游戏相机系统

### 5. 长距离物体移动调试
- 适用于需要长距离移动的物体：
  - 太空游戏中的飞船
  - 赛车游戏中的车辆
  - 大地图中的角色移动
- 自动跟随节省手动调整视角的时间
- 可以专注于观察移动效果

## 示例代码
```csharp
// 创建一个简单的移动物体来测试视图锁定
public class TestMovement : MonoBehaviour
{
    public float speed = 5f;
    
    void Update()
    {
        // 让物体做圆周运动
        float x = Mathf.Cos(Time.time) * speed;
        float z = Mathf.Sin(Time.time) * speed;
        transform.position = new Vector3(x, 0, z);
    }
}
```

## 使用步骤
1. 在场景中创建一个球体
2. 将上述脚本添加到球体上
3. 选中球体
4. 按下Ctrl+Alt+F锁定视图
5. 运行游戏，观察视图如何跟随球体移动

## 注意事项
1. 锁定视图会一直跟随目标，直到你：
   - 手动取消锁定
   - 选择其他物体
   - 使用其他视图操作

2. 在编辑复杂场景时要注意：
   - 锁定视图可能影响其他物体的选择
   - 需要时要及时取消锁定
   - 可能会干扰场景的整体编辑 