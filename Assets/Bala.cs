using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour

{
    public const float TIEMPO_DISPARO = .5F;
    private GameObject objetivo;
    private float velocidad;
    private bool disparada;
    private Vector3 puntoInicial;

    private float tiempo;

    private SpriteRenderer sr;
    void Start()
    {
        velocidad = 7;
        sr = this.GetComponent<SpriteRenderer>();
        puntoInicial = new Vector3(-5, 4);
        CambiarOpacidad(0f);
    }

    // Update is called once per frame
    void Update()
    {
     if (objetivo != null)
        {
            if (TiempoVida())
            {
                MoverBalaAunPunto();
            }
            else
            {
                ReciclarBala();
            }
            if (!disparada)
            {
                ReciclarBala();
            }
        }
        
    }
    private bool TiempoVida()
    {
        tiempo += Time.deltaTime;
        return tiempo < TIEMPO_DISPARO;
    }

    private void MoverBalaAunPunto()
    {
        Vector3 direccion;
        Unidad unidad = objetivo.GetComponent<Unidad>();

        if (unidad.Esta_viva)
        {
            Disparada = true;
            direccion = objetivo.transform.position - this.transform.position;
            this.transform.position += velocidad * direccion * Time.deltaTime;
        }
    }

    private void CambiarOpacidad(float valor)
    {
        //sr.color = new Color(1f, 1f, 1f, valor);
    }

    private void ReciclarBala()
    {
        this.transform.position = puntoInicial;
        objetivo = null;
        Disparada  = false;
        CambiarOpacidad(0f);
        tiempo = 0f;

    }

    public void ActivarBala(Torre torre)
    {
        Disparada = true;
        objetivo = torre.Enemigo;
        tiempo = 0;
        puntoInicial = torre.transform.position;
        transform.position = puntoInicial;
        CambiarOpacidad(1f);
    } 

    public bool Disparada
    {
        get
        {
            return disparada;
        }
        set
        {
            disparada = value;
        }
    }



}
