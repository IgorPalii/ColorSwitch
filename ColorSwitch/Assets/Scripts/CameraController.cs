using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float maxY = 0f;
    [SerializeField]
    private GameObject target;
    void Start()
    {
        maxY = transform.position.y;
    }

    void Update()
    {
        if (target.transform.position.y > maxY)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 
                target.transform.position.y, transform.position.z), Time.deltaTime);
            maxY = transform.position.y;
        }
    }
}
