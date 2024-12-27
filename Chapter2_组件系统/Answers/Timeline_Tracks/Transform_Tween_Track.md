# Transform Tween Track（变换补间轨道）使用指南

## 1. 基本介绍
Transform Tween Track是一个用于创建对象变换动画的基础轨道，它提供了简单直观的方式来制作位置、旋转和缩放的补间动画。与Custom Transform Tween Track相比，它更适合基础的变换动画需求。

## 2. 创建和设置
1. **创建轨道**：
   - 在Timeline窗口点击"+"
   - 选择"Transform Tween Track"
   - 绑定目标对象

2. **添加补间片段**：
   - 设置起始状态
   - 设置结束状态
   - 配置补间参数

3. **基础属性设置**：
   ```
   Transform Tween属性：
   ├── Position：位置补间
   ├── Rotation：旋转补间
   └── Scale：缩放补间
   ```

## 3. 高级功能
1. **补间控制器**：
   ```csharp
   public class TransformTweenController : MonoBehaviour
   {
       public PlayableDirector director;
       
       // 创建补间动画
       public void CreateTween(Transform target,
                             Vector3 endPosition,
                             Quaternion endRotation,
                             Vector3 endScale,
                             float duration)
       {
           var timeline = director.playableAsset as TimelineAsset;
           var track = timeline.CreateTrack<TransformTweenTrack>();
           
           var clip = track.CreateClip<TransformTweenClip>();
           clip.duration = duration;
           
           var tween = clip.asset as TransformTweenAsset;
           tween.endPosition = endPosition;
           tween.endRotation = endRotation;
           tween.endScale = endScale;
       }
   }
   ```

2. **补间曲线**：
   ```csharp
   public class TweenCurveController : MonoBehaviour
   {
       // 设置补间曲线
       public void SetTweenCurves(TransformTweenClip clip)
       {
           var asset = clip.asset as TransformTweenAsset;
           
           // 位置曲线
           asset.positionCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
           
           // 旋转曲线
           asset.rotationCurve = AnimationCurve.Linear(0, 0, 1, 1);
           
           // 缩放曲线
           asset.scaleCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
       }
   }
   ```

3. **路径动画**：
   ```csharp
   public class TweenPathController : MonoBehaviour
   {
       // 创建路径动画
       public void CreatePathAnimation(Transform target,
                                    Vector3[] pathPoints,
                                    float totalDuration)
       {
           var timeline = GetComponent<PlayableDirector>().playableAsset as TimelineAsset;
           var track = timeline.CreateTrack<TransformTweenTrack>();
           
           float segmentDuration = totalDuration / (pathPoints.Length - 1);
           
           for (int i = 0; i < pathPoints.Length - 1; i++)
           {
               var clip = track.CreateClip<TransformTweenClip>();
               clip.start = i * segmentDuration;
               clip.duration = segmentDuration;
               
               var tween = clip.asset as TransformTweenAsset;
               tween.startPosition = pathPoints[i];
               tween.endPosition = pathPoints[i + 1];
           }
       }
   }
   ```

## 4. 常见用途
1. **UI动画**：
   - 界面切换
   - 元素移动
   - 缩放效果

2. **相机动画**：
   - 镜头移动
   - 视角转换
   - 跟随目标

3. **游戏对象**：
   - 物体移动
   - 旋转动画
   - 尺寸变化

## 5. 使用技巧
1. **补间类型**：
   ```
   补间方式：
   ├── 线性补间
   ├── 缓动补间
   └── 弹性补间
   ```

2. **优化建议**：
   - 减少关键点
   - 使用曲线优化
   - 合并相似动画

3. **调试支持**：
   - ���径预览
   - 曲线编辑
   - 实时预览

## 6. 编程接口
```csharp
public class AdvancedTransformTweenTrack : PlayableTrack
{
    // 创建基础补间
    public TimelineClip CreateBasicTween(Vector3 start,
                                       Vector3 end,
                                       double duration)
    {
        var clip = CreateClip<TransformTweenClip>();
        clip.duration = duration;
        
        var tween = clip.asset as TransformTweenAsset;
        tween.startPosition = start;
        tween.endPosition = end;
        
        return clip;
    }
    
    // 设置补间曲线
    public void SetTweenEase(TimelineClip clip, AnimationCurve curve)
    {
        var tween = clip.asset as TransformTweenAsset;
        tween.positionCurve = curve;
        tween.rotationCurve = curve;
        tween.scaleCurve = curve;
    }
    
    // 更新补间设置
    public void UpdateTweenSettings(TimelineClip clip,
                                  bool useLocal,
                                  bool affectPosition,
                                  bool affectRotation,
                                  bool affectScale)
    {
        var tween = clip.asset as TransformTweenAsset;
        tween.useLocalTransform = useLocal;
        tween.tweenPosition = affectPosition;
        tween.tweenRotation = affectRotation;
        tween.tweenScale = affectScale;
    }
}
```

## 7. 注意事项
1. **性能考虑**：
   - 补间计算
   - 更新频率
   - 内存使用

2. **常见问题**：
   - 路径偏移
   - 旋转异常
   - 缩放不均匀

3. **最佳实践**：
   - 合理分段
   - 优化曲线
   - 减少复杂度

## 8. 快捷操作
- 右键轨道：添加补间片段
- T：创建关键帧
- Ctrl+拖拽：复制补间
- Alt+拖拽：调整时间
- E：编辑补间曲线 