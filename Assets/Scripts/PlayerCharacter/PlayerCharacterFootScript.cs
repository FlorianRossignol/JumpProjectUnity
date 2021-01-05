using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterFootScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int footContact_ = 0;

    public int FootContact => footContact_;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("platform1"))
        {
            footContact_++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("platform1"))
        {
            footContact_--;
        }
    }
}
