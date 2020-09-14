using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerposition;
    private Vector3 offsetvalue;
    // Start is called before the first frame update
    void Start()
    {
        offsetvalue = transform.position - playerposition.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 finalposition = new Vector3(transform.position.x, transform.position.y, offsetvalue.z + playerposition.position.z);
        transform.position = finalposition;
    }
}
