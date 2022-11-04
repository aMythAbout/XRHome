using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotatePhysics : MonoBehaviour
{
    //NOTE: The object attached with this script is the collider, ObjToMove as the SerializeField is the object to apply physics!

    GameObject Laser;
    TransformLaser transformLaser;
    Vector3 hitPoint; // Def: 
    Vector3 InitPos;
    Vector3 ObjDeltaMove;
    float LaserDeltaMoveX;
    Quaternion DeltaRotate;
    float LaserDeltaMoveY;
    Vector3 InitLaser; // what ??

    float timer; // you sha yong a 
    public float velocityX; // move velocity?
    public float velocityY; // rotate velocity?? 
    public float velParamX = 0.02f; // velocity scale parameter
    public float velParamY = 0.02f; // velocity scale parameter
    public bool laserOnClick;
    public bool laserPressed;

    [SerializeField] GameObject ObjToMove;
    
    // No need to use the laser hit point. Just use mouse click on collider
    // Change laserPressed to hit.clicking

    // Start is called before the first frame update
    void Start()
    {
        Laser = GameObject.Find("Capsule");
        // laserPressed = false;
        transformLaser = Laser.GetComponent<TransformLaser>();
        // test test
        laserOnClick = transformLaser.onClick;
        laserPressed = transformLaser.clicking;
    }
    // Update is called once per frame
    void Update()
    {
        //refractor all of these

        /*
         * A few phases: The moment when laser is pressed, 
         * When laser pressed, when laser released but still with velocity, no velocity
         * 
         * */
        laserOnClick = transformLaser.onClick;
        laserPressed = transformLaser.clicking;
        getHitPoint();
        OnLaserClick();
        OnLaserPressed();
        velDecrease();
        applyPhysicsToObject();
    }

    void getHitPoint()
    {
        // the position of where the laser hit

        hitPoint = transformLaser.hitPoint;
    }
    void OnLaserClick()
    {
        if (laserOnClick)
        {
            timer = 0;
            InitPos = transform.position;
            InitLaser = hitPoint;
            //bug.Log("Click");
        }
    }
    void OnLaserPressed()
    {
        if (laserPressed)
        {
            timer += Time.deltaTime;
            LaserDeltaMoveY = -InitLaser.y + hitPoint.y;
            LaserDeltaMoveX = -InitLaser.x + hitPoint.x;
            velocityX = LaserDeltaMoveX * velParamX / timer;
            velocityY = LaserDeltaMoveY * velParamY / timer;
            ObjDeltaMove = new Vector3(0, LaserDeltaMoveY, 0); // TODO:map it
            DeltaRotate = new Quaternion(LaserDeltaMoveX, 0, 0, 0);
        }

    }


    void applyPhysicsToObject()
    {
        ObjToMove.transform.position += new Vector3(0, velocityY, 0);
        ObjToMove.transform.rotation = new Quaternion(ObjToMove.transform.rotation.x, ObjToMove.transform.rotation.y + velocityX * 0.2f, ObjToMove.transform.rotation.z, ObjToMove.transform.rotation.w);
    }

    void velDecrease()
    {
        if (!laserPressed)
        {
            if (Mathf.Abs(velocityX) > 0.005f)
            {
                if (velocityX > 0.005f)
                {
                    velocityX -= 0.002f;
                }
                else
                {
                    velocityX += 0.002f;
                }
            }
            else
            {
                velocityX = 0;
            }
        }

        if (!laserPressed)
        {
            if (Mathf.Abs(velocityY) > 0.005f)
            {
                if (velocityY > 0.005f)
                {
                    velocityY -= 0.002f;
                }
                else
                {
                    velocityY += 0.002f;
                }
            }
            else
            {
                velocityY = 0;
            }
        }
    }
}
