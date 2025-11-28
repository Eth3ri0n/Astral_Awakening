// Raphael Marczak - University of Waikato - DIW (UTTOP) 2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WalkInAndOutEvents : MonoBehaviour
{
    public GameObject triggeringObject = null;

    public UnityEvent walkInEvents;
    public UnityEvent walkOutEvents;
    // Start is called before the first frame update
    void Start()
    {
        if (triggeringObject == null)
        {
            Debug.Log("Warning: Object " + this.gameObject.name + " has a WalkInAndOutEvents component without a triggeringObject set!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform currentProcessedTransform = other.transform;

        while (currentProcessedTransform != null)
        {
            if (currentProcessedTransform.gameObject == triggeringObject)
            {
                walkInEvents.Invoke(); 
            }

            currentProcessedTransform = currentProcessedTransform.transform.parent;
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        Transform currentProcessedTransform = other.transform;

        while (currentProcessedTransform != null)
        {
            if (currentProcessedTransform.gameObject == triggeringObject)
            {
                walkOutEvents.Invoke();
            }

            currentProcessedTransform = currentProcessedTransform.transform.parent;
        }
    }

   


}
