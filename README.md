# 文本库

[![Build](https://github.com/dotnet-campus/LightTextEditorPlus/actions/workflows/LightTextEditorPlusBuild.yml/badge.svg)](https://github.com/dotnet-campus/LightTextEditorPlus/actions/workflows/LightTextEditorPlusBuild.yml)
[![NuGet WPF](https://img.shields.io/nuget/v/DotNetCampus.LightTextEditorPlus.AllInOne.Wpf.svg?label=WPF)](https://www.nuget.org/packages/DotNetCampus.LightTextEditorPlus.AllInOne.Wpf)
[![NuGet Avalonia](https://img.shields.io/nuget/v/DotNetCampus.LightTextEditorPlus.AllInOne.Avalonia.svg?label=Avalonia)](https://www.nuget.org/packages/DotNetCampus.LightTextEditorPlus.AllInOne.Avalonia)
[![NuGet Skia](https://img.shields.io/nuget/v/DotNetCampus.LightTextEditorPlus.Skia.svg?label=Skia)](https://www.nuget.org/packages/DotNetCampus.LightTextEditorPlus.Skia)
[![NuGet Core](https://img.shields.io/nuget/v/DotNetCampus.LightTextEditorPlus.Core.svg?label=Core)](https://www.nuget.org/packages/DotNetCampus.LightTextEditorPlus.Core)

高控制的富文本布局库。当前可当成简单的 `TextBlock` 或 `TextBox` 使用，并附带基础富文本能力。

## 安装

业务项目推荐直接引用 AllInOne 包，一个包即可接入对应 UI 框架。

### WPF

```xml
<PackageReference Include="DotNetCampus.LightTextEditorPlus.AllInOne.Wpf" Version="*" />
```

或：

```bash
dotnet add package DotNetCampus.LightTextEditorPlus.AllInOne.Wpf
```

### Avalonia

```xml
<PackageReference Include="DotNetCampus.LightTextEditorPlus.AllInOne.Avalonia" Version="*" />
```

或：

```bash
dotnet add package DotNetCampus.LightTextEditorPlus.AllInOne.Avalonia
```

### 包一览

AllInOne 把对应平台所需源码打进同一个程序集，业务项目只引一个包。分层包则拆成 Core / 平台层，适合需要自己拼依赖、或只要渲染不要编辑的场景。

| 包名 | 用途 |
|---|---|
| [DotNetCampus.LightTextEditorPlus.AllInOne.Wpf](https://www.nuget.org/packages/DotNetCampus.LightTextEditorPlus.AllInOne.Wpf) | WPF 业务接入推荐包，含 Core 与 WPF |
| [DotNetCampus.LightTextEditorPlus.AllInOne.Avalonia](https://www.nuget.org/packages/DotNetCampus.LightTextEditorPlus.AllInOne.Avalonia) | Avalonia 业务接入推荐包，含 Core、Skia 与 Avalonia |
| [DotNetCampus.LightTextEditorPlus.Wpf](https://www.nuget.org/packages/DotNetCampus.LightTextEditorPlus.Wpf) | WPF 平台层，依赖 Core |
| [DotNetCampus.LightTextEditorPlus.Avalonia](https://www.nuget.org/packages/DotNetCampus.LightTextEditorPlus.Avalonia) | Avalonia 平台层，依赖 Skia |
| [DotNetCampus.LightTextEditorPlus.Skia](https://www.nuget.org/packages/DotNetCampus.LightTextEditorPlus.Skia) | Skia 渲染层，仅渲染，不提供编辑 |
| [DotNetCampus.LightTextEditorPlus.Core](https://www.nuget.org/packages/DotNetCampus.LightTextEditorPlus.Core) | 平台无关核心排版库 |

请将 `Version="*"` 替换为 NuGet 上的实际版本。

## 快速开始

WPF：

```xml
xmlns:textEditorPlus="clr-namespace:LightTextEditorPlus;assembly=LightTextEditorPlus.Wpf"

<textEditorPlus:TextEditor x:Name="TextEditor" />
```

Avalonia：

```xml
xmlns:textEditorPlus="clr-namespace:LightTextEditorPlus;assembly=LightTextEditorPlus.Avalonia"

<textEditorPlus:TextEditor x:Name="TextEditor" />
```

设置和追加文本：

```csharp
TextEditor textEditor = ...
textEditor.Text = "Text";
textEditor.AppendText("123");
```

设置字号、加粗：

```csharp
TextEditor textEditor = ...
textEditor.AppendText("abc");
textEditor.SetFontSize(25);
textEditor.ToggleBold(textEditor.GetAllDocumentSelection());
```

设置水平居中：

```csharp
TextEditor textEditor = ...
textEditor.Text = "Text";
textEditor.ConfigCurrentCaretOffsetParagraphProperty(property => property with
{
    HorizontalTextAlignment = HorizontalTextAlignment.Center
});
```

更多 API 示例见 [使用说明文档](./Docs/使用说明文档.md)。NuGet 包内也包含该文档，路径为 `docs/使用说明文档.md`，便于本地或 AI 工具阅读。

## 功能

- 平文本
- 加粗、斜体
- 上下标
- 下划线、删除线、波浪线、着重号、装饰层
- 拼音、上加、下加
- 字体、字号、颜色
- 左对齐、右对齐、分散对齐、两端对齐
- 分词换行
- 项目符号
- 左右缩进
- 段前段后间距（段前段后距离）
- 倍数行距、固定倍数行距
- 遵循中文符号换行规则
- 命中测试，属性和光标系统
- 文本公式混排，图文混排
- 四线格法行内排版
- 蒙文、藏文、合写字（需要平台层给力才行）

## 文档导航

- [使用说明文档](./Docs/使用说明文档.md)
- [框架设计](./Docs/框架设计.md)
- [维护文档](./Docs/维护文档.md)
- [行为定义](./Docs/行为定义.md)
- [实现定义](./Docs/实现定义.md)
- [指导布局](./Docs/指导布局.md)
- [术语表](./Docs/术语表.md)
- [参考文档](./Docs/参考文档.md)
- [知识库目录说明](./Docs/Knowledge/README.md)
