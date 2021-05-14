using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovment : MonoBehaviour
{
    public GameObject destination;
    [SerializeField] private float speed  = 1f;
    [SerializeField] float turnSpeed = 1f; 
    void Update()
    {
        if (destination != null)
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, 
                                            destination.transform.position, 
                                            Time.deltaTime * speed);

            Vector3 lTargetDir = destination.transform.position - transform.position;
            lTargetDir.y = 0.0f;
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                                            Quaternion.LookRotation(lTargetDir),
                                            Time.time * turnSpeed);
        }
    }
}
