# Playable Director组件使用指南

Playable Director是Unity时间轴（Timeline）系统的核心组件，用于控制和播放时间轴动画。

## 1. 基本设置
- 添加组件：
  1. 选择物体
  2. 在Inspector中点击"Add Component"
  3. 搜索并选择"Playable Director"

- 主要属性：
  - Playable：关联的Timeline资产
  - Initial Time：开始播放的时间点
  - Play On Awake：是否在场景开始时自动播放
  - Wrap Mode：播放模式（循环、单次等）
  - Update Method：更新方式（Fixed Update、Update等）

## 2. 使用Timeline
1. 创建Timeline资产：
   - 在Project窗口中右键
   - Create > Timeline
   - 将创建的Timeline拖拽到Playable的Playable属性中

2. 编辑Timeline：
   - 添加轨道（Track）：
     - Animation Track（动画轨道）
     - Audio Track（音频轨道）
     - Activation Track（激活轨道）
     - Signal Track（信号轨道）
     - Control Track（控制轨道）

## 3. UI节点操作
1. **UI动画轨道**：
   - 添加Animation Track
   - 将UI对象拖拽到轨道的绑定栏
   - 可以控制的UI属性：
     - RectTransform（位置、大小、旋转、缩放）
     - CanvasGroup（透明度、交互性）
     - Image组件（颜色、填充量、精灵切换）
     - Text/TMP组件（文本内容、颜色、字体大小）
     - Slider组件（Value值、交互性）
     - Image.fillAmount（进度条填充）

2. **进度条动画控制**：
   - **Image类型进度条**：
     - 设置Image的Image Type为Filled
     - 在Timeline中可以动画Image的fillAmount属性（0-1之间）
     - 可以设置Fill Method（水平、垂直、径向等）
   
   - **Slider类型进度条**：
     - 在Timeline中可以动画Slider的Value属性
     - 可以同时控制Handle（滑块）的位置和颜色
     - 支持设置最小值和最大值范围

   ```csharp
   // 代码控制进度条示例
   public class ProgressBarController : MonoBehaviour
   {
       public PlayableDirector director;
       public Image fillImage;     // Image类型进度条
       public Slider slider;       // Slider类型进度条
       
       // 根据Timeline播放进度更新进度条
       void Update()
       {
           if (fillImage != null)
           {
               fillImage.fillAmount = (float)(director.time / director.duration);
           }
           
           if (slider != null)
           {
               slider.value = (float)(director.time / director.duration);
           }
       }
       
       // 通过进度条控制Timeline播放位置
       public void OnSliderValueChanged(float value)
       {
           director.time = value * director.duration;
       }
   }
   ```

3. **进度条动画技巧**：
   - 使用Curve Editor调整动画曲线
   - 可以添加关键帧实现非线性进度变化
   - 结合Signal Track在特定进度触发事件
   - 可以同时控制进度条颜色渐变

4. **常见进度条效果**：
   - 平滑填充效果：使用缓动曲线
   - 分段进度：使用多个关键帧
   - 来回循环：设置循环模式
   - 带缓冲的进度条：使用两个Image叠加

5. **注意事项**：
   - 确保进度条UI正确设置锚点和轴心点
   - 注意Fill Amount的更新频率
   - 考虑在加载场景时使用进度条
   - 可以配合粒子效果增强视觉表现

## 4. 常用操作
- 播放控制：
  ```csharp
  PlayableDirector director;
  
  // 播放
  director.Play();
  
  // 暂停
  director.Pause();
  
  // 停止
  director.Stop();
  
  // 设置时间
  director.time = 2.0f;
  
  // 设置播放速度
  director.playableGraph.GetRootPlayable(0).SetSpeed(2.0f);
  ```

- 事件监听：
  ```csharp
  void OnEnable()
  {
      director.played += OnPlayed;
      director.paused += OnPaused;
      director.stopped += OnStopped;
  }

  void OnDisable()
  {
      director.played -= OnPlayed;
      director.paused -= OnPaused;
      director.stopped -= OnStopped;
  }
  ```

## 5. 实用技巧
1. **绑定设置**：
   - 在Timeline窗口中设置轨道绑定
   - 可以通过代码动态修改绑定对象
   ```csharp
   director.SetGenericBinding(track, newBindingObject);
   ```

2. **时间控制**：
   - 使用Time字段精确控制播放位置
   - 可以通过evaluateOnce预览特定时间点

3. **混合使用**：
   - 可以在同一个物体上使用多个Director
   - 可以通过Control Track控制其他Timeline

## 6. 常见问题
1. **播放不生效**：
   - 检查Play On Awake设置
   - 确认Timeline资产已正确绑定
   - 验证绑定对象是否正确

2. **动画不同步**：
   - ��查Update Method设置
   - 确认时间轴刻度设置正确
   - 验证动画片段长度

3. **性能优化**：
   - 使用适当的Update Method
   - 及时清理未使用的轨道
   - 合理设置Timeline的评估间隔

## 7. 最佳实践
1. 合理组织Timeline结构
2. 使用Signal系统进行事件通信
3. 适当使用子Timeline管理复杂序列
4. 注意资源的加载和卸载
5. 使用预设保存常用Timeline设置

## 补充资源
- [Unity Manual - Timeline](https://docs.unity3d.com/Manual/TimelineOverview.html)
- [Unity Manual - PlayableDirector](https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector.html)
- [Unity Timeline Cookbook](https://unity.com/how-to/use-timeline) 