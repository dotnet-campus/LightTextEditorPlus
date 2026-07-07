# NuGet 包名添加 DotNetCampus 前缀

## 背景与目标

项目开始将核心包纳入 NuGet 打包输出，同时希望统一优化当前参与发布的包名。目标是在不改动程序集名、命名空间和项目引用的前提下，为参与发布的 NuGet 包统一添加 `DotNetCampus.` 品牌前缀。

## 关键文件

- `LightTextEditorPlus.Core/LightTextEditorPlus.Core.csproj`
- `LightTextEditorPlus.Wpf/LightTextEditorPlus.Wpf.csproj`
- `LightTextEditorPlus.Avalonia/LightTextEditorPlus.Avalonia.csproj`
- `LightTextEditorPlus.Skia/LightTextEditorPlus.Skia.csproj`
- `LightTextEditorPlus.MauiGraphics/LightTextEditorPlus.MauiGraphics.csproj`
- `LightTextEditorPlus.Highlighters/LightTextEditorPlus.Highlighters.Avalonia.csproj`
- `LightTextEditorPlus.Highlighters/LightTextEditorPlus.Highlighters.Wpf.csproj`
- `AllInOne.Avalonia/LightTextEditorPlus.AllInOne.Avalonia.csproj`
- `AllInOne.Wpf/LightTextEditorPlus.AllInOne.Wpf.csproj`

## 主要决策

- 仅修改 `PackageId`，不修改项目文件名、程序集名和根命名空间，避免影响代码引用与二进制兼容性。
- 统一采用 `DotNetCampus.LightTextEditorPlus.*` 命名结构，品牌前缀在最前，产品名居中，功能与平台后置。
- 核心包命名为 `DotNetCampus.LightTextEditorPlus.Core`，平台包与扩展包保持现有语义后缀。
- `AllInOne` 包继续保留 `AllInOne` 标识，降低已有用户认知迁移成本。

## 修改摘要

- 为核心包增加 `DotNetCampus.LightTextEditorPlus.Core`。
- 将平台包改为 `DotNetCampus.LightTextEditorPlus.Wpf`、`DotNetCampus.LightTextEditorPlus.Avalonia`、`DotNetCampus.LightTextEditorPlus.Skia`、`DotNetCampus.LightTextEditorPlus.MauiGraphics`。
- 将高亮包改为 `DotNetCampus.LightTextEditorPlus.Highlighters.Wpf` 和 `DotNetCampus.LightTextEditorPlus.Highlighters.Avalonia`。
- 将 AllInOne 包改为 `DotNetCampus.LightTextEditorPlus.AllInOne.Wpf` 和 `DotNetCampus.LightTextEditorPlus.AllInOne.Avalonia`。

## 验证记录

- 已执行 `dotnet test LightTextEditorPlus.slnx -c Release --no-restore`，测试通过：总计 1878，失败 0，成功 1860，跳过 18。

## 风险与后续建议

- NuGet 包改名会产生新的包 ID，不是旧包的原地升级。正式发布时建议在旧包上配置弃用信息，并在 README 或发布说明中提供旧包到新包的迁移表。
- 若后续启用 `LightTextEditorPlus.MauiGraphics` 发布，需要确认移除 `IsPackable=false` 的时机与 API 完成度。
