using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_lv1_manager : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (sc_hero.levelProgress)
        {
            case 0:
                //player.GetComponent<Animator>().SetBool("is_lay", true);
                //StartCoroutine(WaitAndadvanced(2f));

                break;
            case 1:
                //player.GetComponent<Animator>().SetBool("is_lay", false);
                //player.GetComponent<Animator>().SetBool("is_jump", true);
                break;
            case 2:
                player.GetComponent<Animator>().SetBool("is_jump", false);
                break;
            case 3:
                print("Grog SMASH!");
                break;
            case 4:
                print("Ulg, glib, Pblblblblb");
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }

    private IEnumerator WaitAndadvanced(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        print("WaitAndPrint " + Time.time);
        
    }
}
