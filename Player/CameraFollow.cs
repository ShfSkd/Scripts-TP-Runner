using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;


    private void Start()
    {
        offset = transform.position - target.position;
    }
    private void LateUpdate()
    {
        Vector3 newPos = new Vector3(transform.position.x,transform.position.y,offset.z+target.position.z);
        transform.position = Vector3.Lerp(transform.position,newPos,1f*Time.deltaTime);
    }
}
