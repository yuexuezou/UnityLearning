# Track Group（轨道组）使用指南

## 1. 基本介绍
Track Group用于组织和管理多个相关的轨道，类似文件夹的概念，可以让Timeline更有条理。

## 2. 创建方法
1. 在Timeline窗口中点击"+"按钮
2. 选择"Track Group"
3. 输入组名（建议使用描述性名称）

## 3. 使用技巧
1. **组织结构**：
   - 按功能分组（如：动画组、音效组）
   - 按对象分组（如：角色组、场景组）
   - 按时序分组（如：开场组、结束组）

2. **管理操作**：
   - 折叠/展开：点击左侧箭头
   - 重命名：双击组名
   - 删除：右键选择Delete
   - 移动：拖拽到目标位置

3. **轨道添加**：
   - 将新轨道直接拖入组中
   - 在组内右键添加新轨道
   - 将现有轨道拖入组中

## 4. 最佳实践
1. **命名规范**：
   ```
   角色动画组：CharacterAnimations
   场景控制组：SceneControls
   UI动画组：UIAnimations
   音效组：SoundEffects
   ```

2. **组织建议**：
   - 保持层级结构清晰
   - 相关轨道放在同一组
   - 避免过深的嵌套
   - 使用有意义的组名

3. **常见用法**：
   ```
   MainTimeline
   ├── CharacterGroup
   │   ├── Animation Track
   │   ├── Audio Track
   │   └── Control Track
   ├── EnvironmentGroup
   │   ├── Activation Track
   │   └── Animation Track
   └── UIGroup
       ├── Animation Track
       └── Signal Track
   ```

## 5. 注意事项
1. **性能考虑**：
   - 组的折叠状态不影响性能
   - 组织结构仅影响编辑体验
   - 不要创建空组占用空间

2. **维护建议**：
   - 定期整理轨道组织
   - 删除不用的空组
   - 保持命名的一致性
   - 适当添加注释说明

## 6. 快捷操作
- Ctrl + G：创建新组
- Alt + 点击折叠：折叠/展开所有组
- 右键菜单：
  - Duplicate：复制组
  - Delete：删除组
  - Rename：重命名
  - Lock：锁定组
  - Mute：静音组 