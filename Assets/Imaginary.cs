using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imaginary {
    public static ComplexNumber ComplexAddition(ComplexNumber complex1, ComplexNumber complex2)
    {
        //(a+bi) + (c+di) = (a + c) + (b + d)i 
        float realPart = complex1.Real + complex2.Real;
        float imaginaryPart = complex1.Imaginary + complex2.Imaginary;

        ComplexNumber result = new ComplexNumber(realPart, imaginaryPart);
        return result;
    }
    public static ComplexNumber ComplexMultiplication(ComplexNumber complex1, ComplexNumber complex2)
    {
        //(a+bi)(c+di) = (a*c) - (b * d) + (ad + cb)i 
        float realPart = (complex1.Real * complex2.Real) - (complex1.Imaginary * complex2.Imaginary);
        float imaginaryPart = (complex1.Real * complex2.Imaginary) + (complex1.Imaginary * complex2.Real);

		ComplexNumber result = new ComplexNumber(realPart, imaginaryPart);
		return result;
    }
}

[System.Serializable]
public class ComplexNumber
{
	public float Real;
	public float Imaginary;

	public ComplexNumber(float real, float imaginary)
	{
		Real = real;
		Imaginary = imaginary;
	}

}

[System.Serializable]
public class MyQuaternion
{
    public float X;
    public float Y;
    public float Z;
    public float W;

    public MyQuaternion(float x, float y, float z, float w)
    {
        X = x; Y = y; Z = z; W = w;
    }
}
