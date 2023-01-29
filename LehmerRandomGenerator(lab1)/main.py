import tkinter as tk
import customtkinter as ctk
from GuiDrawer import *
from matplotlib.pyplot import *
from matplotlib.backends.backend_tkagg import *

app = ctk.CTk()

app.geometry("800x600")



fig = Figure(figsize = (5, 5),  dpi = 100)

canvas = FigureCanvasTkAgg(fig, master = app)
plot1 = fig.add_subplot()

label = ctk.CTkLabel(master=app, text="R0")
label.grid(row=0, column=0, sticky='w')
seed = ctk.CTkEntry(master=app, placeholder_text="R0")
seed.grid(row=0, column=1, sticky='w')


label = ctk.CTkLabel(master=app, text="m")
label.grid(row=1, column=0, sticky='w')
mod = ctk.CTkEntry(master=app, placeholder_text="m")
mod.grid(row=1, column=1, sticky='w')

label = ctk.CTkLabel(master=app, text="a").grid(row=2, column=0, sticky='w')
a = ctk.CTkEntry(master=app, placeholder_text="a")
a.grid(row=2, column=1, sticky='w')

label = ctk.CTkLabel(master=app, text="n").grid(row=3, column=0, sticky='w')
numbers_count = ctk.CTkEntry(master=app, placeholder_text="n")
numbers_count.grid(row=3, column=1, sticky='w')


periodic = ctk.CTkLabel(master=app, text="Периодичность: ")
periodic.grid(row=4, column=0, sticky='w')
aperiodic = ctk.CTkLabel(master=app, text="Апериодичность: ")
aperiodic.grid(row=5, column=0, sticky='w')
mat = ctk.CTkLabel(master=app, text="Матожидание: ")
mat.grid(row=6, column=0, sticky='w')
dis = ctk.CTkLabel(master=app, text="Дисперсия: ")
dis.grid(row=7, column=0, sticky='w')
sko = ctk.CTkLabel(master=app, text="СКО: ")
sko.grid(row=8, column=0, sticky='w')
tu = ctk.CTkLabel(master=app, text="Теоретическая вероятность: " + str(pi / 4))
tu.grid(row=9, column=0, sticky='w')
fu = ctk.CTkLabel(master=app, text="Фактическая вероятность: ")
fu.grid(row=10, column=0, sticky='w')
delta = ctk.CTkLabel(master=app, text="Разность вероятностей: ")
delta.grid(row=11, column=0, sticky='w')


button = ctk.CTkButton(master=app, text="Построить", command=lambda: button_event(float(seed.get()), float(mod.get()), float(a.get()), int(numbers_count.get()),
                                                                                            canvas, plot1, periodic, aperiodic, mat, dis, sko, fu, delta))
button.grid(row=12, column=1, sticky='w')
app.mainloop()