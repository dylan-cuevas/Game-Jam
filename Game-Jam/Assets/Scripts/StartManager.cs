using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{

    public GameObject cam;
    public GameObject instructions;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position += new Vector3(Time.deltaTime / 1.5f, 0f, 0f);

    }

    public void OnInstructionClick()
    {
        instructions.SetActive(true);
    }

    public void OnXClick()
    {
        instructions.SetActive(false);
    }

  
}
