# Loop Control Track（循环控制轨道）使用指南

## 1. 基本介绍
Loop Control Track用于控制Timeline中的循环播放行为，可以设置特定片段或整个序列的循环次数、循环条件和循环方式。它提供了灵活的循环控制机制，适用于需要重复播放的动画和事件序列。

## 2. 创建和设置
1. **创建轨道**：
   - 在Timeline窗口点击"+"
   - 选择"Loop Control Track"
   - 设置循环参数

2. **添加循环控制**：
   - 设置循环区间
   - 配置循环次数
   - 定义循环条件

3. **基础属性设置**：
   ```
   Loop Control属性：
   ├── Loop Count：循环次数
   ├── Loop Mode：循环模式
   └── Loop Condition：循环条件
   ```

## 3. 高级功能
1. **循环控制器**：
   ```csharp
   public class LoopController : MonoBehaviour
   {
       public PlayableDirector director;
       
       // 设置循环区间
       public void SetLoopRange(double startTime, double endTime, int loopCount)
       {
           var timeline = director.playableAsset as TimelineAsset;
           var track = timeline.CreateTrack<LoopControlTrack>();
           
           var marker = track.CreateMarker<LoopControlMarker>();
           marker.startTime = startTime;
           marker.endTime = endTime;
           marker.loopCount = loopCount;
       }
   }
   ```

2. **条件循环**：
   ```csharp
   public class ConditionalLoop : MonoBehaviour
   {
       public bool shouldContinueLoop = true;
       
       // 条件循环控制
       public void UpdateLoopCondition(LoopControlTrack track)
       {
           var marker = track.GetMarkers().First() as LoopControlMarker;
           marker.condition = () => shouldContinueLoop;
       }
       
       // 循环回调
       public void OnLoopComplete(int currentLoop)
       {
           Debug.Log($"完成第 {currentLoop} 次循环");
           shouldContinueLoop = currentLoop < 5;
       }
   }
   ```

3. **循环事件**：
   ```csharp
   public class LoopEventHandler : MonoBehaviour
   {
       public event System.Action<int> onLoopStart;
       public event System.Action<int> onLoopEnd;
       
       // 处理循环事件
       public void HandleLoopEvents(LoopControlMarker marker)
       {
           marker.loopStartCallback += (loopIndex) => 
           {
               onLoopStart?.Invoke(loopIndex);
           };
           
           marker.loopEndCallback += (loopIndex) => 
           {
               onLoopEnd?.Invoke(loopIndex);
           };
       }
   }
   ```

## 4. 常见用途
1. **动画循环**：
   - 角色动作
   - 环境动画
   - 特效循环

2. **事件重复**：
   - 定时触发
   - 条件执行
   - 序列重复

3. **游戏机制**：
   - 关卡重复
   - 行为模式
   - 状态循环

## 5. 使用技巧
1. **循环模式**：
   ```
   循环类型：
   ├── 固定次数
   ├── 条件循环
   └── 无限循环
   ```

2. **优化建议**：
   - 合理设置次数
   - 避免死循环
   - 性能监控

3. **调试支持**：
   - 循环计数
   - 状态检查
   - 条件验证

## 6. 编程接口
```csharp
public class AdvancedLoopTrack : PlayableTrack
{
    // 创建循环控制
    public LoopControlMarker CreateLoopControl(double start, double end)
    {
        var marker = CreateMarker<LoopControlMarker>(start);
        marker.endTime = end;
        return marker;
    }
    
    // 设置循环行为
    public void ConfigureLoop(LoopControlMarker marker,
                            int count,
                            System.Func<bool> condition,
                            System.Action<int> onComplete)
    {
        marker.loopCount = count;
        marker.condition = condition;
        marker.loopEndCallback += onComplete;
    }
    
    // 动态更新循环
    public void UpdateLoopSettings(LoopControlMarker marker,
                                 double newStart,
                                 double newEnd,
                                 int newCount)
    {
        marker.startTime = newStart;
        marker.endTime = newEnd;
        marker.loopCount = newCount;
    }
}
```

## 7. 注意事项
1. **性能考虑**：
   - 循环开销
   - 内存使用
   - 更新频率

2. **常见问题**：
   - 循环卡死
   - 条件失效
   - 性能下降

3. **最佳实践**：
   - 合理分段
   - 条件优化
   - 资源管理

## 8. 快捷操作
- 右键轨道：添加循环控制
- L：创建循环标记
- Ctrl+L：编辑循环设置
- Alt+拖拽：调整循环范围
- Delete：删除循环控制 