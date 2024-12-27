# Animation Track（动画轨道）使用指南

## 1. 基本介绍
Animation Track用于控制对象的动画播放，支持动画片段的播放、混合和过渡。可以控制任何带有Animator组件的对象。

## 2. 创建和设置
1. **创建轨道**：
   - 在Timeline窗口点击"+"
   - 选择"Animation Track"
   - 将带有Animator组件的对象拖拽到轨道绑定栏

2. **添加动画片段**：
   - 直接拖拽动画文件到轨道
   - 右键选择"Add From Animation Clip"
   - 创建新的动画片段（Record Mode）

3. **基础属性设置**：
   ```
   Animation Track属性：
   ├── Track Offsets
   │   ├── Position：位置偏移
   │   ├── Rotation：旋转偏移
   │   └── Scale：缩放偏移
   ├── Apply Avatar Mask
   └── Apply Foot IK
   ```

## 3. 高级功能
1. **动画混合**：
   ```csharp
   public class AnimationMixerController : MonoBehaviour
   {
       public PlayableDirector director;
       
       // 设置动画混合权重
       public void SetAnimationWeight(AnimationClip clip, float weight)
       {
           var timeline = director.playableAsset as TimelineAsset;
           var track = timeline.GetOutputTrack(0) as AnimationTrack;
           
           foreach (var timelineClip in track.GetClips())
           {
               if (timelineClip.animationClip == clip)
               {
                   timelineClip.mixInCurve = AnimationCurve.Linear(0, 0, 1, weight);
               }
           }
       }
   }
   ```

2. **动画重定向**：
   - 支持Avatar重定向
   - 可以在不同模型间复用动画
   - 设置Avatar Mask控制影响范围

3. **曲线编辑**：
   - 支持关键帧编辑
   - 可以修改动画曲线
   - 支持添加额外属性动画

## 4. 常见用途
1. **角色动画**：
   - 过场动画
   - 动作序列
   - 表情动画

2. **相机动画**：
   - 镜头移动
   - 景深控制
   - 视角切换

3. **环境动画**：
   - 场景物体动画
   - 天气效果
   - 植被动画

## 5. 使用技巧
1. **动画过渡**：
   ```
   过渡设置：
   ├── 混合持续时间
   ├── 混合曲线类型
   └── 过渡起始/结束时间
   ```

2. **动画叠加**：
   - 使用多个轨道叠加效果
   - 设置不同的混合模式
   - 控制各层动画权重

3. **优化建议**：
   - 合理使用动画压缩
   - 控制同时播放的动画数量
   - ��用Avatar Mask优化性能

## 6. 编程控制
```csharp
public class AnimationTrackController : MonoBehaviour
{
    public PlayableDirector director;
    
    // 播放指定时间点的动画
    public void PlayAtTime(float time)
    {
        director.time = time;
        director.Evaluate();
    }
    
    // 动态添加动画片段
    public void AddAnimationClip(AnimationClip clip, double startTime)
    {
        var timeline = director.playableAsset as TimelineAsset;
        var track = timeline.GetOutputTrack(0) as AnimationTrack;
        
        var newClip = track.CreateClip(clip);
        newClip.start = startTime;
        newClip.duration = clip.length;
    }
    
    // 设置动画速度
    public void SetAnimationSpeed(float speed)
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(speed);
    }
}
```

## 7. 注意事项
1. **性能考虑**：
   - 避免过多动画同时播放
   - 合理使用动画压缩
   - 注意内存占用

2. **常见问题**：
   - 动画不同步
   - 过渡不平滑
   - 动画冲突

3. **调试技巧**：
   - 使用Timeline预览
   - 检查动画状态
   - 监控性能指标

## 8. 快捷操作
- 右键轨道：添加动画片段
- Alt+拖拽：创建动画片段副本
- Ctrl+拖拽边缘：调整持续时间
- E：进入动画编辑模式
- K：添加关键帧 