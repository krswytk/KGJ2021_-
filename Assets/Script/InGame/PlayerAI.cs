using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAI : MonoBehaviour
{
    //�ړ�
    [SerializeField] private float Speed = 0.1f;
    private Rigidbody2D Rigidbody2D;
    private Vector2 SpeedVector;

    //HP
    [SerializeField] public int HP = 10;
    [SerializeField] private int HealCoolTime = 2;
    private bool HealSw = true;
    [SerializeField] private float HitCoolTime = 0.5f;
    private bool HitCoolTimeSw = true;

    [SerializeField] SpriteRenderer[] _color;
    private float MaxHP;

    // Start is called before the first frame update
    void Start()
    {
        //�ړ�
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpeedVector = new Vector2(Speed * -1f, 0);

        //HP
        HealSw = true;
        MaxHP = HP;
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
            ColorChange();
            StartCoroutine(HitCoolTimeRiflesh());
            //�̗͂��Ȃ��Ȃ�����
            if (HP < 1)
            {
                if(this.gameObject.name == "PlayerManager")
                {
                    //�s�k����
                    SceneManager.LoadScene("Risult");

                }
                //���g���폜
                this.gameObject.SetActive(false);
            }
            return;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(" tag " + other.gameObject.tag);
        //HP
        if (HealSw)
        {
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
    private void ColorChange()
    {
        for(int i = 0;i< _color.Length; i++)
        {
            _color[i].color = new Color(HP/MaxHP, HP / MaxHP, HP / MaxHP, HP / MaxHP);
        }
    }
}
