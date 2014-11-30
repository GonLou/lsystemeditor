///////////////////////////////////////////////////////////////////
/// 
/// author:
/// Goncalo Lourenco
/// 
/// 
/// <summary>
/// Interface editor from Lindenmayer.cs
/// </summary>
/// 
///////////////////////////////////////////////////////////////////

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
			myScript.CreateFullAxiom();
			myScript.Axiom2Vectors();
			// save to file if toggle is checked
			if (GUI.Toggle(new Rect(10, 10, 100, 30), myScript.toggleSaveFile, "save to file")) myScript.SaveFile();
			myScript.drawEnable = true;
		}

		if (GUILayout.Button("+")) {
			myScript.BiggerRecord();
			myScript.LoadFile(myScript.record_number);
		}

		EditorGUILayout.LabelField("Record number # ", (myScript.record_number+1).ToString());

		if (GUILayout.Button("-")) {
			myScript.SmallerRecord();
			myScript.LoadFile(myScript.record_number);
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
