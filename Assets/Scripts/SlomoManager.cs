// Raphael Marczak - University of Waikato - DIW (UTTOP) 2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;





public class SlomoManager : MonoBehaviour
{
    public float magnitude = 1;
    public float minValue = 0;
    public float maxValue = 1;
    public bool sendOppositeValue = false;

    public float offset = 0f;
   

    public float refreshRate = 0.1f;

    private float counter = 0f;

    public UnityEvent<float> eventsToCall;

    private Vector3 prevPos= Vector3.zero;

    public float currentSloMoValue = 0;


    // Start is called before the first frame update
    void Start()
    {
        prevPos = this.transform.position;
  
    }

    // Update is called once per frame
    void Update()
    {
    
        if (!this.gameObject.activeInHierarchy)
        {
            return;
        }

  
        counter += Time.deltaTime;

        if (counter < refreshRate)
        {
            return;
        }

        float prevSloMoValue = currentSloMoValue;

        ComputeSloMoValue();

        currentSloMoValue += prevSloMoValue;
        currentSloMoValue /= 2f;

        float eventParam = currentSloMoValue / counter * magnitude;
       
      //  Debug.Log(eventParam); 

        if (eventParam > maxValue)
        {
            SetToMaxValue();
        } else if (eventParam < minValue)
        {
            SetToMinValue();
        } else
        {
            if (sendOppositeValue)
            {
                eventParam *= -1;
            }
            eventsToCall.Invoke(offset + eventParam);
        }

        counter = 0;


    }

    void ComputeSloMoValue()
    {
   

        if (!this.gameObject.activeInHierarchy)
        {
            return;
        }

        float currentlyProcessedSloMoValue = Vector3.Distance(this.transform.position, prevPos);
        prevPos = this.transform.position;

        currentSloMoValue = currentlyProcessedSloMoValue;
    }

    public void SetToMaxValue()
    {
        float mult = 1f;

        if (sendOppositeValue)
        {
            mult *= -1;
        }
        eventsToCall.Invoke(mult*maxValue);
    }

    public void SetToMinValue()
    {
        float mult = 1f;

        if (sendOppositeValue)
        {
            mult *= -1;
        }

        eventsToCall.Invoke(mult*minValue);
    }

    
}
