using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    [Header("Respawn")]
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private bool reloadSceneInstead = false;

    private void OnTriggerEnter(Collider other)
    {
        // On ne réagit qu'au joueur (XR Rig)
        if (!other.CompareTag("Player"))
            return;

        Debug.Log("[DeathZone] Le joueur est tombé dans le vide.");

        if (reloadSceneInstead)
        {
            // Option 1 : recharger la scène
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        else
        {
            // Option 2 : téléporter au point de respawn
            RespawnPlayer(other);
        }
    }

    private void RespawnPlayer(Collider playerCollider)
    {
        if (respawnPoint == null)
        {
            Debug.LogWarning("[DeathZone] Aucun respawnPoint assigné.");
            return;
        }

        // On récupère le Transform du XR Rig
        Transform rigTransform = playerCollider.transform;

        // Si le CharacterController est sur ce même objet, on le désactive le temps de bouger
        var cc = rigTransform.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        rigTransform.position = respawnPoint.position;
        rigTransform.rotation = respawnPoint.rotation;

        if (cc != null) cc.enabled = true;
    }
}
