using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(UIManager))]
public class GameManager : Singleton<GameManager>{
    protected GameManager() { }

    [HideInInspector] public InputManager inputManager;
    [HideInInspector] public UIManager uiManager;

    [HideInInspector] public List<Transform> spawnPoints;

    void Awake()
    {
        inputManager = GetComponent<InputManager>();
        uiManager = GetComponent<UIManager>();
    }
}
