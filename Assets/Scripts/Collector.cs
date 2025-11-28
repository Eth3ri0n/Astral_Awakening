// Raphael Marczak - University of Waikato - DIW (UTTOP) 2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    public int nbOfObjectToCollect = 2;
    public UnityEvent eventsWhenAllObjectCollected;
    bool everythingHasBeenCollected = false;

    public int nbOfCollectedObject = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!everythingHasBeenCollected && nbOfCollectedObject >= nbOfObjectToCollect)
        {
            eventsWhenAllObjectCollected.Invoke();
            everythingHasBeenCollected = true;
        }
    }

    public void NewObjectCollected()
    {
        nbOfCollectedObject++;
    }
}
