# hex-dump

[![HexDump NuGet version](https://img.shields.io/nuget/v/HexDump)](https://www.nuget.org/packages/HexDump/)
[![HexDump NuGet download count](https://img.shields.io/nuget/dt/HexDump)](https://www.nuget.org/packages/HexDump/)

Formats a hex dump from bytes.

## Usage

```c#
string hex = HexDump.Format(myBytes);
```

Produces output resembling:

```
0000    61 62 63 64 65 66 67 68  69 6A 6B 6C 6D 6E 6F 70    abcdefgh ijklmnop
0010    71 72 73 74 75 76 77 78  79 7A                      qrstuvwx yz      
```

Options:

- `includeOffset` controls whether the leftmost column is displayed
- `includeAscii` controls whether the rightmost column is displayed

## Installation

Use the `HexDump` package from NuGet.

https://www.nuget.org/packages/HexDump

