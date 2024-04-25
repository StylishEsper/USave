//***************************************************************************************
// Writer: Stylish Esper
// Last Updated: April 2024
// Description: Custom create menu options for USave.
//***************************************************************************************

using Esper.USave.Encryption;
using UnityEditor;
using UnityEngine;

namespace Esper.USave.Editor
{
    public static class USaveMenuItems
    {
        [MenuItem("GameObject/USave/Save File")]
        private static void CreateSaveFile()
        {
            GameObject go = ObjectFactory.CreateGameObject("SaveFile", typeof(SaveFileSetup));

            var saveFile = go.GetComponent<SaveFileSetup>();
            saveFile.saveFileData = new SaveFileSetupData("Example_Save",
                SaveFileSetupData.SaveLocation.DataPath, "Example_Saves", SaveFileSetupData.FileType.Json,
                SaveFileSetupData.EncryptionMethod.None, USaveEncryption.GenerateRandomToken(16),
                USaveEncryption.GenerateRandomToken(16), false);

            if (Selection.activeGameObject)
            {
                go.transform.SetParent(Selection.activeGameObject.transform);
            }

            Selection.activeGameObject = go;
        }

        [MenuItem("GameObject/USave/Save Storage")]
        private static void CreateSaveStorage()
        {
            GameObject storage = ObjectFactory.CreateGameObject("SaveStorage", typeof(SaveStorage));

            var saveFile = storage.GetComponent<SaveFileSetup>();
            saveFile.saveFileData = new SaveFileSetupData("GameName_SavePaths", 
                SaveFileSetupData.SaveLocation.DataPath, "GameName_Saves", SaveFileSetupData.FileType.Json, 
                SaveFileSetupData.EncryptionMethod.None, USaveEncryption.GenerateRandomToken(16), 
                USaveEncryption.GenerateRandomToken(16), false);

            if (Selection.activeGameObject)
            {
                storage.transform.SetParent(Selection.activeGameObject.transform);
            }

            Selection.activeGameObject = storage;
        }
    }
}

