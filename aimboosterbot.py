from pyautogui import *
import pyautogui
import time
import keyboard
import random
import win32api, win32con
#Top speed approx 6.4 targets/second
#Site used: http://www.aimbooster.com/

time.sleep(4)
#(255, 219, 195)
def click(x, y):
    win32api.SetCursorPos((x, y))
    win32api.mouse_event(win32con.MOUSEEVENTF_LEFTDOWN, 0, 0)
    time.sleep(0.05) #Pause for 0.01 seconds
    win32api.mouse_event(win32con.MOUSEEVENTF_LEFTUP, 0, 0)

while keyboard.is_pressed('q') == False:
    pic = pyautogui.screenshot(region=(647, 320, 633, 500))
    width, height = pic.size
    for x in range(0, width, 15):
        for y in range(0, height, 15):
            r,g,b = pic.getpixel((x, y))
            if b == 195:
                click(x + 647, y + 320)
                time.sleep(0.04)
                #break
