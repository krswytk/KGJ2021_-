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
            //‘Ì—Í‚ª‚È‚­‚È‚Á‚½‚ç
            if (Damage < 1)
            {
                //Ž©g‚ðíœ
                Destroy(this);
            }
            return;
        }
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        //’e‚É“–‚½‚Á‚½
        if (other.gameObject.tag == "Bullet")
        {
            Hit(1);
        }
        //ƒ‚ƒu‚É“–‚½‚Á‚½
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
