using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mole : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    [SerializeField]
    private GameObject textScore;
    [SerializeField]
    private GameObject textLives;
    [SerializeField]
    private GameObject textCombo;
    [SerializeField]
    private GameObject start;
    [SerializeField]
    private MoleAppears moleAppears;

    public void OnMoleHit()
    {
        gameData.setCombo(gameData.getCombo() + 1);
        gameData.setScore(gameData.getScore() + 100 * gameData.getCombo());
        textScore.GetComponent<TextMeshProUGUI>().text = "Score : " + gameData.getScore();
        textCombo.GetComponent<TextMeshProUGUI>().text = "Combo : " + gameData.getCombo();
    }

    public void OnMoleFlee()
    {
        gameData.setLives(gameData.getLives() - 1);
        if (gameData.getLives() >= 1)
        {
            gameData.setCombo(0);
            textLives.GetComponent<TextMeshProUGUI>().text = "Vies restantes : " + gameData.getLives();
            textCombo.GetComponent<TextMeshProUGUI>().text = "Combo : " + gameData.getCombo();
        }
        else
        {
            textCombo.SetActive(false);
            textLives.SetActive(false);
            start.SetActive(true);
        }
    }

    public void StartGame()
    {
        gameData.setScore(0);
        gameData.setLives(3);
        gameData.setCombo(0);
        textCombo.SetActive(true);
        textLives.SetActive(true);
        textScore.GetComponent<TextMeshProUGUI>().text = "Score : " + gameData.getScore();
        textLives.GetComponent<TextMeshProUGUI>().text = "Vies restantes : " + gameData.getLives();
        textCombo.GetComponent<TextMeshProUGUI>().text = "Combo : " + gameData.getCombo();
        StartCoroutine(moleAppears.RandomMole());
        start.SetActive(false);
    }
}
