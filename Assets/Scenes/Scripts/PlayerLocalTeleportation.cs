using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerLocalTeleportation : MonoBehaviour
{
    Collider playerCollider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCollider = GetComponent<Collider>(); //
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerCollider != null) { 
            if (other.CompareTag("TeleportationZone"))
            {
                playerCollider.transform.position = other.transform.position;
            }
        }
    }
}
