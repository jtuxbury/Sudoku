using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {

	//these bools keep track of wether or not a given square can be each number 
	//so if they are true that means that it can still be that number
	public bool one = true, two = true,three= true, four= true, five= true, six= true, seven= true, eight= true, nine= true,solved = false; //A boolean for each number
	public Material oneMat,twoMat,threeMat,fourMat,fiveMat,sixMat,sevenMat,eightMat,nineMat;//The materials for the numbers
	public int value = 0;//The value of the given square
	public Vector2 location;//Where on the puzzle the given square is
	public int zone = 0;//Which 3x3 square the given square is



	// Use this for initialization


	void Start () {
	
		
	}
	
	// Update is called once per frame
	void Update () {
		check ();		
	}

	void check()
		//This method checks to see if there is only one option for the given square to be
	{
		if(one && !two && !three && !four && !five && !six && !seven && !eight && !nine)
		{
			gameObject.renderer.material = oneMat;
			change(1);
		}
		if(!one && two && !three && !four && !five && !six && !seven && !eight && !nine)
		{
			gameObject.renderer.material = twoMat;
			change(2);
		}
		if(!one && !two && three && !four && !five && !six && !seven && !eight && !nine)
		{
			gameObject.renderer.material = threeMat;
			change(3);
		}
		if(!one && !two && !three && four && !five && !six && !seven && !eight && !nine)
		{
			gameObject.renderer.material = fourMat;
			change(4);
		}
		if(!one && !two && !three && !four && five && !six && !seven && !eight && !nine)
		{
			gameObject.renderer.material = fiveMat;
			change(5);
		}
		if(!one && !two && !three && !four && !five && six && !seven && !eight && !nine)
		{
			gameObject.renderer.material = sixMat;
			change(6);
		}
		if(!one && !two && !three && !four && !five && !six && seven && !eight && !nine)
		{
			gameObject.renderer.material = sevenMat;
			change(7);
		}
		if(!one && !two && !three && !four && !five && !six && !seven && eight && !nine)
		{
			gameObject.renderer.material = eightMat;
			change(8);
		}
		if(!one && !two && !three && !four && !five && !six && !seven && !eight && nine)
		{
			gameObject.renderer.material = nineMat;
			change(9);
		}
	}

	public void set(int x)
		//This method does not change a square it just tells the square that it cannot be a given number
	{
		if (x == 1)
			one = false;
		if (x == 2)
			two = false;
		if (x == 3)
			three = false;
		if (x == 4)
			four = false;
		if(x == 5)
			five = false;
		if(x == 6)
			six = false;
		if(x == 7)
			seven = false;
		if(x == 8)
			eight = false;
		if(x == 9)
			nine = false;
		//check ();
	}

	public void change(int x)
		//This method changes the material of the square to reflect the value
	{
		value = x;
		if (x == 1)
		{
			gameObject.renderer.material = oneMat;
			two = false;
			three = false;
			four = false;
			five = false;
			six = false;
			seven = false;
			eight = false;
			nine = false;
		}
		if (x == 2)
		{
			gameObject.renderer.material = twoMat;
			five = false;
			three = false;
			four = false;
			one = false;
			six = false;
			seven = false;
			eight = false;
			nine = false;
		}
		if (x == 3)
		{
			gameObject.renderer.material = threeMat;
			two = false;
			five = false;
			four = false;
			one = false;
			six = false;
			seven = false;
			eight = false;
			nine = false;
		}
		if (x == 4)
		{
			gameObject.renderer.material = fourMat;
			two = false;
			three = false;
			five = false;
			one = false;
			six = false;
			seven = false;
			eight = false;
			nine = false;
		}
		if (x == 5)
		{
			gameObject.renderer.material = fiveMat;
			two = false;
			three = false;
			four = false;
			one = false;
			six = false;
			seven = false;
			eight = false;
			nine = false;
		}
		if (x == 6)
		{
			gameObject.renderer.material = sixMat;
			two = false;
			three = false;
			four = false;
			one = false;
			five = false;
			seven = false;
			eight = false;
			nine = false;
		}
		if (x == 7)
		{
			gameObject.renderer.material = sevenMat;
			two = false;
			three = false;
			four = false;
			one = false;
			six = false;
			five = false;
			eight = false;
			nine = false;
		}
		if (x == 8)
		{
			gameObject.renderer.material = eightMat;
			two = false;
			three = false;
			four = false;
			one = false;
			six = false;
			seven = false;
			five = false;
			nine = false;
		}
		if (x == 9)
		{
			gameObject.renderer.material = nineMat;
			two = false;
			three = false;
			four = false;
			one = false;
			six = false;
			seven = false;
			eight = false;
			five = false;
		}
		solved = true;
	}
}
