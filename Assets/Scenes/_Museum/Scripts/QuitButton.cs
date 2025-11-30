using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("[QuitButton] Quit demandé via bouton UI.");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
