import pyautogui as pg
import random
import time
import sys
import threading
from PyQt5.QtWidgets import *

imgloc="./images/"
imgstart=0
imgfailed=0

def ranclick(a):
    time.sleep(random.randrange(1,3))
    pg.click(a)
    time.sleep(random.randrange(1,5))
    a=None


def E24():
    global imgstart,imgfailed
    imglist=["24E.png","commonFightButton.png","commandcenter.png","check.png","run"]
    try:
        for num in range(imgstart,len(imglist)):
            i=imglist[num]
            '''
            if i=="commandcenter.png":
                pg.move(-170,-270)
                pg.click()
                time.sleep(random.randrange(3,6))
                continue
            '''
            if i=="run":
                time.sleep(random.randrange(1,4))
                pg.click()
            print(imgloc+i)
            a=pg.locateCenterOnScreen(imgloc+i)                
            ranclick(a)
            imgfailed=0
        
    except Exception as ex:
        if imgfailed>=3:
            print("----all failed----...")
            return
        print("no image %d/%d" %(imgfailed,4))
        print("error :"+str(ex))
        time.sleep(1.4)
        imgstart=num
        imgfailed+=1
        E24()

def startthread():
    global imgstart,imgfailed
    imgstart=imgfailed=0
    t=threading.Thread(target=E24)
    t.start()
class MyApp(QWidget):

    def __init__(self):
        super().__init__()
        self.layout=QVBoxLayout()
        self.button=QPushButton("2-4E")
        self.button.clicked.connect(startthread)
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
    
