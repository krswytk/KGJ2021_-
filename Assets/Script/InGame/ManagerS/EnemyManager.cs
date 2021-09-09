using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �G�̎�������
/// �G�{�w��HP�Ǘ��@����ɔ������U���g�N��
/// 
/// </summary>
public class EnemyManager : MonoBehaviour
{
    private SceneManagerScript SceneManagerScript; 

    [Header("�G�{�w��HP")]
    [SerializeField] private int EnemyHomeHP = 100;
    [Header("�GPOP�̃N�[���^�C��(�b)")]
    [SerializeField] private int EnemyCreateCoolTime = 10;

    [Header("�G�̃v���n�u")]
    [SerializeField] private GameObject[] EnemyPrefab;
    [Header("�G�̃v���n�u�����ʒu")]
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
        //���Ԍv��
        CoolTimer += Time.deltaTime;

        if(CoolTimer > EnemyCreateCoolTime)
        {
            CoolTimer = 0;
            CreateEnemy();
        }
    }

    //�G�̐���
    private void CreateEnemy()
    {
        var Ramde = Random.Range(0,EnemyPrefab.GetLength(0));
        Instantiate(EnemyPrefab[Ramde], EnemyPos, Quaternion.identity, Enemys.transform);
    }

    public void OnTriggerEnter(Collider other)
    {
        //�e�ɓ�������
        if (LayerMask.LayerToName(other.gameObject.layer) == "Bullet")
        {
            EnemyHomeHP--;
        }
        //���u�ɓ�������
        if(LayerMask.LayerToName(other.gameObject.layer) == "Player")
        {
            EnemyHomeHP -= 5;
        }

        //��������
        if (EnemyHomeHP < 1)
        {
            Debug.Log("�������������I");
            SceneManagerScript.LoadRisult();
        }
    }
}
