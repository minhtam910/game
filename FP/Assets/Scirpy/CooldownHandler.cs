using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownHandler : MonoBehaviour {

    public Transform fullFillImage;
    public Transform fillImage;
    private float fillAmount;
    private float cdTime = 0;
    // Use this for initialization
    void Start () {
        var newScale = this.fillImage.localScale;
        newScale.y = 4.58f;
        this.fillImage.localScale = newScale;
        fillAmount = -1;
    }

    private void Update()
    {
        if (fillAmount <= 1 && fillAmount >= 0)
        {
            this.SetFillBar(fillAmount);
            Invoke("startFilling", cdTime/10);
        }
        
    }
    public void isHit(float cdTime)
    {
        var newScale = this.fillImage.localScale;
        newScale.y = 0;
        this.fillImage.localScale = newScale;
        fillAmount = 0;
        this.cdTime = cdTime;
    }

    public void cooldownNow()
    {
        fillAmount = -1;
        var newScale = this.fillImage.localScale;
        newScale.y = 4.58f;
        this.fillImage.localScale = newScale;
    }

    public void SetFillBar(float fillAmount)
    {
        // Make sure value is between 0 and 1
        fillAmount = Mathf.Clamp01(fillAmount);

        // Scale the fillImage accordingly
        var newScale = this.fillImage.localScale;
        newScale.y = this.fullFillImage.localScale.y * fillAmount;
        this.fillImage.localScale = newScale;
    }
    public void startFilling()
    {       
        fillAmount += 0.005f;
    }
}
