using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.Find("PLAYER").transform;
    }

    private void LateUpdate() //se suele utilizar para configurar las animaciones que dependen de estos parámetros
    {
        transform.position = playerTransform.position; //La posicion se esta cambiando constantemente
    }

}
