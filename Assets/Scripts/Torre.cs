using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject enemigo;
    private float distancia_umbral = 4.3f;

    void Start()
    {

    }
    void Update()
    {
        Enemigo = BuscarEnemigoCercano();
        if (Enemigo != null)
        {
            Disparar();
            Debug.DrawLine(this.transform.position, enemigo.transform.position, Color.yellow);
        }
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

    void Disparar()
    {
        GameObject obj = (GameObject)Instantiate(GameObject.Find("bala"), this.transform.position, Quaternion.identity);
        Bala bala = obj.GetComponent<Bala>();
        bala.ActivarBala(this);
    }

    public GameObject Enemigo { get => enemigo; set => enemigo = value; }

    

    // Update is called once per frame
   
}
