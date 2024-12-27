# 如何使用Playable Director控制UI进度条？

## 1. 准备工作
1. **创建UI进度条**：
   - 创建Image或Slider类型的进度条
   - 设置好锚点和轴心点
   - 配置合适的大小和位置

2. **设置Playable Director**：
   - 添加Playable Director组件
   - 创建并绑定Timeline资产
   - 设置适当的播放模式

## 2. 进度条类型选择
### 2.1 Image类型进度条
1. **设置Image组件**：
   - Image Type选择Filled
   - Fill Method选择合适的填充方式
   - Fill Origin设置起始位置
   - Fill Amount范围为0-1

2. **代码控制**：
   ```csharp
   [SerializeField] private Image progressBar;
   [SerializeField] private PlayableDirector director;
   
   void Update()
   {
       // 计算当前进度（0-1之间）
       float progress = (float)(director.time / director.duration);
       // 更新进度条填充量
       progressBar.fillAmount = progress;
   }
   ```

### 2.2 Slider类型进度条
1. **设置Slider组件**：
   - 设置最小值（通常为0）
   - 设置最大值（通常为1）
   - 配置Handle（可选）
   - 设置Fill Area

2. **代���控制**：
   ```csharp
   [SerializeField] private Slider progressSlider;
   [SerializeField] private PlayableDirector director;
   
   void Update()
   {
       progressSlider.value = (float)(director.time / director.duration);
   }
   
   // Slider的值改变事件
   public void OnSliderValueChanged(float value)
   {
       director.time = value * director.duration;
       // 如果Timeline没在播放，立即更新到当前时间点
       if (director.state != PlayState.Playing)
           director.Evaluate();
   }
   ```

## 3. 高级功能
### 3.1 带缓冲的进度条
```csharp
public class BufferedProgressBar : MonoBehaviour
{
    public PlayableDirector director;
    public Image progressBar;      // 主进度条
    public Image bufferBar;        // 缓冲进度条
    public float bufferSpeed = 1f; // 缓冲速度
    
    void Update()
    {
        float targetProgress = (float)(director.time / director.duration);
        
        // 更新主进度条
        progressBar.fillAmount = targetProgress;
        
        // 缓冲进度条平滑跟随
        bufferBar.fillAmount = Mathf.Lerp(
            bufferBar.fillAmount,
            targetProgress,
            Time.deltaTime * bufferSpeed
        );
    }
}
```

### 3.2 分段进度条
```csharp
public class SegmentedProgressBar : MonoBehaviour
{
    public PlayableDirector director;
    public Image[] segments;       // 进度条段数组
    public float[] segmentTimes;   // 每段对应的时间点
    
    void Update()
    {
        float currentTime = (float)director.time;
        
        // 更新每个段的显示
        for (int i = 0; i < segments.Length; i++)
        {
            if (currentTime >= segmentTimes[i])
                segments[i].fillAmount = 1f;
            else if (i > 0 && currentTime > segmentTimes[i-1])
            {
                float segmentProgress = (currentTime - segmentTimes[i-1]) / 
                                      (segmentTimes[i] - segmentTimes[i-1]);
                segments[i].fillAmount = segmentProgress;
            }
            else
                segments[i].fillAmount = 0f;
        }
    }
}
```

## 4. 实用技巧
1. **平滑过渡**：
   - 使用Mathf.Lerp实现平滑过渡
   - 添加缓动效果
   - 使用协程控制动画

2. **性能优化**：
   - 使用定时更新替代每帧更新
   - 添加更新阈值
   - 避免频繁的GC

3. **视觉增强**：
   - 添加进度文本显示
   - 使用粒子效果
   - 颜色渐变

## 5. 常见问题
1. **进度条更新不平滑**：
   - 检查更新频率
   - 使用插值平滑处理
   - 确认时间计算准确

2. **进���条与Timeline不同步**：
   - 验证duration计算正确
   - 检查时间缩放设置
   - 确认更新方法选择

3. **交互响应延迟**：
   - 优化事件系统
   - 减少不必要的计算
   - 使用适当的更新方式 