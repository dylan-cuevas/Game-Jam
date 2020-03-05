using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{

    public GameObject cam;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position += new Vector3(Time.deltaTime / 1.5f, 0f, 0f);

    }

    public void onClick()
    {
        SceneManager.LoadScene("First");
        Debug.Log("Pressed");
    }
}
