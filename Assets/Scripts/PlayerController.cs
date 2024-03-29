﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;

    void Start() {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "Count: " + count.ToString ();
        setCountText ();
        winText.text = "";
    }

    // Called before render
    void Update ()
    {

    }

    // Called before physics calculations
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.CompareTag ("Pick Up")) {
            other.gameObject.SetActive (false);
            count++;
            setCountText ();
        }
        
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString ();
        if (count == 6)
        {
            winText.text = "Yay!";
        }
    }
}
