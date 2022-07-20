---
permalink: /namespaces/ao.collections/
author: "Stefan Wagner"
title: "Ao.Collections"
description: "Double-ended queues and priority queues in C#."
---

# Ao.Collections

The `Ao.Collections` namespace contains two generic collection classes for double-ended queues and priority queues, respectively.

## Double-Ended Queues

Just like the `deque` type in the C++ Standard Template Library, the `Deque<T>` class implements a [double-ended queue](https://en.wikipedia.org/wiki/Double-ended_queue) that supports constant-time insertion and removal at either end. 

Therefore, the `Dequeu<T>` class is internally based on a linked list.

```csharp
var Q = new Deque<int>();
```

### Push Back

```csharp
Q.PushBack(1);
Q.PushBack(2);
Q.PushBack(3);

foreach (var x in Q)
{
    Console.WriteLine(x);
}
```

```console
1
2
3
```

### Push Front

```csharp
Q.PushFront(4);
Q.PushFront(5);
Q.PushFront(6);

foreach (var x in Q)
{
    Console.WriteLine(x);
}
```

```console
6
5
4
1
2
3
```

### Pop Front

```csharp
Q.PopFront();
Q.PopFront();

foreach (var x in Q)
{
    Console.WriteLine(x);
}
```

```console
4
1
2
3
```

### Pop Back

```csharp
Q.PopBack();

foreach (var x in Q)
{
    Console.WriteLine(x);
}
```

```console
4
1
2
```

## Priority Queue

A [priority queue](https://en.wikipedia.org/wiki/Priority_queue) is a widely used data structure, e.g. when dealing with a stream of incoming messages in such a way, that important messages are processed first.

The `PriorityQueue<T>`  class is implemented as a [**minimum** heap](https://en.wikipedia.org/wiki/Heap_(data_structure)) using a list for the items and a dictionary for the items' indexes.

### Push

```csharp
var Q = new PriorityQueue<int>();

Q.Push(4);
Q.Push(2);
Q.Push(5);
Q.Push(1);
Q.Push(3);
Q.Push(6);

Console.WriteLine(Q.Peek());
```

```console
1
```

### Pop

```csharp
Q.Pop();
Q.Pop();

Console.WriteLine(Q.Peek());
```

```console
3
```

### Priorities

In contrast to integers, other types' priorities are not so obvious. When default-constructed, a priority queue will use a default comparer for comparisons. 

```csharp
public PriorityQueue() => Comparer = Comparer<T>.Default;
```

For custom value types or reference types, this most probably won't do very well. Then, a custom comparer should be provided.

```csharp
public class Message
{
    public DateTime Time { get; set; }

    public string Sender { get; set; }
}

public class MessageComparer : Comparer<Message>
{
    public override int Compare(Message x, Message y) => x.Time.CompareTo(y.Time);
}
```

```csharp
var C = new MessageComparer();

var Q = new PriorityQueue<Message>(C);
```