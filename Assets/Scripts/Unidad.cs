using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unidad : MonoBehaviour
{
    [SerializeField]
    public GameObject ruta;
    private int indice;
    private Vector2 posicion_inicial;
    private Transform posicion_siguiente;
    private Transform posicion_actual;
    private float vel;
    private float distancia_punto;
    private bool esta_viva;
    private float tiempo;
    [SerializeField]
    private int vidas;
    private float delta_vida;
    private Vector3 posicion_muerte;
    //private Animator controlador;
    private LogicaBarra lb;
    public bool Esta_viva { get => esta_viva; set => esta_viva = value; }





    // Update is called once per frame

    private void Start()

    {
        vel = 2f;
        delta_vida = 1f / vidas;
        distancia_punto = .1f;
        esta_viva = true;
        posicion_inicial = this.transform.position;
        posicion_siguiente = ruta.transform.GetChild(0);
        //controlador = this.GetComponent<Animator>();
        lb = this.GetComponent<LogicaBarra>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Bala bala; 
        if (vidas > 0)
        {
            if (other.gameObject.tag == "bala")
            {
                bala = other.gameObject.GetComponent<Bala>();
                bala.Disparada = false;
                if (--vidas == 0)
                {
                    esta_viva = false;
                    Debug.Log("se murio");
                }
                else
                {
                    lb.ModificarBarra(delta_vida);
                }
            }
        }
       
    }
    

    void Update()
    {


        if (Esta_viva)
        {
            //Vector3 dir = posicion_siguiente - this.transform.position;
            // this.transform.position += dir * vel * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, posicion_siguiente.position, vel * Time.deltaTime);

            if (Vector2.Distance(transform.position,posicion_siguiente.position)<distancia_punto)
            {
                if (indice + 1 < ruta.transform.childCount)
                {
                    indice++;
                    posicion_actual = posicion_siguiente;
                    posicion_siguiente = ruta.transform.GetChild(indice);
                   //CambiarPosicion();
                }
                else
                {
                    indice = 0;
                    transform.position = posicion_inicial;
                    posicion_siguiente = ruta.transform.GetChild(0);
                    posicion_actual = null;
                    
                }
            }
        }
       
    }

    private void CambiarPosicion()
    {
        int direccion = 1;
        Direccion mira_hacia;

        if(posicion_actual != null)
        {
            mira_hacia = posicion_actual.GetComponent<Direccion>();
            if (mira_hacia.Ubicacion == Direccion.arriba)
            {
                direccion = Direccion.arriba;
            }
            mira_hacia = posicion_actual.GetComponent<Direccion>();
            if (mira_hacia.Ubicacion == Direccion.abajo)
            {
                direccion = Direccion.abajo;
            }
            mira_hacia = posicion_actual.GetComponent<Direccion>();
            if (mira_hacia.Ubicacion == Direccion.izquierda)
            {
                direccion = Direccion.izquierda;
            }
            mira_hacia = posicion_actual.GetComponent<Direccion>();
            if (mira_hacia.Ubicacion == Direccion.derecha)
            {
                direccion = Direccion.derecha;
            }
            //controlador.SetInteger("direccion", direccion);



        }




    }

}

