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
    [SerializeField] private int EnemyCreateCoolTime =1;

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
        CoolTimer += Time.deltaTime*2;

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

    public void OnCollisionEnter(Collision other)
    {
        //�e�ɓ�������
        if (other.gameObject.tag == "Bullet")
        {
            EnemyHomeHP--;
        }
        //���u�ɓ�������
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("aaa");
            EnemyHomeHP -= 1;
        }
        //��������
        if (EnemyHomeHP < 1)
        {
            Lisult.GameSet = false;
            Debug.Log("�������������I");
            SceneManagerScript.LoadRisult();
        }
    }
}
