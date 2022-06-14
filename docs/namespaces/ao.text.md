---
permalink: /namespaces/ao.text/
title: "Ao.Text"
---

# Ao.Text

The `Ao.Text` namespace contains a single class providing a fine selection of emojis.

```csharp
var lines = new string[]
{
    Emoji.Rainbow,
    Emoji.RedHeart
};

System.IO.File.WriteAllLines("emojis.md", lines);
```

```markdown
🌈
❤️
```
