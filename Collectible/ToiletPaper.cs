using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPaper : MonoBehaviour
{
    private float rotationSpeed=15f;

    private void Update()
    {
        transform.Rotate(new Vector3(10f,0,0) * rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<SoundManager>().PlaySound("PickUpTP"); 
            PlayerGameManager.numOfToiletPepers+=1;
            Destroy(gameObject);
        }
    }
}
