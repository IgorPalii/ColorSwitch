using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject circlePref;
    [SerializeField]
    private GameObject changeColorPref;
    private float prevGeneratePos = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        if(Camera.main.transform.position.y >= prevGeneratePos - 5f)
        {
            Instantiate(circlePref, new Vector3(0f, prevGeneratePos + 5f, 0f), Quaternion.identity);
            Instantiate(changeColorPref, new Vector3(0f, prevGeneratePos + 2.5f, 0f), Quaternion.identity);
            prevGeneratePos += 5f;
        }
    }
}
