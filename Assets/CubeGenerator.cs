using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CubeGenerator : MonoBehaviour
{

	Mesh mesh;
	Vector3[] vertices;
	int[] triangles;
	Vector2 zRotation;
    public float zTheta;
    public float yTheta;
    public float xTheta;
    // Use this for initialization
    void Start()
	{
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;


	}

	// Update is called once per frame
	void Update()
	{
		CreateShape();
		RotateMesh();
		UpdateMesh();
	}

	void CreateShape()
	{
		vertices = new Vector3[]
		{

			new Vector3(-1, 1,-1),
			new Vector3(-1, 1,1),
			new Vector3(1, 1,-1),
			new Vector3(1, 1,1),
			new Vector3(-1,-1,-1),
			new Vector3(-1,-1,1),
			new Vector3(1,-1,-1),
			new Vector3(1,-1,1)
		};
		triangles = new int[]
		{
		2,1,3,
		0,1,2,
		2,4,0,
		0,4,5,
		6,4,2,
		3,6,2,
		7,6,3,
		3,5,7,
		1,5,3,
		0,5,1,
		7,4,6,
		5,4,7





		};
	}
	void UpdateMesh()
	{
		mesh.Clear();
		mesh.vertices = vertices;
		mesh.triangles = triangles;

		mesh.RecalculateNormals();

	}

	void RotateMesh()
	{
		for (int i = 0; i < mesh.vertices.Length; i++)
        {
			vertices[i].Normalize();
            Vector2 zRotation = RotateObject.Rotate(zTheta, vertices[i].x, vertices[i].y,false);
			vertices[i] = new Vector3(zRotation.x, zRotation.y, vertices[i].z);
		}
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            Vector2 yRotation = RotateObject.Rotate(yTheta, vertices[i].x, vertices[i].z, false);
            vertices[i] = new Vector3(yRotation.x, vertices[i].y, yRotation.y);
        }
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            Vector2 xRotation = RotateObject.Rotate(xTheta, vertices[i].y, vertices[i].z, false);
            vertices[i] = new Vector3(vertices[i].x, xRotation.x, xRotation.y);
        }
    }
}
