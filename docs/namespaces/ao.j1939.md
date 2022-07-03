---
permalink: /namespaces/ao.j1939/
title: "Ao.J1939"
---

# Ao.J1939

The [SAE International](https://en.wikipedia.org/wiki/SAE_International) has developed a standard for messages sent between vehicle components, such as engine, breakes, or tachograph,  in order to exchange control and status information. It is called [SAE J1939](https://en.wikipedia.org/wiki/SAE_J1939) and has ever since been utilized not only in passenger cars, but also in heavy vehicles in agriculture or construction.

The standard defines a high-level protocol that is based on [CAN](https://en.wikipedia.org/wiki/CAN_bus). The `Ao.J1939` namespace contains a couple of types dealing with J1939 messages. I have been using them in a field test application for diagnostic and debugging purposes.

Actually, the standard defines a huge number of different messages. Unfortunately, it is not freely available, but must be purchased, and is protected by copyright. Although I have developed a lot of classes for individual messages, I do not publish them here. Instead, I stick to a couple of messages that are essential for basic networking and communication purposes.

## Node

J1939 messages are being exchanged between nodes on the CAN bus. From a hardware point of view, a node is a microcontroller or another kind of electronic control unit (ECU) embedded in a vehicle component, such as the engine. From a software point of view, a node is an application performing some specific task, such as engine control.

However, each node is assigned an address, that is a unique 8-bit identifier. Thereby, addresses 254 and 255 are reserved for special cases and cannot be assigned to a node. The static `Address` class contains symbolic constants for these values.

```csharp
Console.WriteLine("{0:X2}", Address.Null);
Console.WriteLine("{0:X2}", Address.Broadcast);
```

```console
FE
FF
```

## Message

The payload of a message is specified by a parameter group (PG). Every parameter group is assigned an acronym and a unique identifier, the parameter group number (PGN), and consists of a set of suspect parameters (SP). Once again, every suspect parameter is assigned a unique identifier, the suspect parameter number (SPN).

For example, there is a parameter group for the current time and date. Its acronym is *TD* and its PGN is 65254. It consists of the following suspect parameters.

| SP                  | SPN  | Size   |
|---------------------|------|--------|
| Seconds             |  959 | 1 byte |
| Minutes             |  960 | 1 byte |
| Hours               |  961 | 1 byte |
| Month               |  963 | 1 byte |
| Day                 |  962 | 1 byte |
| Year                |  964 | 1 byte |
| Local minute offset | 1601 | 1 byte |
| Local hour offset   | 1602 | 1 byte |

Consequently, the payload has a total size of 8 bytes. Therefore, a *TD* message can be sent in a single CAN message. This holds good for most parameter groups. 

However, there are a couple of parameter groups whose payload is greater than 8 bytes. Such messages must be sent in multiple CAN messages subsequently, packed in the payload of two dedicated parameter groups called *TP.CM* and *TP.DT*.

Besides the payload, every message that is sent contains the PGN, a source address identifying the sender, and a 3-bit priority ranging from 0 (highest) through 7 (lowest).

## Parameter Group Number

The PGN is an 18-bit number that identifies a parameter group. It consists of the following fields.

| Field              | Offset  | Size   |
|--------------------|---------|--------|
| Data page extended | 17 bits | 1 bit  |
| Data page          | 16 bits | 1 bit  |
| PF                 | 8 bits  | 8 bits |
| PS                 | 0 bits  | 8 bits |

The two data page bits subdivide the set of all possible PGN into four subsets of equal size. Currently however, only PGN are in use, whose data page bits are clear.

The PF field indicates whether a message is standard or proprietary. 

| Definition  |                           |
|-------------|---------------------------|
| Standard    | `0x00 <= PF <= 0xEE \|\|` |
|             | `0xF0 <= PF <= 0xFE`      |
| Proprietary | `0xEF == PF \|\|`         |
|             | `0xFF == PF`              |

Additionally, the PF field indicates whether a message is broadcast to all nodes or unicast to a specific node.

| Communication Mode |                      |
|--------------------|----------------------|
| Unicast            | `0x00 <= PF <= 0xEF` |
| Broadcast          | `0xF0 <= PF <= 0xFF` |

In case of a broadcast message, the PS field simply extends the PF field, which yields 4096 instead of 16 possible PGN. In case of a unicast message, the PS field contains the destination address.

Using the `PGN` struct, we can inspect the fields of the PGN of the parameter group *TD*.

```csharp
var x = new PGN 
{
    Value = 65254 
};

Console.WriteLine(x.DataPageExtended);
Console.WriteLine(x.DataPage);
Console.WriteLine("{0:X2}", x.PF);
Console.WriteLine("{0:X2}", x.PS);
```

```console
DataPage0
DataPage0
FE
E6
```

Accordingly, the *TD* message is defined in the standard and broadcast to all nodes.

```csharp
Console.WriteLine(x.IsBroadcast);
Console.WriteLine(x.IsStandard);
```

```console
True
True
```

## Parameter Group

The `PG` class is an abstract class that can be used as a base class for classes representing specific parameter groups. It contains properties for getting and setting, respectively, the payload, the PGN, the priority, and the source address.

```csharp
public abstract class PG
{
    // ...

    public abstract byte[] Data { get; set; }

    public PGN PGN => /* ... */

    public Priority Priority { get; set; }

    // ...

    public byte SourceAddress { get; set; }
}
```

## TD

The `TD` class subclasses `PG` and represents parameter group *TD*.

```csharp
var T = new TD();

Console.WriteLine(T.Acronym);
Console.WriteLine(T.DataLength);
Console.WriteLine(T.Label);
Console.WriteLine(T.PGN.Value);
```

```console
TD
8
Time/Date
65254
```

The class provides a couple of properties to conveniently access individual suspect parameters.

```csharp
T.DateTime = DateTime.Now;

Console.WriteLine(T.Year);
Console.WriteLine(T.Month);
Console.WriteLine(T.Day);
Console.WriteLine(T.Hour);
Console.WriteLine(T.Minute);
Console.WriteLine(T.Second);
Console.WriteLine(T.Millisecond);
```

```console
2022
7
3
15
7
46
250
```

## RQST

The `RQST` class represents the *RQST* parameter group, that contains a request for a specific parameter group. It is a standard unicast message. A node can send such a request to another node. For example, the following creates a request for the node with address `0x01` to send a *TD* message.

```csharp
var R = new RQST();

R.DestinationAddress = 0x01;
R.RequestedPGN = new PGN 
{
    Value = 65254 
};
```

Even though it is a unicast message, a request can be directed to all nodes, that is, it can be broadcast.

```csharp
R.DestinationAddress = Address.Global;
```

## ACKM

The `ACKM` class represents the *ACKM* parameter group, that contains an acknowledgement. A node is expected to send it, after it has received a request or another command.

```csharp
var A = new ACKM();

A.Address = 0x01;
A.RequestedPGN = new PGN 
{
    Value = 65254 
};
A.Result = ACKMResult.Positive;
```

## NAME

Nodes within a network must have an individual address. On start-up, a node usually assigns itself a so-called preferred address, based on the primary function of the node. For example, in a passenger car, the primary engine uses address `0x00` and the primary shift console uses address `0x05`. 

In many cases this is sufficient. However, it is still possible, that two nodes share the same address. The standard provides ways to resolve such a conflict. In order for this work, every node must also be equipped with a second, globally unique identifier.

That identifier is called a NAME. It is a 64-bit number that can be subdivided into several fields, that provide information about the manufacturer and the primary function of a node.

## AC

The `AC` class represents the *AC* parameter group. It contains a NAME as its only suspect parameter and can be sent by a node to tell the other nodes it has claimed a specific address.

```csharp
var A = new AC();

A.NAME = new NAME
{
    Value = 0x0123456789ABCDEFUL
};
A.DestinationAddress = Address.Global;
A.SourceAddress = 0x07;
```

In a common setup, every node sends an *AC* message on start-up, claiming its preferred address. If there are two nodes claiming the same address, the node with the lesser NAME wins the claimed address. The losing node could then try to claim another address, if it is capable of doing so. Otherwise, it must send the *AC* message again, but with a special source address, indicating to the other nodes, that it cannot claim an address.

```csharp
A.SourceAddress = Address.Null;
```

## CA

If a node cannot claim an address itself, it can be commanded an address by another node using a *CA* message.

```csharp
var C = new CA();

C.NAME = 0x0123456789ABCDEFUL;
C.Address = 0x8B;
```

## TP.CM

The *CA* message is an example of a so-called multi-packet message, whose payload exceeds 8 bytes. Therefore, it cannot be sent in a single CAN message. The standard specifies a means to send such messages packed in a sequence of CAN messages.

The *TP.CM* message is to announce such a transfer in the case of a broadcast message and manage the control flow in case of a unicast message.

In order to send a *CA* message, the sender must start with a request-to-send message.

```csharp
var C1 = new TPCM
{
    Mode = TPCMMode.RTS,

    MessagePGN = new PGN
    {
        Value = 65240
    },

    RTSMessageSize = 9,
    RTSMessagePackagesTotal = 2,
    RTSMessagePackagesMax = 255
};
```

The receiver answers with a clear-to-send message.

```csharp
var C2 = new TPCM
{
    Mode = TPCMMode.CTS,

    MessagePGN = new PGN
    {
        Value = 65240
    },

    CTSMessagePackages = 2,
    CTSMessagePackageNext = 1
};
```

Then, the sender transfers the payload. Afterwards, the receiver sends and end-of-message acknowledgement.

```csharp
var C3 = new TPCM
{
    Mode = TPCMMode.EOM,

    MessagePGN = new PGN
    {
        Value = 65240
    },

    EOMMessageSize = 9,
    EOMMessagePackages = 2
};
```

A node can abort the transfer anytime using an abort message.

```csharp
var C4 = new TPCM
{
    Mode = TPCMMode.Abort,

    MessagePGN = new PGN
    {
        Value = 65240
    },

    AbortReason = TPCMAbortReason.Timeout
};
```

## TP.DT

The actual payload is transferred using a sequence of *TP.DT* messages.

```csharp
var D1 = new TPDT();

D1.SequenceNumber = 1;
D1.PacketizedData0 = C.Data[0];
D1.PacketizedData1 = C.Data[1];
D1.PacketizedData2 = C.Data[2];
D1.PacketizedData3 = C.Data[3];
D1.PacketizedData4 = C.Data[4];
D1.PacketizedData5 = C.Data[5];
D1.PacketizedData6 = C.Data[6];

var D2 = new TPDT();

D2.SequenceNumber = 2;
D2.PacketizedData0 = C.Data[7];
D2.PacketizedData1 = C.Data[8];
D2.PacketizedData2 = 0xFF;
D2.PacketizedData3 = 0xFF;
D2.PacketizedData4 = 0xFF;
D2.PacketizedData5 = 0xFF;
D2.PacketizedData6 = 0xFF;
```

## Protocol Data Unit

Using the *TP.CM* and *TP.DT* messages, multi-packet messages end up being sent in messages of no more than 8 bytes of payload. Such messages can be mapped to CAN messages directly. The `PDU` struct helps accomplishing this task.

```csharp
var M = new TD
{
    DateTime = DateTime.Now,
    Kind = TDKind.Local,
    Priority = Priority.Priority6,
    SourceAddress = 0x73
};

var P = new PDU
{
    CANData = BitConverter.ToUInt64(M.Data, 0),
    PGN = M.PGN,
    Priority = M.Priority,
    SourceAddress = M.SourceAddress
};

var C = P.CAN;

Console.WriteLine("{0:X8}", C.XID);
```

```console
18FEE673
```
