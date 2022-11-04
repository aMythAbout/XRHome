using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TH2ClickHoverResponse : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Parent;
    HoverShader1 hoverShader;
   // TransformLaser laserScript;
   // GameObject laser;
   // public bool colliding;
    Material materialInstance;
    float AlphaVal = 0.1f;
    
    void Start()
    {
        Parent = this.gameObject.transform.parent.gameObject;
        hoverShader = Parent.GetComponent<HoverShader1>();
      //  laser = GameObject.Find("Capsule");
     //   laserScript = laser.GetComponent<TransformLaser>();
        materialInstance = this.gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        setAlphaOnCollide();
        setValToMaterial();
     //   Debug.Log(AlphaVal);
    }

    void setAlphaOnCollide()
    {
        /*
        if (hoverShader.ifCollide() && AlphaVal <= 0.85f)
        {
            AlphaVal += 0.245f;
            Debug.Log("1");
            //  emissionAlphaVal = 0.1f;
        }
        if (!hoverShader.ifCollide() && AlphaVal > 0.1f)
        {
            AlphaVal -= 0.245f;
            Debug.Log("0");
            //  emissionAlphaVal = 0.005f;
        }*/

        if (hoverShader.ifCollide() && AlphaVal <= 1.05f)
        {
            AlphaVal += 0.0065f;
            Debug.Log("1");
            //  emissionAlphaVal = 0.1f;
        } else if (!hoverShader.ifCollide() && AlphaVal >= 0.1f)
        {
            AlphaVal -= 0.0065f;
            Debug.Log("0");
            //  emissionAlphaVal = 0.005f;
        }
    }

    void setValToMaterial()
    {
        materialInstance.SetFloat("AlphaVal", AlphaVal);
    }
}
