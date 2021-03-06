using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAI : MonoBehaviour
{
    //移動
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
        //移動
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpeedVector = new Vector2(Speed * -1f, 0);

        //HP
        HealSw = true;
        MaxHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        //移動
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
            //体力がなくなったら
            if (HP < 1)
            {
                if(this.gameObject.name == "PlayerManager")
                {
                    //敗北処理
                    Lisult.GameSet = false;
                    SceneManager.LoadScene("Risult");

                }
                //自身を削除
                this.gameObject.SetActive(false);
            }
            return;
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(" tagaaaa " + other.gameObject.tag);
        //HP

        Debug.Log("aaa");

        if (HealSw)
        {
            if (other.gameObject.tag == "Heal")
            {
                HP++;
                StartCoroutine(HealCool());
            }
        }
        //弾に当たった
        if (other.gameObject.tag == "Bullet")
        {
            Hit(1);
        }
        //モブに当たった
        if (other.gameObject.tag == "Enemy")
        {
            Hit(2);
        }
    }
    public void OnCollisionStay2D(Collision2D other)
    {
       
        //HP
        if (HealSw) {
            if (other.gameObject.tag == "Heal")
            {
                HP++;
                StartCoroutine(HealCool());
            }
        }

        //弾に当たった
        if (other.gameObject.tag == "Bullet")
        {
            Hit(1);
        }
        //モブに当たった
        if (other.gameObject.tag == "Enemy")
        {
          
            Hit(2);
        }
    }

    private IEnumerator HealCool()
    {
        HealSw = false;
        //停止
        yield return new WaitForSeconds(HealCoolTime);
        //削除
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
