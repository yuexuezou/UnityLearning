# Signal Track（信号轨道）使用指南

## 1. 基本介绍
Signal Track用于在Timeline中发送事件信号，可以在特定时间点触发自定义事件，实现Timeline与其他游戏系统的通信和同步。

## 2. 创建和设置
1. **创建轨道**：
   - 在Timeline窗口点击"+"
   - 选择"Signal Track"
   - 设置接收对象

2. **添加信号**：
   - 右键选择"Add Signal Emitter"
   - 创建新的Signal Asset
   - 设置信号接收器

3. **基础属性设置**：
   ```
   Signal Track属性：
   ├── Signal Asset：信号资源
   ├── Emitter Settings：发送器设置
   └── Receiver Settings：接收器设置
   ```

## 3. 高级功能
1. **信号管理**：
   ```csharp
   public class SignalManager : MonoBehaviour
   {
       public PlayableDirector director;
       
       // 创建信号发送器
       public void CreateSignalEmitter(double timePoint)
       {
           var timeline = director.playableAsset as TimelineAsset;
           var track = timeline.GetOutputTrack(0) as SignalTrack;
           
           var marker = track.CreateMarker<SignalEmitter>(timePoint);
           marker.asset = CreateInstance<SignalAsset>();
       }
       
       // 注册信号接收器
       public void RegisterSignalReceiver(UnityAction callback)
       {
           var receiver = gameObject.GetComponent<SignalReceiver>();
           if (receiver == null)
               receiver = gameObject.AddComponent<SignalReceiver>();
               
           receiver.AddReaction(signalAsset, callback);
       }
   }
   ```

2. **自定义信号**：
   ```csharp
   [CreateAssetMenu(fileName = "CustomSignal", menuName = "Timeline/Custom Signal")]
   public class CustomSignal : SignalAsset
   {
       public string signalName;
       public float signalValue;
       
       // 自定义信号数据
       public object GetSignalData()
       {
           return new { name = signalName, value = signalValue };
       }
   }
   ```

3. **信号回调系统**：
   ```csharp
   public class SignalReceiver : MonoBehaviour
   {
       private Dictionary<SignalAsset, UnityAction> signalCallbacks 
           = new Dictionary<SignalAsset, UnityAction>();
           
       public void OnSignalReceived(SignalAsset signal)
       {
           if (signalCallbacks.TryGetValue(signal, out var callback))
           {
               callback.Invoke();
           }
       }
   }
   ```

## 4. ���见用途
1. **游戏事件**：
   - 触发剧情
   - 播放音效
   - 切换场景

2. **系统同步**：
   - 动画同步
   - 音频同步
   - 特效同步

3. **交互控制**：
   - UI响应
   - 相机切换
   - 玩家控制

## 5. 使用技巧
1. **信号组织**：
   ```
   信号分类：
   ├── 系统信号
   ├── 游戏信号
   └── 调试信号
   ```

2. **时序控制**：
   - 精确定时
   - 延迟触发
   - 条件触发

3. **调试支持**：
   - 信号监视
   - 事件追踪
   - 状态记录

## 6. 编程接口
```csharp
public class AdvancedSignalTrack : MonoBehaviour
{
    public PlayableDirector director;
    
    // 动态创建信号点
    public void CreateSignalPoint(float time, SignalAsset signal)
    {
        var timeline = director.playableAsset as TimelineAsset;
        var signalTrack = timeline.CreateTrack<SignalTrack>();
        
        var emitter = signalTrack.CreateMarker<SignalEmitter>(time);
        emitter.asset = signal;
    }
    
    // 批量注册信号
    public void RegisterSignals(Dictionary<SignalAsset, UnityAction> signalMap)
    {
        var receiver = GetComponent<SignalReceiver>();
        foreach (var pair in signalMap)
        {
            receiver.AddReaction(pair.Key, pair.Value);
        }
    }
    
    // 移除信号监听
    public void UnregisterSignal(SignalAsset signal)
    {
        var receiver = GetComponent<SignalReceiver>();
        receiver.RemoveReaction(signal);
    }
}
```

## 7. 注意事项
1. **性能考虑**：
   - 控制信号数量
   - 优化回调处理
   - 及时清理注册

2. **常见问题**：
   - 信号丢失
   - 时序错误
   - 回调异常

3. **最佳实践**：
   - 合理分组
   - 清晰命名
   - 文档记录

## 8. 快捷操作
- 右键轨道：添加信号发送器
- S：在当前时间点添加信号
- Delete：删除信号点
- 双击信号：编辑属性
- Alt+拖拽：复制信号点 