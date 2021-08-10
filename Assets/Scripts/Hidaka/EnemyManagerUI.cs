using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManagerUI : MonoBehaviour
{
    public EnemyManager enemyManager;
    public Text waveText;
    public Text enemyText;

    void Update()
    {
        waveText.text = $"WAVE:{enemyManager.wave + 1}/{enemyManager.waves.Length}";
        enemyText.text = $"ENEMY:{enemyManager.EnemyCnt}";
    }
}
