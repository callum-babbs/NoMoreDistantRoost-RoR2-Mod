using BepInEx;
using RoR2;
using System;
using System.Linq;

namespace NoMoreDistantRoost
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class NoMoreDistantRoostPlugin : BaseUnityPlugin
    {
        public const string PluginAuthor = "callitricks";
        public const string PluginName = "NoMoreDistantRoost";
        public const string PluginVersion = "1.0.0";
        public const string PluginGUID = PluginAuthor + "." + PluginName;

        private void Awake()
        {
            Log.Init(Logger);
            Log.Info($"{PluginName} initialized");

            On.RoR2.Run.PickNextStageScene += Run_PickNextStageScene;
        }

        private void Run_PickNextStageScene(On.RoR2.Run.orig_PickNextStageScene orig, Run self, WeightedSelection<SceneDef> choices)
        {
            orig(self, choices);

            if (self.nextStageScene != null && (self.nextStageScene.baseSceneName == "blackbeach" || self.nextStageScene.baseSceneName == "blackbeach2"))
            {
                Log.Info("Skipping Distant Roost hehehehe... rerolling stage selection");

                var validScenes = choices.choices
                    .Select(c => c.value)
                    .Where(scene => scene && (scene.baseSceneName != "blackbeach" && scene.baseSceneName != "blackbeach2"))
                    .ToArray();

                if (validScenes.Length > 0)
                {
                    self.nextStageScene = self.nextStageRng.NextElementUniform(validScenes);
                    Log.Info($"Rerolled stage: {self.nextStageScene.baseSceneName}");
                }
            }
        }
    }
}
