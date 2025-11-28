using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class OrbSocketTrigger : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Scene_SerenityGarden";
    [SerializeField] private string orbTag = "Orb";
    [SerializeField] private float requiredStayTime = 1.0f;

    private float _timer = 0f;
    private bool _orbInside = false;
    private bool _hasTriggered = false;

    private void Reset()
    {
        var col = GetComponent<Collider>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_hasTriggered) return;

        if (other.CompareTag(orbTag))
        {
            _orbInside = true;
            _timer = 0f;
            Debug.Log("[OrbSocket] Orb ENTER");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_hasTriggered) return;

        if (other.CompareTag(orbTag))
        {
            _orbInside = false;
            _timer = 0f;
            Debug.Log("[OrbSocket] Orb EXIT");
        }
    }

    private void Update()
    {
        if (_hasTriggered || !_orbInside)
            return;

        _timer += Time.deltaTime;

        if (_timer >= requiredStayTime)
        {
            _hasTriggered = true;
            Debug.Log("[OrbSocket] Orb validated, loading scene: " + nextSceneName);
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
