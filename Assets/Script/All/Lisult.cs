using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lisult : MonoBehaviour
{

    public static bool GameSet;
    public bool a;
    public GameObject Win;
    public GameObject Loose;

    // Start is called before the first frame update
    void Start()
    {
        

        if (GameSet == false)
        {
            Loose.SetActive(true);
            Win.SetActive(false);
        }
        else if (GameSet == true)
        {

            Loose.SetActive(false);
            Win.SetActive(true);

        }





    }

    // Update is called once per frame
    void Update()
    {
       

       



    }
}
