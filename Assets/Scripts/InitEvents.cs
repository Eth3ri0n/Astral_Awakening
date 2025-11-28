// Raphael Marczak - University of Waikato - DIW (UTTOP) 2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InitEvents : MonoBehaviour
{
    public UnityEvent launchEvents;
    // Start is called before the first frame update
    void Start()
    {
        launchEvents.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
