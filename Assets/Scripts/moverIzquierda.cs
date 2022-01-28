using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverIzquierda : MonoBehaviour
{
    private float velocidad = 20;
    private float limiteIzquierdo = -15;

    private controlJugador scriptControlJugador; 
    // Start is called before the first frame update
    void Start()
    {
        scriptControlJugador = GameObject.Find("Jugador").GetComponent<controlJugador>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!scriptControlJugador.gameOver)
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }

        if (transform.position.x < limiteIzquierdo && gameObject.CompareTag("Obstaculo"))
        {
            Destroy(gameObject);
        }
    }
}
