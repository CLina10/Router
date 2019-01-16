using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerController playerHealth;
    public GameObject LoseUI;

    void Update()
    {
        if (playerHealth.health <=0)
        {
            Lose();
        }
    }

    void Lose()
    {
        LoseUI.SetActive(true);
    }
}