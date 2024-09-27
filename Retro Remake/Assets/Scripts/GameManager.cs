using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Rigidbody2D ball;
    public TMPro.TMP_Text scoreLeftText;
    public TMPro.TMP_Text scoreRightText;
    public TMPro.TMP_Text countDownText;
    public GameObject countDownWrapper;

    private int _scoreLeft;
    private int _scoreRight;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;

        _scoreLeft = 0;
        _scoreRight = 0;

        InitializeBall();
        StartCoroutine(_CountingDown());
    }

    public void InitializeBall()

    {
        float angle = Random.Range(0f, 30f);
        float r = Random.Range(0f, 1f);
        if (r < 0.25f)
            angle = 180f - angle;
        else if (r < 0.5)
            angle += 180f;
        else if (r < 0.75f)
            angle = 360f - angle;
        angle *= Mathf.Deg2Rad;

        Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        ball.velocity = dir.normalized * 10f;

        ball.transform.position = Vector3.zero;

    }

    public void Increasescore(bool left)
    {
        if (left)
        {
            _scoreLeft++;
            scoreLeftText.text = _scoreLeft.ToString();
        }

        else
        {
            _scoreRight++;
            scoreRightText.text = _scoreRight.ToString();
        }
    }

    private IEnumerator _CountingDown()
    {
        Time.timeScale = 0;

        for (int c = 3; c > 0; c--)
        {
            countDownText.text = c.ToString();
            yield return new WaitForSecondsRealtime(1);
        }

        countDownWrapper.SetActive(false);

        Time.timeScale = 1;
    }

}
