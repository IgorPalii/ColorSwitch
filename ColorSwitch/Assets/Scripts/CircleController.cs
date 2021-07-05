using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    private float rotateSpeed = 0.0f;
    private int rotateDir = 1;

    private void Start()
    {
        rotateSpeed = Random.Range(60f, 100f);
        if(Random.Range(0f, 2f) < 1f)
        {
            rotateDir = -1;
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0f, 0f, rotateSpeed * rotateDir * Time.fixedDeltaTime));

        if(transform.position.y < Camera.main.transform.position.y - 10f)
        {
            Destroy(gameObject);
        }
    }
}
