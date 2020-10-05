using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaBarra : MonoBehaviour
{

   

    [SerializeField]
    private GameObject barraVerde;

    [SerializeField]
    private GameObject barraRoja;

    
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = barraVerde.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }

    public void ModificarBarra(float escala)
    {
        if (sr.transform.localScale.x > 0)
        {
            sr.transform.localScale -= new Vector3(escala, 0);
        }
    }
}
