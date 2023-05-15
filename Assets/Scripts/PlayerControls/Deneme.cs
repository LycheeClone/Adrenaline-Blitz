using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{
    public float baslangicHizi = 10f; // başlangıç hızı
    public float artisHizi = 2f; // her saniye alınacak ek hız
    private float oynamaSuresi = 0f; // oynama süresi
    private Rigidbody rb;
    private bool _hasMoved = false;

    //The variable that holds the right to move Left
    private bool _canMoveLeft = true;

    //the variable that holds the right to move right
    private bool _canMoveRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        SideMovement();
        //Controls the Behavior of Falling At Specific Locations
        if (transform.position.z >= 500)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.down * 70, ForceMode.Acceleration);
        }
        //Controls for Return to the Default Gravity
        if (transform.position.z >= 640)
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
    }

    void FixedUpdate()
    {
        Debug.Log(Time.time+"Oyuncu hizi: " + rb.velocity.z);

        // oynama süresini güncelle
        oynamaSuresi += Time.fixedDeltaTime;

        // yeni hızı hesapla
        float hiz = baslangicHizi + (artisHizi * oynamaSuresi);

        // Rigidbody bileşenine yeni hızı uygula
        Vector3 hareket = new Vector3(0, 0, hiz); // sadece x yönünde hareket edildiği varsayıldı
        rb.velocity = hareket;
    }
    private void SideMovement()
    {
        if (!_hasMoved)
        {
            if (_canMoveLeft && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                transform.Translate(-2, 0, 0);
                _hasMoved = true;
                _canMoveLeft = false;
                _canMoveRight = true;
            }
            else if (_canMoveRight && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
            {
                transform.Translate(2, 0, 0);
                _hasMoved = true;
                _canMoveLeft = true;
                _canMoveRight = false;
            }
        }
        else
        {
            if (_canMoveLeft && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                transform.Translate(-2, 0, 0);
                _hasMoved = false;
                _canMoveLeft = false;
                _canMoveRight = true;
            }
            else if (_canMoveRight && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
            {
                transform.Translate(2, 0, 0);
                _hasMoved = false;
                _canMoveLeft = true;
                _canMoveRight = false;
            }
        }
    }
}
