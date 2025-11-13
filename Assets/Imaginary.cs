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
    public float S;
    public float X;
    public float Y;
    public float Z;
    public MyQuaternion(float s, float x, float y, float z)
    {
        S = s; X = x; Y = y; Z = z;
    }

    public static MyQuaternion QuaternionMultiplication(MyQuaternion q1, MyQuaternion q2)
    {
        //(sasb−xaxb−yayb−zazb)+(saxb+sbxa+yazb−ybza)i+(sayb+sbya+zaxb−zbxa)j+(sazb+sbza+xayb−xbya)k
        float sPart = (q1.S * q2.S) - (q1.X * q2.X) - (q1.Y * q2.Y) - (q1.Z * q2.Z);
        float iPart = (q1.S * q2.X) + (q2.S * q1.X) + (q1.Y * q2.Z) - (q2.Y * q1.Z);
        float jPart = (q1.S * q2.Y) + (q2.S * q1.Y) + (q1.Z * q2.X) - (q2.Z * q1.X);
        float kPart = (q1.S * q2.Z) + (q2.S * q1.Z) + (q1.X * q2.Y) - (q2.X * q1.Y);

        MyQuaternion result = new MyQuaternion(sPart, iPart, jPart, kPart);
        return result;
    }
    public static MyQuaternion QuaternionConjugate(MyQuaternion q1)
    {

        MyQuaternion result = new MyQuaternion(q1.S, -1f * q1.X, -1f * q1.Y,-1f * q1.Z);
        return result;
    }

}
