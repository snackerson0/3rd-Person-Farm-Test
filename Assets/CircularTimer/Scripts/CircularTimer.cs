using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class CircularTimer : MonoBehaviour
{
    Color lerpedColor, bgLerpedColor;

    [SerializeField] public Color firstColor, secondColor, thirdColor, fourthColor, fifthColor;

    public enum ColorMode { normal, single, custom }

    public enum TextPosition { aboveCircle, belowCircle }

    public enum FillType { tick, smooth }   // call tranistion type?
    private float duration;

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
        public ColorMode colorMode;
        public Color color;
        public FillType fillType;
        public Image fillImage;
    }
    public FillSettings fillSettings;

    [System.Serializable]
    public class BackgroundSettings
    {
        public bool enabled;
        public Color color;
        public Image backgroundImage;
        public ColorMode colorMode;
        public Color firstColor, secondColor, thirdColor, fourthColor, fifthColor;

    }
    public BackgroundSettings backgroundSettings;

    [System.Serializable]
    public class TextSettings
    {
        public bool enabled;
        public bool displayMillisecond;
        public Text text;
        public Color color;
    }
    public TextSettings textSettings;

    [System.Serializable]
    public class SpriteSettings
    {
        public bool enabled = false;
        public Image image;
        public Sprite sprite;
        public TextPosition textPostion;
    }
    public SpriteSettings spriteSettings;

    public UnityEvent didFinishedTimerTime;

    public float CurrentTime { get; private set; }
    float AfterImageTime;

    bool isPaused = false;

    private void Start()
    {
        CalculateDuration();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PauseTimer();

        if (Input.GetKeyUp(KeyCode.Space))
            ResumeTimer();

        if (Input.GetKeyDown(KeyCode.LeftControl))
            ResetTimer();

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

        ProcessSprite();

        ProcessText();
    }
    private void ProcessSprite()
    {
        if (spriteSettings.enabled)
        {
            spriteSettings.image.gameObject.SetActive(true);

            if (spriteSettings.sprite != null)
                spriteSettings.image.sprite = spriteSettings.sprite;
            else
                print("You enabled the sprite but never set the image for the sprite.");
        }
        else
            spriteSettings.image.gameObject.SetActive(false);
    }

    private void ProcessBackGround()
    {
        if (backgroundSettings.enabled)
        {
            if (turnClockwise)
            {
                if (backgroundSettings.colorMode == ColorMode.normal)
                {
                    backgroundSettings.color = new Color(0.61f, 0.64f, 0.67f, 0.17f);
                    backgroundSettings.backgroundImage.color = backgroundSettings.color;
                }

                else if (backgroundSettings.colorMode == ColorMode.custom)
                {
                    print("Using custom colr");
                    ProcessCustomBackgroundColors();
                    backgroundSettings.backgroundImage.color = bgLerpedColor;

                }
                else if (backgroundSettings.colorMode == ColorMode.single)
                    backgroundSettings.backgroundImage.color = backgroundSettings.firstColor;
            }

        }
        else
        {
            backgroundSettings.backgroundImage.gameObject.SetActive(false);
        }

    }
    private void ProcessCustomBackgroundColors()
    {
        if (fillSettings.fillImage.fillAmount <= .25f)
            bgLerpedColor = Color.Lerp(backgroundSettings.firstColor, backgroundSettings.secondColor, fillSettings.fillImage.fillAmount * 4);

        else if (fillSettings.fillImage.fillAmount > .25f && fillSettings.fillImage.fillAmount <= .50f)
            bgLerpedColor = Color.Lerp(backgroundSettings.secondColor, backgroundSettings.thirdColor, ((fillSettings.fillImage.fillAmount) - .25f) * 4);

        else if (fillSettings.fillImage.fillAmount > .50f && fillSettings.fillImage.fillAmount <= .75f)
            bgLerpedColor = Color.Lerp(backgroundSettings.thirdColor, backgroundSettings.fourthColor, (fillSettings.fillImage.fillAmount - .50f) * 4);

        else if (fillSettings.fillImage.fillAmount > .75f && fillSettings.fillImage.fillAmount <= 1f)
            bgLerpedColor = Color.Lerp(backgroundSettings.fourthColor, backgroundSettings.fifthColor, (fillSettings.fillImage.fillAmount - .75f) * 4);

    }

    public void PauseTimer()
    {
        isPaused = true;
    }

    public void ResumeTimer()
    {
        isPaused = false;
    }

    public void StopAndReset()
    {
        isPaused = true;
        ResetTimer();
    }

    void ResetTimer()
    {
        CurrentTime = 0f;
    }

    private void ProcessColors()
    {
        if (fillSettings.colorMode == ColorMode.normal)
            ProcessDefaultColors();

        else if (fillSettings.colorMode == ColorMode.custom)
            ProcessCustomColors();

        else if (fillSettings.colorMode == ColorMode.single)
            fillSettings.fillImage.color = firstColor;
    }

    private void ProcessDefaultColors()
    {
        /*In order to gradually change between two colors, a color lerp is required.
         *Simply input the color you want displayed first in the first argument and the second
         * color you want to transition to in the second argument.
         * The third argument only accepts values from 0-1. A zero value will give you the first
         * color and a value of 1 will give you the second color. I get the value to zero by
         * getting the fill value and subtracting what is necessary to get to 0
         * then gradually multiplying it by 4 until the value becomes 1 which makes the color change 
         * to the second color.
         */

        Color orange = new Color(1, .64f, 0, 1);
        Color lightGreen = new Color(0.85f, 1f, 0f, 1);
        if (turnClockwise)
        {
            if (fillSettings.fillImage.fillAmount <= .25f)
                lerpedColor = Color.Lerp(Color.red, orange, fillSettings.fillImage.fillAmount * 4);

            else if (fillSettings.fillImage.fillAmount > .25f && fillSettings.fillImage.fillAmount <= .50f)
                lerpedColor = Color.Lerp(orange, Color.yellow, (fillSettings.fillImage.fillAmount - .25f) * 4);

            else if (fillSettings.fillImage.fillAmount > .50f && fillSettings.fillImage.fillAmount <= .75f)
                lerpedColor = Color.Lerp(Color.yellow, lightGreen, (fillSettings.fillImage.fillAmount - .50f) * 4);

            else if (fillSettings.fillImage.fillAmount > .75f && fillSettings.fillImage.fillAmount <= 1f)
                lerpedColor = Color.Lerp(lightGreen, Color.green, (fillSettings.fillImage.fillAmount - .75f) * 4);


            fillSettings.fillImage.color = lerpedColor;
        }

        else
        {//this may be the answer!!
            if (fillSettings.fillImage.fillAmount > .75)
                lerpedColor = Color.Lerp(lightGreen, Color.green, ((duration - CurrentTime) / duration)) * 4;

            else if (fillSettings.fillImage.fillAmount > .50f && fillSettings.fillImage.fillAmount <= .75f)
                lerpedColor = Color.Lerp(lightGreen, Color.yellow, ((CurrentTime / duration) - .50f) * 4);

            else if (fillSettings.fillImage.fillAmount <= .50f)
                lerpedColor = Color.Lerp(Color.red, Color.yellow, (CurrentTime / duration) * 2);





            fillSettings.color = lerpedColor;
            fillSettings.fillImage.color = fillSettings.color;
        }
    }

    private void ProcessCustomColors()
    {
        /*In order to gradually change between two colors, a color lerp is required.
       *Simply input the color you want displayed first in the first argument and the second
       * color you want to transition to in the second argument.
       * The third argument only accepts values from 0-1. A zero value will give you the first
       * color and a value of 1 will give you the second color. I get the value to zero by
       * getting the fill value and subtracting what is necessary to get to 0
       * then gradually multiplying it by 4 until the value becomes 1 which makes the color change 
       * to the second color.
       */

        if (fillSettings.fillImage.fillAmount <= .25f)
            lerpedColor = Color.Lerp(firstColor, secondColor, fillSettings.fillImage.fillAmount * 4);

        else if (fillSettings.fillImage.fillAmount > .25f && fillSettings.fillImage.fillAmount <= .50f)
            lerpedColor = Color.Lerp(secondColor, thirdColor, (fillSettings.fillImage.fillAmount - .25f) * 4);

        else if (fillSettings.fillImage.fillAmount > .50f && fillSettings.fillImage.fillAmount <= .75f)
            lerpedColor = Color.Lerp(thirdColor, fourthColor, (fillSettings.fillImage.fillAmount - .50f) * 4);

        else if (fillSettings.fillImage.fillAmount > .75f && fillSettings.fillImage.fillAmount <= 1f)
            lerpedColor = Color.Lerp(fourthColor, fifthColor, (fillSettings.fillImage.fillAmount - .75f) * 4);

        fillSettings.fillImage.color = lerpedColor;
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

            if (spriteSettings.enabled)
            {



            }
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

    private void CalculateDuration()
    {
        int hours = timerDuration.hours;
        int minutes = timerDuration.minutes;
        int seconds = timerDuration.seconds;


        if (hours > 0)
            minutes += hours * 60;

        if (minutes > 0)
            seconds += minutes * 60;

        duration = seconds;
    }
}