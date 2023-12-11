using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform player;
    public Transform middlebg, sidebg;

    public float lenght = 33.1f;


    private void Update()
    {
        if (player.position.x > middlebg.position.x)
        {
            sidebg.position = middlebg.position + Vector3.right * lenght;

            if (player.position.x < middlebg.position.x)
            {
                sidebg.position=middlebg.position + Vector3.left * lenght;
            }


            if(player.position.x>sidebg.position.x || player.position.x < sidebg.position.x)
            {
                Transform z = middlebg;
                middlebg = sidebg;
                sidebg = z;
            }
        }
    }
}
