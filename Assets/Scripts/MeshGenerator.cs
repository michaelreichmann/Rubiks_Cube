using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    public float size = 1;

    [SerializeField]
    private Material[] materials;

    private Mesh mesh;
    Vector3[] vertices;


    private void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateCube();
        UpdateMesh();
    }

    private void CreateCube()
    {
        vertices = new Vector3[]
        {
            new Vector3(-size, -size, -size),
            new Vector3(-size,  size, -size),
            new Vector3( size,  size, -size),
            new Vector3( size, -size, -size),
            new Vector3( size, -size,  size),
            new Vector3( size,  size,  size),
            new Vector3(-size,  size,  size),
            new Vector3(-size, -size,  size)
        };
    }


    private void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        
        mesh.subMeshCount = 6;
        mesh.SetTriangles(new[] { 0, 1, 3, 1, 2, 3 }, 0);
        mesh.SetTriangles(new[] { 0, 7, 6, 0, 6, 1 }, 1);
        mesh.SetTriangles(new[] { 5, 2, 1, 5, 1, 6 }, 2);
        mesh.SetTriangles(new[] { 3, 2, 5, 3, 5, 4 }, 3);
        mesh.SetTriangles(new[] { 3, 4, 7, 3, 7, 0 }, 4);
        mesh.SetTriangles(new[] { 4, 5, 6, 4, 6, 7 }, 5);

        //materials get assigned in order
        GetComponent<Renderer>().materials = materials;

        mesh.RecalculateNormals();
    }
}
