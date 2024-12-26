# 如何调整Editor Quality设置？

Unity编辑器中的Quality设置主要在Project Settings中调整：

## 1. 主要的性能设置
- 路径：`Edit > Project Settings > Quality`
- 在Quality Settings窗口中：
  - 预设等级管理（从低到高）：
    - Very Low（最低质量）
    - Low（低质量）
    - Medium（中等质量）
    - High（高质量）
    - Ultra（超高质量）
  
  - 预设管理操作：
    1. 添加新预设：点击底部的"Add Quality Level"按钮
    2. 删除预设：点击预设右侧的垃圾桶图标
    3. 设置默认：使用Default下拉菜单选择
    4. 启用/禁用：使用预设左侧的复选框

  - 主要渲染参数设置：
    - Rendering：渲染管线设置（如URP、HDRP等）
    - Texture Quality：纹理质量（Full Res, Half Res等）
    - Anisotropic Textures：各向异性过滤（Per Texture, Forced On等）
    - Realtime Reflection Probes：实时反射探针
    - Billboards Face Camera Position：公告板面向相机
    - Resolution Scaling Fixed DPI Factor：分辨率缩放因子
    - Texture Streaming：纹理流送
    - Shadows：阴影设置
    - Other：其他渲染相关设置

  - 注意事项：
    - 当使用可编程渲染管线（如URP）时，某些设置可能不可用
    - 设置更改会实时生效，可以在Game视图中查看效果
    - 不同平台可能支持的选项不同

## 2. 编辑器性能设置
- 路径：`Edit > Preferences > General`（Windows）或 `Unity > Preferences > General`（Mac）
- 可调整选项：
  - Refresh Rate（刷新率）
  - Animation Preview Speed（动画预览速度）
  - Enable Preview Packages（预览包启用）
  - Asset Pipeline V2（资产管线版本）

## 3. Scene视图特定设置
- 位置：Scene视图右上角的下拉菜单
- 可调整项目：
  - 渲染模式（Shaded, Wireframe等）
  - 特效和后处理效果开关
  - 场景可见性设置
  - Gizmos显示选项

## 4. 性能监控和优化
- Stats窗口（Window > Analysis > Stats）显示：
  - 帧率（FPS）
  - 绘制调用次数（Draw Calls）
  - 三角形数量和顶点数量
  - 内存使用情况

## 性能优化建议
1. 降低Scene视图的实时阴影质量
2. 关闭不必要的实时光照
3. 减少Scene视图中的特效显示
4. 适当降低纹理预览质量
5. 在大型场景中使用遮挡剔除（Occlusion Culling）
6. 关闭不需要的Gizmos显示
7. 调整编辑器的最大FPS限制

这些设置的调整可以显著提升Unity编辑器的响应速度和场景视图的操作流畅度。根据你的电脑配置和项目需求，可以在性能和视觉质量之间找到平衡点。 