using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUCLE : MonoBehaviour
{
    
    public int value;
    public string[] names;
    public Vector3[] positions;
    public GameObject prefab;
    
    void Start()
    {
        /* for(int i = 0; i <= 10; i++)
         {
             Debug.Log(i);

         }
         //ejemplo de tabla de multiplicar
         for(int i = 1; i <= 10; i++)
         {
             Debug.Log(message: $"{value}x {i} = {value * 1}");
         }
        //instanciar elementos
        //version for
         for(int i = 0; i < names.Length; i++)
         {
             Debug.Log(names[i]);
         }

        //version for each

        foreach (Vector3 p in positions)
        {
            Instantiate(prefab, p, Quaternion.identity);
        }

        /*for (int i = 0; i < positions.Length; i++)
        {
            Instantiate(prefab, positions[i], Quaternion.identity);
        }*/

        //multiplicacion while

        int i = 1;
        while (i <= 10)
        {
            Debug.Log(message: $"{value} x {i} = {value * i}");
            i++; //se pone esto para no activar el infinito y que unity pete
        }

    }



}
