using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hud : MonoBehaviour
{
    private static Hud instancia;
    [SerializeField]
    private Text monedas;
    

    private int contador_monedas;
    private int contador_vidas;

    public static Hud GetInstance()
    {
        return instancia;
    }

    public int Contador_monedas {
        get
        {
            return contador_monedas;
        }
        set
        {
            contador_monedas = value;
        }
    }

   

   

    void Start()
    {
        instancia = this;
        contador_monedas = 300;
        instancia = this;
    }
    public void ActualizarMoneda(int valor)
    {
        Contador_monedas += valor;
    }


    // Update is called once per frame
    void Update()
    {
        monedas.text = Contador_monedas.ToString();
    }

    public void DecontarSaldo(int valor)
    {
        contador_monedas -= valor;
    }
}
