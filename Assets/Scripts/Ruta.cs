using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruta : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ruta;
    private int indice;
    private float time;

    // Update is called once per frame
    void Update()
    {
       if(time >0.5)
       {
            if (indice < ruta.transform.childCount)
            {
                Debug.Log(ruta.transform.GetChild(indice).transform.position.x + " " + ruta.transform.GetChild(indice).transform.position.y);
                this.transform.position = new Vector3(ruta.transform.GetChild(indice).transform.position.x, ruta.transform.GetChild(indice).transform.position.y, this.transform.position.z);

                indice++;
            }
            time = 0;
        
       }
       else
        {
            time += Time.deltaTime;
        }
    }
}
