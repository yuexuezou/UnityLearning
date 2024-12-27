# 第二章：Unity组件系统

## 1. Transform组件
// ... existing code ...

## 2. Playable Director组件
### 2.1 组件概述
- **功能定义**：
  - Timeline系统的核心组件
  - 用于控制和播放时间轴动画
  - 支持多轨道混合控制

- **应用场景**：
  - UI动画序列
  - 过场动画
  - 游戏剧情
  - 多媒体同步

### 2.2 基础配置
1. **添加组件**：
   - 选择目标物体
   - Add Component > Playable Director
   
2. **核心属性**：
   - Playable：Timeline资产引用
   - Initial Time：起始时间点
   - Play On Awake：自动播放设置
   - Wrap Mode：循环模式
   - Update Method：更新方式

### 2.3 Timeline资产
1. **创建方式**：
   - Project窗口右键
   - Create > Timeline
   - 拖拽到Director的Playable属性

2. **轨道类型**：
   Timeline提供了丰富的轨道类型，用于不同的控制需求。
   > [查看完整的轨道类型说明](Answers/Timeline_Track_Types.md)

3. **轨道使用建议**：
   - 合理组织Track Group
   - 根据需求选择合适的轨道类型
   - 注意轨道之间的优先级
   - 适当使���混合模式
   - 控制轨道数量，避免过度复杂

### 2.4 Animator控制
1. **基础设置**：
   - 添加Animation Track
   - 将带有Animator组件的物体拖拽到轨道
   - 创建动画片段或使用现有动画片段

2. **动画控制方式**：
   ```csharp
   public class AnimationController : MonoBehaviour
   {
       public PlayableDirector director;
       public Animator animator;

       // 混合动画权重
       public void SetAnimationWeight(float weight)
       {
           var timelineAsset = director.playableAsset as TimelineAsset;
           foreach (var track in timelineAsset.GetOutputTracks())
           {
               if (track is AnimationTrack)
               {
                   var mixer = director.GetGenericBinding(track) as Animator;
                   if (mixer != null)
                   {
                       mixer.SetLayerWeight(0, weight);
                   }
               }
           }
       }

       // 动画过渡
       public void TransitionToState(string stateName)
       {
           animator.CrossFade(stateName, 0.25f);
       }
   }
   ```

3. **高级功能**：
   - **动画混合**：
     - 使用多个Animation Track
     - 设置轨道的混合模式
     - 调整动画权重

   - **动画重定向**：
     - 支持Avatar重定向
     - 可以在不同模型间复用动画

   - **动画事件**：
     - 在Timeline中添加Marker
     - 使用Signal发送动画事件
     - 在代码中响应事件

4. **注意事项**：
   - 确保Animator Controller设置正确
   - 注意动画状态机的过渡设置
   - 处理好动画权重和混合
   - 避免动画冲突

### 2.5 进度控制
1. **代码控制**：
   ```csharp
   PlayableDirector director;
   
   // 基础控制
   director.Play();    // 播放
   director.Pause();   // 暂停
   director.Stop();    // 停止
   
   // 时间控制
   director.time = 2.0f;  // 跳转到指定时间
   
   // 速度控制
   director.playableGraph.GetRootPlayable(0).SetSpeed(2.0f);
   ```

2. **进度条同步**：
   ```csharp
   public class TimelineProgressBar : MonoBehaviour
   {
       public PlayableDirector director;
       public Image progressBar;
       public Slider progressSlider;
       
       void Update()
       {
           float progress = (float)(director.time / director.duration);
           
           // Image类型进度条
           if (progressBar != null)
               progressBar.fillAmount = progress;
           
           // Slider类型进度条
           if (progressSlider != null)
               progressSlider.value = progress;
       }
       
       // 进度条控制Timeline
       public void OnProgressChanged(float value)
       {
           director.time = value * director.duration;
           if (director.state != PlayState.Playing)
               director.Evaluate();  // 立即更新到指定时间点
       }
   }
   ```

### 2.6 事件系统
1. **回调事件**：
   ```csharp
   void OnEnable()
   {
       director.played += OnTimelinePlayed;
       director.paused += OnTimelinePaused;
       director.stopped += OnTimelineStopped;
   }
   ```

2. **Signal系统**：
   - 添加Signal Track
   - 创建Signal Asset
   - 绑定Signal Receiver
   - 实现事件响应

### 2.7 高级应用
1. **多轨道控制**：
   - 动画与音频同步
   - UI动画序列
   - 场景切换控制

2. **运行时操作**：
   ```csharp
   // 动态修改绑定
   director.SetGenericBinding(track, newBindingObject);
   
   // 预览指定时间点
   director.Evaluate();
   
   // 动态调整播放范围
   director.playableAsset.duration = newDuration;
   ```

