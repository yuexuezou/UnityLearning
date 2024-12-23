# 第二章：Unity进阶开发

## 1. 图形渲染系统
### 1.1 渲染管线概述
- Built-in渲染管线
- Universal渲染管线(URP)
- 高清渲染管线(HDRP)
- 渲染管线的选择原则

### 1.2 Shader编程基础
```ShaderLab
Shader "Custom/BasicShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            // 基础顶点着色器
            // 片段着色器
            ENDCG
        }
    }
}
```

### 1.3 材质系统
- 材质属性
- Shader Graph使用
- 材质实例化

## 2. 动画系统
### 2.1 Animation组件
- 动画片段(Animation Clip)
- 动画状态机
- 动画事件
- 动画混合

### 2.2 Animator控制器
```csharp
// 动画控制器示例
public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        // 设置动画参数
        animator.SetBool("IsRunning", Input.GetKey(KeyCode.W));
        animator.SetFloat("Speed", Input.GetAxis("Vertical"));
    }
}
```

### 2.3 Timeline系统
- 时间轴编辑
- 动画轨道
- 音频轨道
- 信号系统

## 3. UI系统
### 3.1 UGUI基础
- Canvas系统
- 事件系统
- 布局系统
- 富文本

### 3.2 UI优化
```csharp
// UI优化示例
public class UIOptimization : MonoBehaviour
{
    // 对象池管理
    private ObjectPool<GameObject> uiPool;
    
    // UI元素批处理
    [SerializeField] private CanvasRenderer[] renderers;
    
    void Start()
    {
        // 初始化对象池
        uiPool = new ObjectPool<GameObject>(CreateUIElement, OnTakeFromPool, OnReturnToPool);
    }
    
    // UI元素合批
    void OptimizeBatching()
    {
        Canvas.ForceUpdateCanvases();
    }
}
```

### 3.3 UI架构设计
- MVC模式
- MVVM模式
- UI管理器
- UI导航系统

## 本章练习
1. 创建自定义Shader
2. 实现角色动画系统
3. 设计UI框架

## 实践项目
创建一个包含以下功能的小游戏：
1. 自定义材质效果
2. 角色动画系统
3. 完整的UI界面 