---
permalink: /namespaces/ao.can/
title: "Ao.Can"
---

# Ao.Can

The `Ao.Can` namespace contains some useful stuff for dealing with [CAN](https://en.wikipedia.org/wiki/CAN_bus) messages.

I have been using this code in conjunction with a self-made CAN sniffer, in order to log all messages being sent on particular CAN bus, such as a vehicle's powertrain bus.

## CAN message

The `CAN` struct carries all properties that a CAN message can possibly have. Note that depending on the message format (standard or extended) and message type (data or remote), some properties are irrelevant and need to be ignored.

| Property | |
|----------|-|
| `Data` | Each data message carries up to 8 bytes of  **data** or payload. Single bytes or bits can be gotten or set using the extension methods defined in the [Ao.Bits](ao.bits.md) namespace. The property is irrelevant for remote messages, since these do not carry data. |
| `DLC` | The **data length code** indicates the number of data bytes in data messages. It is irrelevant in remote messages. |
| `EID` | The **extension identifier** specifies the 18 least significant bits of the identifier of an extended message. It is irrelevant for standard messages. |
| `IDE` | The **identifier extension** specifies whether the message is a standard message (`false`) or an extended messages (`true`). |
| `RTR` | The **remote transmission request** specifies whether the message is a data message (`false`) or a remote messages (`true`). |
| `SID` | The **standard identifier** is the identifier of a standard message. In case of an extended message, this property specifies the 11 most significant bits of its identifier. |
| `XID` | This property gets or sets the entire 29-bit identifier and is thus relevant only for extended messages. |

## CAN statistics

When logging traffic on a CAN bus in order to track down software bugs or general misbehavior of embedded controllers in a vehicle, it is quite useful to have an outline of all types of messages being sent, as well as their frequencies.

The `CANStat` class generates such an outline.

```csharp
var Stat = new CANStat();
```

Whenever a new message arrives, simply hand it over, together with a time stamp.

```csharp
void OnCAN(Time T, CAN C)
{
    Stat.Add(T, C);
}
```

Afterwards, the outline can be accessed via the object's properties.

| Property | Outline for all recorded ... |
|----------|-|
| `Extended.Data` | ... extended data messages. |
| `Extended.Remote` | ... extended remote messages. |
| `Standard.Data` | ... standard data messages. |
| `Standard.Remote` | ... standard remote messages. |

### Example 1

Print a list of all 29-bit identifiers of extended data messages.

```csharp
foreach (var i in Stat.Extended.Data.XID)
{
    Console.WriteLine("{0:X8}", i);
}
```

```console
...
18FDC40B
18FE4AEF
18FE592F
18FEAD0B
18FEBF0B
18FEC1EE
18FECAEF
18FEDFEF
18FEE617
18FEE6EE
18FEEA2F
18FEEEEF
18FEF111
18FEF1EF
...
```

### Example 2

Print a list of all periods of extended data messages.

```csharp
var T = Stat.Extended.Data.Time;

foreach (var i in T.Keys)
{
    var t1 = T[i].TimespanAverage.Milliseconds;

    var t2 = Round.HalfUp(t1);

    Console.WriteLine("{0:X8} : {1} ms", i, t2);
}
```

```console
...
18FDC40B : 101 ms
18FE4AEF : 116 ms
18FE592F : 100 ms
18FEAD0B : 101 ms
18FEBF0B : 51 ms
18FEC1EE : 1008 ms
18FECAEF : 5906 ms
18FEDFEF : 288 ms
18FEE617 : 9998 ms
18FEE6EE : 1000 ms
18FEEA2F : 1009 ms
18FEEEEF : 443 ms
18FEF111 : 100 ms
18FEF1EF : 116 ms
...
```

### Example 3

For the extended data message, whose 29-bit identifier is `18FEAD0B`, print a list of all distinct data values.

```csharp
var E1 = Stat.Extended.Data.Data[0x18FEAD0B].Entries;

var E2 = from x in E1 select x.Data;

var E3 = E2.Distinct();

var E4 = from x in E3 orderby x select x;

foreach (var x in E4)
{
    Console.WriteLine("{0:X16}", x);
}
```

```console
...
FFFFFFFF211F2020
FFFFFFFF21211111
FFFFFFFF23231515
FFFFFFFF322F1D1D
FFFFFFFF33321E1E
FFFFFFFF35322323
FFFFFFFF37372121
FFFFFFFF3D3D2525
FFFFFFFF3E3B2525
FFFFFFFF3E3C2525
FFFFFFFF3E3F2626
FFFFFFFF40422727
FFFFFFFF40442A2A
FFFFFFFF41432929
...
```