using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TextFontChanger))]
public class TextFontChangerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var textFontChanger = (TextFontChanger)target;
        DrawDefaultInspector();

        // Create a button that, when clicked, will change the font on all Text elements in the scene.
        if (GUILayout.Button("Change font on all Text elements"))
        {
            textFontChanger.UpdateFontOnAllText();
        }
    }
}