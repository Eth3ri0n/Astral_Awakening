// Raphael Marczak - University of Waikato - DIW (UTTOP) 2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

[RequireComponent(typeof(VideoPlayer))]
public class VideoOverEvents : MonoBehaviour
{
    public UnityEvent eventsWhenVideoIsOver;

    VideoPlayer vp = null;

    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponent<VideoPlayer>();

        vp.loopPointReached += CallVideoEndEvents;
    }

    // Update is called once per frame
    void CallVideoEndEvents(VideoPlayer vp)
    {
        eventsWhenVideoIsOver.Invoke();
    }
}
