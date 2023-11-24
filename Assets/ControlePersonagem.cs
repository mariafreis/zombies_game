using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePersonagem : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    private Animator heroi;
    public float distanciaProximidade = 3.0f; 
    private AudioSource audioSource; // Referência ao AudioSource

    public AudioClip somTaco; 
    public AudioClip somAtaque; 
    void Start()
    {
        speed = 5.0f;
        heroi = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Movimento do personagem
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            AtualizarAnimacao(true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
            AtualizarAnimacao(true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0);
            AtualizarAnimacao(true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
            AtualizarAnimacao(true);
        }

        // Verificar se a tecla de espaço foi pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            heroi.SetBool("Atacando", true);
            heroi.SetBool("Correndo", false); // Adicionado para garantir que "Correndo" seja falso durante o ataque
            audioSource.clip = somAtaque;
            audioSource.Play();
        }

        // Verificar se nenhuma tecla está pressionada
        if (!Input.anyKey)
        {
            AtualizarAnimacao(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar se o personagem colidiu com o taco de baseball
        if (other.CompareTag("TacoBaseball"))
        {
            // Desativar o objeto colidido
            other.gameObject.SetActive(false);

            // Reativar o objeto filho específico
            Transform bip001RClavicle = transform.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 R Clavicle");
            Transform bip001RClavicle2 = transform.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 R Clavicle 2");
            if (bip001RClavicle != null)
            {
                bip001RClavicle.gameObject.SetActive(true);
                bip001RClavicle2.gameObject.SetActive(false);
                audioSource.clip = somTaco;
                audioSource.Play();
            }
        }
        if (other.CompareTag("GUN"))
        {
            // Desativar o objeto colidido
            other.gameObject.SetActive(false);

            // Reativar o objeto filho específico
            Transform bip001RClavicle = transform.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 R Clavicle");
            Transform bip001RClavicle2 = transform.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 R Clavicle 2");
            if (bip001RClavicle2 != null)
            {
                bip001RClavicle2.gameObject.SetActive(true);
                bip001RClavicle.gameObject.SetActive(false);
                audioSource.clip = somTaco;
                audioSource.Play();
            }
        }
    }


    void AtualizarAnimacao(bool correndo)
    {
        heroi.SetBool("Correndo", correndo);
        heroi.SetBool("Parado", !correndo);
        heroi.SetBool("Atacando", false); // Adicionado para garantir que "Atacando" seja falso quando não estiver atacando
    }


}