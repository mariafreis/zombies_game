using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieRadar : MonoBehaviour
{
    public Transform target;
    public float proximidade;
    public float speed;
    public float rotationSpeed;
    private Animator zombieAnim;
    public float distanciaDeAtaque;
    public int vidaZombie = 3; // Adiciona a variável de vida


    public AudioSource audioSource;
    public AudioClip somMorteZumbi;
    public AudioClip somAtproximar; 

    private bool isColliding = false;

    void Start()
    {
        zombieAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null && vidaZombie > 0) // Verifica se o zombie ainda está vivo
        {
            float distX = Mathf.Abs(target.position.x - transform.position.x);
            float distZ = Mathf.Abs(target.position.z - transform.position.z);

            if (distX <= proximidade && distZ <= proximidade)
            {
                zombieAnim.SetBool("runZombie", true);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

                if (distX <= distanciaDeAtaque && distZ <= distanciaDeAtaque)
                {
                    zombieAnim.SetBool("ataqueZombie", true);
                    audioSource.clip = somAtproximar;
                    audioSource.Play();
                }
                else
                {
                    zombieAnim.SetBool("ataqueZombie", false);
                }

                float newSpeed = Random.Range(1.5f, 2.5f);
                target.GetComponent<followPath>().SetSpeed(newSpeed, true);
            }
            else
            {
                zombieAnim.SetBool("runZombie", false);
                target.GetComponent<followPath>().SetSpeed(speed, false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Heroi" && !isColliding && vidaZombie > 0)
        {
            isColliding = true;
            Debug.Log("Zombie collided with Personagem");
            zombieAnim.SetBool("ataqueZombie", true);

            // Reduz a vida do zombie quando atingido pelo personagem
            vidaZombie--;

            if (vidaZombie <= 0)
            {
                // Se a vida do zombie é zero ou menos, ativa a animação de morte
                zombieAnim.SetBool("mortoZombie", true);
                zombieAnim.SetBool("ataqueZombie", false);
                zombieAnim.SetBool("runZombie", false);
                audioSource.PlayOneShot(somMorteZumbi);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Personagem")
        {
            isColliding = false;
            zombieAnim.SetBool("ataqueZombie", false);
        }
    }
}
