using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    //continuosly assigns the newly calculated polar position to the transform keeping in mind the values of the properties.
    //all the objetcs affected by it have to have the script

    public float latitude;
    public float longitude;
    public float height;
    [SerializeField]
    private Rigidbody2D spaceShip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spaceShip.AddForce(transform.up * (-height*0.02f), ForceMode2D.Impulse);
    }

    public Vector2 CartesianToPolar(float x,float y)
    {
         Vector2 polar = new Vector2(0.0f,0.0f);
 
         //calc longitude
         polar.y = Mathf.Atan2(x, y);
 
         //this is easier to write and read than sqrt(pow(x,2), pow(y,2))!
         var xzLen = new Vector2(x, y).magnitude;
        //atan2 does the magic
        polar.x = Mathf.Atan2(-y,xzLen);
 
         //convert to deg
         polar *= Mathf.Rad2Deg;
 
         return polar;
    }

    public Vector2 PolarToCartesian(float x, float y)
    {
 
         //an origin vector, representing lat,lon of 0,0. 
 
         var origin = new Vector3(0, 0, 1);
        //build a quaternion using euler angles for lat,lon
        var rotation = Quaternion.Euler(x, y, 0);
        //transform our reference vector by the rotation. Easy-peasy!
        Vector3 point = new Vector3();
        point = rotation * origin;

        return point;
    }

}
