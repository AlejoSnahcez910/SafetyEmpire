using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject enemigo;
    private bool esta_activa;
    private float distancia_umbral;
    private float tiempo_disparo;
    private GameObject[] balas;
    private int valor_actual;

    public Torre()
    {
        Valor_actual= 150;
    }



    void Start()
    {
        distancia_umbral = 1.5f;
        tiempo_disparo = .8f;
        crearBalas(5);

    }
    void Update()
    {
        Enemigo = BuscarEnemigoCercano();
        if (Enemigo != null&& tiempo_disparo <= 0)
        {
            Disparar();
            Debug.DrawLine(this.transform.position, enemigo.transform.position, Color.yellow);
            tiempo_disparo = 1f;
        }
        else
        {
            tiempo_disparo -= Time.deltaTime;
        }
    }

    private void crearBalas(int totalBalas)
    {
        balas = new GameObject[totalBalas];
        for (int i = 0; i < balas.Length; i++)
        {
            balas[i] = Instantiate(GameObject.Find("bala"), this.transform.position, Quaternion.identity);
        }
    }

    private Bala DespacharBalaLibre()
    {
        Bala libre = null;
        for (int i = 0; i < balas.Length ; i++)
        {
            libre = balas[i].GetComponent<Bala>();
            if (!libre.Disparada)
            {
                break;
            }
        }
        return libre;

    }
    void Disparar()
    {
        Bala bala = DespacharBalaLibre();
        bala.ActivarBala(this);
    }

    GameObject BuscarEnemigoCercano()
    {
        ArrayList enemigos = PoolingUnidades.enemigos;
        GameObject temp;
        foreach (Object item in enemigos)
        {
            temp = (GameObject)item;
            if(Vector3.Distance(temp.transform.position,this.transform.position) < distancia_umbral)
            {
                return temp;
            }
        }
        return null;

    }


    public GameObject Enemigo { get => enemigo; set => enemigo = value; }
    public int Valor_actual { get => valor_actual; set => valor_actual = value; }
    public bool Esta_activa
    {
        get
        {
            return esta_activa;
        }

        set
        {
            esta_activa = value;

        }

    }


    // Update is called once per frame

}
