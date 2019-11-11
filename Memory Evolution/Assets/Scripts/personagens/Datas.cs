using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datas : MonoBehaviour
{
    public Principais principais;
    public CombatStats combatStats;
    public Team team;
    public Collision collision;

    [System.Serializable]
    public class Principais
    {
        public float health = 100;
        public float maxHealth= 100;
        public float stamina = 20;
        public float maxStamina = 20;
        public float speed = 5;
        public float maxSpeed = 10;
        public bool facedRight;
        public bool inControl = true;
    }

    [System.Serializable]
    public class CombatStats
    {
        public bool atack = true; 
        public float damageRemaining = 0;
        public float attackPower = 20;
        public float defense = 10;
    }

    [System.Serializable]
    public class Team
    {
        public bool player;
        public bool team1;
        public bool team2;
    }

    [System.Serializable]
    public class Collision
    {
        public bool collision = true;
    }


    void Update()
    {
        if (principais.health > principais.maxHealth)
            principais.health = principais.maxHealth;
        if (principais.stamina > principais.maxStamina)
            principais.stamina = principais.maxStamina;
    }
}
