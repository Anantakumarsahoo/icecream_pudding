using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posideral_circel : MonoBehaviour
{
    // Start is called before the first frame update
    [Header(" Elements ")]
    [SerializeField] private MeshFilter filter;

    [Header(" setting ")]
    [Range(3, 20)]
    [SerializeField] private int circleresoluction;
    [SerializeField] private float radius;

    [Header(" icecream settings")]
    [SerializeField] private int icecreamResoiution;
    [SerializeField] private float icecreamRadius;
    [SerializeField] private float icecreamHeight;
    [Range(1, 20)]
    [SerializeField] private int loops;



    [SerializeField] SkinnedMeshRenderer meshRendererTouse;
    [SerializeField] Material materialTouse;



    [Header(" Data ")]
    Mesh mesh;

    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();

    List <circle> circles= new List<circle>();

    // Start is called before the first frame update
    void Start()
    {
        genarate_circle();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            meshRendererTouse.materials[1] = materialTouse;
        }
      
    }

    private void genarate_circle()
    {
        mesh =new Mesh();

     vertices.Clear();
        triangles.Clear();
        circles.Clear();
        creatCircle();

        linkCircles();




        UpdateData();


        mesh.vertices = vertices.ToArray();


        mesh.triangles = triangles.ToArray();



        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        filter.mesh = mesh;



    }


    private void  creatCircle()
    {

        float angleStep = loops* 360 / icecreamResoiution;
        float yStep = icecreamHeight/ icecreamResoiution;

        for( int i=0; i< icecreamResoiution;i++)
        {
            Vector3 position = Vector3.zero;

            float currentCirclrPesent = 1- ((float)i /  icecreamResoiution);

            float realicecreamradius= currentCirclrPesent* icecreamRadius;

            position.x =realicecreamradius * Mathf.Cos(Mathf.Deg2Rad* i *angleStep);
            position.y = i * yStep;
            position.z = realicecreamradius * Mathf.Sin(Mathf.Deg2Rad * i * angleStep);

            Quaternion rotation = Quaternion.Euler(0, -angleStep*i, 0);

            bool iscap = i == 0 || i == icecreamResoiution - 1;
            bool isFlipped = i == icecreamResoiution - 1;


            circle circle = new circle(radius, circleresoluction, i, position, rotation, iscap, isFlipped);

            circles.Add(circle);
        }

    }

    private void UpdateData()
    {
        for(int i=0;i <circles.Count;i++)
        {
            vertices.AddRange(circles[i].GetVertices());
            triangles.AddRange(circles[i].GetTriangles());
        }
    }

    private void linkCircles()
    {
        for(int i=0;i <circles.Count-1;i++)
            linkCircles(circles[i], circles[i+1]);
    }


    private void linkCircles( circle c0,circle c1)
    {
        int c0CenterIndex = c0.GetCenterIndex();
        int c1CenterIndex = c1.GetCenterIndex();


        for(int i=0;i <circleresoluction -1;i++)
        {
            triangles.Add(c0CenterIndex + i + 1);
            triangles.Add(c1CenterIndex + i + 2);
            triangles.Add(c1CenterIndex + i + 1);

            triangles.Add(c0CenterIndex + i + 1);
            triangles.Add(c0CenterIndex + i + 2);
            triangles.Add(c1CenterIndex + i + 2);





        }

        triangles.Add(c0CenterIndex + circleresoluction);
        triangles.Add(c1CenterIndex + 1);
        triangles.Add(c1CenterIndex + circleresoluction);

        triangles.Add(c0CenterIndex + circleresoluction);
        triangles.Add(c0CenterIndex + 1);
        triangles.Add(c1CenterIndex + 1);

    }


  

 void ChangeMaterialOnMesh()
    {
       
    }
    
    





   
}
