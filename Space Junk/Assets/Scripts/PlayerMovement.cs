using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D spaceShip;
    [SerializeField]
    private float thrustUp = 10.0f;
    [SerializeField]
    private float thrustLeft = 50.0f;
    [SerializeField]
    private float velAngIni = 1.1f;
    [SerializeField]
    private float aceAng = 2.0f;

    Vector2 polar = new Vector2(0.0f,0.0f);

    


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-15.0f, 0.0f, 0.0f);

        // calcular longitud
        polar.y = Mathf.Atan2(polar.x,polar.y);

       // Vector2 xzLen = new Vector2(xzLen.x,xzLen.z);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            spaceShip.AddForce(transform.up * thrustUp, ForceMode2D.Impulse);
            spaceShip.AddForce(transform.right * thrustLeft, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            spaceShip.AddForce(transform.up * -thrustUp, ForceMode2D.Impulse);
            spaceShip.AddForce(transform.right * -thrustLeft, ForceMode2D.Impulse);
        }
    }


}
