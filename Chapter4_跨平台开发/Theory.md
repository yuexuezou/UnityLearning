# 第四章：跨平台开发

## 1. 平台特性
### 1.1 移动平台开发
- iOS开发特性
  - 内存限制
  - 热更新限制
  - AppStore规范

- Android开发特性
  - 设备碎片化
  - 性能优化
  - 权限管理

### 1.2 平台适配代码
```csharp
public class PlatformManager : MonoBehaviour
{
    // 平台判断
    void Start()
    {
        #if UNITY_ANDROID
            SetupAndroid();
        #elif UNITY_IOS
            SetupIOS();
        #endif
    }
    
    // 平台特定功能
    private void SetupAndroid()
    {
        // Android特定初始化
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = 60;
    }
    
    private void SetupIOS()
    {
        // iOS特定初始化
        Application.targetFrameRate = 30;
    }
}
```

### 1.3 输入系统适配
- 触摸输入
- 键鼠输入
- 手柄输入
- 新输入系统

## 2. 性能优化
### 2.1 移动平台优化
```csharp
public class MobileOptimization : MonoBehaviour
{
    // 质量设置
    void SetQualityForPlatform()
    {
        #if UNITY_ANDROID || UNITY_IOS
            // 降低质量设置
            QualitySettings.SetQualityLevel(1); // 中等质量
            QualitySettings.shadows = ShadowQuality.HardOnly;
            QualitySettings.shadowDistance = 20f;
        #else
            // PC平台使用高质量
            QualitySettings.SetQualityLevel(5);
        #endif
    }
    
    // 资源管理
    void ManageResources()
    {
        // 根据平台设置纹理压缩
        #if UNITY_ANDROID
            // 使用ETC2压缩
        #elif UNITY_IOS
            // 使用ASTC压缩
        #endif
    }
}
```

### 2.2 平台特定优化
- 纹理压缩
- 着色器变体
- 内存管理
- 电池优化

## 3. 发布流程
### 3.1 构建设置
- 平台切换
- 构建选项
- 签名设置
- 版本控制

### 3.2 自动化构建
```csharp
public class BuildAutomation
{
    static void PerformBuild()
    {
        // 构建设置
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/Main.unity" };
        buildPlayerOptions.locationPathName = "Builds/GameBuild";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.Development;

        // 执行构建
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}
```

### 3.3 CI/CD流程
- Jenkins集成
- 自动化测试
- 发布流程
- 版本管理

## 4. 应用商店发布
### 4.1 商店规范
- AppStore审核规范
- Google Play规范
- 隐私政策
- 评分系统

### 4.2 发布准备
- 应用图标
- 截图准备
- 描述文案
- 关键词优化

## 本章练习
1. 实现跨平台输入系统
2. 配置多平台构建
3. 优化移动平台性能

## 实践项目
创建一个跨平台游戏项目：
1. 支持PC/移动平台
2. 实现平台特定优化
3. 自动化构建流程
4. 应用商店发布准备 