using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ComplexCalculator),true), CanEditMultipleObjects]
public class ComplexCalculatorEditor : Editor {

	public override void OnInspectorGUI()
	{
        base.OnInspectorGUI();
        ComplexCalculator complexCalc = (ComplexCalculator)target;

        if (GUILayout.Button("Add"))
        {
            complexCalc.Add();
        }
        if (GUILayout.Button("Multiply"))
        {
            complexCalc.Multiply();
        }
    }
}
