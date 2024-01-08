# Smelter Mining Machines (A&B) / Chemical Mining Machines (C)  / Refinery Oil Extractor

There are 7 types (A, B and C，and corresponding advanced mining machines A, B, C. And Refinery Oil Extrator.). A and B require "High-strength glass" technology to unlock, C requires "Quantum chip" technology to unlock. Advanced Mining machines A, B, C Requires the same technology that unlocks the vanilla advanced mining machine. Refinery Oil Extrator requires the "High-strength glass" technology to unlock.

There is basically no difference between A and B types, except "When certain minerals can be smelted into different products, A and B machine will smelt them into different products". 
For example: iron ore--A-->iron nuggets;  iron ore--B-->Magnet".

Type C is designed to replace the functions of mining machines + chemical plants, specifically collecting fire ice to output graphene, and collecting spiniform stalagmite crystal to output carbon nanotubes. Refinery Oil Extrator will output refined oil instead of crude oil.

Some products (such as glass) require 2 raw ores to produce one product. Under these circumstances, the smelter mining machine collects minerals at a normal speed, but only produces glass at a speed of 50%.

For minerals that cannot be processed by the mining machineABC, the function of the new mining machine is exactly the same as the original mining machine.

Work comsumption A/B/C: 2.4 / 2.4 / 4.8 MW (Advanced Machines: 7.2 / 7.2 / 9.0 MW)  (Refinery Oil Extractor: 6.0MW)
Idle consumption A/B/C: 60 / 60 / 120 kW (Advanced Machines: 180 / 180 / 180 kW)  (Refinery Oil Extractor: 150kW)

### Same way type A and B (including advanced A and B) produce the ore（Veins：Output）--Notice: C or Advanced C can't do recipes below--

Copper ore: Copper ingot    
Silicon ore: High-purity silicon    
Titanium ore: Titanium ingot    
Fractal silicon: Crystal silicon    
Coal: Energetic graphite    
Kimberlite ore: Diamond

### Smelter Mining Machine A - Special

Iron ore：Iron ingot    
Stone: Stone brick  

### Smelter Mining Machine B - Special

Iron ore：magnet    
Stone: Glass

### Chemical Mining Machine C - Only these

Fire ice: Graphene     
Spiniform stalagmite crystal: Carbon nanotube

The Refinery Oil Extractor was placed in the Research build bar (7) instead of Gathering (2), due to insufficient build bar slots.

### Installation

1. Install BepInEx.  
2. Install LDBTool. (version lower than 1.7.0 may cause errors)   
3. Drag SmelterMiner.dll into "Dyson Sphere Program/BepInEx/plugins/"  

### Mod conflicts

Problems may arise when other mods that create new items/recipes use the following IDs:  
RecipeProto.ID: 452, 453, 454, 472, 473, 474, 475.  
ItemProto.ID: 9446, 9447, 9448, 9466, 9467, 9468, 9469.  
StringProto.ID: 10547, 10548, 10549, 10550, 10551, 10552, 10577, 10578, 10579, 10580, 10581, 10582, 10583, 10584.  

Problems may arise when other mods that create new items/recipes use the following GridIndex:  
2610, 2611, 2612, 2510, 2511, 2512, 2609.  

Problems may arise when other mods that create new items/recipes use the following BuildIndex:  
205, 206, 207, 208, 209, 210, 705.   

Besides, since this mod changes the function that controlls the normal mining, it may cause some related mods lose their functions (such as infinate mining). This mod provides a way that you can customize your own mining rate (not mining speed) in the config file.

### ChangeLog
v1.6.4: Updated to work with game version 0.10.28.21247.  

v1.6.3: Updated to work with game version 0.9.26.13026.

v1.6.2: Updated to work with game version 0.9.25.11985.

v1.6.1: Fix a bug that may occur later in the game.   
The error might affect the function of the miner (i.e. no products). If there is any abnormality, please contact me.

v1.6.0: Add the new building: Refinery Oil Extractor.  
	Fix display problems of the recipe links.  
	Fix a problem that the mining machine only produces one instead of two diamond with each Kimberlite ore.  
	(Known issue: The diamond output speed displayed in the miner is still half. But the actual output speed and the speed displayed in the statistics panel are correct.)  

See the previous changelog at the end.

# 熔炉采矿机AB、化工采矿机C、等离子精炼油井

