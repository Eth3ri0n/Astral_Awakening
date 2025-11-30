using UnityEngine;
using UnityEngine.Events;

public class GazeTrigger : MonoBehaviour
{
    [Tooltip("Temps en secondes pendant lequel le joueur doit regarder l'objet")]
    public float activationTime = 2f;

    [Tooltip("Distance max de détection du regard")]
    public float maxDistance = 10f;

    [Tooltip("Événement déclenché quand le regard est maintenu suffisamment longtemps")]
    public UnityEvent onGazeActivated;

    private float _timer = 0f;

    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
        if (_cam == null)
            Debug.LogWarning("[GazeTrigger] Aucune caméra MainCamera trouvée.");
    }

    private void Update()
    {
        if (_cam == null) return;

        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                _timer += Time.deltaTime;
                if (_timer >= activationTime)
                {
                    _timer = 0f;
                    onGazeActivated?.Invoke();
                }
            }
            else
            {
                _timer = 0f;
            }
        }
        else
        {
            _timer = 0f;
        }
    }
}
