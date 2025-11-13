using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Analytics;

public class RotateObject : MonoBehaviour {

    public float ztheta = 0f;
    public float ytheta = 0f;
    public float xtheta = 0f;
    public bool radianMode;
    // Use this for initialization
    void Awake()
    {
    }
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //RotateCube();
        RotateWithQuaternions();
    }
    public void RotateCube()
    {
        Vector2 zRotation = Rotate(ztheta, gameObject.transform.position.x, gameObject.transform.position.y, radianMode);
        gameObject.transform.position = new Vector3(zRotation.x, zRotation.y, gameObject.transform.position.z);
        Vector2 yRotation = Rotate(ytheta, gameObject.transform.position.x, gameObject.transform.position.z, radianMode);
        gameObject.transform.position = new Vector3(yRotation.x, gameObject.transform.position.y, yRotation.y);
        Vector2 xRotation = Rotate(xtheta, gameObject.transform.position.y, gameObject.transform.position.z, radianMode);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, xRotation.x, xRotation.y);
    }

    public void RotateWithQuaternions()
    {
        //gameObject.transform.position = qRotate2(Vector3.right, xtheta, radianMode);
        //gameObject.transform.position = qRotate2(Vector3.up, ytheta, radianMode);
        //gameObject.transform.position = qRotate2(Vector3.forward, ztheta, radianMode);

        gameObject.transform.position = qRotate(gameObject.transform, xtheta, ytheta, ztheta, radianMode);
        //gameObject.transform.position = qRotate(gameObject.transform, 0, ytheta, 0, radianMode);
        //gameObject.transform.position = qRotate(gameObject.transform, 0, 0, ztheta, radianMode);
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

    public static Vector3 qRotate(Transform self, float xTheta, float yTheta, float zTheta, [DefaultValue("false")] bool radianMode)
    {
        if (!radianMode)
        {
            xTheta = xTheta * Mathf.Deg2Rad;
            yTheta = yTheta * Mathf.Deg2Rad;
            zTheta = zTheta * Mathf.Deg2Rad;
        }
        MyQuaternion p = new MyQuaternion(0, self.position.x, self.position.y, self.position.z);
        MyQuaternion q = new MyQuaternion(Mathf.Cos(xTheta), Mathf.Sin(xTheta), Mathf.Sin(yTheta), Mathf.Sin(zTheta));
        MyQuaternion qInverse = new MyQuaternion(Mathf.Cos(-xTheta), Mathf.Sin(-xTheta), Mathf.Sin(-yTheta), Mathf.Sin(-zTheta));
        //MyQuaternion q = new MyQuaternion(Mathf.Cos(theta), 0,0,0); //Mathf.Cos(the rest of the quaternion )

        MyQuaternion result = MyQuaternion.QuaternionMultiplication(p, qInverse);
        MyQuaternion result2 = MyQuaternion.QuaternionMultiplication(q, result);
        if(result.S == Mathf.Infinity)
        {
            result.S = -1f * Mathf.Infinity;
        }
        Vector3 dir = new Vector3(result2.X, result2.Y, result2.Z);
        return dir;
    }

    public static Vector3 qRotate2(Vector3 dir, float theta, [DefaultValue("false")] bool radianMode)
    {
        if (!radianMode)
        {
            theta = theta * Mathf.Deg2Rad;
            //yTheta = yTheta * Mathf.Deg2Rad;
            //zTheta = zTheta * Mathf.Deg2Rad;
        }
        MyQuaternion q = new MyQuaternion(Mathf.Cos(theta), Mathf.Sin(theta), Mathf.Sin(theta), Mathf.Sin(theta));
        MyQuaternion p = new MyQuaternion(5,dir.x,dir.y,dir.z);
        //MyQuaternion qInverse = new MyQuaternion(Mathf.Cos(-theta), Mathf.Sin(-theta), Mathf.Sin(-theta), Mathf.Sin(-theta));
        //MyQuaternion q = new MyQuaternion(Mathf.Cos(theta), 0,0,0); //Mathf.Cos(the rest of the quaternion )

        //MyQuaternion result = MyQuaternion.QuaternionMultiplication(p, qInverse);
        MyQuaternion result2 = MyQuaternion.QuaternionMultiplication(q, p);
        if (result2.S == Mathf.Infinity)
        {
            result2.S = -1f * Mathf.Infinity;
        }
        Vector3 pos = new Vector3(result2.X, result2.Y, result2.Z);
        return pos;
    }
}
