using UnityEngine;
using UnityEngine.UI;


public class sc_yes : MonoBehaviour
{

    public void reset_clicked()
    {
        this.GetComponent<Button>().interactable = true;
    }

    public void no_clicked()
    {
        this.GetComponent<Button>().interactable = false;
    }

}
