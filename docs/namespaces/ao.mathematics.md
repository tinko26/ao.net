---
permalink: /namespaces/ao.mathematics/
title: "Ao.Mathematics"
---

# Ao.Mathematics

The `Ao.Mathematics` contains various types and methods for mathematical calculations.

## Complex numbers

The `Complex` struct represents a complex number, even though the [FCL](https://en.wikipedia.org/wiki/Framework_Class_Library) already contains a type for that.

```csharp
var a = new Complex(2, -3);
var b = new Complex(-4, 1);

var c = a * b;

Console.WriteLine("{0}, {1}", c.Real, c.Imaginary);
Console.WriteLine("{0}", c.Modulus);
Console.WriteLine("{0}°", c.Argument * 180.0 / Math.PI);
```

```console
-5, 14
14.8660687473185
109.653824058053°
```

## Cylindrical coordinates

The `Cylindrical` struct represents cylindrical coordinates, that are an extension of polar coordinates in 3D. They consist of an azimuth, a radius, and z-coordinate. The latter reflects the height of a cylinder.

## Matrices

The `Ao.Mathematics` namespace contains a total of 25 structs representing row-major matrices of dimension $2\times 2$ through $6\times 6$, equipped with all the necessary operators. 

Additionally, all the square matrices have properties that are useful in geometric calculations. However, the implementation does not focus on speed. Calculating the inverse of a $6\times 6$ really takes some time.

```csharp
var A = new Matrix2x2(1, -2, -3, 1);
var B = new Matrix2x2(2, -1, -1, -3);

var C = A * B.Transposed;

Console.WriteLine("C = ({0} {1} {2} {3})", C.M11, C.M12, C.M21, C.M22);
Console.WriteLine();
Console.WriteLine("det(C) = {0}", C.Determinant);
Console.WriteLine("tr(C)  = {0}", C.Trace);
```

```console
C = (4 5 -7 0)

det(C) = 35
tr(C)  = 4
```

## Points

There a three structs representing 2D, 3D, and 4D points, which is useful for geometric operations. 

```csharp
var A = new Point2(1, 1);
var b = new Vector2(-3, 5);

var C = A + b;

Console.WriteLine("C = ({0}, {1})", C.M1, C.M2);
```

```console
C = (-2, 6)
```

## Polar coordinates

## Quadratic equations

## Quaternions

## Random number generators

## Ranges

## Rounding

## Spherical coordinates

## Vectors