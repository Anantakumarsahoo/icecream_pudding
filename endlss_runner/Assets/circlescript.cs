using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circlescript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Elements")]
    [SerializeField] private MeshFilter filter;
    public GameObject lll;
    [Header("setting")]
    [Range(3, 20)]
    [SerializeField] private int circleresoluction;
    [SerializeField] private float radius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
