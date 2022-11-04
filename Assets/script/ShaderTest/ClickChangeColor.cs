using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickChangeColor : MonoBehaviour
{
 
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
            materialInstance.SetColor("Color_93be980adad74a088a48e3fa2c6bca61", Color.blue);
        }
        else
        {
            materialInstance.SetColor("Color_93be980adad74a088a48e3fa2c6bca61", Color.white);
        }

    }
}
