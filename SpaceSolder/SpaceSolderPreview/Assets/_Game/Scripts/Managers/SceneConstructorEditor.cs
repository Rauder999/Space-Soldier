using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneConstructor))]
public class SceneConstructorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var sceneConstructor = target as SceneConstructor;
        EditorGUILayout.Space();
        if(!sceneConstructor.constructDatas.IsNullOrEmpty())
        {
        for(int index = 0; index < sceneConstructor.constructDatas.Count; index++)
            {
                SceneConstructor.ConstructData data = sceneConstructor.constructDatas[index];
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField("Element " + index);
                data.Prefab = (GameObject)EditorGUILayout.ObjectField("Prefab", data.Prefab, typeof(GameObject), false);
                data.TransPos = EditorGUILayout.Vector3Field("TransPos", data.TransPos);
                data.Rotation = Quaternion.Euler(EditorGUILayout.Vector3Field("Rotation", data.Rotation.eulerAngles));
                if (GUILayout.Button("Save"))
                {
                    var selectedObject = Selection.activeGameObject;
                    if (selectedObject != null)
                    {

                        data.TransPos = selectedObject.transform.position;
                        data.Rotation = selectedObject.transform.rotation;
                        sceneConstructor.constructDatas.RemoveAt(index);
                        sceneConstructor.constructDatas.Insert(index, data);
                    }
                }
                if (GUILayout.Button("Spawn"))
                {
                    Instantiate(data.Prefab, data.TransPos, data.Rotation);
                }
                EditorGUILayout.EndVertical();
            }
        }
    }
}
