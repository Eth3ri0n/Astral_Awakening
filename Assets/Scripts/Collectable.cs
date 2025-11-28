// Raphael Marczak - University of Waikato - DIW (UTTOP) 2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TOUCHED" + other.name);
        Transform currentProcessedTransform = other.transform;


        while (currentProcessedTransform != null)
        {
            Collector currentCollector = currentProcessedTransform.GetComponent<Collector>();
            if (currentCollector != null)
            {
                currentCollector.NewObjectCollected();
                this.gameObject.SetActive(false);
            }

            currentProcessedTransform = currentProcessedTransform.transform.parent;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("TOUCHED Coll");
        OnTriggerEnter(collision.collider);
    }
}
