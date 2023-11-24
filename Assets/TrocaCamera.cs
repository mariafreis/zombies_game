using UnityEngine;
public class TrocaCamera : MonoBehaviour
{
    public Camera cameraTerceiraPessoa;
    public Camera cameraMotorista;
    public Camera cameraRoda;
    void Start()
    {
        cameraTerceiraPessoa.enabled = true;
        cameraMotorista.enabled = false;
        cameraRoda.enabled = false;

        Debug.Log("Script executado");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            AtivarCamera(cameraTerceiraPessoa);
            Debug.Log("Tecla 1 pressionada");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            AtivarCamera(cameraMotorista);
            Debug.Log("Tecla 2 pressionada");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            AtivarCamera(cameraRoda);
            Debug.Log("Tecla 3 pressionada");
        }
    }
    void AtivarCamera(Camera cameraAtivar)
    {
        cameraTerceiraPessoa.enabled = false;
        cameraMotorista.enabled = false;
        cameraRoda.enabled = false;
        cameraAtivar.enabled = true;
    }
}
