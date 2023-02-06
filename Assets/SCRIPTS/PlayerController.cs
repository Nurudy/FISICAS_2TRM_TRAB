using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 30f;
    private float forwardInput;
    private Rigidbody _rigidbody;

    private GameObject focalPoint;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); //aquí declaras el script para que le hagas caso
        focalPoint = GameObject.Find("FocalPoint");

    }

    private void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }


    public bool hasPowerup;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
        }

    }

    public float PowerupCountdown;
        public float powerupForce = 15f;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(PowerupCountDown());

            Rigidbody enemyRigidbody = other.gameObject.
            GetComponent<Rigidbody>();
            Vector3 awayFromPlayer =
            (other.gameObject.transform.position - transform.position).normalized;
            enemyRigidbody.AddForce(awayFromPlayer * powerupForce, ForceMode.Impulse);
        }
    }

    private IEnumerator PowerupCountDown()
    {
        yield return new WaitForSeconds(6);
        hasPowerup = false;
    }
}

