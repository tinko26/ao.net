---
permalink: /namespaces/ao.mathematics/
title: "Ao.Mathematics"
---

# Ao.Mathematics

The `Ao.Mathematics` contains useful types for mathematical calculations.

## Rounding

The `Round` class contains methods for various [rounding](https://en.wikipedia.org/wiki/Rounding) modes. This includes directed rounding to an integer ...

```csharp
var x = 2.75;

Console.Write("{0}, ", Round.Down(x));
Console.Write("{0}, ", Round.Up(x));
Console.WriteLine();

Console.Write("{0}, ", Round.AwayFromInfinity(x));
Console.Write("{0}, ", Round.AwayFromNegativeInfinity(x));
Console.Write("{0}, ", Round.AwayFromPositiveInfinity(x));
Console.Write("{0}, ", Round.AwayFromZero(x));
Console.WriteLine();

Console.Write("{0}, ", Round.ToInfinity(x));
Console.Write("{0}, ", Round.ToNegativeInfinity(x));
Console.Write("{0}, ", Round.ToPositiveInfinity(x));
Console.Write("{0}  ", Round.ToZero(x));
Console.WriteLine();
```

```console
2, 3, 
2, 3, 2, 3, 
3, 2, 3, 2
```

... as well as rounding to the nearest integer.

```csharp
var x = 2.5;

Console.Write("{0}, ", Round.HalfDown(x));
Console.Write("{0}, ", Round.HalfUp(x));
Console.WriteLine();

Console.Write("{0}, ", Round.HalfAwayFromInfinity(x));
Console.Write("{0}, ", Round.HalfAwayFromNegativeInfinity(x));
Console.Write("{0}, ", Round.HalfAwayFromPositiveInfinity(x));
Console.Write("{0}, ", Round.HalfAwayFromZero(x));
Console.WriteLine();

Console.Write("{0}, ", Round.HalfToInfinity(x));
Console.Write("{0}, ", Round.HalfToNegativeInfinity(x));
Console.Write("{0}, ", Round.HalfToPositiveInfinity(x));
Console.Write("{0}, ", Round.HalfToZero(x));
Console.WriteLine();

Console.Write("{0}, ", Round.HalfToEven(x));
Console.Write("{0}  ", Round.HalfToOdd(x));
Console.WriteLine();
```

```console
2, 3, 
2, 3, 2, 3, 
3, 2, 3, 2, 
2, 3
```

## Numbers

The `Complex` and `Quaternion` structs represent [complex numbers](https://en.wikipedia.org/wiki/Complex_number) and [quaternions](https://en.wikipedia.org/wiki/Quaternion), respectively, that are useful for geometric calculations and others.

### Complex Numbers

```csharp
var x = Complex.Rotation(Math.PI / 3);

Console.Write("{0:0.##} + ", x.Real);
Console.Write("{0:0.##} i ", x.Imaginary);
Console.WriteLine();

Console.WriteLine("{0}°", x.Argument * 180 / Math.PI);
```

```console
0.5 + 0.87 i
60°
```

### Quaternions

```csharp
var x = Quaternion.Rotation(Math.PI / 3, new Vector3(1, 2, 1));

Console.Write("{0:0.##} + ", x.Real);
Console.Write("{0:0.##} i + ", x.Imaginary1);
Console.Write("{0:0.##} j + ", x.Imaginary2);
Console.Write("{0:0.##} k   ", x.Imaginary3);
Console.WriteLine();

Console.WriteLine("{0}°", x.RotationAngle * 180 / Math.PI);
```

```console
0.87 + 0.2 i + 0.41 j + 0.2 k
60°
```

## Coordinates

The `Point` and `Vector` structs represent points and vectors, respectively, in [Cartesian coordinates](https://en.wikipedia.org/wiki/Cartesian_coordinate_system).

```csharp
var P = new Point2(1, 2);
var v = new Vector2(2, -4);

var Q = P + v;

Console.WriteLine("({0}, {1})", Q.X, Q.Y);
```

```console
(3, -2)
```

The `Polar` struct represents a 2D point in [polar coordinates](https://en.wikipedia.org/wiki/Polar_coordinate_system).

```csharp
var P = new Polar
{
    Azimuth = Math.PI / 3,
    Radius = 1
};

var v = P.ToVector();

Console.Write("({0:0.##},", v.X);
Console.Write(" {0:0.##})", v.Y);
Console.WriteLine();
```

```console
(0.5, 0.87)
```

The `Cylindrical` and `Spherical` structs represent [cylindrical](https://en.wikipedia.org/wiki/Cylindrical_coordinate_system) and [spherical coordinates](https://en.wikipedia.org/wiki/Spherical_coordinate_system), respectively, which are 3D extensions of polar coordinates.

```csharp
var C = new Cylindrical
{
    Azimuth = Math.PI / 3,
    Radius = 1,
    Z = 2
};

var S = new Spherical
{
    Azimuth = Math.PI / 3,
    Inclination = Math.PI / 4,
    Radius = 1
};

var vc = C.ToVector();
var vs = S.ToVector();

Console.Write("({0:0.00},", vc.X);
Console.Write(" {0:0.00},", vc.Y);
Console.Write(" {0:0.00})", vc.Z);
Console.WriteLine();

Console.Write("({0:0.00},", vs.X);
Console.Write(" {0:0.00},", vs.Y);
Console.Write(" {0:0.00})", vs.Z);
Console.WriteLine();
```

```console
(0.50, 0.87, 2.00)
(0.35, 0.61, 0.71)
```

## Matrices

The `Matrix` structs represent row-major matrices of dimension $$2\times 2$$ through $$6\times 6$$.

```csharp
var A = new Matrix2x2(1, -2, -3, 1);
var B = new Matrix2x2(2, -1, -1, -3);

var C = A * B.Transposed;

Console.WriteLine("C = ");
Console.Write("({0,2},", C.M11);
Console.Write(" {0,2},", C.M12);
Console.WriteLine();
Console.Write(" {0,2},", C.M21);
Console.Write(" {0,2})", C.M22);
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("det(C) = {0}", C.Determinant);
Console.WriteLine("tr(C)  = {0}", C.Trace);
```

```console
C = 
( 4,  5,
 -7,  0)

det(C) = 35
tr(C)  = 4
```

Additionally, all the square matrices have properties that are useful in geometric calculations. However, the implementation does not focus on speed. For example, calculating the inverse of a $$6\times 6$$ matrix really takes some time.

```csharp
var M = Matrix2x2.Householder(Vector2.Unit1);

Console.WriteLine("M = ");
Console.Write("({0,2},", M.M11);
Console.Write(" {0,2},", M.M12);
Console.WriteLine();
Console.Write(" {0,2},", M.M21);
Console.Write(" {0,2})", M.M22);
Console.WriteLine();
Console.WriteLine();

var I = M.Inverted;

Console.WriteLine("M.Inverted = ");
Console.Write("({0,2},", I.M11);
Console.Write(" {0,2},", I.M12);
Console.WriteLine();
Console.Write(" {0,2},", I.M21);
Console.Write(" {0,2})", I.M22);
Console.WriteLine();
Console.WriteLine();

var S = M.Squared;

Console.WriteLine("M.Squared = ");
Console.Write("({0,2},", S.M11);
Console.Write(" {0,2},", S.M12);
Console.WriteLine();
Console.Write(" {0,2},", S.M21);
Console.Write(" {0,2})", S.M22);
Console.WriteLine();
```

```console
M =
(-1,  0,
  0,  1)

M.Inverted =
(-1,  0,
  0,  1)

M.Squared =
( 1,  0,
  0,  1)
```
