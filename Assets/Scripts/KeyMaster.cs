using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KeyMaster : MonoBehaviour
{
    public GameObject firstScreen;
    public GameObject secondScreen;
    public GameObject winScreen;
    public GameObject winScreen2;
    public GameObject loseScreen;
    private GameObject currentScreen;
    private Text seconds;
    public Text timerText;
    public float time = 60;
    private TimeSpan timer = new TimeSpan(60);
    public Text pinOne;
    public Text pinTwo;
    public Text pinThree;
    public Text winText;
    private int a;
    private int b;
    private int c;
    public int counterClick;
    public Text counterClickText;
    string[] nums = { "6", "3", "6", "6", "4", "4", "7", "2", "4" };
    int one = 0;
    int two = 1;
    int three = 2;
    private void Start()
    {
        firstScreen.SetActive(true);
        currentScreen = firstScreen;       
    }
    public void Timer()
    {
    	time --;
    	timer = TimeSpan.FromSeconds(time);
    	timerText.text = timer.Seconds.ToString("00");
    	if (time == 0)
    	{
    		TimeOut();
    	}    	
    }

    public IEnumerator Cowntdown()
    {
    	while(time > 0)
    	{
    		Timer();
    		yield return new WaitForSeconds(1);
    	}
    }

	private void TimeOut()
   	{
   		loseScreen.SetActive(true);
    	winText.text = "Вы проиграли";
    }


    public void Restart()
    {
        counterClickText.text = "5";
        counterClick = 5;
    	pinOne.text = nums[one];
    	pinTwo.text = nums[two];
    	pinThree.text = nums[three];
    	winScreen.SetActive(false);
        loseScreen.SetActive(false);
        secondScreen.SetActive(true);
        time = 60;
    	StartCoroutine(Cowntdown());
    }

    private void Finish()
    {        
		if (a == 5 && b == 5 && c == 5)
  	    {  	     
    		   winScreen.SetActive(true);
            secondScreen.SetActive(false);
            time = 0;
    		   winText.text = "Вы победили";
            one += 3;
            two += 3;
            three += 3;
            if (one == 9) 
            {
                winScreen.SetActive(false);
                winScreen2.SetActive(true);            
            }
   	    }
        if (counterClick == 0)
        {
            TimeOut();
        }
   	}

   	    public void ChangeState(GameObject state)
    {
        if (currentScreen != null)
        {
        	currentScreen.SetActive(false);
        	state.SetActive(true);
        	currentScreen = state;
        	StartCoroutine(Cowntdown());
        }
    }

    public void KeyButton1_OnPress()
    {
        counterClickText.text = (--counterClick).ToString();
        a = int.Parse(pinOne.text);
    	if (a < 10)
    	{
    		a ++;
    		pinOne.text = $"{a}";
    	}
    	b = int.Parse(pinTwo.text);
    	if (b > 0)
    	{
    		b --;
    		pinTwo.text = $"{b}";
    	}
    	c = int.Parse(pinThree.text);
    	Finish();    	
    }

    public void KeyButton2_OnPress()
    {
        counterClickText.text = (--counterClick).ToString();
        a = int.Parse(pinOne.text);
    	if (a > 0)
    	{
    		a --;
    		pinOne.text = $"{a}";
    	}
    	b = int.Parse(pinTwo.text);
    	if (b < 10)
    	{
    		b += 2;
    		if (b == 11)
    		{
    			b = 10;
    			pinTwo.text = $"{b}";
    		}
    		pinTwo.text = $"{b}";
    	}

    	c = int.Parse(pinThree.text);
    	if (c > 0)
    	{
    		c --;
    		pinThree.text = $"{c}";
    	}
    	Finish();
    }

    public void KeyButton3_OnPress()
    {
        counterClickText.text = (--counterClick).ToString();
        a = int.Parse(pinOne.text);
    	if (a > 0)
    	{
    		a --;
    		pinOne.text = $"{a}";
    	}
    	b = int.Parse(pinTwo.text);
    	if (b < 10)
    	{
    		b ++;
    		pinTwo.text = $"{b}";
    	}
    	c = int.Parse(pinThree.text);
    	if (c < 10)
    	{
    		c ++;
    		pinThree.text = $"{c}";
    	}
    	Finish();
    }
    public void Win2()
    {
        winScreen2.SetActive(false);
        firstScreen.SetActive(true);
        one = 0;
        two = 1;
        three = 2;
    }
}
