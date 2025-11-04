using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MatrixCalculator), true), CanEditMultipleObjects]
public class MatrixCalculatorEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MatrixCalculator matrixCalc = (MatrixCalculator)target;

        if (GUILayout.Button("Multiply"))
        {
            matrixCalc.Multiply();
        }
    }
}
