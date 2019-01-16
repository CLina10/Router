using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningManager : MonoBehaviour
{
    public EnemyCounter count;
    public GameObject WinUI;

    void Update()
    {
        if (EnemyCounter.count == 7)
        {
            Win();
            GameObject.Find("character").SendMessage("Finnish");
        }
    }

    void Win()
    {
        WinUI.SetActive(true);
    }
}