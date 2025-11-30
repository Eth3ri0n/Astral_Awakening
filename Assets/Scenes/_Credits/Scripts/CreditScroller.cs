using UnityEngine;

public class CreditScroller : MonoBehaviour
{
    public float speed = 20f;       // vitesse du défilement
    public float startY = -500f;    // point de départ
    public float endY = 800f;       // point final

    private RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, startY);
    }

    private void Update()
    {
        rt.anchoredPosition += Vector2.up * speed * Time.deltaTime;

        if (rt.anchoredPosition.y >= endY)
        {
            // Quand les crédits se terminent
            // (option 1) revenir au menu
            // (option 2) quitter l’app
            // Ici on revient au menu :
            UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
        }
    }
}
