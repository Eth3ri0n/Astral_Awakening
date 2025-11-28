using UnityEngine;

public class Switch_Light : MonoBehaviour
{
    Light lightComponent;
    [SerializeField] private GameObject lightSource;
    Material lightMaterial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightComponent = lightSource.GetComponent<Light>();
        lightMaterial = lightSource.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ToggleLight();
        }
    }

    private void ToggleLight()
    {
        if (lightComponent != null)
        {
            lightComponent.enabled = !lightComponent.enabled;
            lightMaterial.color = lightComponent.enabled ? Color.white : Color.black;
        }
        else
        {
            lightComponent.enabled = true;
            lightMaterial.color = Color.white;
        }
    }
}
