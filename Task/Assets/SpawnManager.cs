using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject agent;
    [SerializeField] [Range(2, 10)] private float timeToSpawn = 2;
    [SerializeField] private List<GameObject> agents;

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
            agents.Add(newAgent);
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
            if (!agents[i].activeInHierarchy)
            {
                Vector3 pos = new Vector3(random.Next(2, 10), 1.5f, random.Next(-10, -2));
                agents[i].transform.position = pos;
                agents[i].SetActive(true);
                return;
            }
        }
    }
}
