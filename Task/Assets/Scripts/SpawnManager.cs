using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject agent;
    [SerializeField] private UIManager uIManager;
    [SerializeField] [Range(2, 10)] private float timeToSpawn = 2;
    public List<AgentMovement> agents;
    private float _timer;
    private int _multiple = 30;

    private void Awake()
    {
        _timer = timeToSpawn;
      SpawnObjectsOnStart();
    }

    private void SpawnObjectsOnStart()
    {
        for (int i = 0; i < _multiple; i++)
        {
            var newAgent = Instantiate(agent);
            newAgent.GetComponent<AgentMovement>().spawnManager = this;
            newAgent.GetComponent<AgentMovement>().uIManager = uIManager;
            newAgent.name = "Agent " + i;
            agents.Add(newAgent.GetComponent<AgentMovement>());
            newAgent.SetActive(false);
        }
    }
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            ShowAgent();
            _timer = timeToSpawn;
        }
    }

    private void ShowAgent()
    {
        Random random = new Random();
        for (int i = 0; i < agents.Count; i++)
        {
            if (!agents[i].gameObject.activeInHierarchy)
            {
                Vector3 pos = new Vector3(random.Next(2, 10), 1.5f, random.Next(-10, -2));
                agents[i].transform.position = pos;
                agents[i].gameObject.SetActive(true);
                return;
            }
        }
    }
}
