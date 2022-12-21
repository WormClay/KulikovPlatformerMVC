using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BulletView : MonoBehaviour
{
    public Transform Transform;
    public void SetVisible(bool value) 
    {
        gameObject.SetActive(value);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
