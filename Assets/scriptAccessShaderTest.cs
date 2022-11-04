using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptAccessShaderTest : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public Material testMaterial;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(ray, out hit))
        {
        
        }
            
      //  testMaterial.SetVector("Vector3_189617afbe694e33a77550bea37fed15", new Vector3(-24,0,0));
    }
}
