using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialTimer : MonoBehaviour
{
    private Image timerCircle;
    [SerializeField] private ShipPlayerParent player;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        timerCircle = GetComponent<Image>();
        player = FindObjectOfType<ShipPlayerParent>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(timerCircle.fillAmount > 0)
        {
            timerCircle.fillAmount = Mathf.Lerp(1, 0, t);
            transform.position = player.GetSpecialTimerPosition();
            t += Time.deltaTime/5;
        }

        if (t >= 1)
        {
            t = 0;
            timerCircle.enabled = false;
        }
    }

    public void InitializedTimer()
    {
        transform.position = player.GetSpecialTimerPosition();
        timerCircle.fillAmount = 1;
        timerCircle.enabled = true;
    }
}
