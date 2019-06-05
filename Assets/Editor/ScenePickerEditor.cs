using UnityEngine;
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

[CustomEditor(typeof(StartSceneScript), true)]
public class StartScenePickerEditor : Editor {
	public override void OnInspectorGUI() {
		
		DrawDefaultInspector();
		
		StartSceneScript picker = target as StartSceneScript;
		var oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(picker.sceneToLoad);

		serializedObject.Update();

		EditorGUI.BeginChangeCheck();
		var newScene = EditorGUILayout.ObjectField("Scene To Load", oldScene, typeof(SceneAsset), false) as SceneAsset;

		if (EditorGUI.EndChangeCheck()) {
			var newPath = AssetDatabase.GetAssetPath(newScene);
			var scenePathProperty = serializedObject.FindProperty("sceneToLoad");
			scenePathProperty.stringValue = newPath;
		}
		serializedObject.ApplyModifiedProperties();
	}
}