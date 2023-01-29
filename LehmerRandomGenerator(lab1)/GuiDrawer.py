import matplotlib.pyplot as plt

from  MathOperations import *


def button_event(r, m, a, n, canvas, fig, periodic, aperiodic, mat, dis, sko, fu, delta):

    # hash = { 'r': 508656626642567.0, 'm': 1234532532352.0, 'a': 134568654252.0, 'n': 109000}

    seeds = list(lehmer_random_numbers(a, m, r, n))

    fu_text, delta_text = indirect_signs_checking(seeds)

    mat_text, dis_text, sko_text = numerical_characteristics_estimation(seeds)
    aperiodic_text, periodic_text = aperiodic_interval_and_period(seeds)
    periodic.set_text("Периодичность: " + periodic_text)
    aperiodic.set_text("Апериодичность: " + aperiodic_text)
    mat.set_text("Матожидание: " + mat_text)
    dis.set_text("Дисперсия: " + dis_text)
    sko.set_text("СКО: " + sko_text)
    fu.set_text("Фактическая вероятность: " + fu_text)
    delta.set_text("Разность вероятностей: " + delta_text)

    show_results(seeds)


def show_results(seeds):
    plt.hist(seeds, bins=20, rwidth=0.6)
    plt.show()

