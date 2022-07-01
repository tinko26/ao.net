---
permalink: /namespaces/ao.j1939/
title: "Ao.J1939"
---

# Ao.J1939

The `Ao.J1939` namespace contains a couple of types dealing with messages defined in the [SAE J1939](https://en.wikipedia.org/wiki/SAE_J1939) standard. I have been using them in a field test application for diagnostic and debugging purposes.

The J1939 messages are sent on a [CAN](https://en.wikipedia.org/wiki/CAN_bus) bus and used by vehicle components, such as the engine, the breakes, or the tachograph, to communicate with each other and exchange status and diagnostic information. 

The standard defines a huge number of different messages. Additionally, these definitions are not freely available, but must be purchased. This is why I did not publish classes for most messages, but only a few basic ones used for networking.

## Parameter Group Number

## Parameter Group

## Protocol Data Unit
