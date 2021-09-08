using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敵の自動生成
/// 敵本陣のHP管理　それに伴うリザルト起動
/// 
/// </summary>
public class EnemyManager : MonoBehaviour
{
    private SceneManagerScript SceneManagerScript; 

    [Header("敵本陣のHP")]
    [SerializeField] private int EnemyHomeHP = 100;
    [Header("敵POPのクールタイム(秒)")]
    [SerializeField] private int EnemyCreateCoolTime = 10;

    [Header("敵のプレハブ")]
    [SerializeField] private GameObject[] EnemyPrefab;

    private float CoolTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        CoolTimer = 60f;

        SceneManagerScript = SceneManagerScript.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        //時間計測
        CoolTimer += Time.deltaTime;

        if(CoolTimer > EnemyCreateCoolTime)
        {
            CoolTimer = 0;
            CreateEnemy();
        }
    }

    //敵の生成
    private void CreateEnemy()
    {
        var Ramde = Random.Range(0,EnemyPrefab.GetLength(0) + 1);
        Instantiate(EnemyPrefab[Ramde], this.transform);
    }
    public void Hit(int Damage)
    {
        EnemyHomeHP -= Damage;
        if(EnemyHomeHP < 1)
        {
            SceneManagerScript.LoadRisult();
        }
    }
}
