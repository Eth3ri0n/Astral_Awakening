using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonVRChangeScene : MonoBehaviour
{
    public string nomScene = "Scene_Museum";
    
    // Appelé quand on clique sur le bouton
    public void ChangerScene()
    {
        Debug.Log("Changement vers: " + nomScene);
        SceneManager.LoadScene(nomScene);
    }
}