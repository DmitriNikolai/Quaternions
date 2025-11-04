using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    public float ztheta = 0f;
    public float ytheta = 0f;
    public float xtheta = 0f;
    public bool radianMode;
	// Use this for initialization
	void Awake()
	{
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RotateCube();
    }
    public void RotateCube()
    {
        Vector2 zRotation = Rotate(ztheta, gameObject.transform.position.x, gameObject.transform.position.y, radianMode);
        gameObject.transform.position = new Vector3 (zRotation.x, zRotation.y, gameObject.transform.position.z);
        Vector2 yRotation = Rotate(ytheta, gameObject.transform.position.x, gameObject.transform.position.z, radianMode);
        gameObject.transform.position = new Vector3( yRotation.x, gameObject.transform.position.y, yRotation.y);
        Vector2 xRotation = Rotate(xtheta, gameObject.transform.position.y, gameObject.transform.position.z, radianMode);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x ,xRotation.x, xRotation.y);
    }

	public static Vector2 Rotate(float theta, float dir1, float dir2, [DefaultValue("false")] bool radianMode)
	{
        float[,] rotation;

        Matrix rotationMatrix = new Matrix(2, 2);
        Matrix positionMatrix = new Matrix(2, 1);
        Matrix newPositionMatrix = new Matrix(2, 1); 
        if (radianMode){
             rotation = new float[,] {
                                 { Mathf.Cos(theta), -1f * Mathf.Sin(theta) },
                                 { Mathf.Sin(theta), Mathf.Cos(theta) }
                                };
        }
        else
        {
            rotation = new float[,] {
                                 { Mathf.Cos((theta * Mathf.PI)/180), -1f * Mathf.Sin((theta * Mathf.PI)/180) },
                                 { Mathf.Sin((theta * Mathf.PI)/180), Mathf.Cos((theta * Mathf.PI)/180) }
                                };
        }


        rotationMatrix = new Matrix(2, 2);
        rotationMatrix.Populate(rotation);
        float[,] TwoDPosition = new float[,] { {dir1}, { dir2} };
        //float[,] TwoDPosition = new float[,] { { 0 }, { 5 } };
        positionMatrix = new Matrix(2, 1);
        positionMatrix.Populate(TwoDPosition);
        newPositionMatrix = new Matrix(2, 1);
        newPositionMatrix = Matrix.Multiply(rotationMatrix, positionMatrix);

        Vector2 dir = new Vector2(newPositionMatrix.matrix[0, 0], newPositionMatrix.matrix[1, 0]);
        return dir;
        //gameObject.transform.position = new Vector3(newPositionMatrix.matrix[0, 0], newPositionMatrix.matrix[1, 0], 0f);
    }
}
