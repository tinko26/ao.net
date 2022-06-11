---
layout: default
title: Ao.Bits
nav_order: 2
---

# Ao.Bits

The ```Ao.Bits``` namespace contains a single static class with extension methods for integer types.

## Extensions

The ```Extensions``` class contains methods that get or set bits in an integer value, respectively.

```c#
var a = 0x12345678U;

// Get bits.

var a3 = a.GetBits(24, 8);
var a2 = a.GetBits(16, 8);
var a1 = a.GetBits( 8, 8);
var a0 = a.GetBits( 0, 8);

Debug.Assert(a3 == 0x12U);
Debug.Assert(a2 == 0x34U);
Debug.Assert(a1 == 0x56U);
Debug.Assert(a0 == 0x78U);

// Set bits.

a.SetBits(24, 8, 0x87U);
a.SetBits(16, 8, 0x65U);
a.SetBits( 8, 8, 0x43U);
a.SetBits( 0, 8, 0x12U);

Debug.Assert(a == 0x87654321U);
```
