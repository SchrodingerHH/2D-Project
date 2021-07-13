using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ToolbarMenuTest
{
    [MenuItem("AssetBundle/BuildBundle")]
    static void BuildBundle()
    {
        BuildPipeline.BuildAssetBundles("Assets/Bundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }



}