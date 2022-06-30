---
permalink: /namespaces/ao.measurements/
title: "Ao.Measurements"
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
var V = new Velocity { KilometersPerHour = 50 };
var A = new Acceleration { MetersPerSquareSecond = 1.5 };

var T = V / A;

Console.WriteLine("Accelerating from 0 to 50 km/h at 1.5 m/s² takes {0} s.", Round.HalfUp(T.Seconds));
```

```console
Accelerating from 0 to 50 km/h at 1.5 m/s² takes 9 s.
```