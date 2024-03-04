using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject veiculo;
    public Vector3 cameraOffset = new Vector3(0,10,-20);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = veiculo.transform.position + cameraOffset;
    }
}
