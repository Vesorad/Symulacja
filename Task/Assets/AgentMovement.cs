using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] private int hp = 3;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;

    private int[] _options = {0, 90, 180, 270, 360};

    private void OnEnable()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Rotate();
        rb.AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Oberwałem"+gameObject.name);
            hp -= 1;
            if (hp <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void Rotate()
    {
        Random random = new Random();
        int rotate = random.Next(0, _options.Length);
        transform.rotation = Quaternion.Euler(0, _options[rotate], 0);
    }
}
