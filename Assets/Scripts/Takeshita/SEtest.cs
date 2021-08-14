using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEtest : MonoBehaviour
{
    GameObject seManager;
    SoundEffectManager se;

    GameObject bgmManager;

    string input;

    // Start is called before the first frame update
    void Start()
    {
        seManager = GameObject.Find("SoundEffectManager");
        se = seManager.GetComponent<SoundEffectManager>();

        bgmManager = GameObject.Find("bgmManager");
        bgmManager.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.inputString;

        switch(input)
        {
            case ("1"):
                se.DefeatEnemySE();
                Debug.Log("Defeat Enemy");
                break;
            case ("2"):
                se.GameOverSE();
                Debug.Log("Game Over");
                break;
            case ("3"):
                se.MyDamageSE();
                Debug.Log("Damaged!");
                break;
            case ("4"):
                se.SetBowSE();
                Debug.Log("Set a Bow");
                break;
            case ("5"):
                se.ShotArrowSE();
                Debug.Log("Shoot!");
                break;
            case ("6"):
                se.SpawnEnemySE();
                Debug.Log("Spawn an Enemy");
                break;
            case ("7"):
                se.StartGameSE();
                Debug.Log("Game Start!");
                break;
            case ("8"):
                se.StartWaveSE();
                Debug.Log("Wave Start");
                break;
            default:
                break;
        }
    }
}
