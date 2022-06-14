---
permalink: /namespaces/ao.optimization/
title: "Ao.Optimization"
---

# Ao.Optimization

The `Ao.Optimization` namespace contains particle swarm optimizers for functions of up to 6 variables.

## Particle swarm optimization

The [particle swarm optimization](https://en.wikipedia.org/wiki/Particle_swarm_optimization) (PSO) is a numerical optimization method introduced by Eberhart and Kennedy in 1995. It has emerged from earlier-developed swarm algorithms in an attempt to investigate human social behavior.

Nowadays, the PSO has become a quite popular optimizer, because it is both not difficult to understand and easy to implement. Using the `PSOx` classes is straightforward.

```csharp
var PSO = new PSO2();
```

Let's suppose we aim to find a minimum of [Himmelblau's function](https://en.wikipedia.org/wiki/Himmelblau's_function).

$$ f(x, y) = (x^2+y-11)^2 + (x+y^2-7)^2 $$

This needs to be set as the objective.

```csharp
double Himmelblau(Vector2 v)
{
    var x = v.M1;
    var y = v.M2;

    var t1 = x * x + y - 11;
    var t2 = x + y * y - 7;

    return t1 * t1 + t2 * t2;
}
```

```csharp
PSO.Objective = Himmelblau;
```

Additionally, ...
