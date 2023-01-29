from GuiDrawer import show_results
from Algorithms import *


def run_triangle_distribution():
    a = float(input('a: '))
    b = float(input('b: '))
    count = int(input('Count: '))
    vect, mean, dispersion, deviation = generate_triangle_distribution(a, b, count)
    print("Mean: " + str(mean))
    print("Dispersion: " + str(dispersion))
    print("Deviation: " + str(deviation))
    show_results(vect)


def run_simpson_distribution():
    a = int(input('a: '))
    b = int(input('b: '))
    count = int(input('Count: '))
    vect, mean, dispersion, deviation = generate_simson_distribution(a, b, count)
    print("Mean: " + str(mean))
    print("Dispersion: " + str(dispersion))
    print("Deviation: " + str(deviation))
    show_results(vect)


def run_uniform_distribution():
    a = float(input('a: '))
    b = float(input('b: '))
    count = int(input('Count: '))
    vect, mean, dispersion, deviation = generate_uniform_distribution(a, b, count,
                                                                      lehmer_random_numbers(7, 209715120, 3, count))
    print("Mean: " + str(mean))
    print("Dispersion: " + str(dispersion))
    print("Deviation: " + str(deviation))
    show_results(vect)


def run_gaussian_distribution():
    m = float(input('m: '))
    sigma = float(input('sigma: '))
    count = int(input('Count: '))
    vect, mean, dispersion, deviation = generate_gaussian_distribution(m, sigma, count)
    print("Mean: " + str(mean))
    print("Dispersion: " + str(dispersion))
    print("Deviation: " + str(deviation))
    show_results(vect)


def run_exponential_distribution():
    lyambda = float(input('lambda: '))
    count = int(input('Count: '))
    vect, mean, dispersion, deviation = generate_exponential_distribution(lyambda, count)
    print("Mean: " + str(mean))
    print("Dispersion: " + str(dispersion))
    print("Deviation: " + str(deviation))
    show_results(vect)


def run_gamma_distribution():
    lyambda = float(input('lambda: '))
    eta = float(input('eta: '))
    count = int(input('Count: '))
    vect, mean, dispersion, deviation = generate_gamma_distribution(lyambda, eta, count)
    print("Mean: " + str(mean))
    print("Dispersion: " + str(dispersion))
    print("Deviation: " + str(deviation))
    show_results(vect)


DISTRIBUTION_CASES = {
    '1': lambda: run_uniform_distribution(),
    '2': lambda: run_gaussian_distribution(),
    '3': lambda: run_exponential_distribution(),
    '4': lambda: run_gamma_distribution(),
    '5': lambda: run_triangle_distribution(),
    '6': lambda: run_simpson_distribution(),
}


def print_menu():
    print('''
        1 - Uniform
        2 - Gaussian
        3 - Exponential
        4 - Gamma
        5 - Triangle
        6 - Simpson
        0 - Exit
    ''')


choice = None
while choice != '0':
    print_menu()
    choice = input()
    if choice in DISTRIBUTION_CASES:
        DISTRIBUTION_CASES[choice]()
    elif choice == '0':
        print('Exiting...')