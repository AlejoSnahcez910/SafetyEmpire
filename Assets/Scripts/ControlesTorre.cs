using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesTorre : MonoBehaviour
{
    [SerializeField]
    private GameObject botonActualizar;
    [SerializeField]
    private GameObject BotonVender;
    // Start is called before the first frame update
    void Start()
    {
        CambiarEstadoBotones(false);
    }
    private void OnMouseDown()
    {
        CambiarEstadoBotones(true);
    }
    public void CambiarEstadoBotones (bool estado)
    {
        botonActualizar.SetActive(estado);
        BotonVender.SetActive(estado);
    }
    // Update is called once per frame
   
}
