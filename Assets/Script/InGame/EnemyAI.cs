using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float Speed = 0.1f;
    [SerializeField] private int HP = 10;

    private Rigidbody2D Rigidbody2D;

    private Vector2 SpeedVector;

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
        // Rigidbody2D.velocity = SpeedVector * Time.deltaTime;
    }

    public void Hit(int Damage)
    {
        HP -= Damage;
        if(Damage < 1)
        {
            Destroy(this);
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        //弾に当たった
        if (other.gameObject.tag == "Bullet")
        {
            HP--;
        }
        //モブに当たった
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("aaa");
            HP -=1;
        }

        //勝利処理
        if (HP < 1)
        {

            this.gameObject.SetActive(false);
        }
    }




}
