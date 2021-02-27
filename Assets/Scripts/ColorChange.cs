using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material[] mat;
    private Material col;
    [SerializeField] private Renderer rend;


    private void Start()
    {
        rend = this.GetComponentInChildren<Renderer>();
    }

    public void Blue()
    {
        rend.material = mat[0];
        col = rend.material;
    }
    

    //public void ChangeMaterial()
    //
    //foreach (Renderer r in this.GetComponentsInChildren<Renderer>())
    //    {
    //        r.material.color = Color.red;
    //    }
    //}
    
    
}
