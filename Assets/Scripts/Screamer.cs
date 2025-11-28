using UnityEngine;

public class Screamer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject screamer;
    [SerializeField] Animator erikaAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            erikaAnimator.SetTrigger("Screamer");
        }
    }
}
