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
        public float health;
        public float maxHealth;
        public float stamina;
        public float maxStamina;
        public float speed;
        public float maxSpeed;
        public bool facedRight;
    }

    [System.Serializable]
    public class CombatStats
    {
        public float damageRemaining;
        public float attackPower;
        public float defense;
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
