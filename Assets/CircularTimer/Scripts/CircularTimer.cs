using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class CircularTimer : MonoBehaviour
{
    Color lerpedColor;

    [SerializeField] Color firstColor, secondColor, thirdColor, fourthColor;

    public enum CountDirection { countUp, countDown }

    public enum ColorMode {normal, custom}
   
    public enum FillType { tick, smooth }   // call tranistion type?
    public float duration;

    public bool turnClockwise = true;

    [HideInInspector]
    public bool isTimerFinished = false;

    [System.Serializable]
    public class TimerDuration
    {
        public int hours = 0, minutes = 0, seconds = 0;
    }
    public TimerDuration timerDuration;

    [System.Serializable]
    public class FillSettings
    {
        public Color color;
        public FillType fillType;
        public Image fillImage;
        public ColorMode colorMode;
    }
    public FillSettings fillSettings;

    [System.Serializable]
    public class BackgroundSettings
    {
        public bool enabled;
        public Color color;
        public Image backgroundImage;
    }
    public BackgroundSettings backgroundSettings;

    [System.Serializable]
    public class TextSettings
    {
        public bool enabled;
        public bool displayMillisecond;
        public Text text;
        public Color color;
        public CountDirection countType;
    }
    public TextSettings textSettings;




    public UnityEvent didFinishedTimerTime;

    public float CurrentTime { get; private set; }
    float AfterImageTime;

    bool isPaused = false;

    void Update()
    {

        if (!isPaused)
        {
            CurrentTime += Time.deltaTime;

            if (CurrentTime >= duration)
            {
                isPaused = true;
                CurrentTime = duration;
                didFinishedTimerTime.Invoke();
            }
            ProcessFillTypeAndDirection();


            UpdateUI();

        }
    }

    public void UpdateUI()
    {
        ProcessColors();

        ProcessBackGround();

        ProcessText();
    }

    private void ProcessBackGround()
    {
        if (backgroundSettings.enabled)
        {
            backgroundSettings.backgroundImage.gameObject.SetActive(true);
            backgroundSettings.backgroundImage.color = backgroundSettings.color;
        }
        else
        {
            backgroundSettings.backgroundImage.gameObject.SetActive(false);
        }

    }

    public void PauseTimer()
    {
        isPaused = true;
    }

    public void StartTimer()
    {
        isPaused = false;
    }

    public void StopTimer()
    {
        CurrentTime = 0;
        AfterImageTime = 0;
        isPaused = true;
        ResetTimer();
    }

    void ResetTimer()
    {/*
        switch (fillSettings.fillDirection)
        {
            case FillDirection.fillDown:
                fillSettings.fillImage.fillAmount = 0;
                break;
            case FillDirection.fillUp:
                fillSettings.fillImage.fillAmount = 1;
                break;
        }*/
    }

    private void ProcessColors()
    {
        if (fillSettings.colorMode == ColorMode.normal)
            ProcessDefaultColors();

        else if (fillSettings.colorMode == ColorMode.custom)
            ProcessCustomColors();
    }

    private void ProcessDefaultColors()
    {
        /*In order to gradually change between two colors, a color lerp is required.
         *Simply input the color you want displayed first in the first argument and the second
         * color you want to transition to in the second argument.
         * The third argument only accepts values from 0-1. A zero value will give you the first
         * color and a value of 1 will give you the second color. I get the value to zero by
         * dividing the current time by the duration and subtracting what is necessary to get to 0
         * then gradually multiplying it by 4 until the value becomes 1 which makes the color change 
         * to the second color.
         */

        Color lightGreen = new Color(0.85f, 1f, 0f, 1);

        if (fillSettings.fillImage.fillAmount <= .50f)
            lerpedColor = Color.Lerp(Color.red, Color.yellow, (CurrentTime / duration) * 2);

        else if (fillSettings.fillImage.fillAmount > .50f && fillSettings.fillImage.fillAmount <= .75f)
            lerpedColor = Color.Lerp(Color.yellow, lightGreen, ((CurrentTime / duration) - .50f) * 4);

        else if (fillSettings.fillImage.fillAmount > .75f && fillSettings.fillImage.fillAmount <= 1f)
            lerpedColor = Color.Lerp(lightGreen, Color.green, ((CurrentTime / duration) - .75f) * 4);


        fillSettings.color = lerpedColor;

        fillSettings.fillImage.color = fillSettings.color;
    }

    private void ProcessCustomColors()
    {
        /*In order to gradually change between two colors, a color lerp is required.
         *Simply input the color you want displayed first in the first argument and the second
         * color you want to transition to in the second argument.
         * The third argument only accepts values from 0-1. A zero value will give you the first
         * color and a value of 1 will give you the second color. I get the value to zero by
         * dividing the current time by the duration and subtracting what is necessary to get to 0
         * then gradually multiplying it by 4 until the value becomes 1 which makes the color change 
         * to the second color.
         */


        if (fillSettings.fillImage.fillAmount <= .50f)
            lerpedColor = Color.Lerp(firstColor, secondColor, (CurrentTime / duration) * 2);

        else if (fillSettings.fillImage.fillAmount > .50f && fillSettings.fillImage.fillAmount <= .75f)
            lerpedColor = Color.Lerp(secondColor, thirdColor, ((CurrentTime / duration) - .50f) * 4);

        else if (fillSettings.fillImage.fillAmount > .75f && fillSettings.fillImage.fillAmount <= 1f)
            lerpedColor = Color.Lerp(thirdColor, fourthColor, ((CurrentTime / duration) - .75f) * 4);


        fillSettings.color = lerpedColor;

        fillSettings.fillImage.color = fillSettings.color;
    }

    private void ProcessFillTypeAndDirection()
    {
        if (turnClockwise)
        {
            if (fillSettings.fillType == FillType.smooth)
                fillSettings.fillImage.fillAmount = CurrentTime / duration;

            else if (fillSettings.fillType == FillType.tick)
                fillSettings.fillImage.fillAmount = (float)System.Math.Round(CurrentTime / duration, 1);
        }

        else if (!turnClockwise)
        {
            if (fillSettings.fillType == FillType.smooth)
                fillSettings.fillImage.fillAmount = (duration - CurrentTime) / duration;

            else if (fillSettings.fillType == FillType.tick)
                fillSettings.fillImage.fillAmount = (float)System.Math.Round((duration - CurrentTime) / duration, 1);

        }
          
        
    }

    private void ProcessText()
    {       
        if (textSettings.enabled)
        {
            textSettings.text.color = textSettings.color;

            textSettings.text.gameObject.SetActive(true);

            float time = CurrentTime;

            if (turnClockwise)
            {
                if (textSettings.displayMillisecond)
                {
                    textSettings.text.text = time.ToString("F2");
                }
                else
                {
                    textSettings.text.text = time.ToString("F0");
                }
            }

            else if (!turnClockwise)
            {
                if (textSettings.displayMillisecond)
                {
                    textSettings.text.text = (duration - time).ToString("F2");
                }
                else
                {
                    textSettings.text.text = (duration - time).ToString("F0");
                }
            }
            } 
        
        else
        {
            textSettings.text.gameObject.SetActive(false);
        }
    }
}
