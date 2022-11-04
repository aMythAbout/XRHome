using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget: MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject target;
    Quaternion InitRotation;
    void Start()
    {
        InitRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.activeSelf)
        {
            transform.LookAt(target.transform, InitRotation.eulerAngles);
        }
        else
        {
            transform.rotation = InitRotation;
        }
        
    }
}
