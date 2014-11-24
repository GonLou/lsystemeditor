using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Lindenmayer))]
public class LindenmayerEditor : Editor {

	public override void OnInspectorGUI() {
		EditorGUI.BeginChangeCheck();
		DrawDefaultInspector();

		Lindenmayer myScript = (Lindenmayer)target;

		//toggleSaveFile = GUI.Toggle(new Rect(10, 10, 100, 30), toggleSaveFile, "save to file");

		if (GUILayout.Button("Generate String")) {
			//GUIText.text = "wait a moment, this can take a while";
			myScript.CreateFullAxiom();
			myScript.Axiom2Vectors();
			// save to file if toggle is checked
			if (GUI.Toggle(new Rect(10, 10, 100, 30), myScript.toggleSaveFile, "save to file")) myScript.SaveFile();
			//GUIText.text = "";
		}

		if (GUILayout.Button("Load from file")) {

		}

		if (EditorGUI.EndChangeCheck()) {
			RefreshCreator();
		}

	}

	private void OnEnable () {
		//creator = target as TextureCreator;
		//Undo.undoRedoPerformed += RefreshCreator;
	}
	
	private void OnDisable () {
		//Undo.undoRedoPerformed -= RefreshCreator;
	}
	
	private void RefreshCreator () {
		if (Application.isPlaying) {
			//creator.FillTexture();
		}
	}
}
