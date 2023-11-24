using UnityEngine;

public class DNController : MonoBehaviour
{
    private bool isDay = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleDayNight();
        }
    }

    void ToggleDayNight()
    {
    isDay = !isDay;
    
    Light sun = GameObject.Find("Directional Light").GetComponent<Light>(); 
    
    if (isDay)
    {
        sun.intensity = 1f; 
    }
    else
    {
        sun.intensity = 0.2f; 
    }
    }


}
