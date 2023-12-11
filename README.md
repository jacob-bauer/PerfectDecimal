# PerfectDecimal
A .NET decimal type with infinite precision and scale.

`PerfectDecimal` is so called because it is built as a ratio between two integer types, enabling the correct representation of non-terminating decimals.
Using a ratio of two integer types also allows `PerfectDecimal` to correctly represent numbers that are not correctly representable by standard floating
point types.

In other words, `PerfectDecimal` has (theoretically) infinite precision and scale.
