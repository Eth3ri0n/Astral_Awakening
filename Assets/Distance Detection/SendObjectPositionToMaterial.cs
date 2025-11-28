using UnityEngine;

public class SendObjectPositionToMaterial : MonoBehaviour
{
    public GameObject objectToTrackPos = null;
    public int matId = 0;
    public string shaderParameterId = "";

    private Renderer meshRenderer = null;
    private Material currentMaterial = null;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer = GetComponent<Renderer>();
        currentMaterial = meshRenderer.materials[matId];
    }

    // Update is called once per frame
    void Update()
    {
        currentMaterial.SetVector(shaderParameterId, objectToTrackPos.transform.position);
    }
}
