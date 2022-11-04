using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformLaser : MonoBehaviour
{
    Ray ray;
    public RaycastHit hit;
    public Vector2 hotSpot = Vector2.zero;
    // Start is called before the first frame update
    public bool hitting = false;
    public bool onClick;
    public bool clicking;

    public float hitDist;
    public Vector3 hitPoint;

    //To Test Material Instancing
    

    public Material rayHitShader;
    //[SerializeField]  ReferencedScript refScript = GetComponent<ReferencedScript>();
    void Start()
    {
        hitting = false;
        clicking = false;
        onClick = false;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(hitPoint);
        hitDist = hit.distance;
        hitPoint = hit.point;
        transform.LookAt(hitPoint, Vector3.forward);
        if (hitDist > 0)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, hitDist);
        }
        else
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            hitting = true;
            // Debug.Log(hitPoint);
           // print(hit.transform.gameObject);
            rayHitShader.SetVector("Vector3_189617afbe694e33a77550bea37fed15", hitPoint);
            // testClickChangeColor();
            
            //    Debug.Log("hovering something ehh");
            if (Input.GetMouseButton(0))
            {
                
                //    Debug.Log("Clicking something ehhhh");
                clicking = true;
                if (Input.GetMouseButtonDown(0))
                {

                    onClick = true;
                }
                else
                {
                    onClick = false;
                }
            }
            else
            {
          //    onClick = false;
            }
        }
        else
        {
            hitting = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            clicking = false;

        }
    }

    private void OnMouseEnter()
    {
    }
    void OnMouseOver()
    {
        // Change the Color of the GameObject when the mouse hovers over it
        if (Input.GetMouseButtonDown(0))
        {
            print(hit.collider.name);
        }
    }

    void OnMouseExit()
    {
        //Change the Color back to white when the mouse exits the GameObject
    }
}
