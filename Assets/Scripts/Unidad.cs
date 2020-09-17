using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unidad : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ruta;
    private int indice;
    private Vector3 posicion_inicial;
    private Vector3 posicion_siguiente;
    private float vel = 1.5f;
    private float distancia_punto = 0.5f;
    private bool esta_viva;

    public bool Esta_viva { get => esta_viva; set => esta_viva = value; }





    // Update is called once per frame

    private void Start()

    {
        esta_viva = true;
        posicion_inicial = this.transform.position;
        posicion_siguiente = ruta.transform.GetChild(0).position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bala")
        {
            Destroy(other.gameObject);
        }
    }
    

    void Update()
    {


        if (Esta_viva)
        {
            Vector3 dir = posicion_siguiente - this.transform.position;
            this.transform.position += dir * vel * Time.deltaTime;

            if (dir.magnitude <= distancia_punto)
            {
                if (indice + 1 < ruta.transform.childCount)
                {
                    indice++;
                    posicion_siguiente = ruta.transform.GetChild(indice).position;
                    Debug.Log("xs" + posicion_siguiente.x + "ys" + posicion_siguiente.y);
                }
                else
                {
                    indice = 0;
                    this.transform.position = posicion_inicial;
                    posicion_siguiente = ruta.transform.GetChild(0).position;
                }
            }
        }
       
    }

}