共有7种类型（A、B和C，以及对应的大型矿机版本。以及等离子精炼油井），AB需要高强度玻璃科技解锁，C需要量子芯片科技解锁。大型矿机A、B、C的解锁科技与游戏本体的大型矿机的解锁科技相同。等离子精炼油井需要高强度玻璃科技解锁。  
AB型两种基本没有区别，除了“当某些矿物可以熔炼成不同产物时，A、B型采矿机会将它们熔炼成不同产物”。例如铁矿石--A-->铁块；铁矿石--B-->磁铁”。  
C型则旨在替代矿机+化工厂的功能，专门采集可燃冰输出石墨烯，采集刺笋晶体输出碳纳米管。等离子精炼油井则采集原油并输出精炼油。  
对于矿机无法处理的矿物，矿机功能和原始的矿机完全相同。  

一些产物（例如玻璃）需要2个原矿生产一个产物，这时采矿机会正常采集矿物，但只以50%的速率产生玻璃。

工作功率 A/B/C：2.4 / 2.4 / 4.8 MW（大型矿机则是7.5 / 7.5 / 9.0 MW）  （等离子精炼油井为6.0MW）
待机功率 A/B/C：60 / 60 / 120 kW（大型矿机则是180 / 180 / 180 kW）  （等离子精炼油井为150kW）

由于建造栏位置不足，等离子精炼油井被放在了研究栏（7）中而不是采集（2）。  

### A和B（包括大型A和B）相同的处理方式（地表矿脉：矿机输出），注意C以及大型C矿机不能处理这个

铜矿：铜块   
硅石：高纯硅块  
钛石：钛块  
分型硅石：晶格硅  
煤矿：高能石墨  
金伯利矿石：金刚石

### A独特的处理方式

铁矿：铁块  
石矿：石材

### B独特的处理方式

铁矿：磁铁  
石矿：玻璃

### C独特的处理方式

可燃冰：石墨烯  
刺笋晶体：碳纳米管

### 安装

1. 安装 BepInEx框架。  
2. 安装 LDBTool. （低于1.7.0的版本可能会导致错误）感谢宵夜97提供了方便的工具。  
3. 将SmelterMiner.dll放入 "Dyson Sphere Program/BepInEx/plugins/"文件夹内

### Mod冲突

当其他创造新物品/配方的mod使用了以下ID时，可能会产生问题：  
RecipeProto.ID: 452, 453, 454, 472, 473, 474, 475.  
ItemProto.ID: 9446, 9447, 9448, 9466, 9467, 9468, 9469.  
StringProto.ID: 10547, 10548, 10549, 10550, 10551, 10552, 10577, 10578, 10579, 10580, 10581, 10582, 10583, 10584.  
当其他创造新物品/配方的mod使用了以下位置时，可能会产生问题： 
2610, 2611, 2612, 2510, 2511, 2512, 2609.  
当其他创造新物品/配方的mod使用了以下快速建造栏位置时，可能会产生问题：  
205, 206, 207, 208, 209, 210, 705.

此外，这个mod修改了正常采矿的函数，所以可能会导致一些相关的mod失效（尤其是使用了prefix的，例如无限采矿），因此这个mod提供了一个可以自定义采矿消耗率（不是采矿速度）的功能，可以在config文件中修改。

### 更新
v1.6.4: 更新以适配游戏版本 0.10.28.21247。  

v1.6.3: 更新以适配游戏版本 0.9.26.13026。

v1.6.2: 更新以适配游戏版本 0.9.25.11985。

v1.6.1: 修复一个可能在游戏后期导致报错的问题。  
该bug可能导致矿机功能异常（没有产物），如果有任何异常请联系我。

v1.6.0: 新增等离子精炼油井。  
	修复物品配方链接在简单模式下显示不正确的问题。  
	修复采集一个金伯利矿石只能产出一个钻石而非两个的问题。  
	（已知问题：在矿机内显示的产出钻石的速度仍为一半。但是实际产出速度和在数据分析面板中显示的速度是正确的。）  

### Previous Versions 更早版本
v1.5.0: A placed Smelter Miner will now display the correct product icon instead of the original ore icon of the vein. (only works for the miners built after this update)   
	Fix a problem that the mining animations could not be displayed.  
	Fix a problem that the energy consumption of the smelter miners were not increasing correctly. (only works for the miners built after this update)    
	Fix a problem that the smelter miner incorrectly consumes half of the minerals in some cases. 

