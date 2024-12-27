# Control Track（控制轨道）使用指南

## 1. 基本介绍
Control Track用于在Timeline中控制预制体的实例化和销毁，可以在特定时间点创建或移除场景对象，常用于动态加载和管理场景元素。

## 2. 创建和设置
1. **创建轨道**：
   - 在Timeline窗口点击"+"
   - 选择"Control Track"
   - 设置父物体作为生成位置

2. **添加控制片段**：
   - 将预制体拖拽到轨道
   - 右键选择"Add Control Clip"
   - 设置预制体引用

3. **基础属性设置**：
   ```
   Control Clip属性：
   ├── Prefab：预制体引用
   ├── Parent Object：父物体
   └── Start Location：生成位置
   ```

## 3. 高级功能
1. **预制体控制**：
   ```csharp
   public class ControlTrackManager : MonoBehaviour
   {
       public PlayableDirector director;
       
       // 动态添加预制体控制
       public void AddPrefabControl(GameObject prefab, double startTime, double duration)
       {
           var timeline = director.playableAsset as TimelineAsset;
           var track = timeline.GetOutputTrack(0) as ControlTrack;
           
           var clip = track.CreateClip<ControlPlayableAsset>();
           clip.start = startTime;
           clip.duration = duration;
           
           var controlAsset = clip.asset as ControlPlayableAsset;
           controlAsset.prefabGameObject = prefab;
           controlAsset.updateParent = true;
       }
       
       // 设置生成位置
       public void SetSpawnTransform(Transform spawnPoint)
       {
           var track = director.playableAsset.GetOutputTrack(0) as ControlTrack;
           foreach (var clip in track.GetClips())
           {
               var controlAsset = clip.asset as ControlPlayableAsset;
               controlAsset.parentObject = spawnPoint;
           }
       }
   }
   ```

2. **生命周期控制**：
   - 实例化回调
   - 销毁回调
   - 状态监听

3. **对象池集成**：
   ```csharp
   public class PooledControlTrack : MonoBehaviour
   {
       private ObjectPool<GameObject> objectPool;
       
       void OnControlClipStart(PlayableDirector director)
       {
           // 从对象池获取实例
           var instance = objectPool.Get();
           // 设置实例属性
       }
       
       void OnControlClipEnd(PlayableDirector director)
       {
           // 返回实例到对象池
           objectPool.Release(instance);
       }
   }
   ```

## 4. 常见用途
1. **场景管理**：
   - 动态加载场景物体
   - 管理临时特效
   - 控制NPC出场

2. **资源控制**：
   - 预加载资源
   - 延迟加载
   - 资源释放

3. **游戏机制**：
   - 生成敌人
   - 投放道具
   - 触发机关

## 5. 使用技巧
1. **性能优化**：
   ```
   优化策略：
   ├── 使用对象池
   ├── 预加载资源
   └── 延迟销毁
   ```

2. **生成控制**：
   - 批量生成
   - 随机位置
   - 自定义参数

3. **实例管理**：
   - 引用跟踪
   - 状态同步
   - 生命周期管理

## 6. 编程接口
```csharp
public class AdvancedControlTrack : MonoBehaviour
{
    public PlayableDirector director;
    private Dictionary<GameObject, GameObject> instances = new Dictionary<GameObject, GameObject>();
    
    // 预制体实例化事件处理
    void OnControlInstanceSpawned(GameObject instance, GameObject prefab)
    {
        instances[prefab] = instance;
        // 初始化实例
        InitializeInstance(instance);
    }
    
    // 预制体销毁事件处理
    void OnControlInstanceDestroyed(GameObject instance, GameObject prefab)
    {
        instances.Remove(prefab);
        // 清理实例
        CleanupInstance(instance);
    }
    
    // 获取当前活���的实例
    public GameObject GetActiveInstance(GameObject prefab)
    {
        return instances.TryGetValue(prefab, out var instance) ? instance : null;
    }
}
```

## 7. 注意事项
1. **资源管理**：
   - 及时释放资源
   - 避免内存泄漏
   - 控制实例数量

2. **常见问题**：
   - 实例化失败
   - 位置错误
   - 引用丢失

3. **调试建议**：
   - 检查预制体引用
   - 验证生成位置
   - 监控实例状态

## 8. 快捷操作
- 右键轨道：添加控制片段
- Ctrl+拖拽：复制控制片段
- Delete：删除片段
- 双击片段：编辑属性
- Alt+拖拽：调整时间位置 