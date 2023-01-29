from functools import reduce
from math import pi, fabs, sqrt
from statistics import mean

def lehmer_random_numbers(a, m, r, n):
    numbers = []
    for i in range(n):
        r = (r * a) % m
        el = r / m
        numbers.append(el)

    return numbers


def numerical_characteristics_estimation(numbers):
    mate_expectation = mean(numbers)
    coefficient = 1 / (len(numbers) - 1)
    dispersion = coefficient * reduce(lambda acc, x: acc + (x - mate_expectation) ** 2, numbers, 0)
    mean_squared_deviation = sqrt(dispersion)
    return str(mate_expectation), str(dispersion), str(mean_squared_deviation)


def indirect_signs_checking(numbers):
    pairs = zip(numbers[::2], numbers[1::2])
    valid_pair_count = sum(a ** 2 + b ** 2 < 1.0 for a, b in pairs)
    actual_probability = valid_pair_count * 2 / len(numbers)
    delta = fabs(THEORETICAL_PROBABILITY - actual_probability)
    return str(actual_probability), str(delta)


def aperiodic_interval_and_period(numbers):
    last_index = len(numbers) - 1
    last = numbers.pop()
    no_period = 0
    for i, value in reversed(list(enumerate(numbers))):
        if last == value:
            no_period = i
            break
    period = len(numbers) - no_period
    numbers.append(last)
    aperiodic_interval = 0
    print(last)
    print(numbers)
    print(period)
    first = numbers[0]
    all = []

    for i, value in (enumerate(numbers)):
        if value in all:
            aperiodic_interval = len(all)
            break
        else:
            all.append(value)
    return str(aperiodic_interval), str(period)


