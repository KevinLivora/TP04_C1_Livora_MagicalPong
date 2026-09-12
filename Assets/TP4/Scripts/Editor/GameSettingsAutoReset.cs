#if UNITY_EDITOR
using UnityEditor;

// Vive en una carpeta "Editor": Unity la excluye automáticamente de cualquier build.
[InitializeOnLoad]
public static class GameSettingsAutoReset
{
    static GameSettingsAutoReset()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        // Justo al salir de Play, antes de que Unity guarde los cambios del asset.
        if (state != PlayModeStateChange.ExitingPlayMode) return;

        string[] guids = AssetDatabase.FindAssets("t:GameSettings");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameSettings settings = AssetDatabase.LoadAssetAtPath<GameSettings>(path);
            if (settings == null) continue;

            settings.ResetToDefaults();
            EditorUtility.SetDirty(settings);
        }

        AssetDatabase.SaveAssets();
    }
}
#endif
