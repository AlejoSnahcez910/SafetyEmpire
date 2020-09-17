using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingUnidades : MonoBehaviour
{
    public static ArrayList enemigos = new ArrayList();

    void Start()
    {
        GameObject enemigo = GameObject.Find("Enemigo1");
        GameObject temp;
        Vector3 incremento = new Vector3(-1, 0);
        Vector3 posicion_actual = enemigo.transform.position;
        for (int i = 0; i < 10; i++)
        {
            temp = (GameObject)Instantiate(enemigo, posicion_actual + incremento, Quaternion.identity);
            posicion_actual = temp.transform.position;
            enemigos.Add(temp);
        }

    }

    // Update is called once per frame
    void Update() 
    {
        
    }
}
