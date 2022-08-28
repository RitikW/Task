using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;

public class PendulumMotion : MonoBehaviour
{
    public Rigidbody2D rb;
    public Slider Length;
    public Slider Mass;
    public Text MassText;
    public Text LengthText;
    public GameObject Ball;
    public GameObject AngleObj;
    public Text Angle;
    private float curangle;
    private float timePer;
    public Text timeperiod;
    bool isShown;
    bool trail;
    public TrailRenderer tr;

    private void Start()
    {

    }
    public void StopSim()
    {
        SceneManager.LoadScene(0);
        /*this.transform.localRotation = Quaternion.identity;
        rb.drag = 15f;
        StartCoroutine(Stop());*/
    }

    /*IEnumerator Stop()
    {
        yield return new WaitForSeconds(2f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        //curangle = 0;
        rb.drag = .01f;
    }*/
    public void Timecalculate()
    {
        
        timeperiod.text = timePer.ToString("Time Period -> 0.00 sec");
    }
    public void trailon()
    {
        StartCoroutine(trailoff(timePer));       
    }
    IEnumerator trailoff(float timePer)
    {
        tr.emitting = true;
        yield return new WaitForSeconds(timePer);
        tr.emitting = false;
    }

    public void AngleShow()
    {
        isShown = !isShown;
        AngleObj.SetActive(isShown);
    }
    private void SetMassAndLength()
    {
        transform.localScale = new Vector3(Length.value, Length.value, 1);
        rb.mass = Mass.value;
        Mass.onValueChanged.AddListener((v) => { MassText.text = v.ToString("Mass -> 0.00kg"); });
        //Length.onValueChanged.AddListener((v) => { LengthText.text = v.ToString("Length -> 0.00mm"); });
    }
    public void SetLength()
    {
        LengthText.text = transform.localScale.x.ToString("Length -> 0.00mm");
    }

    private void CalculateAngle()
    {
        if (curangle > 270 && curangle <= 360)
        {
            curangle = 360 - curangle;
        }
        if (curangle > 90 && curangle < 180)
        {
            curangle = 0;
        }
        else if (curangle > 180 && curangle < 270)
        {
            curangle = 0;
        }
    }
    // Update is called once per frame
    private void Update()
    {
        timePer = 2 * Mathf.PI * (Mathf.Sqrt(Length.value / rb.gravityScale));
        SetMassAndLength();       
        curangle = transform.rotation.eulerAngles.z;
        CalculateAngle();        
        Angle.text = curangle.ToString("Angle -> 00.00 Deg");
    }

}
