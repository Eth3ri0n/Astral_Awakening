using UnityEngine;

public class SlowMotionFollower : MonoBehaviour
{
    [Tooltip("Ce que cet objet doit suivre (caméra, main, etc.)")]
    public Transform target;

    [Tooltip("Vitesse de rattrapage (plus petit = plus 'slow motion')")]
    public float followSpeed = 3f;

    private Vector3 _currentPosition;

    private void Start()
    {
        if (target != null)
            _currentPosition = target.position;
        else
            _currentPosition = transform.position;
    }

    private void Update()
    {
        if (target == null) return;

        _currentPosition = Vector3.Lerp(
            _currentPosition,
            target.position,
            Time.deltaTime * followSpeed
        );

        transform.position = _currentPosition;
    }
}