v1.5.0: 现在放置后熔炉矿机会正确显示熔炼后的产物图标，而非矿脉的原矿图标。  
	修复一个bug，该bug曾导致矿机工作时无法正确播放采矿动画。  
	修复一个bug，该bug曾导致熔炉矿机消耗的能量没有正确增加。  
	修复一个bug，该bug曾导致熔炉矿机某些时候只消耗一半的矿物。

v1.4.1: Fix the problem that the new machines may cover the icons of the EM-rail ejector and the launching silo, BUT YOU MUST take ONE of the following operations, otherwise the update is invalid:   
   (1) If this is your first time using this mod, OR if your current LDBTool version is higher than 2.0.3, you don't have to do anything, Otherwise(that you've installed this mod before), you need to:  
   (2) If you never edited this file(\Dyson Sphere Program\BepInEx\config\LDBTool\LDBTool.CustomGridIndex.cfg), and you don't know its function. Simply delete this file, the problem will be fixed;  
   (3) Or, if you've edited this file before, it means that you know that you know the function of this file. In order to protect your previous modifications, you need to enter the file, only modify the value of 9446, 9447, 9448, 452, 453, 454 into 2610, 2611, 2612, 2610, 2611, 2612 respectively (ie the Default Value displayed). such as 9446 = 2610

v1.4.1: 更新以修复新增的矿机图标会覆盖太阳帆发射器、火箭发射井的问题。但是你必须得做下面的任意一步，否则修复不会生效：  
（1）如果你之前没装过这个mod，或者你当前的LDBTool mod版本高于2.0.3，那你啥也不用做就行了。否则（也就是说你装过老版本），你必须得：  
（2）如果你从没修改过这个配置文件（\Dyson Sphere Program\BepInEx\config\LDBTool\LDBTool.CustomGridIndex.cfg），你也不知道他是干啥用的，那你把他删了就行了，这样就修复了。  
（3）如果你改过这个配置文件，那说明你知道它是干嘛用的。你得把这些项（9446, 9447, 9448, 452, 453, 454）的值分别修改成2610, 2611, 2612, 2610, 2611, 2612 （也就是改成Default Vaule里显示的那样）。即改成形如9446 = 2610这样。


v1.4.0: Update for game version 0.9.24.11182. (2022-1-20).    
          Add new Advanced Mining Machines A, B and C.

v1.4.0: 更新以适配游戏版本0.9.24.11182（游戏更新于2022-1-20）。  
          添加了对应的大型矿机A、B、C型。


v1.3.0: More Bugs fixed.  :)   If there are any problems, please let me know, I will try my best to fix that. Thanks to *djemrelek* and *rmwoj* to help me to find the bugs and fix them.

v1.3.0: Bug修复。如果有任何问题，请联系我，我会尽力修复。


v1.2.0: Bugs fixed! (Lower version would cause errors after finished mining a mineral vein (when it was mining glass or graphite).)

v1.2.0: 严重Bug修复。低版本的mod可能会在采干一片矿脉时报错（当你生产玻璃、石墨时）。


v1.1.2: Now you can reduce the technological requirements and construction costs of the new mining machines by modifying the config file. But this is not recommended since this may harm the fun of the game, especially when this is the first time you play this game. So I write this only in changelog.

v1.1.2: 现在你可以通过修改配置文件大幅降低新矿机的科技需求和建造成本。不过不推荐这样做，因为这可能损害游戏寿命和游戏的可玩性，尤其当你刚开始玩你的第一个存档的时候。所以这个只在更新日志里提了一嘴，正文没写。

v1.1.1: Correct the error of the description text

v1.1.1: 更正描述文字的错误。

v1.1.0: A new chemical mining machine C is added to collect fire ice and spiniform stalagmite crystal. In addition, the technical requirements and costs of the three mining machines have been greatly increased. This mod aims to provide some convenience for the large-scale laying of scattered basic resource production areas in the middle and late stages of the game.

v1.1.0: 新增化工采矿机C，采集可燃冰输出石墨烯，采集刺笋晶体输出碳纳米管。此外，大幅提高了三种采矿机的科技需求和成本，本mod旨在为游戏中后期大规模铺设散落的基础资源生产区提供一些便利。

v1.0.1: When mining and smelting items that require two raw ore to produce one (such as glass), the [probability] is no longer used, but is fixed at 50% [speed] (without changing the mining speed).

v1.0.1: 开采并熔炼需要两个原矿产出一个的物品时（例如玻璃），不再使用概率进行产出，而是固定以50%速度产出（不改变采矿速度）。