﻿namespace EDAutomate
{
    class Commodities
    {
        public enum Commodity
        {
            None = 0,
            AgronomicTreatment = 10268,
            Explosives = 3,
            HydrogenFuel = 4,
            HydrogenPeroxide = 138,
            LiquidOxygen = 137,
            MineralOil = 5,
            NerveAgents = 96,
            Pesticides = 6,
            RockforthFertiliser = 10264,
            SurfaceStabilisers = 97,
            SyntheticReagents = 98,
            Tritium = 10269,
            Water = 139,
            Clothing = 7,
            ConsumerTechnology = 8,
            DomesticAppliances = 9,
            EvacuationShelter = 99,
            SurvivalEquipment = 164,
            Beer = 10,
            BootlegLiquor = 95,
            Liquor = 11,
            Narcotics = 12,
            Tobacco = 13,
            Wine = 14,
            Algae = 15,
            AnimalMeat = 16,
            Coffee = 17,
            Fish = 18,
            FoodCartridges = 19,
            FruitandVegetables = 20,
            Grain = 21,
            SyntheticMeat = 23,
            Tea = 22,
            CeramicComposites = 100,
            CMMComposite = 140,
            InsulatingMembrane = 141,
            MetaAlloys = 101,
            MicroWeaveCoolingHoses = 185,
            NeofabricInsulation = 183,
            Polymers = 26,
            Semiconductors = 28,
            Superconductors = 27,
            ArticulationMotors = 182,
            AtmosphericProcessors = 87,
            BuildingFabricators = 102,
            CropHarvesters = 29,
            EmergencyPowerCells = 158,
            EnergyGridAssembly = 149,
            ExhaustManifold = 159,
            GeologicalEquipment = 103,
            HeatsinkInterlink = 151,
            HNShockMount = 150,
            IonDistributor = 160,
            MagneticEmitterCoil = 152,
            MarineEquipment = 86,
            MicrobialFurnaces = 85,
            MineralExtractors = 31,
            ModularTerminals = 181,
            PowerConverter = 153,
            PowerGenerators = 83,
            PowerTransferBus = 161,
            RadiationBaffle = 162,
            ReinforcedMountingPlate = 163,
            SkimmerComponents = 104,
            ThermalCoolingUnits = 105,
            WaterPurifiers = 82,
            AdvancedMedicines = 166,
            AgriMedicines = 1,
            BasicMedicines = 33,
            CombatStabilisers = 34,
            PerformanceEnhancers = 35,
            ProgenitorCells = 36,
            Aluminium = 37,
            Beryllium = 38,
            Bismuth = 106,
            Cobalt = 39,
            Copper = 40,
            Gallium = 41,
            Gold = 42,
            Hafnium178 = 124,
            Indium = 43,
            Lanthanum = 107,
            Lithium = 44,
            Osmium = 72,
            Palladium = 45,
            Platinum = 81,
            Praseodymium = 143,
            Samarium = 142,
            Silver = 46,
            Tantalum = 47,
            Thallium = 108,
            Thorium = 109,
            Titanium = 48,
            Uranium = 50,
            Alexandrite = 10249,
            Bauxite = 51,
            Benitoite = 10247,
            Bertrandite = 52,
            Bromellite = 148,
            Coltan = 55,
            Cryolite = 110,
            Gallite = 56,
            Goslarite = 111,
            Grandidierite = 10248,
            Indite = 57,
            Jadeite = 168,
            Lepidolite = 58,
            LithiumHydroxide = 147,
            LowTemperatureDiamonds = 144,
            MethaneClathrate = 145,
            MethanolMonohydrateCrystals = 146,
            Moissanite = 116,
            Monazite = 10245,
            Musgravite = 10246,
            Painite = 84,
            Pyrophyllite = 112,
            Rhodplumsite = 10243,
            Rutile = 59,
            Serendibite = 10244,
            Taaffeite = 120,
            Uraninite = 60,
            VoidOpals = 10250,
            AIRelics = 89,
            AncientArtefact = 121,
            AncientCasket = 10153,
            AncientKey = 10240,
            AncientOrb = 10154,
            AncientRelic = 10155,
            AncientTablet = 10156,
            AncientTotem = 10157,
            AncientUrn = 10158,
            AntimatterContainmentUnit = 10167,
            AntiqueJewellery = 10209,
            Antiquities = 91,
            AssaultPlans = 169,
            BlackBox = 122,
            CommercialSamples = 170,
            DamagedEscapePod = 10215,
            DataCore = 10166,
            DiplomaticBag = 171,
            EarthRelics = 10210,
            EncryptedCorrespondence = 172,
            EncryptedDataStorage = 173,
            ExperimentalChemicals = 123,
            FossilRemnants = 10221,
            GeneBank = 10211,
            GeologicalSamples = 174,
            Hostage = 175,
            LargeSurveyDataCache = 125,
            MilitaryIntelligence = 126,
            MilitaryPlans = 127,
            MolluscBrainTissue = 10256,
            MolluscFluid = 10255,
            MolluscMembrane = 10252,
            MolluscMycelium = 10253,
            MolluscSoftTissue = 10254,
            MolluscSpores = 10251,
            MysteriousIdol = 10219,
            OccupiedEscapePod = 129,
            PersonalEffects = 10159,
            PodCoreTissue = 10259,
            PodDeadTissue = 10257,
            PodMesoglea = 10262,
            PodOuterTissue = 10260,
            PodShellTissue = 10261,
            PodSurfaceTissue = 10258,
            PodTissue = 10263,
            PoliticalPrisoner = 177,
            PreciousGems = 10165,
            ProhibitedResearchMaterials = 10220,
            PrototypeTech = 130,
            RareArtwork = 131,
            RebelTransmissions = 132,
            SAP8CoreContainer = 90,
            ScientificResearch = 178,
            ScientificSamples = 179,
            SmallSurveyDataCache = 10208,
            SpacePioneerRelics = 10164,
            TacticalData = 180,
            TechnicalBlueprints = 133,
            ThargoidBasiliskTissueSample = 10236,
            ThargoidBiologicalMatter = 10160,
            ThargoidCyclopsTissueSample = 10234,
            ThargoidHeart = 10235,
            ThargoidHydraTissueSample = 10239,
            ThargoidLink = 10161,
            ThargoidMedusaTissueSample = 10237,
            ThargoidProbe = 186,
            ThargoidResin = 10162,
            ThargoidScoutTissueSample = 10238,
            ThargoidSensor = 10226,
            ThargoidTechnologySamples = 10163,
            TimeCapsule = 10212,
            TradeData = 134,
            TrinketsofHiddenFortune = 135,
            UnstableDataCore = 176,
            WreckageComponents = 10207,
            ImperialSlaves = 49,
            Slaves = 53,
            AdvancedCatalysers = 61,
            AnimalMonitors = 62,
            AquaponicSystems = 63,
            AutoFabricators = 65,
            BioreducingLichen = 66,
            ComputerComponents = 67,
            HESuits = 68,
            HardwareDiagnosticSensor = 155,
            LandEnrichmentSystems = 71,
            MedicalDiagnosticEquipment = 154,
            MicroControllers = 156,
            MuonImager = 119,
            Nanobreakers = 167,
            ResonatingSeparators = 69,
            Robotics = 70,
            StructuralRegulators = 117,
            TelemetrySuite = 184,
            ConductiveFabrics = 165,
            Leather = 73,
            MilitaryGradeFabrics = 157,
            NaturalFabrics = 74,
            SyntheticFabrics = 75,
            Biowaste = 76,
            ChemicalWaste = 32,
            Scrap = 77,
            ToxicWaste = 54,
            BattleWeapons = 88,
            Landmines = 118,
            NonLethalWeapons = 78,
            PersonalWeapons = 79,
            ReactiveArmour = 80
        }
    }
}
