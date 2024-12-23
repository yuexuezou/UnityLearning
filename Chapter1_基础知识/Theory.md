# 第一章：Unity基础知识

## 1. Unity界面基础
### 1.1 主要视图介绍
- **Scene视图**：场景编辑视图
  - 场景导航
  - 物体操作
  - 快捷键使用
  
- **Game视图**：游戏预览视图
  - 分辨率设置
  - 屏幕比例
  - 设备模拟
  
- **Inspector视图**：组件检查器
  - 组件添加/删除
  - 属性修改
  - 自定义编辑器

### 1.2 项目结构
- Assets目录结构规范
- 资源命名规范
- Meta文件说明

## 2. 核心组件系统
### 2.1 Transform组件
```csharp
// Transform基础操作
transform.position = new Vector3(0, 0, 0);
transform.rotation = Quaternion.identity;
transform.localScale = Vector3.one;

// 相对运动
transform.Translate(Vector3.forward * Time.deltaTime);
transform.Rotate(Vector3.up * 45f);
```

### 2.2 GameObject系统
- 创建与销毁
- 激活状态
- 标签与层级
- 查找机制

### 2.3 组件生命周期
1. Awake()
2. OnEnable()
3. Start()
4. Update()
5. FixedUpdate()
6. LateUpdate()
7. OnDisable()
8. OnDestroy()

## 3. 预制体系统
### 3.1 预制体基础
- 创建预制体
- 预制体变体
- 嵌套预制体
- 预制体更新

### 3.2 预制体最佳实践
- 模块化设计
- 预制体引用管理
- 性能考虑

## 本章练习
1. 创建一个场景，包含基础几何体
2. 实现物体的基本运动控制
3. 创建并使用预制体系统

## 补充资源
- [Unity Manual - Interface](https://docs.unity3d.com/Manual/UsingTheEditor.html)
- [Unity Manual - GameObjects](https://docs.unity3d.com/Manual/GameObjects.html)
- [Unity Manual - Prefab System](https://docs.unity3d.com/Manual/Prefabs.html) 