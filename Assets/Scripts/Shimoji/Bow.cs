using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SearchAndShot());
    }

    private IEnumerator SearchAndShot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            //TODO ここで敵を探して、矢を撃つ
            var collider = Physics2D.OverlapCircle(transform.position, 2.0f, LayerMask.GetMask("Enemy"));
            if(collider != null)
            {
                Bowtransform.rotation = Quaternion.FromToRotation(Vector3.right, collider.transform.position - transform.position);
                var arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
                arrow.targetEnemy = collider.GetComponent<Enemy>();
            }
        }
    }
}
