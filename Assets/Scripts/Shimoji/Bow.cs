using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Arrow arrowPrefab;

    //弓LV
    public int lv = 1;
    //LVに応じた攻撃範囲
    public float ShotRange => 1 + lv * 0.5f;
    //LVに応じた攻撃速度
    public float ShotInterval => 1.0f * Mathf.Pow(0.9f, lv);
    //LVに応じたパワーアップコスト
    public int Cost => (int)(100 * Mathf.Pow(1.5f, lv));
    //LVに応じた売却額
    public int Price => Cost / 2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SearchAndShot());
    }

    private IEnumerator SearchAndShot()
    {
        while (true)
        {
            yield return new WaitForSeconds(ShotInterval);
            //TODO ここで敵を探して、矢を撃つ
            var collider = Physics2D.OverlapCircle(transform.position, ShotRange, LayerMask.GetMask("Enemy"));
            if(collider != null)
            {
                transform.rotation = Quaternion.FromToRotation(Vector3.right, collider.transform.position - transform.position);
                var arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
                arrow.targetEnemy = collider.GetComponent<Enemy>();
            }
        }
    }
}
