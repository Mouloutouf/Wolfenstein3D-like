using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class GameManager : Singleton<GameManager>{
    protected GameManager() { }

    [HideInInspector] public InputManager inputManager;

    [HideInInspector] public List<Transform> spawnPoints;

    void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }
}
