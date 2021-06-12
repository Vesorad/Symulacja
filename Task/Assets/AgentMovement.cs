using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AgentMovement : MonoBehaviour
{
    [HideInInspector] public bool selected;
    [HideInInspector] public SpawnManager spawnManager;
    [HideInInspector] public UIManager  uIManager;
    [HideInInspector] public int hp = 3;
    
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;

    private Renderer _myMaterial;
    private int[] _options = {0, 90, 180, 270, 360};

    private void Awake()
    {
        _myMaterial = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Rotate();
        rb.AddForce(transform.forward * speed);
    }
    private void Rotate()
    {
        Random random = new Random();
        int rotate = random.Next(0, _options.Length);
        transform.rotation = Quaternion.Euler(0, _options[rotate], 0);
    }

    private void OnMouseDown()
    {
       
        foreach (var VARIABLE in spawnManager.agents)
        {
            VARIABLE.ChangeColorToWhite();
            VARIABLE.selected = false;
        }
        if (!selected)
        {
            Debug.Log("1");
            _myMaterial.material.color = Color.gray;
            uIManager.UpdateText(this);
            selected = true;
        }

        if (selected)
        {
            selected = false;
            ChangeColorToWhite();
            uIManager.ClearText();
        }
    }

    public void ChangeColorToWhite()
    {
        _myMaterial.material.color = Color.white;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Oberwałem"+gameObject.name);
            hp -= 1;
            if (selected)
            {
                uIManager.UpdateText(this);
            }
            if (hp <= 0)
            {
                uIManager.ClearText();
                gameObject.SetActive(false);
            }
        }
    }
   
}
