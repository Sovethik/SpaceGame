using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arc : MonoBehaviour
{
    public GameObject Electron;

    private void Start()
    {
        gameObject.transform.SetParent(Electron.transform);
        Destroy(gameObject, 1.3f);
    }


}
