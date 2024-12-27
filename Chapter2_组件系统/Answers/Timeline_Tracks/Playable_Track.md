# Playable Track（可播放轨道）使用指南

## 1. 基本介绍
Playable Track是Timeline中最灵活的轨道类型，允许自定义任何类型的可播放内容。它通过Playable API提供了完全的自定义控制能力，可以实现复杂的动画效果和行为。

## 2. 创建和设置
1. **创建轨道**：
   - 在Timeline窗口点击"+"
   - 选择"Playable Track"
   - 设置绑定对象

2. **添加片段**：
   - 创建自定义PlayableAsset
   - 将资源拖拽到轨道
   - 设置片段属性

3. **基础属性设置**：
   ```
   Playable Track属性：
   ├── Script：脚本引用
   ├── Template：模板设置
   └── Clip Settings：片段设置
   ```

## 3. 高级功能
1. **自定义Playable**：
   ```csharp
   public class CustomPlayableAsset : PlayableAsset
   {
       public float customValue;
       
       public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
       {
           var playable = ScriptPlayable<CustomPlayableBehaviour>.Create(graph);
           var behaviour = playable.GetBehaviour();
           behaviour.customValue = customValue;
           return playable;
       }
   }
   
   public class CustomPlayableBehaviour : PlayableBehaviour
   {
       public float customValue;
       
       public override void ProcessFrame(Playable playable, FrameData info, object playerData)
       {
           float weight = playable.GetInputWeight(0);
           // 实现自定义行为
       }
   }
   ```

2. **混合系统**：
   ```csharp
   public class PlayableMixer : PlayableBehaviour
   {
       public override void ProcessFrame(Playable playable, FrameData info, object playerData)
       {
           int inputCount = playable.GetInputCount();
           for (int i = 0; i < inputCount; i++)
           {
               float inputWeight = playable.GetInputWeight(i);
               var inputPlayable = (ScriptPlayable<CustomPlayableBehaviour>)playable.GetInput(i);
               var input = inputPlayable.GetBehaviour();
               // 混合多个Playable的效果
           }
       }
   }
   ```

3. **时间控制**：
   ```csharp
   public class TimeController : PlayableBehaviour
   {
       public override void PrepareFrame(Playable playable, FrameData info)
       {
           double time = playable.GetTime();
           float progress = (float)(time / playable.GetDuration());
           // 基于时间实现效果
       }
   }
   ```

## 4. 常见用途
1. **自定义动画**：
   - 程序化动画
   - 物理模拟
   - 粒子系统控制

2. **特效控制**：
   - shader参数动画
   - 材质属性控制
   - 后处理效果

3. **游戏逻辑**：
   - AI行为控制
   - 关卡流程
   - 游戏机制

## 5. 使用技巧
1. **性能优化**：
   ```
   优化方向：
   ├── 重用Playable
   ├── 批处理操作
   └── 缓存计算结果
   ```

2. **调试支持**：
   - 状态可视化
   - 数据监控
   - 错误追踪

3. **扩展性设计**：
   - 组件化架构
   - 接口抽象
   - 事件系统

## 6. 编程接口
```csharp
public class AdvancedPlayableTrack : PlayableTrack
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        var mixer = ScriptPlayable<PlayableMixer>.Create(graph, inputCount);
        return mixer;
    }
    
    protected override void OnCreateClip(TimelineClip clip)
    {
        clip.asset = CreateInstance<CustomPlayableAsset>();
        clip.duration = 5.0; // 默认持续时间
    }
    
    public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
    {
        // 收集需要动画的属性
        var component = director.GetGenericBinding(this) as Component;
        if (component != null)
        {
            driver.AddFromComponent(component.gameObject, component);
        }
    }
}
```

## 7. 注意事项
1. **生命周期**：
   - 初始化时机
   - 更新顺序
   - 资源释放

2. **常见问题**：
   - 性能开销
   - 内存管理
   - 同步问题

3. **最佳实践**：
   - 模块化设计
   - 错误处理
   - 版本兼容

## 8. 快捷操作
- 右键轨道：添加自定义片段
- Ctrl+拖拽：复制片段
- Alt+拖拽：调整时间
- 双击片段：编辑属性
- Delete：删除片段 