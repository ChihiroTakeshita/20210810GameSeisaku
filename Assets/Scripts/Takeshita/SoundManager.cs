using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンによってBGMを変えるスクリプトです
/// </summary>

public class SoundManager : MonoBehaviour
{
    [SerializeField] public AudioSource prologue;
    [SerializeField] public AudioSource rule;
    [SerializeField] public AudioSource game;
    [SerializeField] public AudioSource gameClear;
    [SerializeField] public AudioSource gamOver;

    private string beforeScene = "Yamazaki2";

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(prologue.gameObject);
        DontDestroyOnLoad(game.gameObject);
        DontDestroyOnLoad(gameClear.gameObject);
        DontDestroyOnLoad(gamOver.gameObject);
        DontDestroyOnLoad(rule.gameObject);

        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    /// <summary>
    /// シーン遷移時にシーンの名前を取得して、当てはまるシーンのBGMを流します
    /// </summary>
    /// <param name="prevScene"></param>
    /// <param name="nextScene"></param>

    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        if(beforeScene == "Yamazaki2" && nextScene.name == "Yamazaki")
        {
            game.Stop();
            prologue.Play();
        }

        if(beforeScene =="Yamazaki" && nextScene.name == "Rule")
        {
            prologue.Stop();
            rule.Play();
        }

        if(beforeScene == "Rule" && nextScene.name == "Game")
        {
            rule.Stop();
            game.Play();
        }

        if (beforeScene == "Game" && nextScene.name == "GameClear")
        {
            game.Stop();
            gameClear.Play();
        }

        if (beforeScene == "Game" && nextScene.name == "GameOver")
        {
            game.Stop();
            gamOver.Play();
        }
    }
}
