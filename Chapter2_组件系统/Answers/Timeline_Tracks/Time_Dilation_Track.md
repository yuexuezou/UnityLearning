# Time Dilation Track（时间膨胀轨道）使用指南

## 1. 基本介绍
Time Dilation Track用于控制Timeline中的时间流速，可以实现慢动作、快进等效果。它允许动态调整播放速度，创建时间变速效果，适用于创建戏剧性的场景和特殊的游戏效果。

## 2. 创建和设置
1. **创建轨道**：
   - 在Timeline窗口点击"+"
   - 选择"Time Dilation Track"
   - 设置时间参数

2. **添加时间控制**：
   - 设置时间系数
   - 配置变速曲线
   - 定义作用范围

3. **基础属性设置**：
   ```
   Time Dilation属性：
   ├── Time Scale：时间缩放
   ├── Blend Curve：混合曲线
   └── Affect Range：影响范围
   ```

## 3. 高级功能
1. **时间控制器**：
   ```csharp
   public class TimeDilationController : MonoBehaviour
   {
       public PlayableDirector director;
       
       // 设置时间缩放
       public void SetTimeScale(double time, float scale)
       {
           var timeline = director.playableAsset as TimelineAsset;
           var track = timeline.CreateTrack<TimeDilationTrack>();
           
           var marker = track.CreateMarker<TimeDilationMarker>(time);
           marker.timeScale = scale;
       }
       
       // 创建渐变时间缩放
       public void CreateTimeScaleTransition(double startTime, 
                                          double endTime,
                                          float startScale,
                                          float endScale)
       {
           var track = timeline.GetOutputTrack(0) as TimeDilationTrack;
           var clip = track.CreateClip<TimeDilationAsset>();
           
           clip.start = startTime;
           clip.duration = endTime - startTime;
           
           var dilationAsset = clip.asset as TimeDilationAsset;
           dilationAsset.startScale = startScale;
           dilationAsset.endScale = endScale;
       }
   }
   ```

2. **效果混合**：
   ```csharp
   public class TimeDilationBlender : MonoBehaviour
   {
       // 混合多个时间效果
       public float BlendTimeScales(float[] scales, float[] weights)
       {
           float finalScale = 1f;
           float totalWeight = 0f;
           
           for (int i = 0; i < scales.Length; i++)
           {
               finalScale += scales[i] * weights[i];
               totalWeight += weights[i];
           }
           
           return totalWeight > 0 ? finalScale / totalWeight : 1f;
       }
   }
   ```

3. **范围控制**：
   ```csharp
   public class TimeDilationRange : MonoBehaviour
   {
       // 设置时间效果范围
       public void SetAffectedTracks(TimeDilationTrack dilationTrack,
                                   TrackAsset[] affectedTracks)
       {
           var dilationAsset = dilationTrack.GetClips()
               .First().asset as TimeDilationAsset;
               
           dilationAsset.affectedTracks.Clear();
           dilationAsset.affectedTracks.AddRange(affectedTracks);
       }
   }
   ```

## 4. 常见用途
1. **特效增强**：
   - 慢动作效果
   - 快进场景
   - 时间冻结

2. **游戏机制**：
   - 子弹时间
   - 技能时间
   - 关键时刻

3. **叙事控制**：
   - 戏剧性时刻
   - 过场动画
   - 重要事件

## 5. 使用技巧
1. **时间控制**：
   ```
   控制方式：
   ├── 全局控制
   ├── 局部控制
   └── 渐变控制
   ```

2. **优化建议**：
   - 合理使用
   - 避免叠加
   - 性能优化

3. **调试支持**：
   - 时间监视
   - 效果预览
   - 性能分析

## 6. 编程接口
```csharp
public class AdvancedTimeDilationTrack : PlayableTrack
{
    // 创建时间控制片段
    public TimelineClip CreateDilationClip(double start, 
                                         double duration,
                                         float scale)
    {
        var clip = CreateClip<TimeDilationAsset>();
        clip.start = start;
        clip.duration = duration;
        
        var asset = clip.asset as TimeDilationAsset;
        asset.timeScale = scale;
        
        return clip;
    }
    
    // 设置时间曲线
    public void SetDilationCurve(TimelineClip clip, AnimationCurve curve)
    {
        var asset = clip.asset as TimeDilationAsset;
        asset.dilationCurve = curve;
    }
    
    // 更新时间效果
    public void UpdateDilation(TimelineClip clip,
                             float newScale,
                             bool affectChildren)
    {
        var asset = clip.asset as TimeDilationAsset;
        asset.timeScale = newScale;
        asset.affectChildren = affectChildren;
    }
}
```

## 7. 注意事项
1. **性能影响**：
   - 计算开销
   - 更新频率
   - 内存使用

2. **常见问题**：
   - 效果冲突
   - 同步问题
   - 性能下降

3. **最佳实践**：
   - 合理使用
   - 效果优化
   - 资源管理

## 8. 快捷操作
- 右键轨道：添加时间控制
- T：创建时间标记
- Ctrl+T：编辑时间设置
- Alt+拖拽：调整时间范围
- Delete：删除时间控制 