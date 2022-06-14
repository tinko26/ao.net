---
permalink: /namespaces/ao.dash/
title: "Ao.Dash"
---

# Ao.Dash

The `Ao.Dash` namespace contains classes for managing dashcams attached to a Windows computer. I have been using them in WPF applications in order to let the user select one out of many dashcams whose video to show. 

The code requires a reference to the following [AForge](https://en.wikipedia.org/wiki/AForge.NET) assemblies, that can be acquired in Visual Studio via NuGet.

- AForge
- AForge.Video
- AForge.Video.DirectShow

## Dashcam manager

The `DashcamManager` class is a static class that provides a list of dashcams currently attached to the computer.

```csharp
foreach (var D in DashcamManager.Dashcams)
{
    Console.WriteLine(D.Name);
}
```

```console
Integrated Webcam
LifeCam Studio
```

Upon initialization, the dashcam manager starts a management event watcher, that keeps the manager informed about devices being attached and detached. For each such event, the dashcam manager updates the dashcam list.

Additionally, it informs about changes via its `DashcamConnected` and `DashcamDisconnected` events.

```csharp
void OnDashcamConnected(object sender, DashcamEventArgs e)
{
    Console.WriteLine("Dashcam {0} is now connected.", e.Dashcam.Name);
}

void OnDashcamDisconnected(object sender, DashcamEventArgs e)
{
    Console.WriteLine("Dashcam {0} is gone.", e.Dashcam.Name);
}

```

```csharp
DashcamManager.DashcamConnected += OnDashcamConnected;

DashcamManager.DashcamDisconnected += OnDashcamDisconnected;
```

The `Dashcam` class provides access to a dashcam's frames. Each new frame is broadcast via its `Frame` event. However, a dashcam must be started first.

```csharp
void OnFrame(object sender, DashcamEventArgs e)
{
    var F = e.Frame;

    // ...
}
```

```csharp
var D = DashcamManager.Dashcams.First();

D.Frame += OnFrame;

D.Start();
```

