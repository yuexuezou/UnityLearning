# Cinemachine Track（相机轨道）使用指南

## 1. 基本介绍
Cinemachine Track用于在Timeline中控制虚拟相机的行为，可以实现复杂的相机运动和转场效果。它与Cinemachine系统紧密集成，提供了专业级的相机控制能力。

## 2. 创建和设置
1. **创建轨道**：
   - 在Timeline窗口点击"+"
   - 选择"Cinemachine Track"
   - 绑定CinemachineBrain组件

2. **添加片段**：
   - 拖拽虚拟相机到轨道
   - 右键选择"Add Cinemachine Shot"
   - 设置相机引用

3. **基础属性设置**：
   ```
   Cinemachine Shot属性：
   ├── Virtual Camera：虚拟相机引用
   ├── Blend Settings：混合设置
   └── Custom Blends：自定义混合
   ```

## 3. 高级功能
1. **相机混合**：
   ```csharp
   public class CameraBlendManager : MonoBehaviour
   {
       public PlayableDirector director;
       
       // 设置相机混合时间
       public void SetBlendDuration(float duration)
       {
           var timeline = director.playableAsset as TimelineAsset;
           var track = timeline.GetOutputTrack(0) as CinemachineTrack;
           
           foreach (var clip in track.GetClips())
           {
               var shotAsset = clip.asset as CinemachineShot;
               shotAsset.BlendInCurve = AnimationCurve.Linear(0, 0, duration, 1);
           }
       }
   }
   ```

2. **相机动画**：
   ```csharp
   public class CameraAnimationController : MonoBehaviour
   {
       public CinemachineVirtualCamera virtualCamera;
       
       // 创建相机动画
       public void CreateCameraAnimation()
       {
           var dolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
           var path = dolly.m_Path;
           
           // 设置路径点
           path.m_Waypoints = new CinemachinePath.Waypoint[]
           {
               new CinemachinePath.Waypoint { position = Vector3.zero, tangent = Vector3.forward },
               new CinemachinePath.Waypoint { position = Vector3.forward * 10, tangent = Vector3.forward }
           };
       }
   }
   ```

3. **事件控制**：
   ```csharp
   public class CameraEventHandler : MonoBehaviour
   {
       public void OnCameraActivated(ICinemachineCamera camera, ICinemachineCamera previousCamera)
       {
           // 处理相机激活事件
           Debug.Log($"Camera {camera.Name} activated");
       }
       
       public void OnCameraDeactivated(ICinemachineCamera camera)
       {
           // 处理相机关闭事件
           Debug.Log($"Camera {camera.Name} deactivated");
       }
   }
   ```

## 4. 常见用途
1. **场景演出**：
   - 过场动画
   - 剧情演出
   - 环境展示

2. **相机效果**：
   - 跟随镜头
   - 环绕拍摄
   - 聚焦特写

3. **转场效果**：
   - 淡入淡出
   - 推拉摇移
   - 景深变化

## 5. 使用技巧
1. **相机设置**：
   ```
   优化设置：
   ├── 跟随设置
   ├── 视角范围
   └── 噪点控制
   ```

2. **路径编辑**：
   - 路径平滑
   - 速度控制
   - 关键点设置

3. **混合控制**：
   - 自定义曲线
   - 时间控制
   - 过渡效果

## 6. 编程接口
```csharp
public class AdvancedCameraController : MonoBehaviour
{
    public PlayableDirector director;
    public CinemachineVirtualCamera[] cameras;
    
    // 切换相机
    public void SwitchToCamera(int index, float blendTime)
    {
        var timeline = director.playableAsset as TimelineAsset;
        var track = timeline.GetOutputTrack(0) as CinemachineTrack;
        
        var clip = track.CreateClip<CinemachineShot>();
        clip.start = director.time;
        clip.duration = blendTime;
        
        var shot = clip.asset as CinemachineShot;
        shot.VirtualCamera.exposedName = cameras[index].name;
    }
    
    // 设置相机属性
    public void SetCameraProperties(CinemachineVirtualCamera camera, 
                                  Vector3 position, 
                                  Vector3 rotation,
                                  float fieldOfView)
    {
        camera.transform.position = position;
        camera.transform.eulerAngles = rotation;
        camera.m_Lens.FieldOfView = fieldOfView;
    }
}
```

## 7. 注意事项
1. **性能考虑**：
   - 相机数量控制
   - 更新频率优化
   - 混合计算开销

2. **常见问题**：
   - 相机抖动
   - 转场卡顿
   - 深度冲突

3. **最佳实践**：
   - 合理分组
   - 预设管理
   - 参数调优

## 8. 快捷操作
- 右键轨道：添加相机片段
- F：聚焦选中相机
- Ctrl+拖拽：复制片段
- Alt+拖拽：调整时间
- E：编辑相机路径 