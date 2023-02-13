using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 30f;
    private float forwardInput;
    private Rigidbody _rigidbody;
    private float originalScale = 1.5f;
    private float powerupScale = 2f; //escala eumentada por el powerup
    private bool hasPowerup, hasPowerup2;

    private GameObject focalPoint;

    private void Start()
    {
        
        focalPoint = GameObject.Find("FocalPoint");

    }

    private void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>(); //aquí declaras el script para que le hagas caso
    }


    
    public GameObject[] powerupIndicators;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDown());
        }
        if (other.gameObject.CompareTag("Powerup2"))
        {
            hasPowerup2 = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDown());
        }

    }

    public float PowerupCountdown;
    public float powerupForce = 15f;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            

            Rigidbody enemyRigidbody = other.gameObject.
            GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position).normalized;
            enemyRigidbody.AddForce(awayFromPlayer * powerupForce, ForceMode.Impulse);
        }
    }

    private IEnumerator PowerupCountDown()
    {

        if (hasPowerup2)
        {
            transform.localScale = 2 * Vector3.one;
        }
        for (int i = 0; i < powerupIndicators.Length; i++)
        {
            powerupIndicators[i].SetActive(true);
            yield return new WaitForSeconds(2);
            powerupIndicators[i].SetActive(false);
        }
        if (hasPowerup2)
        {
            transform.localScale = originalScale * Vector3.one;
        }
        hasPowerup = false;
        hasPowerup2 = false;
    }
}

