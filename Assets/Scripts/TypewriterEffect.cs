using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{
    public float Delay = 0.1f;
    public string FullText;
    private string _currentText = "";

    IEnumerator ShowText()
    {
        for (int i = 0; i <= FullText.Length; i++)
        {
            _currentText = FullText.Substring(0, i);
            GetComponent<Text>().text = _currentText;
            yield return new WaitForSeconds(Delay);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
        
    }


}
