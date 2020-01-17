using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public  class BuildScript
{
    //extra commands

   static void PerformBuild()
    {
        string[] defaultScene = {"Assets/Scenes/SampleScene.Unity" };
        BuildPipeline.BuildPlayer(defaultScene, "./builds/game.exe",
            BuildTarget.StandaloneWindows, BuildOptions.None);

    }
}
