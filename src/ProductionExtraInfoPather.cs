using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmelterMiner
{
    public class ProductionExtraInfoPather
    {


        [HarmonyPostfix]
        [HarmonyPatch(typeof(ProductionExtraInfoCalculator), "CalculateFactory")]
        public static void CalculateFactoryPatch(ref ProductionExtraInfoCalculator __instance, GameData gameData, PlanetFactory factory)
        {
            try
            {
                FactoryProductionStat factoryProductionStat = __instance.productionStatistics.factoryStatPool[factory.index];
                FactorySystem factorySystem = factory.factorySystem;
                FactoryStorage factoryStorage = factory.factoryStorage;
                PowerSystem powerSystem = factory.powerSystem;
                PowerConsumerComponent[] consumerPool = powerSystem.consumerPool;
                VeinData[] veinPool = factory.veinPool;

                MinerComponent[] minerPool = factorySystem.minerPool;
                int minerCursor = factorySystem.minerCursor;
                double num13 = (double)gameData.history.miningSpeedScale;
                int waterItemId = factory.planet.waterItemId;
                for (int num14 = 1; num14 < minerCursor; num14++)
                {
                    if (minerPool[num14].id == num14)
                    {
                        ref MinerComponent ptr3 = ref minerPool[num14];

                        int gmProtoId = factory.entityPool[ptr3.entityId].protoId;
                        Dictionary<int, int> mapDict;
                        if (gmProtoId == 9446 || gmProtoId == 9466)
                        {
                            mapDict = SmelterMiner.ProductMapA;
                        }
                        else if (gmProtoId == 9447 || gmProtoId == 9467)
                        {
                            mapDict = SmelterMiner.ProductMapB;
                        }
                        else if (gmProtoId == 9448 || gmProtoId == 9468)
                        {
                            mapDict = SmelterMiner.ProductMapC;
                        }
                        else if (gmProtoId == 9469)
                        {
                            mapDict = SmelterMiner.ProductMapO;
                        }
                        else
                        {
                            continue;
                        }
                        //if (ptr3.productId > 0 && ptr3.productCount > 0)
                        //{
                        //    factoryProductionStat.AddStorageCount(ptr3.productId, ptr3.productCount);
                        //    factoryProductionStat.AddDetailedStorageCount(ptr3.productId, EDetailedStorageCountType.Other, ptr3.productCount);
                        //}


                        if (consumerPool[ptr3.pcId].networkId > 0)
                        {
                            int num15 = 0;
                            float refSpeed = 0f;
                            switch (ptr3.type)
                            {
                                case EMinerType.Water:
                                    num15 = waterItemId;
                                    refSpeed = (float)(3600.0 / (double)ptr3.period * num13 * (double)ptr3.speed);
                                    break;
                                case EMinerType.Vein:
                                    num15 = ((ptr3.veinCount > 0) ? veinPool[ptr3.veins[ptr3.currentVeinIndex]].productId : 0);
                                    refSpeed = (float)(3600.0 / (double)ptr3.period * num13 * (double)ptr3.speed * (double)ptr3.veinCount);
                                    break;
                                case EMinerType.Oil:
                                    num15 = veinPool[ptr3.veins[0]].productId;
                                    refSpeed = (float)(3600.0 / (double)ptr3.period * num13 * (double)ptr3.speed * (double)veinPool[ptr3.veins[0]].amount * (double)VeinData.oilSpeedMultiplier);
                                    break;
                            }
                            if (num15 > 0)
                            {
                                factoryProductionStat.AddRefProductSpeed(num15, -refSpeed); // 首先还原之前的计算结果
                            }
                            int productId = ptr3.productId;
                            if (mapDict.ContainsKey(num15)) // 这一步是为了，如果小熔炉矿机不断输出产物，根本没有内部仓储的产物，其productId会不断被刷新成原矿Id，而非熔炼后的产物Id，用这一步保证获取到的还是熔炼后的产物Id
                                productId = mapDict[num15];
                            //int stationId = factory.entityPool[ptr3.entityId].stationId;
                            //if (stationId > 0 && stationId < factory.transport.stationCursor && factory.transport.stationPool[stationId].id == stationId) // 对于大矿机则是 // 没必要了，因为直接用了MapDict
                            //{
                            //    productId = factory.transport.stationPool[factory.entityPool[ptr3.entityId].stationId].storage[0].itemId;
                            //}

                            // 然后计算真的
                            if (SmelterMiner.SmelterRatio.ContainsKey(productId))
                            {
                                float refSpeedReal = refSpeed / 1.0f / SmelterMiner.SmelterRatio[productId];
                                factoryProductionStat.AddRefProductSpeed(productId, refSpeedReal); // 首先还原之前的计算结果
                            }

                        }
                    }
                }
            }
            catch { }
        }


		[HarmonyPostfix]
		[HarmonyPatch(typeof(UIReferenceSpeedTip), "AddEntryDataWithFactory")]
		public static void AddEntryDataPatch(ref UIReferenceSpeedTip __instance, PlanetFactory factory, float incMulti, float accMulti, int maxStack, int productionIdMask)
        {
            if (factory == null)
            {
                return;
            }
            int itemId = __instance.itemId;
            ItemProto itemProto = LDB.items.Select(itemId);
            if (itemProto == null)
            {
                return;
            }
            int astroId = factory.planet.astroId;
            int productionMask = itemProto.productionMask;
            //int consumptionMask = itemProto.consumptionMask;
            GameData data = GameMain.data;
            FactorySystem factorySystem = factory.factorySystem;
            PowerSystem powerSystem = factory.powerSystem;
            //PlanetTransport transport = factory.transport;
            //CargoTraffic cargoTraffic = factory.cargoTraffic;
            PowerConsumerComponent[] consumerPool = powerSystem.consumerPool;
            EntityData[] entityPool = factory.entityPool;
            VeinData[] veinPool = factory.veinPool;
            FactoryProductionStat factoryProductionStat = data.statistics.production.factoryStatPool[factory.index];

            if (__instance.itemCycle == UIReferenceSpeedTip.EItemCycle.Production)
            {
                MinerComponent[] minerPool = factorySystem.minerPool;
                int minerCursor = factorySystem.minerCursor;
                double num12 = (double)data.history.miningSpeedScale;
                int waterItemId = factory.planet.waterItemId;
                for (int num13 = 1; num13 < minerCursor; num13++)
                {
                    if (minerPool[num13].id == num13)
                    {
                        ref MinerComponent ptr3 = ref minerPool[num13];
                        int gmProtoId = (int)entityPool[ptr3.entityId].protoId;
                        Dictionary<int, int> mapDict;
                        if (gmProtoId == 9446 || gmProtoId == 9466)
                        {
                            mapDict = SmelterMiner.ProductMapA;
                        }
                        else if (gmProtoId == 9447 || gmProtoId == 9467)
                        {
                            mapDict = SmelterMiner.ProductMapB;
                        }
                        else if (gmProtoId == 9448 || gmProtoId == 9468)
                        {
                            mapDict = SmelterMiner.ProductMapC;
                        }
                        else if (gmProtoId == 9469)
                        {
                            mapDict = SmelterMiner.ProductMapO;
                        }
                        else
                        {
                            continue;
                        }
                        bool flag11 = consumerPool[ptr3.pcId].networkId <= 0;
                        float num14;
                        bool isOre = true;
                        bool isSmelted = false;
                        int productId = 0;
                        switch (ptr3.type)
                        {
                            //case EMinerType.Water:
                            //    if (waterItemId != itemId)
                            //    {
                            //        goto IL_82A;
                            //    }
                            //    num14 = (float)(3600.0 / (double)ptr3.period * num12 * (double)ptr3.speed);
                            //    break;
                            case EMinerType.Vein:
                                if (((ptr3.veinCount > 0) ? veinPool[ptr3.veins[ptr3.currentVeinIndex]].productId : 0) != itemId)
                                {
                                    isOre = false;
                                    isSmelted = true;
                                    if(((ptr3.veinCount > 0 && mapDict.ContainsKey(veinPool[ptr3.veins[ptr3.currentVeinIndex]].productId)) ? mapDict[veinPool[ptr3.veins[ptr3.currentVeinIndex]].productId] : 0) != itemId)
                                    {
                                        isSmelted = false;
                                        goto IL_82A;
                                    }
                                    productId = mapDict[veinPool[ptr3.veins[ptr3.currentVeinIndex]].productId];
                                }
                                num14 = (float)(3600.0 / (double)ptr3.period * num12 * (double)ptr3.speed * (double)ptr3.veinCount);
                                break;
                            case EMinerType.Oil:
                                if (veinPool[ptr3.veins[0]].productId != itemId)
                                {
                                    isOre = false;
                                    isSmelted = true;
                                    if ((!mapDict.ContainsKey(veinPool[ptr3.veins[0]].productId))|| mapDict[veinPool[ptr3.veins[0]].productId] != itemId)
                                    {
                                        isSmelted = false;
                                        goto IL_82A;
                                    }
                                    productId = mapDict[veinPool[ptr3.veins[ptr3.currentVeinIndex]].productId];
                                }
                                num14 = (float)(3600.0 / (double)ptr3.period * num12 * (double)ptr3.speed * (double)veinPool[ptr3.veins[0]].amount * (double)VeinData.oilSpeedMultiplier);
                                break;
                            default:
                                goto IL_82A;
                        }
                        if (isOre)
                        {
                            if (gmProtoId == productionIdMask)
                            {
                                RemoveSubTipEntryData(ref __instance, astroId, num14, false, false, flag11);
                            }
                            RemoveEntryData(ref __instance, gmProtoId, num14, false, false, flag11);
                            if (!flag11)
                            {
                                factoryProductionStat.AddRefProductSpeed(itemId, -num14);
                            }
                        }
                        else if(isSmelted && SmelterMiner.SmelterRatio.ContainsKey(productId))
                        {
                            float refSpeedReal = num14 / 1.0f / SmelterMiner.SmelterRatio[productId];
                            if (gmProtoId == productionIdMask)
                            {
                                __instance.AddSubTipEntryData(astroId, refSpeedReal, false, false, flag11);
                            }
                            __instance.AddEntryData(gmProtoId, refSpeedReal, false, false, flag11);

                            if (!flag11)
                            {
                                factoryProductionStat.AddRefProductSpeed(itemId, refSpeedReal);
                            }
                        }

                    }
                    IL_82A:;
                }
            }
        }

        /// <summary>
        /// 无视speed直接删除，因为置ptr.productionProtoId = 0
        /// </summary>
        public static void RemoveEntryData(ref UIReferenceSpeedTip _this, int productionProtoId, float speed, bool useInc2Inc, bool useInc2Acc, bool outNetwork)
        {
            ref RefSpeedTipEntryData ptr = ref _this.loadedEntryDatas[productionProtoId];
            ptr.productionProtoId = 0;
            if (outNetwork)
            {
                ptr.outNetworkCount--;
                return;
            }
            if (!useInc2Inc && !useInc2Acc)
            {
                ptr.normalCount--;
                ptr.normalSpeed -= speed;
                return;
            }
            if (useInc2Inc)
            {
                ptr.useInc2IncCount--;
                ptr.useInc2IncSpeed -= speed;
                return;
            }
            if (useInc2Acc)
            {
                ptr.useInc2AccCount--;
                ptr.useInc2AccSpeed -= speed;
            }
        }

        /// <summary>
        /// 无视speed直接删除，因为置ptr.astroId = 0
        /// </summary>
        public static void RemoveSubTipEntryData(ref UIReferenceSpeedTip _this, int astroId, float speed, bool useInc2Inc, bool useInc2Acc, bool outNetwork)
        {
            ref RefSpeedSubTipEntryData ptr = ref _this.loadedSubTipDatas[astroId];
            ptr.astroId = 0;
            if (outNetwork)
            {
                ptr.outNetworkCount--;
                return;
            }
            if (!useInc2Inc && !useInc2Acc)
            {
                ptr.normalCount--;
                ptr.normalSpeed -= speed;
                return;
            }
            if (useInc2Inc)
            {
                ptr.useInc2IncCount--;
                ptr.useInc2IncSpeed -= speed;
                return;
            }
            if (useInc2Acc)
            {
                ptr.useInc2AccCount--;
                ptr.useInc2AccSpeed -= speed;
            }
        }

    }
}
