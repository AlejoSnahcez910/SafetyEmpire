using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direccion : MonoBehaviour
{
    [SerializeField]
    private int ubicacion;
    public const int arriba = 1;
    public const int derecha = 2;
    public const int abajo = 3;
    public const int izquierda = 4;
    
    public int Ubicacion
    {
        get { return ubicacion; }
        set { ubicacion = value; }
    }
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
