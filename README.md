# IsraWare Microgame Template

If you have any questions, contact via Gmail or Discord!

Discord: yoavtc <br>
Gmail: yoavtc2004@gmail.com

---

## List of existing Microgames:

|   Microgame   |  ID   |   Credit(s)   |   Date Added   |
| ------------  | ----- | ------------- | -------------- |
| 🏓 Play Matkot on the Beach | `matkot` | [YoavTC](https://github.com/YoavTC) | 10/03/2025 |
| 🪑 Throw Keter Chair at Ars | `throwKeterChair` | [YoavTC](https://github.com/YoavTC) | 15/03/2025 |
| 🏷️ Sort Kosher Food | `sortKosherFood` | [YoavTC](https://github.com/YoavTC) | 19/03/2025 |
| 🎹 HaTikva Rhythm Game | `rhythm` | [YoavTC](https://github.com/YoavTC) | 24/03/2025 |
| 📢 Gather Protestors | `gatherProtestors` | [YoavTC](https://github.com/YoavTC) | 25/03/2025 |
| 🍺 Beer Pouring | `pourBeer` | [YoavTC](https://github.com/YoavTC) | 26/03/2025 |
| 🌊 Split Red Sea | `splitRedSea` | [YoavTC](https://github.com/YoavTC) | 31/03/2025 |
| 🚀 Type Airstrike Missle Code | `airstrikeTyping` | [YoavTC](https://github.com/YoavTC) | 02/04/2025 |
| 🦵 Rip Nebuchadnezzar II's limbs | `ripNebuchadnezzar` | [YoavTC](https://github.com/YoavTC) | 03/04/2025 |
| 🔍 Spot the Differences **[BOSS]** | `spotTheDifferences` | [YoavTC](https://github.com/YoavTC) | 07/04/2025 |
| 🍎 Resist the Forbidden Fruit | `forbiddenFruit` | [YoavTC](https://github.com/YoavTC) | 09/04/2025 |
| ☕ Make Coffee | `makeCoffee` | [YoavTC](https://github.com/YoavTC) | 14/04/2025 |
| ⛷️ Trip Skier as Bibi [(reference)](https://www.youtube.com/watch?v=LjmnUfbMjws) | `bibiSki` | [YoavTC](https://github.com/YoavTC) | 20/04/2025 |
| 🪙 Catch the Shekel | `catchShekel` | [YoavTC](https://github.com/YoavTC) | 21/04/2025 |
| 🧩 Matza Split | `matzaSplit` | [Yair Gurevich](https://github.com/yairgurza) | 21/04/2025 |
| 🛴 Wolt Surfers **[BOSS]** | `woltSurfers` | [YoavTC](https://github.com/YoavTC), [Ohad Dori](https://github.com/OhadDori/) | WIP |
| 🧃 Poke Tropit with a Straw | `strawTropit` | [YoavTC](https://github.com/YoavTC) | 27/04/2025 |
| ⚡ Mahsanei Hashmal | `mahsaneiHashmal` | [YoavTC](https://github.com/YoavTC) | 28/04/2025 |
| 🚺 Shmirat Negiah | `dontTouchWomen` | [YoavTC](https://github.com/YoavTC) | 29/04/2025 |
| 🗺️ Guess the City | `geoGuessr` | [YoavTC](https://github.com/YoavTC) | 02/05/2025 |



---


- [About](#about)
- [General Guidelines](#general-guidelines)
- [Technical Information](#technical-information)
- [Creating a Microgame](#creating-a-microgame)
- [Microgame Settings](#microgame-settings)
- [Exiting a Microgame](#exiting-a-microgame)
- [Exporting](#exporting)


---


### About

IsraWare is an Israeli [WarioWare](https://en.wikipedia.org/wiki/WarioWare,_Inc.:_Mega_Microgames!) adaptation. A collection of small Microgames that shouldn't take longer than 10s to complete. Each Microgame either ends with a fail state or a success state. You're welcome to make a Microgame about whatever you want, as long as it fits with the whole "Israeli" theme (Jewish themed also fine).


Examples of fitting Microgames are:

-  Playing Matkot on the beach [[Screenshot]](https://i.imgur.com/2Dgqv04.png)
- Throwing a Keter chair on an Ars [[Screenshot]](https://i.imgur.com/P4EEqEo.png)
- Sorting food into Kosher and Non-Kosher [[Screenshot]](https://i.imgur.com/5UGR6LW.png)
- HaTikva as a rhythm game [[Screenshot]](https://i.imgur.com/O37ZYhO.png)


---


### General Guidelines
- Put all of the assets and files needed to run the Microgame inside it's directory (`Assets/_Game Assets/Microgames/MICROGAME/`).
- For an art-style, go wild.
- If you use any asset(s) created by another person, please enter them in the `CreditsSpreadsheet.csv` file.
- Credit yourself in a txt file in the directory of your Microgame.
- I ask that you don't use Gen-AI with the exception of AI generated/assisted scripting.


---


### Technical Information


The project is in Unity 6 (`6000.0.25f1`), and uses some built-in as well as external packages & tools. The Most notable ones are:


- TextMesh Pro [[Docs]](https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/manual/index.html)
- DOTween [[Docs]](https://dotween.demigiant.com/documentation.php)
- Naughty Attributes [[Docs]](https://dbrizov.github.io/na-docs/)
- Serialized Dictionary [[Docs]](https://assetstore.unity.com/packages/tools/utilities/serialized-dictionary-243052)
- Cast Visualizer [[Docs]](https://assetstore.unity.com/packages/tools/utilities/cast-visualizer-167951)
- PlayerPrefs Editor [[Docs]](https://assetstore.unity.com/packages/tools/utilities/playerprefs-editor-167903)
- Vector Visualizer [[Docs]](https://assetstore.unity.com/packages/tools/utilities/vector-visualizer-294644)

You're welcome to add any other external package you want. <br>
I am also using [FEEL](https://feel.moremountains.com/), but it is a paid asset and sharing is against the EULA. If you have a FEEL license yourself you're welcome to add it and use it.


**The systems that tie the Microgames together are not included in the files.**


---


### Creating a Microgame
In order to create a Microgame, click on `Microgames/Create New Microgame`. <br>
![](https://i.imgur.com/eE2Td6f.png)

A window prompting you to save a file will appear. Just type in the name of the Microgame, and hit enter (save location doesn't matter, this is just to get input). <br>
![](https://i.imgur.com/BvumE7G.png)

A file and a directory will be created in the project. The file is the Microgame's settings, and the directory contains a it's scene. <br>
![](https://i.imgur.com/odI97Gb.png)


---


### Microgame Settings
The Microgame settings file is a ScriptableObject instance of `MicrogameScriptableObject.cs`. It contains data telling the game manager how to handle the Microgame.

#### Base Settings:

> string **id** <br> 
> The ID of the Microgame. Used to locate the scene at runtime and manage it. Must match the name of the ScriptableObject as well as the scene containing the Microgame!
> 
> string **ENGLISH_PROMPT** / **HEBREW_PROMPT** <br>
> The prompt shown on the screen at the start of the Microgame
>
> bool - **hideCursor** <br>
> Whether the cursor should be visible or not while playing the Microgame
 
#### Game Settings

> int **positiveFeedbacksToWin** / **negativeFeedbacksToLose** <br>
> How many times does the player fail/win before they officially lose/win the Microgame? <br>
> A value of 1 (for both) makes the game an instant "death" and win. A value larger than 1 can represent hearts or lives during the Microgame.
>
> float **maxMicrogameTime** <br>
> If the Microgame is time-dependent, how long should the timer counting down be? <br>
> **Note:** if the Microgame does _NOT_ rely on time `maxMicrogameTime` should be set to `-1`
>
> bool **winAtTimerFinish** <br>
> When the timer ends, should the player lose or win? <br>
> For example, if the Microgame is some sort of quiz, `winAtTimerFinish` should be `false`.<br>
> But if the Microgame is some sort of surviving challenge, `winAtTimerFinish` should be `true`.


---


### Exiting a Microgame
Each Microgame scene has a `MicrogameInstance` MonoBehaviour script in it attached to a Manager GameObject. You can call `Feedback(bool positive)` on `MicrogameInstance` to increase each one's respective feedbacks counter (`negativeFeedbacksCount` / `positiveFeedbacksCount`). When a feedbacks counter reaches the target feedbacks necessary to lose/win the Microgame (as specified in the Microgame's settings), it will end the Microgame and transition the player to the next scene.

You can delay the switching to the next scene by setting `winFinishDelay` / `loseFinishDelay`.


---


### Exporting

> You're also welcome to make a new branch of this repo with your Microgame, so you can keep updating it! 

Please make sure you credited everyone needed, and made a file in the Microgame's directory with your information for crediting. <br>
Then click `Assets/Export Package...` and deselect everything but the Microgame's assets directory and the Settings file. <br>
![](https://i.imgur.com/9dSVFYK.png) <br>
You can email the exported `.unitypackage` file to me at yoavtc2004@gmail.com!
