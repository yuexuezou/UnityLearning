# 第一章：Unity基础知识

## 1. Unity界面基础
### 1.1 Scene视图
#### 1.1.1 场景导航
- **鼠标操作**：
  - 右键拖动 = 自由旋转视角
  - 按住Alt+左键拖动 = 以选中物体为中心旋转
  - 滚轮 = 缩放视图
  - 按住滚轮拖动 = 平移视图

- **快捷键导航**：
  - F = 聚焦选中物体
  - Ctrl+Alt+F = 锁定视图到选中物体
    > [问题: 什么场景需要用这个功能？](Answers/Scene_Lock_View.md)
  - 数字键盘1-7 = 切换到固定视角（顶视图、侧视图等）
  - Shift+F = 进入飞行模式（WASD移动，QE升降）

#### 1.1.2 物体操作
- **变换工具**（左上角或快捷键）：
  - Q = 手型工具（平移视图）
  - W = 移动工具（移动物体）
  - E = 旋转工具（旋转物体）
  - R = 缩放工具（缩放物体）
  - T = 矩形工具（2D专用）
  - Y = 变换工具（组合移动、旋转、缩放）

- **精确变换**：
  - 按住Ctrl = 网格吸附
  - 按住V = 顶点吸附
  - 按住Shift = 等比例缩放/15度旋转
  - 在Inspector中输入具体数值

#### 1.1.3 场景组织
- **层级管理**：
  - Ctrl+Alt+F = 创建空物体
  - Ctrl+Shift+N = 创建子物体
  - Alt+拖动 = 复制物体
  - Ctrl+D = 快速复制选中物体

- **视图控制**：
  - Scene视图右上角：
    - Shaded = 默认渲染模式
    - Wireframe = 线框模式
    - Textured = 纹理模式
    - 2D = 2D/3D视图切换
    
- **Gizmos工具**：
  - 右上角Gizmos下拉菜单：
    - 3D图标显示控制
    - 网格显示设置
    - 场景辅助线设置

#### 1.1.4 实用技巧
1. **快速对齐**：
   ```csharp
   // 代码方式对齐物体
   transform.position = target.position; // 位置对齐
   transform.rotation = target.rotation; // 旋转对齐
   transform.SetParent(parent); // 设置父子关系
   ```

2. **场景视图快捷操作**：
   - 按住Ctrl拖动物体 = 复制
   - 按住V拖动物体边缘 = 顶点吸附
   - 双击物体 = 聚焦并框选
   - Shift+空格 = 最大化当前视图

3. **自定义布局**：
   - Window > Layouts > Save Layout = 保存当前布局
   - 可以为不同开发任务创建专门的布局

#### 1.1.5 常见问题解决
1. **物体无法选中**：
   - 检查Layer是否可见
   - 确认物体是否被锁定
   - 查看物体是否在当前视图范围

2. **视图操作不流畅**：
   - 调整Editor Quality设置
   - 关闭不必要的Gizmos
   - 减少场景中的实时光源

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