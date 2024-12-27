# 如何使用Playable Director控制Animator？

## 1. 基础设置
1. **准备工作**：
   - 确保物体上有Animator组件
   - 添加Playable Director组件
   - 创建Timeline资产

2. **创建动画轨道**：
   - 在Timeline窗口点击"+"添加Animation Track
   - 将带Animator的物体拖拽到轨道的绑定栏
   - 可以添加多个Animation Track控制不同部分

## 2. 动画片段管理
1. **添加动画片段**：
   - 直接拖拽动画文件到轨道
   - 在轨道上右键Create Animation Clip
   - 使用现有的Animation Controller中的动画

2. **动画片段设置**：
   ```csharp
   public class AnimationClipController : MonoBehaviour
   {
       public PlayableDirector director;
       
       // 动态添加动画片段
       public void AddAnimationClip(AnimationClip clip, float startTime)
       {
           var timelineAsset = director.playableAsset as TimelineAsset;
           var animTrack = timelineAsset.GetOutputTrack(0) as AnimationTrack;
           
           // 创建新的动画片段
           var timelineClip = animTrack.CreateClip(clip);
           timelineClip.start = startTime;
           timelineClip.duration = clip.length;
       }
       
       // 修改动画播放速度
       public void SetClipSpeed(TimelineClip clip, float speed)
       {
           clip.timeScale = speed;
       }
   }
   ```

## 3. 动画混合
1. **权重控制**：
   ```csharp
   public class AnimationMixerController : MonoBehaviour
   {
       public PlayableDirector director;
       
       // 设置动画层权重
       public void SetTrackWeight(AnimationTrack track, float weight)
       {
           var mixer = director.GetGenericBinding(track) as Animator;
           if (mixer != null)
           {
               var playable = director.playableGraph.GetRootPlayable(0);
               playable.SetInputWeight(track.GetBindingID(), weight);
           }
       }
       
       // 创建动画混合
       public void CreateBlend(AnimationClip clip1, AnimationClip clip2, float blendTime)
       {
           var timelineAsset = director.playableAsset as TimelineAsset;
           var animTrack = timelineAsset.GetOutputTrack(0) as AnimationTrack;
           
           var clip1Instance = animTrack.CreateClip(clip1);
           var clip2Instance = animTrack.CreateClip(clip2);
           
           // 设置混合时间
           clip2Instance.blendInDuration = blendTime;
       }
   }
   ```

2. **混合模式**：
   - Overlay：叠加模式
   - Replace：替换模式
   - Additive：添加模式

## 4. 动画事件
1. **使用Marker**：
   ```csharp
   public class AnimationEventHandler : MonoBehaviour
   {
       public PlayableDirector director;
       
       void OnEnable()
       {
           // 订阅Timeline标记事件
           director.played += OnDirectorPlayed;
           director.stopped += OnDirectorStopped;
       }
       
       void OnDisable()
       {
           director.played -= OnDirectorPlayed;
           director.stopped -= OnDirectorStopped;
       }
       
       // 处理动画事件
       public void OnAnimationEvent(string eventName)
       {
           Debug.Log($"Animation Event: {eventName}");
       }
   }
   ```

2. **Signal系统**：
   - 创建Signal Asset
   - 在Timeline中添加Signal标记
   - 实现Signal Receiver

## 5. 高级技巧
1. **动画状态控制**：
   ```csharp
   public class AdvancedAnimationController : MonoBehaviour
   {
       public PlayableDirector director;
       public Animator animator;
       
       // 平滑过渡到某个状态
       public void TransitionToState(string stateName, float transitionTime)
       {
           animator.CrossFadeInFixedTime(stateName, transitionTime);
       }
       
       // 动��参数控制
       public void SetAnimatorParameter(string paramName, float value)
       {
           animator.SetFloat(paramName, value);
       }
       
       // 暂停/恢复动画
       public void ToggleAnimation(bool isPaused)
       {
           if (isPaused)
               director.Pause();
           else
               director.Resume();
       }
   }
   ```

2. **性能优化**：
   - 使用动画压缩
   - 合理设置更新频率
   - 优化动画层级

## 6. 常见问题
1. **动画不播放**：
   - 检查Animator组件设置
   - 验证动画绑定关系
   - 确认Timeline激活状态

2. **动画不同步**：
   - 检查动画片段时间设置
   - 验证Update Mode设置
   - 确认帧率设置

3. **混合问题**：
   - 检查权重设置
   - 验证混合模式
   - 确认动画兼容性

## 7. 最佳实践
1. **组织结构**：
   - 合理分层动画轨道
   - 使用清晰的命名规则
   - 保持Timeline结构简洁

2. **性能考虑**：
   - 避免过多动画层
   - 合理使用动画压缩
   - 控制同时播放的动画数量

3. **调试技巧**：
   - 使用Timeline预览
   - 监控动画性能
   - 善用动画事件调试 