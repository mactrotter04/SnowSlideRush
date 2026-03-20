using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float TorqueAmmount = 10f;
    [SerializeField] float NormalSpeed = 15f;
    [SerializeField] float BoostSpeed = 20f;
    [SerializeField] float SlowSpeed = 5f;
    [SerializeField] float TimeOfSlow = 5f;

    Rigidbody2D rb2d;
    SurfaceEffector2D SurfaceEffect2d;

    [SerializeField] TextMeshProUGUI PointSystem;

    bool canMove = true;
    float slowTime = 0f;
    int pointsPerCoin = 100;
    int points;
    int coins;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PointSystem.text = "0 Pts";
        rb2d = GetComponent <Rigidbody2D>();
        SurfaceEffect2d = FindAnyObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(SurfaceEffect2d.speed);
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
        if(slowTime > 0)
        {
            slowTime -= Time.deltaTime;
        }

        if (slowTime >0)
        {
            SurfaceEffect2d.speed = SlowSpeed;
        }

        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
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

    public void ApplySlow()
    {
        slowTime = TimeOfSlow;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Slow"))
        {
            ApplySlow();
        }
       
        if (other.CompareTag("Coin"))
        {
            if (!other.gameObject.activeSelf) return;
            coins++;
            points += pointsPerCoin;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            Debug.Log("Coins: " + coins + "points: " + points);
            PointSystem.text = points + "Pts";
        }

       


    }



}

