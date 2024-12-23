using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData: ScriptableObject
{
    [SerializeField] private int score;
    [SerializeField] private int lives;
    [SerializeField] private int combo;
    private bool isMolehit = false;

    public void setScore(int score) { this.score = score; }

    public void setCombo(int combo) { this.combo = combo; }

    public void setLives(int lives) { this.lives = lives; }

    public void setIsMoleHit(bool isMoleHit) { this.isMolehit = isMoleHit; }

    public int getScore() { return score; }

    public int getCombo() { return combo; }

    public int getLives() { return lives; }

    public bool getIsMoleHit() { return isMolehit; }
}
