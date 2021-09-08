using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// “G‚Ì©“®¶¬
/// “G–{w‚ÌHPŠÇ—@‚»‚ê‚É”º‚¤ƒŠƒUƒ‹ƒg‹N“®
/// 
/// </summary>
public class EnemyManager : MonoBehaviour
{
    private SceneManagerScript SceneManagerScript; 

    [Header("“G–{w‚ÌHP")]
    [SerializeField] private int EnemyHomeHP = 100;
    [Header("“GPOP‚ÌƒN[ƒ‹ƒ^ƒCƒ€(•b)")]
    [SerializeField] private int EnemyCreateCoolTime = 10;

    [Header("“G‚ÌƒvƒŒƒnƒu")]
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
        //ŠÔŒv‘ª
        CoolTimer += Time.deltaTime;

        if(CoolTimer > EnemyCreateCoolTime)
        {
            CoolTimer = 0;
            CreateEnemy();
        }
    }

    //“G‚Ì¶¬
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
