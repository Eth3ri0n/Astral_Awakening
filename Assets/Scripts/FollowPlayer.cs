using UnityEngine;

public class SuitOsAnimation : MonoBehaviour
{
    public Transform os;  // Glisse ici l'os que tu veux suivre (Head, Hand, etc.)
    public Vector3 offset = new Vector3(0, 0.5f, -2);
    
    void LateUpdate()
    {
        if (os != null)
        {
            transform.position = os.position + offset;
            transform.LookAt(os);
        }
    }
}