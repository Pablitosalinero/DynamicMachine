# Algorithm explanation

## Coins type

|  1  | 2 | 5 | 10 | 20 | 50 | 100 |
|-----|---|---|----|----|----|-----|

## Coins limit

|  1  | 2 | 5 | 10 | 20 | 50 | 100 |
|-----|---|---|----|----|----|-----|
| 100 | 3 | 4 | 1  |  2 |  5 |  1  |

## Table

a[i][j] = MIN(a[i][j-1], i/j + a[i%j][j-1])

|           | 0 | 1 | 2 | 3 | 4 | 5 | 6 |
|-----------|---|---|---|---|---|---|---|
| [1]       | 0 | 1 | 2 | 3 | 4 | 5 | 6 |
| [1, 2]    | 0 | 1 | 0 | 0 | 0 | 0 | 3 |
| [1, 2, 5] | 0 | 0 | 0 | 0 | 0 | 0 | 2 |

# TODO
## Common
- [ ] Complete explanation with git
## :snake: Python
- [x] Implement Algorithm
- [ ] Create examples
- [ ] Create tests
- [ ] Create package to [pip](https://packaging.python.org/tutorials/packaging-projects/)
- [ ] Create instalation guide
- [ ] Implement multithreading
## :ocean: C# 
- [x] Implement Algorithm
- [ ] Create examples
- [x] Create tests
- [ ] Create nuget package
- [ ] Create instalation guide
- [x] Implement multithreading
- [ ] Improve multithreading
