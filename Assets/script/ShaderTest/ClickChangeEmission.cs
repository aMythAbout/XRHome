using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickChangeEmission : MonoBehaviour
{
    // This is for TouchHologram1
    Material materialInstance;
    void Start()
    {

        materialInstance = this.gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            
           materialInstance.SetColor("Color_f962f6a9719a43409e5d3dab7447c086", new Color(0.5f, 0.5f, 1f));
        }
        else
        {
           materialInstance.SetColor("Color_f962f6a9719a43409e5d3dab7447c086", Color.white);
        }

    }
}
