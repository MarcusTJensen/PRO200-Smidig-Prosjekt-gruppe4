using UnityEditor;

// This script is mostly a copy from unity documentation site:
// https://docs.unity3d.com/ScriptReference/SceneAsset.html
// some edits have been done to fit our project

[CustomEditor(typeof(ButtonController), true)]
public class ScenePickerEditor : Editor {
	public override void OnInspectorGUI() {
		
		DrawDefaultInspector();
		
		ButtonController picker = target as ButtonController;
		var oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(picker.targetScene);

		serializedObject.Update();

		EditorGUI.BeginChangeCheck();
		var newScene = EditorGUILayout.ObjectField("Target Scene", oldScene, typeof(SceneAsset), false) as SceneAsset;

		if (EditorGUI.EndChangeCheck()) {
			var newPath = AssetDatabase.GetAssetPath(newScene);
			var scenePathProperty = serializedObject.FindProperty("targetScene");
			scenePathProperty.stringValue = newPath;
		}
		serializedObject.ApplyModifiedProperties();
	}
}

[CustomEditor(typeof(PointScript), true)]
public class MapScenePickerEditor : Editor {
	public override void OnInspectorGUI() {
		
		DrawDefaultInspector();
		
		PointScript picker = target as PointScript;
		var oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(picker.targetScene);

		serializedObject.Update();

		EditorGUI.BeginChangeCheck();
		var newScene = EditorGUILayout.ObjectField("Target Scene", oldScene, typeof(SceneAsset), false) as SceneAsset;

		if (EditorGUI.EndChangeCheck()) {
			var newPath = AssetDatabase.GetAssetPath(newScene);
			var scenePathProperty = serializedObject.FindProperty("targetScene");
			scenePathProperty.stringValue = newPath;
		}
		serializedObject.ApplyModifiedProperties();
	}
}