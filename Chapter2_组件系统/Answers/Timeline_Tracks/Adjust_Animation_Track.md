# Adjust Animation Track（动画调整轨道）使用指南

## 1. 基本介绍
Adjust Animation Track用于在Timeline中调整和修改现有的动画片段，可以在不改变原始动画文件的情况下，实时调整动画的各种参数，如位置、旋转、缩放等。

## 2. 创建和设置
1. **创建轨道**：
   - 在Timeline窗口点击"+"
   - 选择"Adjust Animation Track"
   - 绑定目标对象

2. **添加调整片段**：
   - 右键选择"Add Animation Override"
   - 设置调整参数
   - 添加关键帧

3. **基础属性设置**：
   ```
   Adjust Animation属性：
   ├── Position：位置调整
   ├── Rotation：旋转调整
   └── Scale：缩放调整
   ```

## 3. 高级功能
1. **动画覆盖**：
   ```csharp
   public class AnimationAdjuster : MonoBehaviour
   {
       public PlayableDirector director;
       
       // 创建动画调整
       public void CreateAdjustment(Vector3 positionOffset, Quaternion rotationOffset)
       {
           var timeline = director.playableAsset as TimelineAsset;
           var track = timeline.GetOutputTrack(0) as AnimationTrack;
           
           var clip = track.CreateClip<AnimationPlayableAsset>();
           var adjustTrack = timeline.CreateTrack<AdjustmentTrack>();
           adjustTrack.SetOffset(clip, positionOffset, rotationOffset);
       }
   }
   ```

2. **参数动画**：
   ```csharp
   public class ParameterAnimator : MonoBehaviour
   {
       public AnimationCurve positionCurve;
       public AnimationCurve rotationCurve;
       
       // 创建参数动画
       public void CreateParameterAnimation()
       {
           var clip = new AnimationClip();
           
           // 添加位置曲线
           clip.SetCurve("", typeof(Transform), "localPosition.x", positionCurve);
           
           // 添加旋转曲线
           clip.SetCurve("", typeof(Transform), "localRotation.y", rotationCurve);
       }
   }
   ```

3. **混合控制**：
   ```csharp
   public class AdjustmentBlender : MonoBehaviour
   {
       // 设置混合权重
       public void SetBlendWeight(PlayableDirector director, float weight)
       {
           var playable = director.playableGraph.GetRootPlayable(0);
           playable.SetInputWeight(0, weight);
       }
   }
   ```

## 4. 常见用途
1. **动画微调**：
   - 位置偏移
   - 旋转修正
   - 缩放调整

2. **动作修改**：
   - 动作幅度
   - 速度控制
   - 姿态调整

3. **特效增强**：
   - 动画叠加
   - 过渡效果
   - 动态调整

## 5. 使用技巧
1. **调整方式**：
   ```
   调整类型：
   ├── 绝对调整
   ├── 相对调整
   └── 叠加调整
   ```

2. **参数控制**：
   - 曲线编辑
   - 关键帧设置
   - 插值控制

3. **优化建议**：
   - 减少调整数量
   - 合并相似调整
   - 使用预设值

## 6. 编程接口
```csharp
public class AdvancedAdjustmentTrack : MonoBehaviour
{
    public PlayableDirector director;
    
    // 创建动画调整轨道
    public AdjustmentTrack CreateAdjustmentTrack(string trackName)
    {
        var timeline = director.playableAsset as TimelineAsset;
        var track = timeline.CreateTrack<AdjustmentTrack>(null, trackName);
        return track;
    }
    
    // 添加调整片段
    public TimelineClip AddAdjustmentClip(AdjustmentTrack track, 
                                        double startTime,
                                        double duration,
                                        Vector3 positionOffset)
    {
        var clip = track.CreateClip<AdjustmentPlayableAsset>();
        clip.start = startTime;
        clip.duration = duration;
        
        var asset = clip.asset as AdjustmentPlayableAsset;
        asset.position = positionOffset;
        
        return clip;
    }
    
    // 更新调整参数
    public void UpdateAdjustment(TimelineClip clip,
                               Vector3 position,
                               Quaternion rotation,
                               Vector3 scale)
    {
        var asset = clip.asset as AdjustmentPlayableAsset;
        asset.position = position;
        asset.rotation = rotation;
        asset.scale = scale;
    }
}
```

## 7. 注意事项
1. **性能影响**：
   - 调整复杂度
   - 更新频率
   - 内存占用

2. **常见问题**：
   - 动画冲突
   - 参数失效
   - 性能下降

3. **最佳实践**：
   - 合理分层
   - 优化调整
   - 及时清理

## 8. 快捷操作
- 右键轨道：添加调整片段
- K：添加关键帧
- Alt+拖拽：复制调整
- Ctrl+Z：撤销修改
- Delete：删除调整 