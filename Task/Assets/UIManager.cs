using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI hp;

    private void Start()
    {
        ClearText();
    }

    public void ClearText()
    {
        name.text = "";
        hp.text = "";
    }

    public void UpdateText(AgentMovement agent)
    {
        name.text = agent.name;
        hp.text = agent.hp.ToString();
    }
}
