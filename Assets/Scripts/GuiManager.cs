using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    //public GameObject myMessages;
    public GameObject uiText;
    public float waitTime;
    public string[] textMessages;
    int counter = 1;

    void Start()
    {
        StartCoroutine("MyCoroutine");
    }

    IEnumerator MyCoroutine()
    {
        for(int x = 0; x < textMessages.Length; x++)
        {
            SpawnText(textMessages[x]);
            counter++;
            yield return new WaitForSeconds(waitTime);

            if (x == textMessages.Length - 1)
            {
                x = -1;
                counter = 1;
            }
        }

        // If you want to run it in a loop
    }

    void SpawnText(string textMessage)
    {
        gameObject.SetActive(true);
        GameObject canvas = GameObject.Find("Canvas");
        uiText.GetComponent<Text>().text = textMessage;
        GameObject text = Instantiate(uiText, new Vector3(Screen.width + 50, 290, 0), Quaternion.identity);
        text.transform.SetParent(canvas.transform);
    }
}
