A skill which reveals nearby creatures' HP bars (and optionally other players), shows them on the minimap, and increases detection range based on your skill level.

New Skill "Third Eye" rewards players the longer they play on your server or their world with levels. They level up just by the days passing! Two times per in-game day to earn exp. Morning and Evening trigger experience gain.
The higher the level, the bigger the radius of the ping.

`NOTE:` They only level up if they are on when the day passes. Meaning, they will not randomly gain levels if they haven't played in a few days. (Defaults are intended for balanced, vanilla-like gameplay. Adjustments may cause problems, including glitches or loss of fun.)

`﻿Must be installed on both the client and the server for syncing to work properly. Not required on server.`

> ## Configuration Options

* Base Detection Range [Synced with Server]
    * How far you can see an enemy's health bar by default. Keep in mind that a very large value will not allow you to see enemies unloaded from the game due to distance.
* Skill Multiplier   [Synced with Server]
    * How much to multiply the increase in detection range granted by Third Eye skill level. A multiplier of 1 grants 30 additional meters of range at Third Eye 100, for a total of 60 meters. A multiplier of 5 would grant 150 additional meters, and so on.
* Stamina Drain [Synced with Server]
    * How much stamina to drain when using the skill. By default this is 70, rather large to make the game balanced. Setting this to 0 would cause no drain to occur.
* Message Color [Not Synced with Sever]
    * Customize the color of the message with a hex code.
* Visual Effect Color [Not Synced with Sever]
    * Customize the color of the visual effect with a hex code. Must reboot game for this to take effect.
* Minimap Zoom Level [Not Synced with Server]
    * Zoom level of the minimap, default value allows 2 additional zoom levels. Play around with this setting to get your desired effects.
* Show Message [Not Synced with Server]
    * When using the ability, show a message confirming how many creatures are nearby.
* Visual Effect [Not Synced with Server]
    * Show an expanding circle upon using the ability, representing the detection range.
* Audio Effect [Not Synced with Server]
    * Play a shwimsical sound when using the ability. Can be heard by other players.
* Minimap Icons [Not Synced with Server]
    * Show detected enemies on the minimap.
* Additional Zoom [Not Synced with Server]
    * Lets you zoom in two additional steps on the minimap.
* Custom Keybind [Not Synced with Server]
    * If you really don't like pressing C while crouching. Change the bind to something else.
* Custom Message [Not Synced with Server]
    * Set a custom message if you'd like. Example: Detected # enemies nearby. (# will be replaced with the number of enemies detected.
* Player Detection [Synced with Server]
    * Should the ping be able to detect other players?
* Skill gain factor [Synced with Server]
    * The rate at which you gain experience for the skill.
* Skill effect factor [Synced with Server]
    * The power of the skill, based on the default power.


> ## Installation Instructions
***You must have BepInEx installed correctly! I can not stress this enough.***

#### Windows (Steam)
1. Locate your game folder manually or start Steam client and :
   a. Right click the Valheim game in your steam library
   b. "Go to Manage" -> "Browse local files"
   c. Steam should open your game folder
2. Extract the contents of the archive into the game folder.
3. Locate Azumatt.ThirdEye.cfg under BepInEx\config and configure the mod to your needs

#### Server

`﻿Must be installed on both the client and the server for syncing to work properly.`
1. Locate your main folder manually and :
   a. Extract the contents of the archive into the main folder that contains BepInEx
   b. Launch your game at least once to generate the config file needed if you haven't already done so.
   c. Locate Azumatt.ThirdEye.cfg under BepInEx\config on your machine and configure the mod to your needs
2. Reboot your server. All clients will now sync to the server's config file even if theirs differs. Config Manager mod changes will only change the client config, not what the server is enforcing.


`Feel free to reach out to me on discord if you need manual download assistance.`


# Author Information

### Azumatt

`DISCORD:` Azumatt#2625

`STEAM:` https://steamcommunity.com/id/azumatt/﻿


For Questions or Comments, find me in the Odin Plus Team Discord or in mine:

[![https://i.imgur.com/XXP6HCU.png](https://i.imgur.com/XXP6HCU.png)](https://discord.gg/Pb6bVMnFb2)
<a href="https://discord.gg/pdHgy6Bsng"><img src="https://i.imgur.com/Xlcbmm9.png" href="https://discord.gg/pdHgy6Bsng" width="175" height="175"></a>


## Inspiration/Original Mod Author

### KodaichiZero
`Nexus Profile:` https://www.nexusmods.com/valheim/users/95848023
