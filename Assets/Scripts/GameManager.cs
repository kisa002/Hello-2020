using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject prefabStar;
    public TextMeshProUGUI tmp2020;

    public float speed = 30f;
    public float diffRange = 30f;

    public List<Color> colors = new List<Color>();

    private void Awake()
    {
        if (GameManager.instance == null)
            GameManager.instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(CorCreateStar());
        StartCoroutine(Cor2020AnimSize());
        StartCoroutine(Cor2020AnimFade());
        StartCoroutine(Cor2020AnimRot());

        AddColor("ef5350");
        AddColor("ec407a");
        AddColor("ab47bc");
        AddColor("7e57c2");
        AddColor("5c6bc0");
        AddColor("42a5f5");
        AddColor("29b6f6");
        AddColor("26c6da");
        AddColor("26a69a");
        AddColor("66bb6a");
        AddColor("9ccc65");
        AddColor("d4e157");
        AddColor("ffee58");
        AddColor("ffca28");
        AddColor("ffa726");
        AddColor("ff7043");
        //AddColor("");
    }

    private void AddColor(string colorName)
    {
        Color color;
        ColorUtility.TryParseHtmlString("#" + colorName, out color);

        colors.Add(color);
    }

    public Color GetColor()
    {
        return colors[Random.Range(0, colors.Count)];
    }

    IEnumerator CorCreateStar()
    {
        for (int i = 0; i < 120; i++)
        {
            GameObject star = Instantiate(prefabStar);
            star.transform.position = new Vector3(Random.Range(-diffRange, diffRange), Random.Range(-diffRange, diffRange), 90);

            yield return new WaitForSeconds(0.01f);
        }

        StartCoroutine(CorCreateStar());
    }

    IEnumerator Cor2020AnimSize()
    {
        float timer = 0;
        float min = 100;
        float max = 150;

        while (tmp2020.fontSize < max)
        {
            timer += Time.deltaTime * 1.2f;
            tmp2020.fontSize = Mathf.Lerp(min, max, timer);

            yield return new WaitForEndOfFrame();
        }

        timer = 0;
        while (tmp2020.fontSize > min)
        {
            timer += Time.deltaTime * 0.8f;
            tmp2020.fontSize = Mathf.Lerp(max, min, timer);

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(Cor2020AnimSize());
    }

    IEnumerator Cor2020AnimFade()
    {
        for (int i = 10; i <= 50; i++)
        {
            tmp2020.color = new Color(0.9372549f, 0.9372549f, 0.9372549f, i * 0.02f);
            yield return new WaitForSeconds(0.015f);
        }

        for (int i = 50; i >= 10; i--)
        {
            tmp2020.color = new Color(0.9372549f, 0.9372549f, 0.9372549f, i * 0.02f);
            yield return new WaitForSeconds(0.015f);
        }

        StartCoroutine(Cor2020AnimFade());
    }

    IEnumerator Cor2020AnimRot()
    {
        int rot = 7;
        float speed = 0.03f;

        for(int i=0; i<rot; i++)
        {
            tmp2020.transform.Rotate(Vector3.forward * 1);
            yield return new WaitForSeconds(speed);
        }

        for (int i = 0; i < rot; i++)
        {
            tmp2020.transform.Rotate(Vector3.back * 1);
            yield return new WaitForSeconds(speed);
        }

        for (int i = 0; i < rot; i++)
        {
            tmp2020.transform.Rotate(Vector3.back * 1);
            yield return new WaitForSeconds(speed);
        }

        for (int i = 0; i < rot; i++)
        {
            tmp2020.transform.Rotate(Vector3.forward * 1);
            yield return new WaitForSeconds(speed);
        }

        StartCoroutine(Cor2020AnimRot());
    }
}
