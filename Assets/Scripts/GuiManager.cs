using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    public GameObject uiText;   // These public variables are set in the inspector
    public float waitTime;  
    public float yPosition;     // 0 is at the bottom
    public string[] textMessages;

    void Start()
    {
        StartCoroutine("MyCoroutine");
    }

    IEnumerator MyCoroutine()
    {
        for(int x = 0; x < textMessages.Length; x++)
        {
            SpawnText(textMessages[x]);

            yield return new WaitForSeconds(waitTime); // pauses the for loop for x amount of seconds

            if (x == textMessages.Length - 1)           // Remove this if you dont want the text to loop
                x = -1;
        } 
    }

    void SpawnText(string textMessage)
    {
        gameObject.SetActive(true);
        GameObject canvas = GameObject.Find("Canvas");
        uiText.GetComponent<Text>().text = textMessage;
        GameObject text = Instantiate(uiText, new Vector3(Screen.width + 50, yPosition, 0), Quaternion.identity);
        text.transform.SetParent(canvas.transform);
    }
}
