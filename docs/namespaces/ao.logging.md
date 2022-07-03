---
permalink: /namespaces/ao.logging/
title: "Ao.Logging"
---

# Ao.Logging

The `Ao.Logging` namespace contains classes that support the logging of data into text files. I have been using them in field test applications mostly for debugging purposes and logging status and diagnostic information from vehicle components.

## Session

The `Session` class represents a folder containing a set of log files. The `SessionRoot` class represents a folder containing a set of sessions. It also provides a means to create new sessions.

```csharp
var SR = new SessionRoot("C:\\logs");

var S = SR.CreateSession("first-session");

Console.WriteLine(S.Path);
```

```console
C:\logs\first-session
```

Additionally, there is a parameter-less overload of the `CreateSession()` method, that creates a folder name from the current timestamp. This is useful in order to enable the user to create several sessions subsequently in a field test, without the need to name each one explicitly.

```csharp
var S = SR.CreateSession();

Console.WriteLine(S.Path);
```

```console
C:\logs\2022-07-01-14-20-22
```

## Log

The `Log` class facilitates the logging and manages log files. Especially, it contains a simple mechanism to reduce the actual number of file accesses, as these can be a bottleneck for an application. The class's constructor requires a path to a folder where to store all the log files, for which the `Session` class can be used.

```csharp
var L = new Log(S.Path);
```

The log must be started and stopped explicitly. 

```csharp
L.Start();
```

This is for two important reasons. 

First, in common scenarios, data to be logged is arriving continuously, while logging that data may be required only for a couple of minutes. From a software engineering point of view, it is much easier to simply ignore incoming data that need not be logged, instead of shutting down the data source. This is, what the `Log` object does, if it is not started.

Second, in some scenarios, it is desirable to simultaneously log data to different folders. A `LogControl` object can be used for this purpose. Actually, such a control is used under the hood of every `Log` object. It synchronizes logging with several logs in a thread-safe fashion.

```csharp
var LC = new LogControl();

var L1 = new Log("folder1", LC);
var L2 = new Log("folder2", LC);

L1.Start();

Console.WriteLine(L1.Running);
Console.WriteLine(L2.Running);
```

```console
True
True
```

Logging data is straightforward. The `Log` class contains a single method, that adds a line to a file.

```csharp
L.Add("file1.txt", "Line 1.");
L.Add("file1.txt", "Line 2.");
L.Add("file1.txt", "Line 3.");

L.Add("subfolder/data.csv", "2022-07-01-14-25-00;1.23");
L.Add("subfolder/data.csv", "2022-07-01-14-25-02;1.24");
L.Add("subfolder/data.csv", "2022-07-01-14-25-04;1.21");
```

The `Log` class is not sealed. Hence, it can be subclassed in order to provide more convenient alternatives to the `Add()` method. Another option is to define extension methods.

```csharp
public static void AddTimestamp(this Log L, string fileName, DateTime t)
{
    L.Add(fileName, t.ToString("yyyy-MM-dd-HH-mm-ss"));
}
```

```csharp
L.AddTimestamp("timestamps.txt", DateTime.Now);
```

As mentioned above, the `Log` class reduces the number of actual file accesses. That is, it keeps an added line in memory, instead of immediately updating the respective file. Only when a larger number of lines has been added, these will be bulk-added to the file. The threshold can be set for each `Log` object individually and defaults to 10,000.

```csharp
L.FileLineBufferSize = 2000;
```

Of course, all cached lines will be written to their respective files, when logging is stopped.

```csharp
L.Stop();
```
