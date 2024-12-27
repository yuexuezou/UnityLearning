# Timeline轨道类型详解

Timeline提供了丰富的轨道类型，在Timeline窗口中点击"+"按钮可以添加以下类型的轨道：

```
可用轨道类型：
├── Track Group（轨道组）
├── Activation Track（激活轨道）
├── Animation Track（动画轨道）
├── Audio Track（音频轨道）
├── Control Track（控制轨道）
├── Signal Track（信号轨道）
├── Playable Track（可播放轨道）
├── Cinemachine Track（相机轨道）
├── Adjust Animation Track（动画调整轨道）
├── Custom Signal Track（自定义信号轨道）
├── Custom Transform Tween Track（自定义变换补间轨道）
├── Loop Control Track（循环控制轨道）
├── Time Dilation Track（时间膨胀轨道）
└── Transform Tween Track（变换补间轨道）
```

## 基础轨道
1. **Track Group**
   - 用途：组织和管理多个轨道
   - 特点：可以折叠/展开，便于管理复杂Timeline
   - [详细文档](Timeline_Tracks/Track_Group.md)

2. **Activation Track**
   - 用途：控制GameObject的启用/禁用
   - 特点：可以设置物体在特定时间段的显示状态
   - [详细文档](Timeline_Tracks/Activation_Track.md)

3. **Animation Track**
   - 用途：播放和控制动画片段
   - 特点：支持动画混合和过渡
   - [详细文档](Timeline_Tracks/Animation_Track.md)

4. **Audio Track**
   - 用途：播放音频文件
   - 特点：支持音量控制和淡入淡出
   - [详细文档](Timeline_Tracks/Audio_Track.md)

5. **Control Track**
   - 用途：控制预制体的实例化和销毁
   - 特点：可以在特定时间点创建或移除场景对象
   - [详细文档](Timeline_Tracks/Control_Track.md)

6. **Playable Track**
   - 用途：自定义可播放内容
   - 特点：通过Playable API提供完全的自定义控制能力
   - [详细文档](Timeline_Tracks/Playable_Track.md)

7. **Signal Track**
   - 用途：发送事件信号
   - 特点：可以在特定时间点触发自定义事件
   - [详细文档](Timeline_Tracks/Signal_Track.md)

8. **Transform Tween Track**
   - 用途：创建对象变换动画
   - 特点：提供简单直观的位置、旋转和缩放补间动画
   - [详细文档](Timeline_Tracks/Transform_Tween_Track.md)

9. **Custom Transform Tween Track**
   - 用途：高级变换补间动画
   - 特点：提供更灵活的补间动画控制能力
   - [详细文档](Timeline_Tracks/Custom_Transform_Tween_Track.md)

10. **Custom Signal Track**
    - 用途：自定义信号系统
    - 特点：支持复杂数据结构和自定义回调函数
    - [详细文档](Timeline_Tracks/Custom_Signal_Track.md)

11. **Adjust Animation Track**
    - 用途：调整和修改现有动画片段
    - 特点：可以实时调整动画参数
    - [详细文档](Timeline_Tracks/Adjust_Animation_Track.md)

## 扩展轨道
1. **Cinemachine Track**
   - 用途：控制虚拟相机
   - 特点：用于电影式镜头控制
   - [详细文档](Timeline_Tracks/Cinemachine_Track.md)

2. **Loop Control Track**
   - 用途：控制循环播放
   - 特点：可以设置特定片段的循环
   - [详细文档](Timeline_Tracks/Loop_Control_Track.md)

3. **Time Dilation Track**
   - 用途：控制时间流速
   - 特点：可以加速或减速动画
   - [详细文档](Timeline_Tracks/Time_Dilation_Track.md)

## 使用建议
1. **轨道组织**：
   - 使用Track Group整理相关轨道
   - 保持清晰的层级结构
   - 合理命名每个轨道

2. **性能考虑**：
   - 避免过多轨道同时激活
   - 及时清理不用的轨道
   - 合理使用循环和时间控制

3. **开发技巧**：
   - 善用信号系统触发事件
   - 合理使用动画混合
   - 注意轨道的优先级 