using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle
{
    [Header (" setting ")]

    private float radius;
    private int resolution;
    private int index;
    private int centerIndex;

    private Vector3 position;
    private Quaternion rotation;

    private bool isCap ;
    private bool isFlipped;



    [Header(" Data ")]

    private List<Vector3> vertices;
    private List<int> triangles;


    public circle(float radius, int resolution, int index, Vector3 position, Quaternion rotation, bool isCap, bool isFlipped)
    {
        this.radius = radius;
        this.resolution = resolution;
        this.index = index;
        this.centerIndex = index *(resolution + 1);
        this.position = position;
        this.rotation = rotation;
        this.isCap = isCap;
        this.isFlipped = isFlipped;
       vertices= new List<Vector3>();
        triangles = new List<int>();

        creatvertices();

        if (isCap)

            creatTriangles();
    }

    public Vector3[] GetVertices()
    {
        return vertices.ToArray();
    }

    public int[] GetTriangles()
    {
        return triangles.ToArray();
    }
    public int GetCenterIndex()
    { 
        return centerIndex;
    }

    private void creatvertices()
    {
        Vector3 center = position;

        vertices.Add(center);

        float angleBetweenPoints = 360f / resolution;

        for (int i = 0; i < resolution; i++)
        {
            Vector3 vertex = center;

            vertex.x += radius * Mathf.Cos(angleBetweenPoints * i * Mathf.Deg2Rad);
            vertex.y += radius * Mathf.Sin(angleBetweenPoints * i * Mathf.Deg2Rad);

            vertex = rotation * (vertex - center) + center;

            vertices.Add(vertex);
        }

    }
        private void creatTriangles()
        {
            for (int i = centerIndex; i < resolution - 1 +centerIndex; i++)
            {
                triangles.Add(centerIndex);

            if (!isFlipped)
            {
                triangles.Add(i + 2);
                triangles.Add(i + 1);
            }
            else
            {
                triangles.Add(i + 1);
                triangles.Add(i + 2);
            }




            }
            triangles.Add(centerIndex);

        if (!isFlipped)
        {
            triangles.Add(centerIndex + 1);
            triangles.Add(resolution + centerIndex);
        }
        else {
        
            triangles.Add(resolution + centerIndex);
            triangles.Add(centerIndex + 1);
        }

        }




    




}
