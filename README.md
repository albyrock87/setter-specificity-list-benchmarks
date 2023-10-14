# SetterSpecificityList Benchmarks

This project aims to investigate performance of different solutions to implement `SetterSpecificityList`.

The goal of this list is to always provide the value with the greater specificity in the list.

Implemented solutions:
- **FieldBased**: MAUI implementation at Oct 14th 2023 - **Used as baseline**
- **SortedListBased**: Using a `SortedList` with `GetKeyAtIndex` and `GetValueAtIndex`
- **SortedListBasedDefaultCapacity**: Like `SortedListBased`, but with initial capacity set to 4
- **ListBasedDefaultCapacity**: Using an unsorted `List`, keeping track of the maximum specificity while adding items
- **AdHoc**: Mimics a `SortedList` but implements only what it needed for our purpose

## Result

As expected, `AdHoc` solutions are the fastest.

## Benchmark tables

#### CreateContextBenchmark

Mimics the creation of `BindablePropertyContext`.

| Method                         | Mean      | Error    | StdDev   | Ratio | RatioSD |
|------------------------------- |----------:|---------:|---------:|------:|--------:|
| FieldBased                     | 112.25 us | 2.143 us | 2.468 us |  1.00 |    0.00 |
| SortedListBased                | 216.93 us | 4.336 us | 5.638 us |  1.93 |    0.06 |
| SortedListBasedDefaultCapacity | 181.31 us | 3.543 us | 4.607 us |  1.62 |    0.06 |
| ListBasedDefaultCapacity       | 102.99 us | 2.009 us | 2.540 us |  0.92 |    0.03 |
| AdHoc                          | 126.63 us | 2.077 us | 4.101 us |  1.14 |    0.05 |
| AdHocLinked                    |  70.79 us | 1.362 us | 1.771 us |  0.63 |    0.02 |


#### AddValueBenchmark

Add a value on top of the default value.

| Method                         | Mean     | Error   | StdDev  | Ratio | RatioSD |
|------------------------------- |---------:|--------:|--------:|------:|--------:|
| FieldBased                     | 223.3 us | 4.21 us | 3.94 us |  1.00 |    0.00 |
| SortedListBased                | 305.7 us | 5.97 us | 8.75 us |  1.37 |    0.05 |
| SortedListBasedDefaultCapacity | 265.6 us | 5.23 us | 7.67 us |  1.19 |    0.04 |
| ListBasedDefaultCapacity       | 158.6 us | 3.16 us | 4.54 us |  0.72 |    0.02 |
| AdHoc                          | 149.2 us | 2.96 us | 3.29 us |  0.67 |    0.02 |
| AdHocLinked                    | 129.5 us | 2.57 us | 3.16 us |  0.58 |    0.02 |


#### AddValuesBenchmark

Adds two values on top of the default value.

| Method                         | Mean     | Error    | StdDev   | Ratio | RatioSD |
|------------------------------- |---------:|---------:|---------:|------:|--------:|
| FieldBased                     | 649.8 us | 12.77 us | 17.47 us |  1.00 |    0.00 |
| SortedListBased                | 402.1 us |  8.00 us | 11.72 us |  0.62 |    0.02 |
| SortedListBasedDefaultCapacity | 349.6 us |  6.88 us | 10.30 us |  0.54 |    0.02 |
| ListBasedDefaultCapacity       | 191.4 us |  3.64 us |  4.19 us |  0.29 |    0.01 |
| AdHoc                          | 167.2 us |  3.31 us |  4.30 us |  0.26 |    0.01 |
| AdHocLinked                    | 197.5 us |  3.93 us |  4.97 us |  0.30 |    0.01 |


#### AddAndRemoveValueBenchmark

Adds specificity 0,1,5,3 then removes 1 and 3.
Note that unordered list wins in this case.

| Method                         | Mean       | Error    | StdDev   | Median     | Ratio | RatioSD |
|------------------------------- |-----------:|---------:|---------:|-----------:|------:|--------:|
| FieldBased                     | 1,320.2 us | 26.15 us | 40.72 us | 1,337.5 us |  1.00 |    0.00 |
| SortedListBased                | 1,005.0 us | 20.04 us | 30.61 us | 1,013.5 us |  0.76 |    0.04 |
| SortedListBasedDefaultCapacity |   935.4 us | 18.60 us | 23.53 us |   945.7 us |  0.71 |    0.02 |
| ListBased                      |   424.3 us |  8.33 us | 10.53 us |   428.0 us |  0.32 |    0.01 |
| AdHoc                          |   753.5 us | 14.89 us | 20.38 us |   744.6 us |  0.57 |    0.02 |
| AdHocLinked                    |   411.6 us |  8.09 us |  9.94 us |   417.8 us |  0.31 |    0.01 |


#### GetValueBenchmark

Gets the value when only the default value is present.

| Method                         | Mean      | Error     | StdDev    | Ratio | RatioSD |
|------------------------------- |----------:|----------:|----------:|------:|--------:|
| FieldBased                     | 42.699 us | 0.8508 us | 1.1927 us |  1.00 |    0.00 |
| SortedListBased                | 14.264 us | 0.2835 us | 0.3686 us |  0.33 |    0.01 |
| SortedListBasedDefaultCapacity | 14.507 us | 0.2898 us | 0.3665 us |  0.34 |    0.01 |
| ListBasedDefaultCapacity       | 16.144 us | 0.3167 us | 0.4118 us |  0.38 |    0.02 |
| AdHoc                          |  3.391 us | 0.0667 us | 0.0685 us |  0.08 |    0.00 |
| AdHocLinked                    |  2.194 us | 0.0237 us | 0.0222 us |  0.05 |    0.00 |


#### GetValueOnMultipleValuesBenchmark

Gets the value when there are 4 values in the collection.

| Method                         | Mean       | Error      | StdDev     | Ratio |
|------------------------------- |-----------:|-----------:|-----------:|------:|
| FieldBased                     | 634.341 us | 12.4684 us | 18.6622 us | 1.000 |
| SortedListBased                |  14.585 us |  0.2899 us |  0.4338 us | 0.023 |
| SortedListBasedDefaultCapacity |  14.503 us |  0.2837 us |  0.3977 us | 0.023 |
| ListBasedDefaultCapacity       |  14.008 us |  0.2719 us |  0.3985 us | 0.022 |
| AdHoc                          |   3.755 us |  0.0719 us |  0.0706 us | 0.006 |
| AdHocLinked                    |   2.225 us |  0.0229 us |  0.0214 us | 0.003 |


#### AddAndRemoveManyValues

Gets current value after each change:
- Adds 0,1,5,3
- Removes 1,3
- Adds 6,3,1
- Removes 1
- Sets 4

| Method                         | Mean       | Error     | StdDev    | Median     | Ratio |
|------------------------------- |-----------:|----------:|----------:|-----------:|------:|
| FieldBased                     | 8,485.2 us | 169.10 us | 219.88 us | 8,536.6 us |  1.00 |
| SortedListBased                | 2,804.6 us |  54.07 us |  77.55 us | 2,820.6 us |  0.33 |
| SortedListBasedDefaultCapacity | 2,762.8 us |  54.07 us |  84.19 us | 2,742.5 us |  0.33 |
| ListBased                      |   955.5 us |  18.93 us |  16.78 us |   961.8 us |  0.11 |
| AdHoc                          | 1,654.5 us |  32.45 us |  43.32 us | 1,640.6 us |  0.19 |
| AdHocLinked                    |   772.2 us |  15.22 us |  19.24 us |   759.7 us |  0.09 |
