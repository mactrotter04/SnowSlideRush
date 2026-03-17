using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float TorqueAmmount = 10f;

    [SerializeField] float NormalSpeed = 15f;
    [SerializeField] float BoostSpeed = 20f;

    Rigidbody2D rb2d;
    SurfaceEffector2D SurfaceEffect2d;

    bool canMove = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent <Rigidbody2D>();
        SurfaceEffect2d = FindAnyObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            Respond2Boost();
        }
    }
    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(TorqueAmmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-TorqueAmmount);
        }
    }

    void Respond2Boost()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            SurfaceEffect2d.speed = BoostSpeed;
        }
        else
        {
            SurfaceEffect2d.speed = NormalSpeed;
        }
    }

    public void disableControl()
    {
        canMove = false;
    }
}

