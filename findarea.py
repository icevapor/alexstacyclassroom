import pyautogui
import time
import keyboard
#starting x = 1145
#ending x = 1157
#region=(780, 500, 610, 550)
##time.sleep(5)
##keyboard.press('right')
##time.sleep(1)
##keyboard.release('right')

iml = pyautogui.screenshot(region=(780, 300, 610, 550))
iml.save(r"C:\Users\BURT\Documents\Python Scripts\gamearea.png")
