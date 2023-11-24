using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPath : MonoBehaviour
{
    [SerializeField] public Transform[] allwayPoints;
    [SerializeField] public float rotationSpeed = 0.5f;
    [SerializeField] private float defaultSpeed = 0.5f; 
    [SerializeField] public float proximidade; 
    [SerializeField] public int currentTarget;

    private Animator characterAnim;
    private float currentSpeed;

    void Start()
    {
        characterAnim = GetComponent<Animator>();
        currentSpeed = defaultSpeed;
    }

    void Update()
    {
        Movement();
        Rotate();
        ChangeTarget();
    }

    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, allwayPoints[currentTarget].position, currentSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(allwayPoints[currentTarget].position - transform.position),
            rotationSpeed * Time.deltaTime);
    }

    void ChangeTarget()
    {
        if (transform.position == allwayPoints[currentTarget].position)
        {
            currentTarget++;
            currentTarget = currentTarget % allwayPoints.Length;
        }
    }

    public void SetSpeed(float newSpeed, bool running)
    {
        currentSpeed = newSpeed;
        characterAnim.SetBool("runMan", running);
    }
}
