using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 25f;
    private float yMin = -10f;
    private Rigidbody _rigidbody;
    private GameObject player;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("PLAYER");
    }
    private void Update()
    {
        //cálculo de la direccion del enemigo -> player
        Vector3 direction = (player.transform.position -
         transform.position).normalized;
        //aplicar la fuerza para que el enemigo se mueva siempre hacia el player a la mimsa velocidad
        _rigidbody.AddForce(direction * speed);
        //comprueba si ha caido, y si ha caido por debajo del límite, el enemigo se destruye.
        if (transform.position.y < yMin) //si el enemigo cae por la plataforma, a los 10 metros se destruye
        {
            Destroy(gameObject);
        }
    }
}
