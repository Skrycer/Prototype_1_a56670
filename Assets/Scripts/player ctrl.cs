using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerctrl : MonoBehaviour
{
    Rigidbody rb;
    float speed = 20.0f;
    float turnSpeed = 15.0f;
    float forwardInput;
    float horizontalInput;
    float jumpForce = 5f;
    public float turboSpeed = 35.0f;
    KeyCode turboKey = KeyCode.LeftShift;
    bool isTurboActive = false;
    KeyCode resetVehicle = KeyCode.R;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move o ve�culo para a frente
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput);

        //
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);

        // Define a velocidade horizontal e vertical da Rigidbody
        //rb.velocity = new Vector3(horizontalInput * turnSpeed, rb.velocity.y, forwardInput * speed);

        // Verifica o pulo
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        // Ativa o turbo quando a tecla � pressionada
        if (Input.GetKeyDown(turboKey))
        {
            isTurboActive = true;
        }

        // Desativa o turbo quando a tecla � liberada
        if (Input.GetKeyUp(turboKey))
        {
            isTurboActive = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetVehicle();
        }

    }

    void FixedUpdate()
    {
        // Aplica o turbo se estiver ativo
        if (isTurboActive)
        {
            ApplyTurbo();
        }
    }

    void ApplyTurbo()
    {
        // Aumenta a velocidade do jogador durante o turbo
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forwardInput * (speed + turboSpeed));
    }
    void ResetVehicle()
    {
            // Define a posi��o inicial do ve�culo e zera a velocidade
            transform.position = new Vector3(0f, 1f, 0f); // Adjust the initial position as needed
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Tamb�m pode ser necess�rio reiniciar outras vari�veis relacionadas ao estado do ve�culo
            // (por exemplo, isTurboActive, se aplic�vel)
        
    }
}
//currentPosition = transform.position;
//currentPosition.z += .05f;
//transform.position = currentPosition;

//transfor.Translate(0, 0, .05f)
//transform.Translate(new Vector3(0, 0, .05f));
//transform.Translate(Vector3.forward * speed * Time.deltaTime);