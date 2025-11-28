using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangerSceneApresAnimation : MonoBehaviour
{
    public Animator animator;
    public string nomScene = "Scene_Museum";
    public float tempsAvantChangement = 2f;  // Temps en secondes avant de changer
    
    private bool change = false;
    
    void Start()
    {
        // Change de scène après X secondes
        Invoke("ChargerScene", tempsAvantChangement);
    }
    
    void ChargerScene()
    {
        if (!change)
        {
            change = true;
            Debug.Log("Chargement de: " + nomScene);
            SceneManager.LoadScene(nomScene);
        }
    }
}