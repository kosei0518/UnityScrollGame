using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathEffectDestroyScript : MonoBehaviour
{
    public void onCompleteDeathAnim()
    {
        Destroy(this.gameObject);
    }
}
