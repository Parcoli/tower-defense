using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;

    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    // FadeIn = Ecran noir vers scene
    IEnumerator FadeIn()
    {
        float t = 1f;

        while(t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(58f,69f,147f, a);
            yield return 0;
        }
    }

    // FadeOut = Scene vers écran noir
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t > 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(58f, 69f, 147f, a);
            yield return 0;
        }

        // le code ci-dessous ne se lit que lorsque le fondu est terminé
        SceneManager.LoadScene(scene);
    }
}
