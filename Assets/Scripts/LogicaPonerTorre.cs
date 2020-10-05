using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPonerTorre : MonoBehaviour
{
    [SerializeField]
    private GameObject go_torre;
    private Hud hud;
    private Torre torre;
     void OnMouseDown()
    {
        GameObject temp;
        Vector3 pos = this.transform.position;
        pos.y = pos.y + 0.4f;
        temp = (GameObject)Instantiate(go_torre, pos, Quaternion.identity);
        temp.transform.position = pos;
        temp.layer = 5;
        hud = Hud.GetInstance();
        torre = temp.GetComponent<Torre>();

        if (torre.Valor_actual <= hud.Contador_monedas)
        {
            torre.Esta_activa = true;
            Destroy(this.gameObject);
            hud.DecontarSaldo(torre.Valor_actual);
        }
        else
        {
            
            Destroy(temp);
        }

        torre.Esta_activa = true;
        Destroy(this.gameObject);

    }

     
}
