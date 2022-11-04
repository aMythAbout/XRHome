using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverShader1 : MonoBehaviour
{
    TransformLaser laserScript;
    GameObject laser;
    public bool colliding;
    public float emissionAlphaVal;
    Material materialInstance;
    // Start is called before the first frame update
    void Start()
    {
        laser = GameObject.Find("Capsule");
        laserScript = laser.GetComponent<TransformLaser>();
        emissionAlphaVal = 0.5f;
        materialInstance = this.gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        setAlphaOnCollide();
        setValToMaterial();
        setCollidePosition();
    }
    
    public bool ifCollide()
    {
        if (laserScript.hitting)
        {
            if(laserScript.hit.transform.gameObject == this.gameObject)
            {
                return true;
            }
        }
        return false;

    }

    void setAlphaOnCollide()
    {
        if ( ifCollide() && emissionAlphaVal <= 0.12f)
        {
            emissionAlphaVal += 0.0045f;

          //  emissionAlphaVal = 0.1f;
        }
        if (!ifCollide() && emissionAlphaVal > 0.005f)
        {
            emissionAlphaVal -= 0.0045f;

          //  emissionAlphaVal = 0.005f;

        }
    }

    void setValToMaterial()
    {
        materialInstance.SetFloat("Vector1_875726ad4c76485cba32618df4787db0", emissionAlphaVal);
    }
    
    void setCollidePosition()
    {
        materialInstance.SetVector("Vector3_189617afbe694e33a77550bea37fed15", laserScript.hitPoint);
    }
    
}
