using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    public MeshRenderer mesh;
    public BoxCollider collider;

    public static Cube instance;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        collider = GetComponent<BoxCollider>();
        if (instance == null) instance = this;
        mesh.enabled = false;
    }
}

