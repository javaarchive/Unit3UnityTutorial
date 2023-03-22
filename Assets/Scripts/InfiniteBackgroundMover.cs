using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackgroundMover : MonoBehaviour
{
    private float speed = 200f;
    private Vector3 originalPosition;
    private float originalZ;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalZ = originalPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
        if(transform.position.z < originalZ - 200){
            transform.position = originalPosition;
        }
    }
}
