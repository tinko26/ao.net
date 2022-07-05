---
permalink: /namespaces/ao.geometry/
title: "Ao.Geometry"
---

# Ao.Geometry

The `Ao.Geometry` namespace contains classes for geometric calculations in 2D and 3D.

## Linear Equations

[Linear equations](https://en.wikipedia.org/wiki/Linear_equation) play an important role in Euclidean geometry and computer graphics. They represent straight lines in 2D and planes in 3D. Several forms of linear equations exist.

The `General` structs represent the general form.

$$ 0 = a \cdot x + b \cdot y + c $$

$$ 0 = a \cdot x + b \cdot y + c \cdot z + d $$

```csharp
var G = new General2
{
    A = 1,
    B = 1,
    C = -2
};

Console.WriteLine(G.InterceptX);
Console.WriteLine(G.InterceptY);
```

```console
2
2
```

The `Hesse` structs represent the [Hesse normal form](https://en.wikipedia.org/wiki/Hesse_normal_form).

$$ d = \vec{p}\cdot\vec{n} $$

```csharp
var H = new Hesse2
{
    D = 4,
    Normal = new Vector2(2, 2)
};

Console.WriteLine(H.InterceptX);
Console.WriteLine(H.InterceptY);
```

```console
2
2
```

The `Line2` and `Plane3` structs represent the respective [parametric form](https://en.wikipedia.org/wiki/Parametric_equation).

$$ \vec{x}(t) = \vec{b} + t \cdot \vec{d} $$

$$ \vec{x}(u, v) = \vec{b} + u \cdot \vec{d_1} + v \cdot \vec{d_2} $$

```csharp
var L = new Line2
{
    Base = new Point2(-2, 4),
    Direction = new Vector2(3, -3)
};

Console.WriteLine(L.InterceptX);
Console.WriteLine(L.InterceptY);
```

```console
2
2
```

The forms can be derived from each other as well as from other forms, such as the slope-intercept form in 2D or the intercept form.

```csharp
var G = General2.FromIntercepts(2, 2);

Console.WriteLine(G.A);
Console.WriteLine(G.B);
Console.WriteLine(G.C);
```

```console
2
2
-4
```

Additionally, the calculation of intersections and distances is supported.

```csharp
var d = G.Distance(Point2.Origin);

Console.WriteLine(d);
```

```console
1.41421356237309
```

## Affine Transformations

The `Affinity` classes represent [affine transformations](https://en.wikipedia.org/wiki/Affine_transformation). An affine transformation consists of a transformation matrix and a translation vector. Several constants and static methods provide common transformations, that are often used in computer graphics.

The following example demonstrates how to rotate a point about 180° around the z-axis.

```csharp
var T = Affinity3.RotateZ(Math.PI);

var P = new Point3(1, 2, 3);

var Q = T * P;

Console.WriteLine("P = ({0,2}, {1,2}, {2,2})", P.X, P.Y, P.Z);
Console.WriteLine("Q = ({0,2}, {1,2}, {2,2})", Q.X, Q.Y, Q.Z);
```

```console
P = ( 1,  2,  3)
Q = (-1, -2,  3)
```

Also, affine transformations can be combined ...

```csharp
var T1 = Affinity3.RollPitchYaw(Math.PI, Math.PI / 2, 0);
var T2 = Affinity3.Translate(2, -5, 8);

var T = T2 * T1;
```

... and inverted.

```csharp
var TI = T.Inverted;
```
