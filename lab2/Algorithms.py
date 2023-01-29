from math import *


def lehmer_random_numbers(a, m, r, n):
    numbers = []
    for i in range(n):
        r = (r * a) % m
        el = r / m
        numbers.append(el)

    return numbers


def generate_uniform_distribution(a, b, n, lehmer):
    numbers = []
    for i in range(n):
        number = a + (b - a) * lehmer[i]
        numbers.append(number)

    mean = sum(numbers) / len(numbers)
    dispersion = 0
    for i in range(len(numbers)):
        dispersion += (numbers[i] - mean) ** 2

    sko = sqrt(dispersion)
    return numbers, mean, dispersion, sko


def generate_exponential_distribution(lamb, n):
    numbers = []
    rs = lehmer_random_numbers(7, 209715120, 3, n)
    for i in range(n):
        number = -1 / lamb * log(rs[i])
        numbers.append(number)
    mean = sum(numbers) / len(numbers)
    dispersion = 0
    for i in range(len(numbers)):
        dispersion += (numbers[i] - mean) ** 2

    sko = sqrt(dispersion)
    return numbers, mean, dispersion, sko


def generate_triangle_distribution(a, b, n):
    numbers = []
    rs1 = lehmer_random_numbers(3, 209715120, 7, n)
    rs2 = lehmer_random_numbers(7, 209715120, 3, n)
    for i in range(n):
        number = a + (b - a) * (rs1[i] if rs1[i] > rs2[i] else rs2[i])
        numbers.append(number)
    mean = sum(numbers) / len(numbers)
    dispersion = 0
    for i in range(len(numbers)):
        dispersion += (numbers[i] - mean) ** 2

    sko = sqrt(dispersion)
    return numbers, mean, dispersion, sko


def generate_simson_distribution(a, b, n):
    numbers = []
    l1 = lehmer_random_numbers(7, 209715120, 3, n)
    l2 = lehmer_random_numbers(3, 209715120, 7, n)
    rs1, _, _, _ = generate_uniform_distribution(a/2, b/2, n, l1)
    rs2, _, _, _ = generate_uniform_distribution(a/2, b/2, n, l2)
    for i in range(n):
        number = rs1[i] + rs2[i]
        numbers.append(number)

    mean = sum(numbers) / len(numbers)
    dispersion = 0
    for i in range(len(numbers)):
        dispersion += (numbers[i] - mean) ** 2

    sko = sqrt(dispersion)
    return numbers, mean, dispersion, sko


def generate_gaussian_distribution(m, sigma, n):
    numbers = []
    rs = lehmer_random_numbers(7, 209715120, 3, n)
    counter = 0
    for i in range(n):
        s = 0
        for j in range(6):
            s = s + rs[int(counter % n)]
            counter += 1
        number = abs(m + sigma * sqrt(2) * (s - 3))
        numbers.append(number)

    mean = sum(numbers) / len(numbers)
    dispersion = 0
    for i in range(len(numbers)):
        dispersion += (numbers[i] - mean) ** 2

    sko = sqrt(dispersion)
    return numbers, mean, dispersion, sko


def generate_gamma_distribution(lam, et, n):
    numbers = []
    rs = lehmer_random_numbers(7, 209715120, 3, n)
    counter = 0
    for i in range(0, n):
        multyply = 1
        for j in range(1, round(et) + 1):
            multyply = multyply * rs[int((j + counter) % n)]
            counter += 1
        number = - 1 / lam * log(multyply, e)
        numbers.append(number)
    mean = et / lam
    dispersion = et / (lam ** 2)
    sko = sqrt(dispersion)
    return numbers, mean, dispersion, sko
