using System.Collections;
using UnityEngine;

public class UIFade : MonoBehaviour
{ 
    //Fade out text after a few seconds;
    public IEnumerator Fade(float delay, float speed, float length)
    {
        TMPro.TMP_Text text = GetComponent<TMPro.TMP_Text>();

        Color c = text.color;

        float time = 0;

        while(time < length)
        {
            time += Time.deltaTime;

            //Start fade after delay seconds
            if (time > delay)
            {
                c.a -= speed * Time.deltaTime;

                text.color = c;
                yield return null;
            }
            yield return null;
        }

        //Reset
        gameObject.SetActive(false);
        c.a = 1;
        text.color = c;
        yield return null;
    }
}
