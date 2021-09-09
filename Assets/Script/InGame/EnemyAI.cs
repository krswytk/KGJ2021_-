using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float Speed = 0.1f;
    [SerializeField] private int HP = 10;
    [SerializeField] private float HitCoolTime = 0.5f;

    private Rigidbody2D Rigidbody2D;
    private Vector2 SpeedVector;

    private bool HitCoolTimeSw = true;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpeedVector = new Vector2(Speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.velocity = SpeedVector;
    }

    public void Hit(int Damage)
    {
        if (HitCoolTimeSw)
        {
            HP -= Damage;
            HitCoolTimeSw = false;
            StartCoroutine(HitCoolTimeRiflesh());
            //�̗͂��Ȃ��Ȃ�����
            if (Damage < 1)
            {
                //���g���폜
                Destroy(this);
            }
            return;
        }
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        //�e�ɓ�������
        if (other.gameObject.tag == "Bullet")
        {
            Hit(1);
        }
        //���u�ɓ�������
        if (other.gameObject.tag == "Player")
        {
            Hit(2);
        }
    }

    private IEnumerator HitCoolTimeRiflesh()
    {
        yield return new WaitForSeconds(HitCoolTime);
        HitCoolTimeSw = true;
        yield return null;
    }
}
