---
permalink: /namespaces/ao.geometry/
title: "Ao.Geometry"
---

# Ao.Geometry

The `Ao.Geometry` namespace contains classes for geometric calculations in 2D and 3D.

## Affine Transformation

The `Affinity` classes represent [affine transformations](https://en.wikipedia.org/wiki/Affine_transformation). An affine transformation consists of a transformation matrix and a translation vector. Several constants and static methods provide common transformations, that are often used in computer graphics.

The following example demonstrates how to rotate a point about 180° around the z-axis.

```csharp
var T = Affinity3.RotateZ(Math.PI);

var P = new Point3(1, 2, 3);

var Q = T * P;

Console.WriteLine("Q = ({0}, {1}, {2})", Q.X, Q.Y, Q.Z);
```

```console
Q = (-1, -2, 3)
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

## Basis

## Box

## Circle

## Curve

## Dimension

## General Form of Linear Equations

## Hesse Normal Form

## Line

## Plane

## Sphere

## Surface
