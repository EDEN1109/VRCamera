# VRCamera
VRCamera was developed to make it easy to change the platform of VR contents such as mobile, tablet, Google Cardboard, and PC.

This ReadMe file explains the usage and development process of VRCamera.

### Index
- [Languages ​​supported by ReadMe](#Languages-supported-by-ReadMe)
- [How to Use](#How-to-Use)
	- [How to Set up a Camera?](#How-to-Set-up-a-Camera?)
	- [What is mean of OnRecticleEnter, OnRecticleStay, etc?](#What-is-mean-of-OnRecticleEnter,-OnRecticleStay,-etc?)
	- [How to Set up an Interactive Item or UI?](#How-to-Set-up-an-Interactive-Item-or-UI?)
	- [How to Change the Platform?](#How-to-Change-the-Platform?)
- [What is the development process?](#What-is-the-development-process?)
	- 

## Languages ​​supported by ReadMe

List of languages ​​supported by the ReadMe file.
The default language is English, and you can click the link to view the ReadMe file in a supported language.

ReadMe 파일이 지원하는 언어 목록입니다.
기본 언어는 영어로 설정되어 있으며, 링크를 클릭해 지원하는 언어로 ReadMe 파일을 볼 수 있습니다.

- [한글 README 바로가기](READMES/README_kr.md)
- [Go to English version README](README.md)

## How to Use

### How to Set up a Camera?
Simply,
1. Remove the existing "MainCamera"
2. Find "Player" from the Prefabs folder
![Player prefab locate](https://drive.google.com/uc?export=download&id=18GIv8DUrRnk_Z80x7uoq5RlfeN-wxa7o)
3. Add "Player" to the Scene.
![This is Example](https://drive.google.com/uc?export=download&id=1b4p1hWegZrOLYj3hXfT0jVUJQ53RMqbI)

Now You can use VRCamera!

### What is mean of OnRecticleEnter, OnRecticleStay, etc?


### How to Set up an Interactive Item or UI?
> The item or UI must have a collider with IsTrigger false.
> If the item or UI doesn't have a collider, you can't add a script.

1. Add VRInteractiveItem or VRInteractiveUI script to your items.
 ![Script locate](https://drive.google.com/uc?export=download&id=1u6SdHlEAq_qcdmN3tXMHAsdIzub1G6XO) ![Script locate](https://drive.google.com/uc?export=download&id=1ei8FFNrWoT2j5_eM4KMc5Qn8XGfTVe07)
2. Create or Add Events to the appropriate UnityEvents(OnRecticleEnter, OnRecticleStay, etc).
![How to Add](https://drive.google.com/uc?export=download&id=19I2FvB_XSB2OqH2XtPhOHRmQN5Zihgkf =400x550)  ![How to Add](https://drive.google.com/uc?export=download&id=1nwVtUebbHDk5x3LsNfxGSyPdU0EyAsIr =400x550)

### How to Change the Platform?
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
5. Add Events to the appropriate UnityEvents(OnRecticleEnter, OnRecticleStay, etc).
6. Set the object to the object to which "SwitchPlatforms" script was added.
![Set Object](https://drive.google.com/uc?export=download&id=1S1MfPYW2KgBMg43s7wZQnXZlNEPFFweI)
7. Set the  Event to one of the OnClick Events of "SwitchPlatforms" script.
![Set Event](https://drive.google.com/uc?export=download&id=18_HHYBuGG_yk75O3WPRr6ZWf8mSfIpqk)


## What is the development process?
