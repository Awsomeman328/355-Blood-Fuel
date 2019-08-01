﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static public PlayerManager activeManager;
    static public List<DriverPlayer> activePlayers = new List<DriverPlayer>();

    public FollowTarget camera;

    public Car playerCarPrefab;
    public GameObject prefabGuiGameOver;

    void Start()
    {
        activeManager = this;
        SpawnPlayer();
    }
    void SpawnPlayer() {

        DriverPlayer player = new DriverPlayer();
        Car car = Instantiate(playerCarPrefab);
        player.TakeControl(car);

        activePlayers.Add(player);

        camera.target = car.transform;
    }
    static public void Remove(DriverPlayer player) {
        activePlayers.Remove(player);
        if (activePlayers.Count == 0) activeManager.GameOver();
    }
    static public DriverPlayer PickRandom() {
        return activePlayers[Random.Range(0, activePlayers.Count)];
    }
    public void GameOver() {
        Instantiate(prefabGuiGameOver);
    }
}
