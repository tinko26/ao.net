---
permalink: /namespaces/ao.measurements/
author: "Stefan Wagner"
title: "Ao.Measurements"
description: "Physical quantities in C#."
---

# Ao.Measurements

The `Ao.Measurements` namespace contains various structs that represent physical quantities. I have used them, among others, in applications that logged diagnostic and status data of vehicle components.

Most structs support quantification in and conversion to several common units.

```csharp
var E = new Energy 
{ 
    KilowattHours = 5
};

Console.WriteLine("E = {0} MJ", E.Megajoules);
```

```console
E = 18 MJ
```

Additionally, some of the structs define multiplication and division operators to transform them into each other.

```csharp
var v = new Velocity { KilometersPerHour = 50 };
var a = new Acceleration { MetersPerSquareSecond = 1.5 };

var t = v / a;

Console.WriteLine("{0} s", Round.HalfUp(t.Seconds));
```

```console
9 s
```