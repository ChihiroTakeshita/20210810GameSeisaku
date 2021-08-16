using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SEの再生を制御するスクリプトです。
/// 鳴らしたいタイミングで関数を呼ぶことでSEを鳴らすことができます。
/// </summary>

public class SoundEffectManager : MonoBehaviour
{
    AudioSource se;

    [SerializeField] AudioClip defeatEnemy;
    [SerializeField] AudioClip gameClear;
    [SerializeField] AudioClip gameOvar;
    [SerializeField] AudioClip myDamage;
    [SerializeField] AudioClip setBow;
    [SerializeField] AudioClip shotArrow;
    [SerializeField] AudioClip spawnEnemy;
    [SerializeField] AudioClip startGame;
    [SerializeField] AudioClip startWave;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        se = GetComponent<AudioSource>();
    }

    public void DefeatEnemySE()
    {
        se.PlayOneShot(defeatEnemy);
    }

    public void GameClearSE()
    {
        se.PlayOneShot(gameClear);
    }

    public void GameOverSE()
    {
        se.PlayOneShot(gameOvar);
    }

    public void MyDamageSE()
    {
        se.PlayOneShot(myDamage);
    }

    public void SetBowSE()
    {
        se.PlayOneShot(setBow);
    }

    public void ShotArrowSE()
    {
        se.PlayOneShot(shotArrow);
    }

    public void SpawnEnemySE()
    {
        se.PlayOneShot(spawnEnemy);
    }

    public void StartGameSE()
    {
        se.PlayOneShot(startGame);
    }

    public void StartWaveSE()
    {
        se.PlayOneShot(startWave);
    }
}
