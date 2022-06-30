---
permalink: /namespaces/ao.geodesy/
title: "Ao.Geodesy"
---

# Ao.Geodesy

The `Ao.Geodesy` namespace supports the calculation of distances and angles between places on earth, which is useful when working with GPS data.

The `GeographicPosition2` struct represents a place on the surface and consists of a pair of angles specifying latitude and longitude.

The `GeographicPosition3` struct additionally specifies the altitude, i.e. the distance above the surface.

```csharp
var NewYork = new GeographicPosition2
{
    Latitude = new Angle { Degrees = 40.712778 },
    Longitude = new Angle { Degrees = -74.006111 }
};

var Tokyo = new GeographicPosition2
{
    Latitude = new Angle { Degrees = 35.689722 },
    Longitude = new Angle { Degrees = 139.692222 }
};
```

The `SphericalEarth` class represents earth in the shape of a perfect sphere, that is, every surface point is equidistant to the center.

```csharp
var Radius = new Length { Kilometers = 6300 };

var Earth = new SphericalEarth(Radius);
```

The `SpheroidalEarth` class represents earth in the shape of a spheroid, where the poles are a little closer to the center than the equator. 

```csharp
var EquatorialRadius = new Length { Kilometers = 6378 };
var PolarRadius = new Length { Kilometers = 6356 };

var Earth = new SpheroidalEarth(EquatorialRadius, PolarRadius);
```

Neither approach exactly matches reality, and which one to choose really depends on the required precision and other factors. The spheroidal shape is a little closer to Earth's real shape, but calculations on a spherical shape are a little faster.

The `WGS84` class provides objects for both cases, with fixed radii specified in the [WGS84](https://en.wikipedia.org/wiki/World_Geodetic_System) standard.

```csharp
var Earth = WGS84.SphericalEarth;
```

The earth classes contain methods to calculate the [great-circle distance](https://en.wikipedia.org/wiki/Great-circle_distance) between two places, that is, the distance to travel on the surface from one place to another.

```csharp
var D = Earth.GreatCircleDistance(NewYork, Tokyo);

Console.WriteLine("{0} km", Round.HalfUp(D.Kilometers));
```

```console
10849 km
```

Additionally, one can calculate the [Euclidean distance](https://en.wikipedia.org/wiki/Euclidean_distance), that is, the shortest distance connecting two places through earth's interior. Sometimes, this is called the tunnel distance.

```csharp
var D = Earth.EuclideanDistance(NewYork, Tokyo);

Console.WriteLine("{0} km", Round.HalfUp(D.Kilometers));
```

```console
9585 km
```

Finally, the earth classes support the calculation of the initial [bearing](https://en.wikipedia.org/wiki/Bearing_(angle)) from one place to another, that is, the direction with respect to true north at the starting point, when travelling along a great-circle path to the destination.

| Bearing | Direction |
|---------|-----------|
| 0° | north |
| 45° | north-east |
| 90° | east |
| 135° | south-east |
| 180° | south |
| 225° | south-west |
| 270° | west |
| 315° | north-west |

```csharp
var B = Earth.Bearing(NewYork, Tokyo);

Console.WriteLine("{0}°", Round.HalfUp(B.Degrees));
```

```console
333°
```