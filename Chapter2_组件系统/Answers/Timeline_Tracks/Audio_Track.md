# Audio Track（音频轨道）使用指南

## 1. 基本介绍
Audio Track用于在Timeline中控制音频的播放，支持音乐、音效和语音等多种音频类型，可以精确控制播放时间和音量。

## 2. 创建和设置
1. **创建轨道**：
   - 在Timeline窗口点击"+"
   - 选择"Audio Track"
   - 将AudioSource组件拖拽到轨道绑定栏

2. **添加音频片段**：
   - 直接拖拽音频文件到轨道
   - 右键选择"Add Audio Clip"
   - 从Project窗口拖入音频资源

3. **基础属性设置**：
   ```
   Audio Track属性：
   ├── Volume：音量控制
   ├── Stereo Pan：立体声平衡
   └── Spatial Blend：空间混合
   ```

## 3. 高级功能
1. **音频混合**：
   ```csharp
   public class AudioMixerController : MonoBehaviour
   {
       public PlayableDirector director;
       
       // 设置音频音量
       public void SetAudioVolume(AudioClip clip, float volume)
       {
           var timeline = director.playableAsset as TimelineAsset;
           var track = timeline.GetOutputTrack(0) as AudioTrack;
           
           foreach (var timelineClip in track.GetClips())
           {
               var audioClip = timelineClip.asset as AudioPlayableAsset;
               if (audioClip.clip == clip)
               {
                   timelineClip.mixInCurve = AnimationCurve.Linear(0, 0, 1, volume);
               }
           }
       }
   }
   ```

2. **音频过渡**：
   - 淡入淡出控制
   - 音量渐变
   - 交叉混合

3. **空间音频**：
   - 3D音效设置
   - 距离衰减
   - 多普勒效应

## 4. 常见用途
1. **背景音乐**：
   - 场景配乐
   - 氛围音乐
   - 主题曲播放

2. **音效系统**：
   - 环境音效
   - 交互音效
   - 特效音频

3. **对话系统**：
   - 角色语音
   - 旁白配音
   - 多语言切换

## 5. 使用技巧
1. **音频同步**：
   ```
   同步设置：
   ├── 音频偏移
   ├── 起始时间
   └── 播放速度
   ```

2. **分层管理**：
   - 按类型分轨道
   - 设置优先级
   - 控制混音比例

3. **优化建议**：
   - 合理压缩音频
   - 使用音频池
   - 控制同时播放数量

## 6. 编程控制
```csharp
public class AudioTrackController : MonoBehaviour
{
    public PlayableDirector director;
    
    // 动态添加音频片段
    public void AddAudioClip(AudioClip clip, double startTime)
    {
        var timeline = director.playableAsset as TimelineAsset;
        var track = timeline.GetOutputTrack(0) as AudioTrack;
        
        var newClip = track.CreateClip(clip);
        newClip.start = startTime;
        newClip.duration = clip.length;
    }
    
    // 设置音频音量
    public void SetTrackVolume(float volume)
    {
        var timeline = director.playableAsset as TimelineAsset;
        var track = timeline.GetOutputTrack(0) as AudioTrack;
        
        var audioMixerGroup = track.GetComponent<AudioMixerGroup>();
        if (audioMixerGroup != null)
        {
            audioMixerGroup.audioMixer.SetFloat("Volume", volume);
        }
    }
}
```

## 7. 注意事项
1. **性能考虑**：
   - 控制音频质量
   - 管理内存占用
   - 注意音频加载时机

2. **常见问题**：
   - 音频延迟
   - 播放中断
   - 音量不均衡

3. **调试技巧**：
   - 使用音频分析器
   - 监控音频状态
   - 检查混音设置

## 8. 快捷操作
- 右键轨道：添加音频片段
- M：静音轨道
- Alt+拖拽：复制音频片段
- Ctrl+拖拽边缘：调整持续时间
- 双击片段：编辑音频属性 