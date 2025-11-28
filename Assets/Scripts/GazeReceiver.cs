// Raphael Marczak - University of Waikato - DIW (UTTOP) 2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GazeReceiver : MonoBehaviour
{
    public UnityEvent eventsWhenLookedAt;

    public bool onlyOnce = true;
    private bool hasBeenAlreadyLooked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        hasBeenAlreadyLooked = false;
    }

    public void TriggerGazeEvents()
    {
        if (hasBeenAlreadyLooked && onlyOnce)
        {
            return;
        }

        eventsWhenLookedAt.Invoke();
        hasBeenAlreadyLooked = true;
    }
}
