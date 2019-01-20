# Unity_SaveSystem
easy save system made for unity with c#. 
Attach KayıtDüzenleyici.cs to a GameObject in Hierarchy and insert the objects that you want to save to Cisimler array. This script only saves positions as vector3 of the objects.

Saved data will be located in Save folder created by script under assets folder when running in editor and ProjectName_Data folder when running a built version. Inside Save folder the script creates a Değişkenler.txt file to save data. You can delete the save file to recreate saves. 

Use GenelKayıt() to save the game an GenelYükle() to load.
