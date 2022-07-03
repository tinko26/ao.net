---
permalink: /namespaces/ao.timing.win32/
title: "Ao.Timing.Win32"
---

# Ao.Timing.Win32

The `Ao.Timing.Win32` namespace encapsulates timing features of the native Win32 API. In contrast to the other namespaces, its members are implemented in C++/CLI. 

Just like the [`Ao.Timing`](ao.timing.md) namespace it utilizes the `Time` struct defined in the [`Ao.Measurements`](ao.measurements.md) namespace.

## Tick Counter

The native `GetTickCount64()` function returns the number of milliseconds that have elapsed since the system was started. The `Tick` class provides access to this value.

```csharp
Console.WriteLine(Tick.Now.Seconds);
```

```console
345343.453
```

The resolution of this clock is limited to the resolution of the system timer, which defaults to 15.6 milliseconds. 

## Performance Counter

The native `QueryPerformanceCounter()` function returns a similar value with a much higher resolution, usually less than a microsecond. The `Performance` class provides access to this value.

```csharp
Console.WriteLine(Performance.Now.Seconds);
Console.WriteLine(Performance.Now.Seconds);
Console.WriteLine(Performance.Now.Seconds);
```

```console
346028.0039879
346028.0051237
346028.0052236
```

The class also provides the actual update frequency.

```csharp
Console.WriteLine("{0} MHz", Performance.Frequency.Megahertz);
```

```console
10 MHz
```

## Multimedia Timer

The native multimedia timer services are an alternative to the various timer classes of the .NET framework library, for they can fire events at higher resolutions. The static `MultimediaTimer` class provides a constant for the minimum possible resolution.

```csharp
Console.WriteLine("{0} ms", MultimediaTimer.MinResolutionMs);
```

```console
1 ms
```

As mentioned above, the multimedia timer classes are based on a custom timestamp. The tick counter or the performance counter can be used for this purpose.

```csharp
Time Timestamp() => Tick.Now;
```

```csharp
Time Timestamp() => Performance.Now;
```

### One-Shot Multimedia Timer

The `MultimediaTimerOneShot` class represents a timer, that fires only once after the specified delay and then stops automatically.

```csharp
Time OnElapsed(object sender, TimerEventArgs e)
{
    Console.WriteLine(e.Time.Seconds);
}
```

```csharp
var T = new MultimediaTimerOneShot(Timestamp);

T.DelayMs = 500;
T.Elapsed += OnElapsed;
T.ResolutionMs = 1;

T.Start(); 
```

The `Resolution` property specifies the resolution, however, this is a global value. Windows will always use the minimum resolution currently requested, so starting another timer with a higher resolution will result in that one running at 1 ms resolution, too.

### Periodic Multimedia Timer

The `MultimediaTimerPeriodic` class represents a timer, that fires periodically every time the specified delay has expired. It needs to be stopped manually.

```csharp
var T = new MultimediaTimerPeriodic(Timestamp);

T.DelayMs = 500;
T.Elapsed += OnElapsed;
T.ResolutionMs = 1;

T.Start(); 

Thread.Sleep(5000);

T.Stop();
```

```console
347554.4604155
347554.955485
347555.4553355
347555.9560668
347556.4553727
347556.955237
347557.4556209
347557.9556149
347558.4556545
347558.9562038
```
