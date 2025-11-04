using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixCalculator : MonoBehaviour {

	readonly float[,] matrix1array = { { 2f, 5f, 6f }
									   
									 };
	readonly float[,] matrix2array = { { 3f },
										{4f },
										{-5f }
									 };
	public void Multiply()
	{
		Matrix matrix1 = new Matrix(1, 3);
		matrix1.Populate(matrix1array);
        Matrix matrix2 = new Matrix(3, 1);
        matrix2.Populate(matrix2array);
        Matrix result = Matrix.Multiply(matrix1, matrix2);
		string s = "";

        for (int j = 0; j < result.Rows; j++)
		{
			for (int i = 0; i < result.Columns; i++)
			{
				s += result.matrix[j, i].ToString()+", ";

            }
            Debug.Log(s);
			s = "";
        }
	}
}
