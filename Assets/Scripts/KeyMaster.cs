using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KeyMaster : MonoBehaviour
{
   [SerializeField] private GameObject firstScreen;
   [SerializeField] private GameObject secondScreen;
   [SerializeField] private GameObject winScreen;
   private GameObject currentScreen;
 //  private Text minutes;
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

    private void Start()
    {
        firstScreen.SetActive(true);
        currentScreen = firstScreen;
       
    }

   // public void Update()
   // {
   // time = Mathf.Round(Time.time);
   //  	//timer = timer -60;
   // for (int i = 0; i < 10; i++)
  	//  {
   //  	timerText.text = time.ToString("00"); 
   //  	Debug.Log (i);
 	 //  }
   // 	//timerText.text = timer.ToString();
   // }
    public void Timer()
    {
    	time --;
    	timer = TimeSpan.FromSeconds(time);
    	timerText.text = timer.Seconds.ToString("00");
    	if (time == 0)
    	{
    		timeOut();
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

	private void timeOut()
   	{
   		winScreen.SetActive(true);
    	winText.text = "Вы проиграли";
    }


    public void restart()
    {
    	pinOne.text = "4";
    	pinTwo.text = "6";
    	pinThree.text = "5";
    	winScreen.SetActive(false);
    	time = 60;
    	StartCoroutine(Cowntdown());
    }

    private void finish()
    {
		if (a == 5)
  	    {  	    
    	  if (b == 5)
    	   {    	   
    		 if (c == 5)
    		 {
    		   winScreen.SetActive(true);
    		   time = 0;
    		   winText.text = "Вы победили";
    		 }
    	   }
    	
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

    public void keyButton1_OnPress()
    {
    	a = int.Parse(pinOne.text);
    	if (a < 10)
    	{
    		a = a + 1;
    		pinOne.text = $"{a}";
    	}
    	b = int.Parse(pinTwo.text);
    	if (b > 0)
    	{
    		b = b - 1;
    		pinTwo.text = $"{b}";
    	}
    	c = int.Parse(pinThree.text);
    	finish();    	
    }

    public void keyButton2_OnPress()
    {
    	a = int.Parse(pinOne.text);
    	if (a > 0)
    	{
    		a = a - 1;
    		pinOne.text = $"{a}";
    	}
    	b = int.Parse(pinTwo.text);
    	if (b < 10)
    	{
    		b = b + 2;
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
    		c = c - 1;
    		pinThree.text = $"{c}";
    	}
    	finish();
    }

    public void keyButton3_OnPress()
    {
    	a = int.Parse(pinOne.text);
    	if (a > 0)
    	{
    		a = a - 1;
    		pinOne.text = $"{a}";
    	}
    	b = int.Parse(pinTwo.text);
    	if (b < 10)
    	{
    		b = b + 1;
    		pinTwo.text = $"{b}";
    	}
    	c = int.Parse(pinThree.text);
    	if (c < 10)
    	{
    		c = c + 1;
    		pinThree.text = $"{c}";
    	}
    	finish();
    }


}
