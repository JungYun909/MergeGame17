using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitListAnim : MonoBehaviour
{

    public int level;
    Animator anim;

    // Start is called before the first frame update
    public void FruitAnimSetting()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("Level", level);
    }


}
