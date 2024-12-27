# Custom Transform Tween Track（自定义变换补间轨道）使用指南

## 1. 基本介绍
Custom Transform Tween Track是一个专门用于处理对象变换动画的轨道，它提供了更灵活的补间动画控制能力，可以自定义补间曲线、动画行为和变换规则。

## 2. 创建和设置
1. **创建轨道**：
   - 在Timeline窗口点击"+"
   - 选择"Custom Transform Tween Track"
   - 绑定目标对象

2. **添加补间片段**：
   - 右键选择"Add Transform Tween"
   - 设置起始和结束状态
   - 配置补间参数

3. **基础属性设置**：
   ```
   Transform Tween属性：
   ├── Start Transform：起始变换
   ├── End Transform：结束变换
   └── Tween Settings：补间设置
   ```

## 3. 高级功能
1. **自定义补间行为**：
   ```csharp
   public class CustomTweenBehaviour : PlayableBehaviour
   {
       public Vector3 startPosition;
       public Vector3 endPosition;
       public Vector3 startRotation;
       public Vector3 endRotation;
       public Vector3 startScale;
       public Vector3 endScale;
       
       public AnimationCurve customCurve;
       
       public override void ProcessFrame(Playable playable, FrameData info, object playerData)
       {
           var transform = playerData as Transform;
           if (transform == null) return;
           
           float progress = (float)(playable.GetTime() / playable.GetDuration());
           float curveValue = customCurve.Evaluate(progress);
           
           transform.position = Vector3.Lerp(startPosition, endPosition, curveValue);
           transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, curveValue);
           transform.localScale = Vector3.Lerp(startScale, endScale, curveValue);
       }
   }
   ```

2. **路径动画**：
   ```csharp
   public class PathTweenController : MonoBehaviour
   {
       public Vector3[] pathPoints;
       public float pathDuration = 1f;
       
       // 创建路径动画
       public void CreatePathAnimation(Transform target)
       {
           var timeline = GetComponent<PlayableDirector>().playableAsset as TimelineAsset;
           var track = timeline.CreateTrack<CustomTweenTrack>();
           
           for (int i = 0; i < pathPoints.Length - 1; i++)
           {
               var clip = track.CreateClip<CustomTweenClip>();
               clip.duration = pathDuration / (pathPoints.Length - 1);
               
               var tween = clip.asset as CustomTweenAsset;
               tween.startPosition = pathPoints[i];
               tween.endPosition = pathPoints[i + 1];
           }
       }
   }
   ```

3. **动画混合**：
   ```csharp
   public class TweenBlender : MonoBehaviour
   {
       // 混合多个补间动画
       public void BlendTweens(CustomTweenBehaviour[] tweens, float[] weights)
       {
           Vector3 finalPosition = Vector3.zero;
           Vector3 finalRotation = Vector3.zero;
           Vector3 finalScale = Vector3.one;
           
           for (int i = 0; i < tweens.Length; i++)
           {
               finalPosition += tweens[i].endPosition * weights[i];
               finalRotation += tweens[i].endRotation * weights[i];
               finalScale = Vector3.Scale(finalScale, tweens[i].endScale * weights[i]);
           }
           
           transform.position = finalPosition;
           transform.eulerAngles = finalRotation;
           transform.localScale = finalScale;
       }
   }
   ```

## 4. 常见用途
1. **对象动画**：
   - 平滑移动
   - 旋转动画
   - 缩放效果

2. **相机动作**：
   - 镜头移动
   - 视角转换
   - 景深变化

3. **UI动效**：
   - 界面切换
   - 元素动画
   - 布局变换

## 5. 使用技巧
1. **补间设置**：
   ```
   补间类型：
   ├── 线性补间
   ├── 曲线补间
   └── 自定义补间
   ```

2. **路径控制**：
   - 贝塞尔曲线
   - 样条插值
   - 路径预览

3. **优化建议**：
   - 减少关键点
   - 平滑过渡
   - 性能优化

## 6. 编程接口
```csharp
public class AdvancedTweenTrack : PlayableTrack
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        var mixer = ScriptPlayable<TweenMixerBehaviour>.Create(graph, inputCount);
        return mixer;
    }
    
    // 创建补间片段
    public TimelineClip CreateTweenClip(Vector3 start, Vector3 end, double duration)
    {
        var clip = CreateClip<CustomTweenClip>();
        clip.duration = duration;
        
        var tween = clip.asset as CustomTweenAsset;
        tween.startPosition = start;
        tween.endPosition = end;
        
        return clip;
    }
    
    // 设置补间曲线
    public void SetTweenCurve(TimelineClip clip, AnimationCurve curve)
    {
        var tween = clip.asset as CustomTweenAsset;
        tween.customCurve = curve;
    }
}
```

## 7. 注意事项
1. **性能考虑**：
   - 补间计算
   - 更新频率
   - 内存占用

2. **常见问题**：
   - 动画卡顿
   - 路径偏移
   - 补间不平���

3. **最佳实践**：
   - 合理分段
   - 曲线优化
   - 缓存计算

## 8. 快捷操作
- 右键轨道：添加补间片段
- T：在当前时间点创建关键帧
- Ctrl+拖拽：复制补间片段
- Alt+拖拽：调整补间时间
- E：编辑补间曲线 