# Activation Track（激活轨道）使用指南

## 1. 基本介绍
Activation Track用于控制GameObject的启用和禁用状态，可以在Timeline中设定物体在什么时间显示或隐藏。

## 2. 创建和设置
1. **创建轨道**：
   - 在Timeline窗口点击"+"
   - 选择"Activation Track"
   - 将目标GameObject拖拽到轨道的绑定栏

2. **基础设置**：
   - 在轨道上右键选择"Add Activation Clip"
   - 调整激活片段的起始和结束时间
   - 设置默认状态（激活/禁用）

## 3. 高级功能
1. **片段编辑**：
   ```
   Timeline中的显示状态：
   ├── 灰色区域：GameObject禁用
   ├── 白色区域：GameObject启用
   └── 边界：状态切换点
   ```

2. **过渡设置**：
   - 支持瞬时切换
   - 可以设置延迟激活
   - 可以与其他轨道同步

3. **编程控制**：
   ```csharp
   public class ActivationController : MonoBehaviour
   {
       public PlayableDirector director;
       public GameObject targetObject;

       // 获取激活轨道
       ActivationTrack GetActivationTrack()
       {
           var timeline = director.playableAsset as TimelineAsset;
           return timeline.GetOutputTrack(0) as ActivationTrack;
       }

       // 动态修改激活状态
       public void SetActivationState(bool active, double time)
       {
           var track = GetActivationTrack();
           var clip = track.CreateClip<ActivationPlayableAsset>();
           clip.start = time;
           clip.duration = 1.0; // 设置持续时间
       }
   }
   ```

## 4. 常见用途
1. **场景转换**：
   - 控制场景物体的显示/隐藏
   - 实现淡入淡出效果
   - 管理过场动画元素

2. **UI控制**：
   - 控制UI元素的显示时机
   - 制作UI动画序列
   - 管理HUD元素

3. **游戏机制**：
   - 控制机关的触发
   - 管理物品的出现
   - 控制NPC的出场

## 5. 使用技巧
1. **优化建议**：
   - 合理组织激活序列
   - 避免频繁切换状态
   - 考虑使用对象池

2. **常见模式**：
   ```
   Timeline结构示例：
   ├── 入场序列
   │   ├── 场景物体激活
   │   └── UI元素激活
   ├── 主要内容
   │   ├── 动态物体控制
   │   └── 机关触发
   └── 结束序列
       ├── 场景淡出
       └── UI隐藏
   ```

## 6. 注意事项
1. **性能考虑**：
   - 激活/禁用操作会触发OnEnable/OnDisable
   - 大量物体同时切换可能影响性能
   - 考虑使用批量处理

2. **常见问题**：
   - 确保物体正确绑定
   - 检查轨道的优先级
   - 注意时间轴刻度

3. **调试建议**：
   - 使用Timeline预览
   - 检查GameObject状态
   - 监控性能影响

## 7. 快捷操作
- 右键轨道：添加激活片段
- 拖拽片段边缘：调整持续时间
- Ctrl+拖拽：复制激活片段
- Delete：删除片段
- M：静音轨道 