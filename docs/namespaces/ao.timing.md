---
permalink: /timing/
author: "Stefan Wagner"
title: "Ao.Timing"
description: "Timestamps, timers, and stop watches in C#."
---

# Ao.Timing

The `Ao.Timing` namespace contains a stop watch and a timer class, respectively. Both classes are based on a custom timestamp function, that returns a `Time` value defined in the [`Ao.Measurements`](ao.measurements.md) namespace.

## Timestamp

```csharp
private static readonly DateTime Beginning = DateTime.Now;

private static Time Timestamp()
{
    var T0 = Beginning;

    var T1 = DateTime.Now;

    var T2 = T1 - T0;

    return new Time 
    {
        Seconds = T2.TotalSeconds
    };
}
```

The above custom timestamp is based on `DateTime.Now`, that is, the default Windows timestamp, that is updated every 15.6 milliseconds. The [`Ao.Timing.Win32`](ao.timing.win32.md) namespace provides options for custom timestamps with a higher resolution.

## Stop Watch

The `StopWatch` class is similar to the `System.Diagnostics.Stopwatch` class. 

```csharp
var S = new StopWatch(Timestamp);

S.Start();

Thread.Sleep(200);

S.Stop();

Console.WriteLine(S.Elapsed.Seconds);
```

```console
0.2188731
```

Additionally, it provides a means to measure subintervals or cycles.

```csharp
S.Start();

for (var i = 0; i < 5; i++)
{
    Thread.Sleep(200);

    var T = S.Cycle();

    Console.WriteLine(T.Seconds);
}

S.Stop();

Console.WriteLine();
Console.WriteLine(S.Elapsed.Seconds);
```

```console
0.2077184
0.2121635
0.2138978
0.2058646
0.2030795

1.0427238
```

## Timer

The `Timer` class implements a periodic timer based on a `System.Timers.Timer` object and fires events with a custom timestamp.

```csharp
void OnElapsed(object sender, TimerEventArgs e)
{
    Console.WriteLine(e.Time.Seconds);
}
```

```csharp
var T = new Timer(Timestamp);

T.Elapsed += OnElapsed;
T.Period = new Time 
{ 
    Milliseconds = 500
};

T.Start();

Thread.Sleep(5000);

T.Stop();
```

```console
0.551329
1.0593849
1.5739268
2.0777714
2.5826702
3.083513
3.5886121
4.0938996
4.5949296
```
