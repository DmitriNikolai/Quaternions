using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexCalculator : MonoBehaviour {
	[SerializeField]
	public ComplexNumber imaginary1;
	public ComplexNumber imaginary2;
	// Use this for initialization
	public void Add() {
		ComplexNumber result = Imaginary.ComplexAddition(imaginary1, imaginary2);
		string sReal = result.Real.ToString();
		string sImaginary = result.Imaginary.ToString();
		Debug.Log(sReal + " + " + sImaginary + "i");
	}
	public void Multiply() {
        ComplexNumber result = Imaginary.ComplexMultiplication(imaginary1, imaginary2);
        string sReal = result.Real.ToString();
        string sImaginary = result.Imaginary.ToString();
        Debug.Log(sReal + " + " + sImaginary + "i");
    }
}
