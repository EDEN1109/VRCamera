# VRCamera
VRCamera was developed to make it easy to change the platform of VR contents such as mobile, tablet, Google Cardboard, and PC.

This ReadMe file explains the usage and development process of VRCamera.

### Index
- [Languages ​​supported by ReadMe](#Languages-supported-by-ReadMe)
- [How to Use](#How-to-Use)
	- [How to Set up a Camera](#How-to-Set-up-a-Camera)
	- [What is mean of OnReticleEnter, OnReticleStay, etc](#What-is-mean-of-OnReticleEnter,-OnReticleStay,-etc)
	- [How to Set up an Interactive Item or UI](#How-to-Set-up-an-Interactive-Item-or-UI)
	- [How to Change the Platform](#How-to-Change-the-Platform)
	- [Easily changeable options](#Easily-changeable-options)
- [What is the development process](#What-is-the-development-process)
	- 

# Languages ​​supported by ReadMe

List of languages ​​supported by the ReadMe file.
The default language is set to English, and you can click the link to view the ReadMe file in a supported language.

ReadMe 파일이 지원하는 언어 목록입니다.
기본 언어는 영어로 설정되어 있으며, 링크를 클릭해 지원하는 언어로 ReadMe 파일을 볼 수 있습니다.

- [한글 README 바로가기](READMES/README_kr.md)
- [Go to English version README](README.md)

# How to Use
This chapter explains what users must know to use VRCamera.

## How to Set up a Camera
Simply,
1. Remove the existing "MainCamera"
2. Find "Player" from the Prefabs folder
![Player prefab locate](https://drive.google.com/uc?export=download&id=18GIv8DUrRnk_Z80x7uoq5RlfeN-wxa7o)
3. Add "Player" to the Scene.
![This is Example](https://drive.google.com/uc?export=download&id=1b4p1hWegZrOLYj3hXfT0jVUJQ53RMqbI)

Now You can use VRCamera!

## What is mean of OnReticleEnter, OnReticleStay, etc
- OnReticleEnter
The central Reticle enters the object's Collider area.
- OnReticleStay
The central Reticle stays in the object's Collider area.
- OnReticleExit
The central Reticle exits the object's Collider area.
- OnReticleFullFilled
The central Reticle is now filled in the object's Collider area.
> Mouse option is only available on PC and Unity Editor.
> There are two types of mouse events: applied to "Player" or an object.
> 
> The contents of parentheses are for the event applied to the object.
- OnMouseClick
Click the mouse once (while looking at the object).
- OnMouseDoubleClick
Double-click the mouse (while looking at the object).
- OnMouseUp
Release mouse click (while looking at object).
- OnMouseDown
Push the mouse (while looking at the object).

## How to Set up an Interactive Item or UI
Interactive item and UI do not differ in script.
But use different scripts that override the same parent to separate the two objects from each other.

You can modify each script to give the difference between objects.

> The item or UI must have a collider with IsTrigger false.
> If the item or UI doesn't have a collider, you can't add a script.

1. Add VRInteractiveItem or VRInteractiveUI script to your items.
 ![Script locate](https://drive.google.com/uc?export=download&id=1u6SdHlEAq_qcdmN3tXMHAsdIzub1G6XO) ![Script locate](https://drive.google.com/uc?export=download&id=1ei8FFNrWoT2j5_eM4KMc5Qn8XGfTVe07)
2. Create or Add Events to the appropriate UnityEvents(OnReticleEnter, OnReticleStay, etc).
![How to Add](https://drive.google.com/uc?export=download&id=19I2FvB_XSB2OqH2XtPhOHRmQN5Zihgkf =400x550)  ![How to Add](https://drive.google.com/uc?export=download&id=1nwVtUebbHDk5x3LsNfxGSyPdU0EyAsIr =400x550)

## How to Change the Platform
There is two way.

**First**, Change platform before running
1. Click on "Player" in the scene.
2. Change Platforms in "PlaygroundManager" script.
![Select Platform](https://drive.google.com/uc?export=download&id=1jZ6qeD8JWPG5WbUi1prdJJbSh8q7GvIB)

**Second**, Change platform while running
1. Find "SwitchPlatforms" script.
![Script locate](https://drive.google.com/uc?export=download&id=1Pg7_T7BkOiKEoAgB1CN_bV_IRTRNuCdY)
2. Add "SwitchPlatforms" script to anything you want.
3. Set "PlaygroundManager" of "SwitchPlatforms" script to the "Player"'s "PlaygroundManager".
![Set PlaygroundManager](https://drive.google.com/uc?export=download&id=1P8olxwRJW4_Td_846-oo-YSznNNyrCsq)
4. Add "VRInteractiveItem" or "VRInteractiveUI" script to Item or UI.
5. Add Events to the appropriate UnityEvents(OnReticleEnter, OnReticleStay, etc).
6. Set the object to the object to which "SwitchPlatforms" script was added.
![Set Object](https://drive.google.com/uc?export=download&id=1S1MfPYW2KgBMg43s7wZQnXZlNEPFFweI)
7. Set the  Event to one of the OnClick Events of "SwitchPlatforms" script.
![Set Event](https://drive.google.com/uc?export=download&id=18_HHYBuGG_yk75O3WPRr6ZWf8mSfIpqk)

## Easily changeable options
There are options that can be adjusted by simply changing the check status or value.

**VRInteractive(Item or UI)**
- You can change whether this object is clickable or not.
- Check "Can Mouse Click" option if you want the object to be clickable.
![VRInteractive Set](https://drive.google.com/uc?export=download&id=1o6u5dokntVd5s-A-VSO2VxMbgk1xbBUi)

**VRInput**
- You can change the time interval that recognizes your mouse click as a double-click.
- "Double Click Time" means the time interval between clicks that distinguish whether your click is a double click or not.
![VRInput Set](https://drive.google.com/uc?export=download&id=1ED_F9rk6-CTuxlTxkXrVXpAGKOVaeG3g)

**Reticle**
- You can change the amount of time it takes to fill a reticle.
- "Time to Filmed" means the seconds it takes for a reticle to fill.
![Reticle Set](https://drive.google.com/uc?export=download&id=1opWiT1r01j_qtWD2qwHgcYTW_227JLiN)

**VREyeRaycaster**
- You can set options related to "Debug Ray" and "Ray".
- If "Show Debug Ray" is unchecked, the Debug Ray will no longer work.
- "Debug Ray Length" means the length of "Debug Ray".
- "Debug Ray Duration" means the duration of "Debug Ray"
- "Ray Length" means the length of "Ray".
![VREyeRaycaster Set](https://drive.google.com/uc?export=download&id=1ocWujDjwOihGJlzOtVf1kkleok-t8O5g)

# What is the development process
