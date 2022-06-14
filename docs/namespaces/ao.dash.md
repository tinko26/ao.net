---
permalink: /namespaces/ao.dash/
title: "Ao.Dash"
gallery:
  - url: /assets/images/ao-dash-1.png
    image_path: /assets/images/ao-dash-1.png
    alt: "Dashcam selection in WPF."
    title: "Dashcam selection in WPF."
  - url: /assets/images/ao-dash-2.png
    image_path: /assets/images/ao-dash-2.png
    alt: "Dashcam selection in WPF."
    title: "Dashcam selection in WPF."
  - url: /assets/images/ao-dash-3.png
    image_path: /assets/images/ao-dash-3.png
    alt: "Dashcam selection in WPF."
    title: "Dashcam selection in WPF."
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

Additionally, it informs about changes via its events.

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

## Dashcam

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

## Dashcam controller

The `DashcamController` class supports WPF applications. It can be used as the `DataContext` of a WPF user control.

The user control can show a drop-down list of connected dashcams, in order to let the user select the current one.

```xaml
<ComboBox
    ItemsSource="{Binding Path=Names, Mode=OneWay}" 
    SelectedItem="{Binding Path=Name, Mode=TwoWay}" />
```

Just as easily the user control can show the selected dashcam's video.

```xaml
<Image Source="{Binding Path=Frame, Mode=OneWay}" />
```

Additionally, the user control has access to a variety of dashcam properties.

```xaml
<Label>The number of frames.</Label>
<Label Content="{Binding Mode=OneWay, Path=ReceivedFrames }" />

<Label>The maximum framerate.</Label>
<Label Content="{Binding Mode=OneWay, Path=FrameRateMax }" />

<Label>The frame size.</Label>
<Label Content="{Binding Mode=OneWay, Path=FrameSize }" />
```

{% include gallery caption="Dashcam selection in WPF." %}
