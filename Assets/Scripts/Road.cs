using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] GameObject destination;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            other.gameObject.GetComponent<CarMovment>().destination = destination;

        }
    }
}
