using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    //à⁄ìÆ
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
        //à⁄ìÆ
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpeedVector = new Vector2(Speed * -1f, 0);

        //HP
        HealSw = true;
    }

    // Update is called once per frame
    void Update()
    {

        //à⁄ìÆ
        Rigidbody2D.velocity = SpeedVector * Time.deltaTime;
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
        //í‚é~
        yield return new WaitForSeconds(HealCoolTime);
        //çÌèú
        HealSw = true;

        yield break;
    }
}
