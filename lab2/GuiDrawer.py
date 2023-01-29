import matplotlib.pyplot as plt


def show_results(seeds):
    plt.hist(seeds, bins=20, rwidth=0.6)
    plt.show()