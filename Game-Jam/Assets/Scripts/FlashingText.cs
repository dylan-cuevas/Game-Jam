using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingText : MonoBehaviour
{

    public Text specificText;

    void Start()
    {
        specificText = GetComponent<Text>();
        StartCoroutine(BlinkText());

    }

    IEnumerator BlinkText()
    {
        while (true)
        {
            specificText.text = "";

            yield return new WaitForSeconds(.5f);

            specificText.text = "START GAME";

            yield return new WaitForSeconds(.5f);
        }
    }
    
}