### 2.8 最佳实践
1. **项目规范**：
   - 合理组织Timeline结构
   - 统一命名规则
   - 做好版本控制

2. **常见问题**：
   - 播放控制无效
   - 动画不同步
   - 事件未触发

3. **调试技巧**：
   - 使用Timeline窗口
   - 检查绑定关系
   - 监控运行时状态

> [问题：如何用Playable Director控制UI进度条？](Answers/Timeline_Progress_Control.md)

## 3. Rigidbody组件
// ... rest of existing content ... 

# Timeline轨道类型

Timeline系统中包含多种不同类型的轨道，每种轨道都有其特定的用途和功能。以下是所有轨道类型的详细说明：

## 基础轨道
1. [Animation Track（动画轨道）](Answers/Timeline_Tracks/Animation_Track.md)
   - 用于控制对象的动画播放
   - 支持动画片段的播放、混合和过渡
   - 可以控制任何带有Animator组件的对象

2. [Audio Track（音频轨道）](Answers/Timeline_Tracks/Audio_Track.md)
   - 用于控制音频的播放
   - 支持音乐、音效和语音等多种音频类型
   - 可以精确控制播放时间和音量

3. [Control Track（控制轨道）](Answers/Timeline_Tracks/Control_Track.md)
   - 用于控制预制体的实例化和销毁
   - 可以在特定时间点创建或移除场景对象
   - 常用于动态加载和管理场景元素

4. [Signal Track（信号轨道）](Answers/Timeline_Tracks/Signal_Track.md)
   - 用于发送事件信号
   - 可以在特定时间点触发自定义事件
   - 实现Timeline与其他游戏系统的通信

5. [Playable Track（可播放轨道）](Answers/Timeline_Tracks/Playable_Track.md)
   - 最灵活的轨道类型
   - 允许自定义任何类型的可播放内容
   - 通过Playable API提供完全的自定义控制能力

## 相机与动画
6. [Cinemachine Track（相机轨道）](Answers/Timeline_Tracks/Cinemachine_Track.md)
   - 用于控制虚拟相机的行为
   - 可以实现复杂的相机运动和转场效果
   - 与Cinemachine系统紧密集成

7. [Adjust Animation Track（动画调整轨道）](Answers/Timeline_Tracks/Adjust_Animation_Track.md)
   - 用于调整和修改现有的动画片段
   - 可以在不改变原始动画文件的情况下调整动画
   - 支持位置、旋转、缩放等参数的实时调整

## 自定义轨道
8. [Custom Signal Track（自定义信号轨道）](Answers/Timeline_Tracks/Custom_Signal_Track.md)
   - Signal Track的扩展版本
   - 允许创建自定义的信号类型和处理逻辑
   - 可以传递复杂的数据结构

9. [Custom Transform Tween Track（自定义变换补间轨道）](Answers/Timeline_Tracks/Custom_Transform_Tween_Track.md)
   - 用于处理对象变换动画的高级轨道
   - 提供更灵活的补间动画控制能力
   - 可以自定义补间曲线和变换规则

## 控制轨道
10. [Loop Control Track（循环控制轨道）](Answers/Timeline_Tracks/Loop_Control_Track.md)
    - 控制Timeline中的循环播放行为
    - 可以设置循环次数和条件
    - 支持特定片段或整个序列的循环

11. [Time Dilation Track（时间膨胀轨道）](Answers/Timeline_Tracks/Time_Dilation_Track.md)
    - 控制Timeline中的时间流速
    - 可以实现慢动作、快进等效果
    - 支持动态调整播放速度

12. [Transform Tween Track（变换补间轨道）](Answers/Timeline_Tracks/Transform_Tween_Track.md)
    - 用于创建基础的对象变换动画
    - 提供简单直观的补间动画制作方式
    - 适合基础的变换动画需求

## 使用建议
1. **选择合适的轨道类型**
   - 根据具体需求选择最适合的轨道
   - 避免使用过于复杂的轨道来实现简单功能
   - 合理组合不同类型的轨道

2. **优化性能**
   - 控制同时播放的轨道数量
   - 合理使用循环和时间控制
   - 注意内存和计算资源的使用

3. **组织结构**
   - 使用Track Group组织相关轨道
   - 保持Timeline结构清晰
   - 合理命名和分类

4. **调试和维护**
   - 经常检查轨道状态
   - 使用Signal Track进行调试
   - 保持文档更新

5. **扩展性考虑**
   - 合理使用自定义轨道
   - 设计可重用的轨道模板
   - 保持代码的可维护性 