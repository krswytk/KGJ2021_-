using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float Speed = 0.1f;
    [SerializeField] private int HP = 10;
    [SerializeField] private float HitCoolTime = 0.5f;

    private Rigidbody2D Rigidbody2D;
    private Vector2 SpeedVector;

    private bool HitCoolTimeSw = true;

    [SerializeField] SpriteRenderer[] _color;
    private float MaxHP;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpeedVector = new Vector2(Speed, 0);

        MaxHP = HP;
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
            ColorChange();
            StartCoroutine(HitCoolTimeRiflesh());
            //体力がなくなったら
            if (HP < 1)
            {
                if (this.gameObject.name == "EnemyManager")
                {
                    //敗北処理
                    Lisult.GameSet =true;
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
        //弾に当たった
        if (other.gameObject.tag == "Bullet")
        {
            Hit(1);
        }
        //モブに当たった
        if (other.gameObject.tag == "Player")
        {
            Hit(2);
        }
    }
    public void OnCollisionStay2D(Collision2D other)
    {
        //弾に当たった
        if (other.gameObject.tag == "Bullet")
        {
            Hit(1);
        }
        //モブに当たった
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


    private void ColorChange()
    {
        for (int i = 0; i < _color.Length; i++)
        {
            _color[i].color = new Color(HP / MaxHP, HP / MaxHP, HP / MaxHP, HP / MaxHP);
        }
    }
}
