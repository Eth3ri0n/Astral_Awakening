// Raphael Marczak - University of Waikato - DIW (UTTOP) 2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeManager : MonoBehaviour
{
    GameObject currentGazeObject = null;

    public float distance = 1f;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, distance, layer))
        {
            if (currentGazeObject == null)
            {
                currentGazeObject = hit.transform.gameObject;
                Debug.Log("looking to " + currentGazeObject.name);

                GazeReceiver gr = currentGazeObject.GetComponent<GazeReceiver>();

                if (gr == null)
                {
                    Debug.Log("WARNING " + currentGazeObject.name + " does not have a GazeReceiver Component");
                } else
                {
                    gr.TriggerGazeEvents();
                }
            }
           
        } else
        {
            currentGazeObject = null;
        }
    }
}
