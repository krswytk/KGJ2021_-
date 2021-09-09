using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    //移動
    [SerializeField] private float Speed = 0.1f;
    private Rigidbody2D Rigidbody2D;
    private Vector2 SpeedVector;

    //HP
    [SerializeField] private int HP = 10;
    [SerializeField] private int HealCoolTime = 2;
    private bool HealSw = true;

    // Start is called before the first frame update
    void Start()
    {
        //移動
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpeedVector = new Vector2(Speed * -1f, 0);

        //HP
        HealSw = true;
    }

    // Update is called once per frame
    void Update()
    {

        //移動
        Rigidbody2D.velocity = SpeedVector ;
       // Rigidbody2D.velocity = SpeedVector * Time.deltaTime;
    }

    public void OnTriggerStay(Collider other)
    {
        //HP
        if (HealSw) {
            if (other.tag == "Heal")
            {
                HP++;
                StartCoroutine(HealCool());
            }
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



    public void OnCollisionEnter(Collision other)
    {
        //弾に当たった
        if (LayerMask.LayerToName(other.gameObject.layer) == "Bullet")
        {
            HP--;
        }
        //モブに当たった
        if (LayerMask.LayerToName(other.gameObject.layer) == "Enemy")
        {
            HP -= 1;
            Debug.Log("bbb");
        }

        //勝利処理
        if (HP < 1)
        {

            this.gameObject.SetActive(false);
        }
    }










}
