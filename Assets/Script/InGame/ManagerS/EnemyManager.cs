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
    [Header("敵のプレハブ生成位置")]
    [SerializeField] private GameObject Enemys;
    private Vector2 EnemyPos;
    private Transform EnemysTransform;

    private float CoolTimer = 0f;
    
    void Start()
    {
        CoolTimer = 60f;

        SceneManagerScript = SceneManagerScript.Instance;

        EnemysTransform = Enemys.GetComponent<Transform>();
        EnemyPos = new Vector2(EnemysTransform.position.x, EnemysTransform.position.y);
    }
    
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
        var Ramde = Random.Range(0,EnemyPrefab.GetLength(0));
        Instantiate(EnemyPrefab[Ramde], EnemyPos, Quaternion.identity, Enemys.transform);
    }

    public void OnTriggerEnter(Collider other)
    {
        //弾に当たった
        if (LayerMask.LayerToName(other.gameObject.layer) == "Bullet")
        {
            EnemyHomeHP--;
        }
        //モブに当たった
        if(LayerMask.LayerToName(other.gameObject.layer) == "Player")
        {
            EnemyHomeHP -= 5;
        }

        //勝利処理
        if (EnemyHomeHP < 1)
        {
            Debug.Log("勝った勝った！");
            SceneManagerScript.LoadRisult();
        }
    }
}
