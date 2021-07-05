from pyautogui import *
import pyautogui
import time
import keyboard
import random
import win32api, win32con
#fullregion = region=(780, 140, 610, 910)
#halfregion = region=(780, 500, 610, 550)
#green platform rgb (105 - 125, 185 - 193, 25  - 30) 
#doodle jumper rgb (206 - 215, 204 - 212, 40- 84)
#doodle jumper speed = 486px/s
#doodle jumper start x pos = 307
#Goals: Optimization and dealing with more complicated higher elevation scenarios
#Site used to play game: https://poki.com/en/g/doodle-jump

doodle_x = 307
doodle_y = 0
greenplat_x = 0
greenplat_y = 0
sleep(3)

def getDoodlePos():
    pic = pyautogui.screenshot(region=(780, 300, 610, 550))
    width = pic.width - 1
    height = pic.height - 1
    for y in range(height, 0, -10):
        for x in range(width, 0, -20):
            r, g, b = pic.getpixel((x, y))
            if r in range(206, 220) and b in range(40, 85):
                doodle_x = x
                doodle_y = y
                print("DoodlePos: ", doodle_x, doodle_y)
                return doodle_x, doodle_y
            
#^^^ Returns doodle position

##def getDoodleY(doodle_x):
##    pic = pyautogui.screenshot(region=(780, 300, 610, 550))
##    width = pic.width - 1
##    height = pic.height - 1
##    for y in range(height, 0, -5):
##        r, g, b = pic.getpixel((doodle_x, y))
##        if r in range(206, 220) and b in range(40, 85):
##            return y

#^^^ Meant to find just the y position more efficiently than getDoodlePos, broken for now            
def getGreenPlatPos():
    pic = pyautogui.screenshot(region=(780, 300, 610, 550))
    width = pic.width - 1
    height = pic.height - 1
    for y in range(height, 320, -10):
        for x in range(width, 0, -10):
            r, g, b = pic.getpixel((x, y))
            if g in range(185, 195) and b in range(0, 30):
                greenplat_x = x
                greenplat_y = y
                print("PlatPos: ", greenplat_x)
                return greenplat_x, greenplat_y
                
#^^^ Returns lowest elevation green platform position
            
#doodle_x, doodle_y = getDoodlePos()

while keyboard.is_pressed('q') == False:
    greenplat_x, greenplat_y = getGreenPlatPos()
    doodle_y = 0
    start_doodle_y = 0
    try:
        doodle_x, start_doodle_y = getDoodlePos()
    except TypeError:
        doodle_x = 307
        start_doodle_y = 0
    
    #^^^Get green platform pos, starting doodle pos
    time.sleep(0.05)
    try:
        doodle_x, doodle_y = getDoodlePos()
    except TypeError:
        doodle_y = 0
        
    falling = True
    if doodle_y < start_doodle_y:
        falling = False
    #^^^ If doodle is falling, wait until he is not falling to attempt to move
    #^^^ For some reason, a higher y value is lower on the screen
    distance = doodle_x - greenplat_x

    if falling == False:
        if doodle_x - greenplat_x > 500:
            distance = 610 - doodle_x
            travel_time = (distance / 500)
            keyboard.press('right')
            time.sleep(travel_time)
            keyboard.releae('right')

        elif greenplat_x - doodle_x > 500:
            distance = 610 - greenplat_x
            travel_time = (distance / 500)
            keyboard.press('left')
            time.sleep(travel_time)
            keyboard.releae('left')

        #^^^ These two blocks are for when the doodle needs to go offscreen to reach a plat            

        elif doodle_x > greenplat_x and distance not in range(-20, 20):
            distance = doodle_x - greenplat_x
            travel_time = (distance / 500)
            keyboard.press('left')
            time.sleep(travel_time)
            keyboard.release('left')

        elif doodle_x < greenplat_x and distance not in range(-20, 20):
            distance = greenplat_x - doodle_x
            travel_time = (distance / 500)
            keyboard.press('right')
            time.sleep(travel_time)
            keyboard.release('right')
            time.sleep(0.2)

        #^^^ These two blocks are for standard movement
