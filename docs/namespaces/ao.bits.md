---
permalink: /namespaces/ao.bits/
author: "Stefan Wagner"
title: "Ao.Bits"
description: "Manipulation of bits in integers in C#."
---

# Ao.Bits

The `Ao.Bits` namespace contains a single static class with extension methods that get or set, respectively, bits of integer values.

## Get bits

```csharp
var a = 0x12345678U;

var a3 = a.GetBits(24, 8);
var a2 = a.GetBits(16, 8);
var a1 = a.GetBits( 8, 8);
var a0 = a.GetBits( 0, 8);

Console.WriteLine("{0:X2}", a3);
Console.WriteLine("{0:X2}", a2);
Console.WriteLine("{0:X2}", a1);
Console.WriteLine("{0:X2}", a0);
```

```console
12
34
56
78
```

## Set bits

```csharp
var a = 0U;

a.SetBits(24, 8, 0x87U);
a.SetBits(16, 8, 0x65U);
a.SetBits( 8, 8, 0x43U);
a.SetBits( 0, 8, 0x21U);

Console.WriteLine("{0:X8}", a);
```

```console
87654321
```
