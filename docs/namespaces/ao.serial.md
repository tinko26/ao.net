---
permalink: /serial/
author: "Stefan Wagner"
title: "Ao.Serial"
description: "Managing serial ports on a Windows computer in C#."
---

# Ao.Serial

The `Ao.Serial` namespace contains classes for managing serial ports attached to a Windows computer. I have been using them in several WPF applications in order to let the user select one. This is especially useful, if such an app is to run on different laptops with a different number of serial ports and different names for each one.

## Port Manager

The `PortManager` class is a static class that provides a list of the names of all serial ports currently connected to the computer.

```csharp
foreach (var P in PortManager.Ports)
{
    Console.WriteLine(P);
}
```

```console
COM3
COM5
```

Upon initialization, the port manager starts a management event watcher, that keeps the manager informed about devices being attached and detached. For each such event, the port manager updates the port name list.

Additionally, it informs about changes via its events.

```csharp
void OnPortConnected(object sender, PortEventArgs e)
{
    Console.WriteLine("Port {0} is now connected.", e.Name);
}

void OnPortDisconnected(object sender, PortEventArgs e)
{
    Console.WriteLine("Port {0} is gone.", e.Name);
}
```

```csharp
PortManager.PortConnected += OnPortConnected;
PortManager.PortDisconnected += OnPortDisconnected;
```

## Port

The `Port` class provides all the means for receiving and sending data through a serial port. Internally, it manages a `System.IO.Ports.SerialPort` object and provides access to its methods in a thread-safe way. 

Additionally, it recognizes, when the port is connected or disconnected, respectively, and safely closes or reopens the port. Essentially, this helps to prevent application crashes. This is especially useful in field tests, where people occasionally stumble upon cables. :stuck_out_tongue_winking_eye:

### Start

```csharp
var P = new Port
{
    Name = "COM3",
    Baud = 115200
};

P.Start();
```

### Send

```csharp
var data = new byte[] { 0x12, 0x34, 0x56, 0x78 };

P.Send(data);
```

### Receive

```csharp
void OnReceived(object sender, PortDataEventArgs e)
{
    for (var i = 0; i < e.Count; i++)
    {
        Console.WriteLine("{0:X2}", e.Buffer[e.Offset + i]);
    }
}
```

```csharp
P.Received += OnReceived;
```

### Stop

```csharp
P.Stop();
```
