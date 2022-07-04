---
permalink: /namespaces/ao.optimization/
title: "Ao.Optimization"
---

# Ao.Optimization

The `Ao.Optimization` namespace contains particle swarm optimizers for functions of up to 6 variables.

## Optimization

The term optimization refers to finding the minimum of a function. In case of a quadratic function, this is straightforward.

$$ y = 2x^2 - 5x + 3 $$

$$ y' = 4x - 5 $$

$$ 0 = 4x - 5 $$

$$ ... $$

$$ x = \frac{5}{4} $$

However, there are functions, whose minima cannot be found using an analytical approach like above, either because it is too difficult or even impossible. Let's look at an example.

In an overhead power line, cables are suspended from towers. Especially in summer, the cables tend to bow downwards. This is due to the fact, that they are made of metal. The form of a cable between two towers can be described by a special curve, a so-called [catenary](https://en.wikipedia.org/wiki/Catenary).

$$ y = a \cosh(\frac{x}{a}) $$

The parameter $$a$$ affects the shape of the catenary. Let's suppose, that we want to find $$a$$ for a cable that is supsended from two towers 100 meters apart, that bends down exactly 1 meter.

First, we need to calculate the value of the curve point at $$x=50$$.

$$ y_1 = a \cosh ( \frac{50}{a}) $$

Then, we need to calculate the value of the curve point at $$x=0$$.

$$ y_2 = a \cosh (\frac{0}{a}) = a$$

The difference between the two values must be equal to 1.

$$ 1 = y_1 - y_2 $$

$$ 0 = y_1 - y_2 - 1$$

$$ 0 = a \cosh ( \frac{50}{a}) - a - 1 $$

Now, all that is left is to solve this equation for $$a$$. Unfortunately, this cannot be done analytically.

## Numerical Optimization

Numerical optimization is the process of finding a function's minimum with the help of a computer. First of all, we need the function whose minimum to find, the so-called objective function.

So far, our problem is a root problem, i.e. we aim to find the root of a function. We can turn this into an optimization problem with a simple trick.

$$ f(a) = | a \cosh ( \frac{50}{a}) - a - 1 | $$

Now, we can try to find the minimum of this function with an optimization algorithm, of which numerous exist.

## Particle swarm optimization

The [particle swarm optimization](https://en.wikipedia.org/wiki/Particle_swarm_optimization) (PSO) is a numerical optimization algorithm introduced by Eberhart and Kennedy in 1995. It has emerged from earlier-developed swarm algorithms in an attempt to investigate human social behavior.

Nowadays, the PSO has become a quite popular optimizer, because it is both not difficult to understand and easy to implement.

The `PSO1` class is an optimizer, that solves equations of one variable.

```csharp
double Objective(double a)
{
    return Math.Abs(a * Math.Cosh(50 / a) - a - 1);
}
```

```csharp
var PSO = new PSO1
{
    Objective = Objective;
};
```

Since the PSO heavily facilitates random numbers, we must specify a random number generator.

```csharp
var R = new Random();

PSO.Rand = () => R.NextDouble();
```

In the beginning, the PSO creates a set of particles and randomly distributes them across the search space. As the catenary parameter $$a$$ is always positive, the search space is a subset of the positive real numbers. Let's try the range $$(0, 5000]$$.

```csharp
PSO.MinPosition = double.Epsilon;
PSO.MaxPosition = 5000;
```

Upon initialization, each particle is assigned a random position (in the above range) and a random velocity. The maximum velocity must be specified, too.

```csharp
PSO.MaxVelocityStart = 100;
```

Now, we can solve.

```csharp
PSO.Solve();

Console.WriteLine("a    = {0}", PSO.BestPosition);
Console.WriteLine("f(a) = {0}", PSO.BestValue);
```

```console
a    = 1250.16663110818
f(a) = 1.34150468511507E-11
```

The best value clearly shows, that we have found quite a good solution. Hence, we can represent the cable suspended from two towers 100 meters apart and bending downwards 1 meter with the following catenary.

$$ y = 1250.17 \cdot \cosh(\frac{x}{1250.17}) $$

The `PSO1` class provides a few configuration options that can affect both the end result and the computation speed. 

First of all, as the PSO is an iterative approach, we can limit the number of iterations. By default, there is no limit.

```csharp
PSO.MaxIterations = 1000;
```

In each iteration step, the PSO first calculates the values of all particles. Then, it calculates a new velocity for every particle and, based thereon, a new position. Finally, it checks, whether or not to reiterate.

The calculation of a new velocity for a particle is influenced by three factors, that can be adjusted.

1. The old velocity (inertial factor).
2. The particle's best-ever position (cognitive factor).
3. The particle's neighborhood's best-ever position (social factor).

```csharp
PSO.Cognitive = 1;
PSO.Inertial = 1.2;
PSO.Social = 0.75;
```

The neighborhood of a particle is not defined in a geometric sense, but as a number of adjacent particles in an array.

```csharp
PSO.Neighbors = 100;
```

This value, of course, must not exceed the total number of particles. 

```csharp
PSO.Particles = 1000;
```

According to Eberhart and Kennedy, the size of the neighborhood has a tremendous impact on the optimization process.

- The bigger the neighborhood, the faster the process converges towards a solution.
- The bigger the neighborhood, the more likely a local minimum is found.
- The smaller the neighborhood, the more likely a global minimum is found.

Apart from the maximum number of iterations, there are two other factors that determine the exit condition.

First, the iteration stops, if the best value found so far has fallen below a threshold.

```csharp
PSO.BestValueThreshold = 0.01;
```

Second, the maximum velocity drops by a factor ...

```csharp
PSO.MaxVelocityDrop = 0.7;
```

... if the global best value hasn't changed significantly ...

```csharp
PSO.HistoryAverageDeviationThreshold = 0.000001;
```

... for a number of iterations.

```csharp
PSO.HistorySize = 5;
```

Then again, if the maximum velocity has fallen below a threshold ...

```csharp
PSO.MaxVelocityThreshold = 0.000001;
```

... the iteration stops.
