import cv2 as cv
from tkinter import *
from PIL import ImageTk, Image
from copy import deepcopy


class MainSolution():
    def __init__(self):
        self.image = cv.imread("ede2a664-8a75-46c9-8010-ca081647c96f.jpg")
        self.imgray = None
        self.trsh1 = None
        self.trsh2 = None

    def original(self):
        img = Image.fromarray(self.image)
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)

    def filt(self):
        self.imgray = cv.cvtColor(cv.pyrMeanShiftFiltering(
            self.image, 15, 50), cv.COLOR_BGR2GRAY)
        img = Image.fromarray(self.imgray)
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)

    def adaptive(self):
        self.imgray = cv.cvtColor(cv.pyrMeanShiftFiltering(
            self.image, 15, 50), cv.COLOR_BGR2GRAY)
        img = Image.fromarray(cv.adaptiveThreshold(self.imgray, 255, cv.ADAPTIVE_THRESH_MEAN_C, cv.THRESH_BINARY, 11, 2))
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)

    def local(self):
        self.imgray = cv.cvtColor(cv.pyrMeanShiftFiltering(
            self.image, 15, 50), cv.COLOR_BGR2GRAY)
        img = Image.fromarray(cv.medianBlur(self.imgray, 5))
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)

    def Nonlinearity(self):
        self.imgray = cv.cvtColor(cv.pyrMeanShiftFiltering(
            self.image, 15, 50), cv.COLOR_BGR2GRAY)
        img = Image.fromarray(cv.bilateralFilter(self.imgray, 9, 75, 75))
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)

    def gaussian(self):
        self.imgray = cv.cvtColor(cv.pyrMeanShiftFiltering(
            self.image, 15, 50), cv.COLOR_BGR2GRAY)
        img = Image.fromarray(cv.GaussianBlur(self.imgray, (5, 5), 0))
        img = img.resize((300, 300))
        return ImageTk.PhotoImage(img)



class Gui:
    def __init__(self, master):
        self.master = master
        self.master.title("Image Processing")
        self.master.geometry("900x400")
        self.master.resizable(False, False)
        self.master.configure(background='white')
        self.solution = MainSolution()

        self.frame = Frame(self.master, bg='white')
        self.frame.pack()

        self.button1 = Button(self.frame, text="Original", font=( "Helvetica", 15), bg='white', command=self.original)
        self.button1.grid(row=1, column=0, padx=10, pady=10)

        self.button2 = Button(self.frame, text="Filt", font=( "Helvetica", 15), bg='white', command=self.filt)
        self.button2.grid(row=2, column=0, padx=10, pady=10)

        self.button3 = Button(self.frame, text="Adaptive", font=( "Helvetica", 15), bg='white', command=self.adaptive)
        self.button3.grid(row=3, column=0, padx=10, pady=10)

        self.button4 = Button(self.frame, text="Local", font=( "Helvetica", 15), bg='white', command=self.local)
        self.button4.grid(row=4, column=0, padx=10, pady=10)

        self.button5 = Button(self.frame, text="Nonlinearity", font=( "Helvetica", 15), bg='white', command=self.Nonlinearity)
        self.button5.grid(row=5, column=0, padx=10, pady=10)

        self.button6 = Button(self.frame, text="Gaussian", font=( "Helvetica", 15), bg='white', command=self.gaussian)
        self.button6.grid(row=6, column=0, padx=10, pady=10)

        self.label1 = Label(self.frame, text="Result Image", font=(
            "Helvetica", 15), bg='white')

        self.label1.grid(row=0, column=1, padx=10, pady=10)

        self.image1 = self.solution.original()
        self.label2 = Label(self.frame, image=self.image1, bg='white')
        self.label2.grid(row=1, column=1, rowspan=6, padx=10, pady=10)

        self.image2 = self.solution.original()
        self.label4 = Label(self.frame, image=self.image2, bg="white")
        self.label4.grid(row=1, column=2, rowspan=6, padx=10, pady=10)


    def original(self):
        self.image1 = self.solution.original()
        self.label2.configure(image=self.image1)
        self.label2.image = self.image1

    def filt(self):
        self.image1 = self.solution.filt()
        self.label2.configure(image=self.image1)
        self.label2.image = self.image1

    def adaptive(self):
        self.image1 = self.solution.adaptive()
        self.label2.configure(image=self.image1)
        self.label2.image = self.image1

    def local(self):
        self.image1 = self.solution.local()
        self.label2.configure(image=self.image1)
        self.label2.image = self.image1

    def Nonlinearity(self):
        self.image1 = self.solution.Nonlinearity()
        self.label2.configure(image=self.image1)
        self.label2.image = self.image1

    def gaussian(self):
        self.image1 = self.solution.gaussian()
        self.label2.configure(image=self.image1)
        self.label2.image = self.image1


if __name__ == "__main__":
    root = Tk()
    Gui(root)
    root.mainloop()




