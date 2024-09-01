/* Copyright 2024 Verox
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using UnityEditor;
using System.IO;

namespace ISRU.Unity.Editor
{
    /// <summary>
    /// This script adds a menu item to the Unity Editor under "Assets" called "Build AssetBundles" that will
    /// build all asset bundles in the project and copy them to the "plugin_template/assets/bundles" directory.
    /// </summary>
    public static class CreateAssetBundles
    {
        private const string AssetBundleDirectory = "Assets/AssetBundles";
        // Relative path from the Unity project directory to the target directory
        private const string TargetDirectory = "../../../plugin_template/assets/bundles";

        [MenuItem("Assets/Build AssetBundles")]
        private static void BuildAllAssetBundles()
        {
            // Ensure the AssetBundle directory exists
            if (!Directory.Exists(AssetBundleDirectory))
            {
                Directory.CreateDirectory(AssetBundleDirectory);
            }

            // Build the asset bundles
            BuildPipeline.BuildAssetBundles(
                AssetBundleDirectory,
                BuildAssetBundleOptions.None,
                BuildTarget.StandaloneWindows
            );

            // Delete existing bundles in the target directory
            if (Directory.Exists(TargetDirectory))
            {
                var files = Directory.GetFiles(TargetDirectory, "*.bundle");
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }
            else
            {
                Directory.CreateDirectory(TargetDirectory);
            }

            // Copy the newly built bundles to the target directory
            var newBundles = Directory.GetFiles(AssetBundleDirectory, "*.bundle");
            foreach (var bundle in newBundles)
            {
                var destFile = Path.Combine(TargetDirectory, Path.GetFileName(bundle));
                File.Copy(bundle, destFile, overwrite: true);
            }
        }
    }
}
