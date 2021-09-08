using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMP : MonoBehaviour
{
    int MaxMP = 100;
    int NowMP;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void UsingMP(int NMP,int MMP )
    {
        NowMP = NMP;
        MaxMP = MMP;

        slider.value =( (float)NowMP / (float)MaxMP);



    }


}
