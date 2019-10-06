import pyautogui as pg
import random
import time
import sys
from PyQt5.QtWidgets import *

imgloc="./images/"

def ranclick(a):
    time.sleep(random.randrange(1,3))
    pg.click(a)
    time.sleep(random.randrange(1,2))


def E24():    
    try:
        a=pg.locateCenterOnScreen(imgloc+"24E.png")
        ranclick(a)
        a=pg.locateCenterOnScreen(imgloc+"commonFightButton.png")
        ranclick(a)
        
    except Exception as ex:
        print("no image")
        print("error :"+str(ex))

class MyApp(QWidget):

    def __init__(self):
        super().__init__()
        self.layout=QVBoxLayout()
        self.button=QPushButton("2-4E")
        self.button.clicked.connect(E24)
        self.initUI()

    def initUI(self):

        self.setWindowTitle('GF-macro')
        self.move(300, 300)
        self.resize(400, 200)
        self.layout.addWidget(self.button)
        self.setLayout(self.layout)
        self.show()


if __name__ == '__main__':

    app = QApplication(sys.argv)
    ex = MyApp()
    sys.exit(app.exec_())
    
