﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon {

    public PhysicsHoming prefabRocket;
    public int amountOfRockets = 8;
    public float secondsBetweenLaunches = .1f;
    public float cooldown = 2;

    float countdownCooldown;
    float countdownLaunches;
    int amountOfRocketsInChamber;

    void Update() {
        if (amountOfRocketsInChamber > 0) {
            countdownLaunches -= Time.deltaTime;
            if (countdownLaunches <= 0) {
                PhysicsHoming rocket = Instantiate(prefabRocket, spawnPoint.position, Quaternion.identity);
                rocket.Launch(car.driver, spawnPoint.position, car.state.up, cursor, car.ballBody.velocity);
                countdownLaunches = secondsBetweenLaunches;
                amountOfRocketsInChamber--;
            }
        } else {
            if(countdownCooldown < 0) countdownCooldown -= Time.deltaTime;
        }
    }
    public override void FireWeapons() {
        if (countdownCooldown > 0) return;
        countdownLaunches = 0;
        amountOfRocketsInChamber = amountOfRockets;
    }
}
