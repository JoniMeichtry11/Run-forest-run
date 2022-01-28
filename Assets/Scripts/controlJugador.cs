using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlJugador : MonoBehaviour
{
    private Rigidbody rbJugador;
    private Animator animJugador;

    private AudioSource sonidoJugador;

    public ParticleSystem explosion;
    public ParticleSystem polvo;

    public AudioClip sonidoExplosion;
    public AudioClip sonidoSalto;

    public float fuerzaSalto = 10;
    public float modificadorGravedad = 2;
    public bool estaEnElSuelo = true;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        rbJugador = GetComponent<Rigidbody>();
        Physics.gravity *= modificadorGravedad;
        animJugador = GetComponent<Animator>();
        sonidoJugador = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaEnElSuelo)
        {
            rbJugador.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            estaEnElSuelo = false;
            animJugador.SetTrigger("Jump_trig");
            polvo.Stop();
            sonidoJugador.PlayOneShot(sonidoSalto, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            estaEnElSuelo = true;
            polvo.Play();
        } else if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            animJugador.SetTrigger("Death_b");
            explosion.Play();
            polvo.Stop();
            sonidoJugador.PlayOneShot(sonidoExplosion, 1.0f);
        }
    }
}
