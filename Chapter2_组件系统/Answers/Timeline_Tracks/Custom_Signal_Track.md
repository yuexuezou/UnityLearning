# Custom Signal Track（自定义信号轨道）使用指南

## 1. 基本介绍
Custom Signal Track是Signal Track的扩展版本，允许创建自定义的信号类型和处理逻辑。它提供了更灵活的事件系统，可以传递复杂的数据结构和执行自定义的回调函数。

## 2. 创建和设置
1. **创建轨道**：
   - 在Timeline窗口点击"+"
   - 选择"Custom Signal Track"
   - 设置接收对象

2. **添加信号**：
   - 创建自定义信号资源
   - 添加信号发送器
   - 配置信号参数

3. **基础属性设置**：
   ```
   Custom Signal属性：
   ├── Signal Asset：信号资源
   ├── Custom Data：自定义数据
   └── Receiver Settings：接收器设置
   ```

## 3. 高级功能
1. **自定义信号定义**：
   ```csharp
   [CreateAssetMenu(fileName = "CustomSignal", menuName = "Timeline/Custom Signal")]
   public class CustomSignalAsset : SignalAsset
   {
       public string eventName;
       public float eventValue;
       public GameObject target;
       
       // 自定义数据结构
       [System.Serializable]
       public class SignalData
       {
           public string type;
           public float[] parameters;
           public Object reference;
       }
       
       public SignalData signalData;
   }
   ```

2. **信号处理器**：
   ```csharp
   public class CustomSignalReceiver : MonoBehaviour
   {
       // 信号处理委托
       public delegate void SignalHandler(CustomSignalAsset signal);
       private Dictionary<string, SignalHandler> handlers 
           = new Dictionary<string, SignalHandler>();
       
       // 注册处理器
       public void RegisterHandler(string eventName, SignalHandler handler)
       {
           if (!handlers.ContainsKey(eventName))
               handlers[eventName] = handler;
           else
               handlers[eventName] += handler;
       }
       
       // 处理信号
       public void OnSignalReceived(CustomSignalAsset signal)
       {
           if (handlers.TryGetValue(signal.eventName, out var handler))
           {
               handler.Invoke(signal);
           }
       }
   }
   ```

3. **参数传递**：
   ```csharp
   public class SignalParameterHandler : MonoBehaviour
   {
       // 处理带参数的信号
       public void HandleParameterizedSignal(CustomSignalAsset signal)
       {
           var data = signal.signalData;
           switch (data.type)
           {
               case "Movement":
                   HandleMovement(data.parameters);
                   break;
               case "Animation":
                   HandleAnimation(data.parameters, data.reference as AnimationClip);
                   break;
               case "Effect":
                   HandleEffect(data.parameters);
                   break;
           }
       }
   }
   ```

## 4. 常见用途
1. **游戏事件**：
   - 复杂事件触发
   - 带参数事件
   - 条件事件

2. **数据传递**：
   - 状态同步
   - 参数更新
   - 对象引用

3. **系统联动**：
   - 多系统协调
   - 状态机切换
   - 场景转换

## 5. 使用技巧
1. **信号设计**：
   ```
   信号结构：
   ├── 基础信号
   ├── 复合信号
   └── 条件信号
   ```

2. **处理优化**：
   - 信号分类
   - 优先级控制
   - 批量处理

3. **调试支持**：
   - 信号日志
   - 参数验证
   - 错误处理

## 6. 编程接口
```csharp
public class AdvancedCustomSignalTrack : MonoBehaviour
{
    public PlayableDirector director;
    
    // 创建自定义信号轨道
    public SignalTrack CreateCustomSignalTrack(string trackName)
    {
        var timeline = director.playableAsset as TimelineAsset;
        return timeline.CreateTrack<SignalTrack>(null, trackName);
    }
    
    // 添加自定义信号
    public void AddCustomSignal(SignalTrack track, 
                              double time,
                              CustomSignalAsset signal)
    {
        var marker = track.CreateMarker<SignalEmitter>(time);
        marker.asset = signal;
    }
    
    // 批量注册处理器
    public void RegisterHandlers(CustomSignalReceiver receiver,
                               Dictionary<string, CustomSignalReceiver.SignalHandler> handlers)
    {
        foreach (var pair in handlers)
        {
            receiver.RegisterHandler(pair.Key, pair.Value);
        }
    }
}
```

## 7. 注意事项
1. **性能考虑**：
   - 信号频率
   - 处理复杂度
   - 内存管理

2. **常见问题**：
   - 信号丢失
   - 参数错误
   - 处理延迟

3. **最佳实践**：
   - 信号分组
   - 错误处理
   - 性能监控

## 8. 快捷操作
- 右键轨道：添加自定义信号
- S：在当前时间点添加信号
- Ctrl+C/V：复制/粘贴信号
- Delete：删除信号
- 双击信号：编辑参数 