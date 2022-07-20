---
permalink: /namespaces/ao.simulation/
author: "Stefan Wagner"
title: "Ao.Simulation"
description: "Time-based simulations in C# based on an event queue and a simulator."
---

# Ao.Simulation

The `Ao.Simulation` namespace contains some basic ingredients for simulations.

## Timestamp

This namespace contains a simulator class that can run a simulation based on an event queue, for which it needs a function returning a current timestamp. The event queue stores events ordered by their individual timestamp.

A timestamp is a `Time` value that has been defined in the [`Ao.Measurements`](ao.measurements.md) namespace. 

```csharp
var t = new Time
{
    Seconds = 1.2345
};
```

The framework class library provides the means to build a current timestamp generator.

```csharp
public static class Timestamp
{
    private static readonly DateTime Beginning = DateTime.Now;

    public static Time Now => new Time
    {
        Seconds = (DateTime.Now - Beginning).TotalSeconds
    };
}
```

However, the default Windows timer running behind `DateTime.Now` updates every 15.6 milliseconds, only. A higher resolution is provided, for example, by the performance counter, which can be accessed using interop or the `Performance` class in the [`Ao.Timing.Win32`](ao.timing.win32.md) namespace.

## Event

An event can be anything, for which a timestamp can be specified, for example, the arrival of a message ...

```csharp
public class MessageEvent
{
    public string Message { get; set; }

    public Time Time { get; set; }
}
```

... or an update from a sensor.

```csharp
public class SensorEvent
{
    public Acceleration X { get; set; }
    public Acceleration Y { get; set; }
    public Acceleration Z { get; set; }

    public Time Time { get; set; }
}
```

## Event Queue

The generic `EventQueue<T>` class is a priority queue for events, that internally orders events by their respective timestamp. The generic parameter `T` represents the event. In order to do its job properly, the event queue needs a delegate returning an event's timestamp.

```csharp
var Q = new EventQueue<SensorEvent>(x => x.Time);
```

Thereby, it is not necessary for the event type `T` to carry around the timestamp by itself. The specified delegate can get an event from elsewhere.

```csharp
public static class TimestampProvider
{
    public static Time Get(SensorEvent e)
    {
        // ...
    }
}
```

```csharp
var Q = new EventQueue<SensorEvent>(TimestampProvider.Get);
```

## Simulator

The `Simulator` class uses both an event queue and a current timestamp provider, in order to fire events accordingly.

```csharp
var S = new Simulator<SensorEvent>(Q, Timestamp.Now);
```

There is a single public method, that permanently loops until the event queue is empty. Only then does it return. Therefore, it should better be called in a background thread.

```csharp
S.Run();
```

With every iteration, it gets the current timestamp and removes all the items from the event queue that are due. For each item, it fires an event, that the application can listen to.

```csharp
void OnEvent(object sender, SimulatorEventArgs<SensorEvent> e)
{
    Console.WriteLine("Sensor event at {0} s.", e.Time.Seconds);
}
```

```csharp
S.Event += OnEvent;
```
