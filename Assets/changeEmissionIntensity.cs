using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeEmissionIntensity : MonoBehaviour
{
    GameObject Parent;
    HoverShader1 hoverShader;
    float unhoverVal = -0.015f;
    float hoverVal = 0.125f;
    Color emissionColor;
    Material materialInstance;
    // Start is called before the first frame update
    void Start()
    {
        Parent = this.gameObject.transform.parent.gameObject;
        hoverShader = Parent.GetComponent<HoverShader1>();
        emissionColor = this.gameObject.GetComponent<Renderer>().material.GetColor("EmissionColor");
        materialInstance = this.gameObject.GetComponent<Renderer>().material;

        //Test:
       
    }

    // Update is called once per frame
    void Update()
    {
        
       
        if (hoverShader.ifCollide() && Input.GetMouseButton(0))
        {
            materialInstance.SetColor("_EmissionColor", Color.white * hoverVal);
          //  this.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(1.0f, 1.0f, 1.0f) * hoverVal);
           // materialInstance.SetColor("_Color", new Color(0.0f, 0.7f, 1.0f, 1.0f) * hoverVal);
        }
        else
        {
            materialInstance.SetColor("_EmissionColor", Color.white * unhoverVal);
         //   this.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(1.0f, 1.0f, 1.0f) * unhoverVal);
         //   materialInstance.SetColor("_EmissiveColor", emissionColor * unhoverVal);
        }
        
    }
}
