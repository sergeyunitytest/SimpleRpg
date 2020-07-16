using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimiFather : MonoBehaviour
{
    // Start is called before the first frame update
    public void FatherDestroy()
    {
        Destroy(gameObject, 0.3f);
    }

   
}
