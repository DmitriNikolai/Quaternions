using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RotateObject), true), CanEditMultipleObjects]
public class RotateObjectEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        RotateObject rotateObject = (RotateObject)target;

        if (GUILayout.Button("Rotate"))
        {
            rotateObject.RotateWithQuaternions();
        }
    }
}
