using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class MuseumRelicTrigger : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    [SerializeField] private float requiredStayTime = 1.5f; // temps � rester pr�s de la relique

    private float _timer = 0f;
    private bool _playerInside = false;
    private bool _hasTeleported = false;

    private void Reset()
    {
        // Configuration de base
        var col = GetComponent<Collider>();
        col.isTrigger = true;

        var rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[Relic] ENTER par {other.name} (tag={other.tag})");

        if (_hasTeleported) return;

        // On ne garde QUE le XR Origin (joueur)
        if (!other.CompareTag("Player"))
            return;

        _playerInside = true;
        _timer = 0f;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"[Relic] EXIT par {other.name} (tag={other.tag})");

        if (!other.CompareTag("Player"))
            return;

        _playerInside = false;
        _timer = 0f;
    }

    private void Update()
    {
        TeleportToNextScene(nextSceneName);
    }

    public void TeleportToNextScene(string sceneName)
    {
        if (_hasTeleported || !_playerInside) return;

        _timer += Time.deltaTime;

        if (_timer >= requiredStayTime)
        {
            _hasTeleported = true;
            Debug.Log("[Relic] Temps atteint -> chargement sc�ne : " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
    }
}
