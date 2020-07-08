using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float objectDistance = -40f;
    [SerializeField] private float despondDistance=-110f;

    private bool canSpawnGround = true;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    private void Update()
    {
        
        transform.position += -transform.forward * speed * Time.deltaTime;

        if (transform.position.z <= objectDistance && transform.tag == "Ground" && canSpawnGround)
        {
            //ObjectSpwaner.instance.SpawnGround();
            canSpawnGround = false;
        }
        if (transform.position.z <= despondDistance)
        {
            canSpawnGround = true;
            gameObject.SetActive(false);
        }
    }
}
