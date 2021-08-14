using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    enum GAME_STATE
    {
        TITLE,
        GAME_PLAY,
        WAVE_CHANGE,
        WAVE_CLEAR,
        GAME_CLEAR,
        GAME_OVER
    }

    [SerializeField] private GAME_STATE state;
    [SerializeField] private Text stateText;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private Player player;

    private WaitUntil WaitAnyKey => new WaitUntil(() => Input.anyKeyDown);

    // Start is called before the first frame update
    void Start()
    {
        state = GAME_STATE.TITLE;
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        while (true)
        {
            switch (state)
            {
                case GAME_STATE.TITLE:
                    stateText.text = "タイトルを表示";
                    yield return WaitAnyKey;
                    state = GAME_STATE.WAVE_CHANGE;
                    break;

                case GAME_STATE.GAME_PLAY:
                    stateText.text = "";
                    enemyManager.time += Time.deltaTime;
                    enemyManager.CreateEnemy();

                    if (player.hp <= 0)
                    {
                        state = GAME_STATE.GAME_OVER;
                    }

                    else if (enemyManager.EnemyCnt == 0)
                    {
                        state = GAME_STATE.WAVE_CLEAR;
                    }
                    break;

                case GAME_STATE.WAVE_CHANGE:
                    stateText.text = $"WAVE {enemyManager.wave + 1}";
                    yield return WaitAnyKey;
                    state = GAME_STATE.GAME_PLAY;
                    break;

                case GAME_STATE.WAVE_CLEAR:
                    if (enemyManager.wave == enemyManager.waves.Length - 1)
                    {
                        state = GAME_STATE.GAME_CLEAR;
                    }

                    else
                    {
                        stateText.text = $"WAVE CLEAR\nBONUS + {player.gold * 20 / 100}";
                        yield return WaitAnyKey;
                        player.gold += player.gold * 20 / 100;
                        enemyManager.wave++;
                        enemyManager.time = 0;
                        state = GAME_STATE.WAVE_CHANGE;
                    }
                    break;

                case GAME_STATE.GAME_CLEAR:
                    stateText.text = "GAME CLEAR";
                    yield return WaitAnyKey;
                    SceneManager.LoadScene(0);
                    break;

                case GAME_STATE.GAME_OVER:
                    stateText.text = "GAME OVER";
                    yield return WaitAnyKey;
                    SceneManager.LoadScene(0);
                    break;

            }
            yield return null;
        }
    }
    
}
