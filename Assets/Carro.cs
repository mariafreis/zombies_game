using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{
    [SerializeField] WheelCollider RodaTraseiraDireita;
    [SerializeField] WheelCollider RodaFrenteDireita;
    [SerializeField] WheelCollider RodaFrenteEsquerda;
    [SerializeField] WheelCollider RodaTraseiraEsquerda;
    public float aceleracao = 500f;
    public float freio = 300f;
    public float anguloTorque = 15f;
    private float aceleracaoAtual = 0f;
    private float freioAtual = 0f;
    private float anguloTorqueAtual = 0f;
    private bool faroisAcesos = false;
    private bool freando = false;

    public GameObject luzesFreioObjeto;

    private void FixedUpdate()
    {
        Debug.Log("Script executado2");
        aceleracaoAtual = aceleracao * Input.GetAxis("Vertical");
        RodaFrenteDireita.motorTorque = aceleracaoAtual;
        RodaFrenteEsquerda.motorTorque = aceleracaoAtual;
        anguloTorqueAtual = anguloTorque * Input.GetAxis("Horizontal");
        RodaFrenteDireita.steerAngle = anguloTorqueAtual;
        RodaFrenteEsquerda.steerAngle = anguloTorqueAtual;

        if (Input.GetKey(KeyCode.Space))
        {
            freando = true;
            freioAtual = freio;
        }
        else
        {
            freando = false;
            freioAtual = 0f;
        }

        RodaFrenteDireita.brakeTorque = freioAtual;
        RodaFrenteEsquerda.brakeTorque = freioAtual;
        RodaTraseiraDireita.brakeTorque = freioAtual;
        RodaTraseiraEsquerda.brakeTorque = freioAtual;

        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleFarois();
        }

        // Atualizar estado das luzes de freio
        luzesFreioObjeto.SetActive(freando);
    }

    void ToggleFarois()
    {
        faroisAcesos = !faroisAcesos;

        Light[] farois = GetComponentsInChildren<Light>();

        foreach (Light farol in farois)
        {
            farol.enabled = faroisAcesos;
        }
    }
}
