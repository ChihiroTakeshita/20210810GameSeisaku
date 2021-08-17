using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///   画面遷移のスクリプト（マウス左クリックを押したら遷移する)
/// </summary>


public class Scene_Changer : MonoBehaviour
{
    [SerializeField] string sceneName; // シーン名をInspectorでセッティング

    [SerializeField] AudioClip PushButton_SE;
     AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        // Componentを取得
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(Checking(()=>
            {
            Debug.Log("End");
             }));
    }

    public delegate void functionType();

    private IEnumerator Checking (functionType callback)
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();

            if (!audioSource.isPlaying)
            {
                callback();
                break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) ) // マウス左クリックしたら
        {
            audioSource.PlayOneShot(PushButton_SE); // Buttonの効果音を鳴らす
            StartCoroutine(ChangeScene(sceneName, 2.0f));
        }
    }

    IEnumerator ChangeScene(string name, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(name); // Inspector上で遷移するSceneの名前をセッティングした場所へ飛ぶ
    }
}
