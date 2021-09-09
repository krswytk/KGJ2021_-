using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    //�ړ�
    [SerializeField] private float Speed = 0.1f;
    private Rigidbody2D Rigidbody2D;
    private Vector2 SpeedVector;

    //HP
    [SerializeField] private int HP = 10;
    [SerializeField] private int HealCoolTime = 2;
    private bool HealSw = true;
    [SerializeField] private float HitCoolTime = 0.5f;
    private bool HitCoolTimeSw = true;

    // Start is called before the first frame update
    void Start()
    {
        //�ړ�
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpeedVector = new Vector2(Speed * -1f, 0);

        //HP
        HealSw = true;
    }

    // Update is called once per frame
    void Update()
    {

        //�ړ�
        Rigidbody2D.velocity = SpeedVector ;
       // Rigidbody2D.velocity = SpeedVector * Time.deltaTime;
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
    public void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("aaa");
        //HP
        if (HealSw) {
            if (other.tag == "Heal")
            {
                HP++;
                StartCoroutine(HealCool());
            }
        }

        //�e�ɓ�������
        if (other.gameObject.tag == "Bullet")
        {
            Hit(1);
        }
        //���u�ɓ�������
        if (other.gameObject.tag == "Enemy")
        {
          
            Hit(2);
        }
    }

    private IEnumerator HealCool()
    {
        HealSw = false;
        //��~
        yield return new WaitForSeconds(HealCoolTime);
        //�폜
        HealSw = true;

        yield break;
    }

    private IEnumerator HitCoolTimeRiflesh()
    {
        yield return new WaitForSeconds(HitCoolTime);
        HitCoolTimeSw = true;
        yield return null;
    }
}
