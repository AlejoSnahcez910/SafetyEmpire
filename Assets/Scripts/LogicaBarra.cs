using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaBarra : MonoBehaviour
{

    public GameObject enemigo;
    public GameObject barraVerde;
    public GameObject barraRoja;
    float escala = 0.001f;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = barraVerde.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sr.transform.localScale.x > 0)
        {
            sr.transform.localScale -= new Vector3(escala, 0);
            barraVerde.transform.position = enemigo.transform.position - new Vector3(0.125f-sr.bounds.size.x/2,- 0.4f);
            barraRoja.transform.position = enemigo.transform.position - new Vector3(0,-0.4f);
        }
        
    }
}
