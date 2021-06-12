using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("To Fill")]
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI hp;

    private int _timer=1;
    private void Start()
    {
        ClearText();
    }

    public void ClearText()
    {
        name.text = "";
        hp.text = "";
    }

    public void StartCount()
    {
        InvokeRepeating("Count",1,1);
    }

    private void Count()
    {
        Debug.Log(_timer);
        if (_timer % 3 == 0 && _timer % 5 == 0)
        {
            Debug.Log("MarkoPolo");
        }
        else
        {
            if (_timer % 3 == 0)
            {
                Debug.Log("Marko");
            }

            if (_timer % 5 == 0)
            {
                Debug.Log("Polo");
            }

        }

        if (_timer == 100)
        {
            CancelInvoke();
        }

        _timer += 1;
    }

    public void UpdateText(AgentMovement agent)
    {
        name.text = agent.name;
        hp.text = agent.hp.ToString();
    }
}
