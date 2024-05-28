//***************************************************************************************
// Writer: Stylish Esper
// Last Updated: April 2024
// Description: Save file setup data custom property drawer.
//***************************************************************************************

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Esper.ESave.Editor
{
    [CustomPropertyDrawer(typeof(SaveFileSetupData))]
    public class SaveFileSetupDataDrawer : PropertyDrawer
    {
        private float propertyHeight;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            propertyHeight = EditorGUIUtility.singleLineHeight;
            float y = position.y;

            var headerLineRect = new Rect(position.x, y, position.width, EditorGUIUtility.singleLineHeight);
            property.isExpanded = EditorGUI.Foldout(headerLineRect, property.isExpanded, label);

            if (property.isExpanded)
            {
                EditorGUI.BeginProperty(position, label, property);

                float lineSpacing = EditorGUIUtility.singleLineHeight + 5;
                float indent = 15;
                float x = position.x + indent;

                y += lineSpacing;
                propertyHeight += lineSpacing;
                var fileNameRect = new Rect(x, y, position.width - indent, EditorGUIUtility.singleLineHeight);
                var fileName = property.FindPropertyRelative("fileName");
                fileName.stringValue = EditorGUI.TextField(fileNameRect, "File Name", fileName.stringValue);

                y += lineSpacing;
                propertyHeight += lineSpacing;
                var saveLocationRect = new Rect(x, y, position.width - indent, EditorGUIUtility.singleLineHeight);
                var saveLocation = property.FindPropertyRelative("saveLocation");
                saveLocation.enumValueIndex = EditorGUI.Popup(saveLocationRect, "Save Location", saveLocation.enumValueIndex, saveLocation.enumDisplayNames);

                y += lineSpacing;
                propertyHeight += lineSpacing;
                var filePathRect = new Rect(x, y, position.width - indent, EditorGUIUtility.singleLineHeight);
                var filePath = property.FindPropertyRelative("filePath");
                filePath.stringValue = EditorGUI.TextField(filePathRect, "File Path", filePath.stringValue);

                y += lineSpacing;
                propertyHeight += lineSpacing;
                var fileTypeRect = new Rect(x, y, position.width - indent, EditorGUIUtility.singleLineHeight);
                var fileType = property.FindPropertyRelative("fileType");
                fileType.enumValueIndex = EditorGUI.Popup(fileTypeRect, "File Type", fileType.enumValueIndex, fileType.enumDisplayNames);

                y += lineSpacing;
                propertyHeight += lineSpacing;
                var encryptionMethodRect = new Rect(x, y, position.width - indent, EditorGUIUtility.singleLineHeight);
                var encryptionMethod = property.FindPropertyRelative("encryptionMethod");
                encryptionMethod.enumValueIndex = EditorGUI.Popup(encryptionMethodRect, "Encryption Method", encryptionMethod.enumValueIndex, encryptionMethod.enumDisplayNames);

                if (encryptionMethod.enumValueIndex == 1)
                {
                    y += lineSpacing;
                    propertyHeight += lineSpacing;
                    var aesKeyRect = new Rect(x, y, position.width - indent, EditorGUIUtility.singleLineHeight);
                    var aesKey = property.FindPropertyRelative("aesKey");
                    aesKey.stringValue = EditorGUI.TextField(aesKeyRect, "AES Key", aesKey.stringValue);

                    y += lineSpacing;
                    propertyHeight += lineSpacing;
                    var aesIVRect = new Rect(x, y, position.width - indent, EditorGUIUtility.singleLineHeight);
                    var aesIV = property.FindPropertyRelative("aesIV");
                    aesIV.stringValue = EditorGUI.TextField(aesIVRect, "AES IV", aesIV.stringValue);
                }

                y += lineSpacing;
                propertyHeight += lineSpacing;
                var addToStorageRect = new Rect(x, y, position.width - indent, EditorGUIUtility.singleLineHeight);
                var addToStorage = property.FindPropertyRelative("addToStorage");
                addToStorage.boolValue = EditorGUI.Toggle(addToStorageRect, "Add to Storage", addToStorage.boolValue);

                EditorGUI.EndProperty();
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return propertyHeight;
        }
    }
}
#endif