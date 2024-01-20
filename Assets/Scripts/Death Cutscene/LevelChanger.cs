using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToLevel(string lvl) {
        animator.SetTrigger("FadeOut");
    }


}
