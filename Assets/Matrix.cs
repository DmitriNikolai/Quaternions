using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix {

	public int Rows;
	public int Columns;

	public float[,] matrix;

	public Matrix (int _rows, int _columns){
		Rows = _rows; Columns = _columns;
	}
	public void Populate(float[,] _matrix)
	{
		matrix = _matrix;
	}
	public static Matrix Multiply(Matrix matrix1, Matrix matrix2) {
		if (matrix1.Columns != matrix2.Rows)
		{
			//Matrix rules
			//Columns of first matrix (x direction, number of y) have to equal Rows (y direction, number of x) of second matrix
			//Resulting Matrix is equal to number of rows in first matrix by columns in second column
			Debug.Log("matrix error");
			Matrix emptyMatrix = new Matrix(0, 0);

			return emptyMatrix;
		}
            int r1 = matrix1.Rows;
            int c1 = matrix1.Columns;
			// rows unnecessary
            int c2 = matrix2.Columns;
            float[,] result = new float[r1, c2];
            for (int y = 0; y < r1; y++)
            {
                for (int x = 0; x < c2; x++)
                {
                    for (int w = 0; w < c1; w++)
                    {
						result[y,x] += matrix1.matrix[y, w] * matrix2.matrix[w, x];


                    }
                }
            }
			Matrix matrix = new Matrix(r1, c2);
			matrix.Populate(result);
			return matrix;
    }
}
