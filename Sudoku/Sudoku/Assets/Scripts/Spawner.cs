using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;

public class Spawner : MonoBehaviour
{
		//public ArrayList squareList = new ArrayList();
		public GameObject[,] squareList = new GameObject[9, 9]; //List of squares
		public int[,] numberList = new int[9, 9]; //List of numbers that correspond to squares
		//StreamReader sr;
		TextReader sr;
		public ArrayList zone1 = new ArrayList ();//These each hold the 3x3 zones of the board
		public ArrayList zone2 = new ArrayList ();
		public ArrayList zone3 = new ArrayList ();
		public ArrayList zone4 = new ArrayList ();
		public ArrayList zone5 = new ArrayList ();
		public ArrayList zone6 = new ArrayList ();
		public ArrayList zone7 = new ArrayList ();
		public ArrayList zone8 = new ArrayList ();
		public ArrayList zone9 = new ArrayList ();
		public ArrayList zones = new ArrayList ();//This holds all the above zones
		public TextAsset file;
		public string string1, string2, string3, string4, string5, string6, string7, string8, string9;
		public string[] stringArray;
		
		
		// Use this for initialization
		void Start ()
		{
				file = Resources.Load ("Puzzle") as TextAsset;
		//This is the file to be used.
		//if you want to use your own file. Right now you have to open it in unity
		//and put the file in the resources folder and change its name to Puzzle
		//MUST BE A .TXT FILE
				
			
				stringArray = file.ToString ().Split ("\n" [0]);
				

				//sr = new StreamReader (Resources.Load ("Puzzle"));

				setup ();
				zones.Add (zone1);
				zones.Add (zone2);
				zones.Add (zone3);
				zones.Add (zone4);
				zones.Add (zone5);
				zones.Add (zone6);
				zones.Add (zone7);
				zones.Add (zone8);
				zones.Add (zone9);
		}
	
		// Update is called once per frame
		void Update ()
		{
				Set ();
				zoneSet2 (); //This thing is atrocious but it is the only way that I was able to get it to solve the puzzle. This makes it so that
				//if there is one aquare in a given zone that can be a value it becomes that value
		}

		void setup ()

		//This method generate the 9 by 9 board and also reads in the file and matches the numbers from the file to where they are supposed to go on the board.
		{

				for (int j = 0; j <= 8; j++) {
						//string of numbers
						//string sr = file.

			string str = stringArray [j];
						for (int i = 0; i <= 16; i += 2) {
			
								GameObject go = (GameObject)Instantiate (Resources.Load ("Square"));
								go.transform.position = new Vector3 (-9 + .5f * (i / 2), 10 - .5f * j, 2);
								Square temp = go.GetComponent<Square> ();
								temp.location = new Vector2 (i / 2, j);
				 


								char c = str [i];

			
								if (c != ',') {				
										numberList [i / 2, j] = (int)char.GetNumericValue (c);
										temp.change (numberList [i / 2, j]);

										squareList [i / 2, j] = go;
								} else {
										numberList [i / 2, j] = 0;
										squareList [i / 2, j] = go;
								}
			
								if (temp.location.x >= 0 && temp.location.x <= 2) {
										if (temp.location.y >= 0 && temp.location.y <= 2) {
												temp.zone = 1;
												zone1.Add (temp);

										} else if (temp.location.y >= 3 && temp.location.y <= 5) {
												temp.zone = 4;
												zone4.Add (temp);
												

										} else if (temp.location.y >= 6 && temp.location.y <= 8) {
												temp.zone = 7;
												zone7.Add (temp);

										}
								} else if (temp.location.x >= 3 && temp.location.x <= 5) {
										if (temp.location.y >= 0 && temp.location.y <= 2) {
												temp.zone = 2;
												zone2.Add (temp);

										} else if (temp.location.y >= 3 && temp.location.y <= 5) {
												temp.zone = 5;
												zone5.Add (temp);

										} else if (temp.location.y >= 6 && temp.location.y <= 8) {
												temp.zone = 8;
												zone8.Add (temp);

										}
								} else if (temp.location.x >= 6 && temp.location.x <= 8) {
										if (temp.location.y >= 0 && temp.location.y <= 2) {
												temp.zone = 3;
												zone3.Add (temp);

										} else if (temp.location.y >= 3 && temp.location.y <= 5) {
												temp.zone = 6;
												zone6.Add (temp);

										} else if (temp.location.y >= 6 && temp.location.y <= 8) {
												temp.zone = 9;
												zone9.Add (temp);

										}
								}
						
						}
				}
		}

		public void zoneSet (int zone, int squareNumber)
		//This looks at the 3 x 3 zones to see if any options can be eliminated
		{			
				foreach (GameObject g in squareList) {						
						Square s = g.GetComponent<Square> ();
						if (s.zone == zone) {
								if (s.solved == false) {
										g.GetComponent<Square> ().set (squareNumber);
								}		
										
										
								
						}

				}
		}

		void zoneSet2 ()
		//As explained above this thing is atrocious and should be killed with fire but it works albeit very inefficiently
		//what this does is go through every zone and then checks every tile to see if it is the only one that can be a given
		//number. If the tile is the only one that can be a given number it will become that number and set all other values 
		//to false
		{
				foreach (ArrayList a in zones) {
						int oneSolved = 0;
						int twoSolved = 0;
						int threeSolved = 0;
						int fourSolved = 0;
						int fiveSolved = 0;
						int sixSolved = 0;
						int sevenSolved = 0;
						int eightSolved = 0;
						int nineSolved = 0;
						foreach (Square s in a) {						
								if (s.one == false) {
										oneSolved++;
										if (oneSolved == 8) {
												foreach (Square s1 in a) {
														if (s1.one == true) {
																s1.change (1);
														}
												}
										}
								}
								if (s.two == false) {
										twoSolved++;
										if (twoSolved == 8) {
												foreach (Square s1 in a) {
														if (s1.two == true) {
																s1.change (2);
														}
												}
										}
								}
								if (s.three == false) {
										threeSolved++;
										if (threeSolved == 8) {
												foreach (Square s1 in a) {
														if (s1.three == true) {
																s1.change (3);
														}
												}
										}
								}
								if (s.four == false) {
										fourSolved++;
										if (fourSolved == 8) {
												foreach (Square s1 in a) {
														if (s1.four == true) {
																s1.change (4);
														}
												}
										}
								}
								if (s.five == false) {
										fiveSolved++;
										if (fiveSolved == 8) {
												foreach (Square s1 in a) {
														if (s1.five == true) {
																s1.change (5);
														}
												}
										}
								}
								if (s.six == false) {
										sixSolved++;
										if (sixSolved == 8) {
												foreach (Square s1 in a) {
														if (s1.six == true) {
																s1.change (6);
														}
												}
										}
								}
								if (s.seven == false) {
										sevenSolved++;
										if (sevenSolved == 8) {
												foreach (Square s1 in a) {
														if (s1.seven == true) {
																s1.change (7);
														}
												}
										}
								}
								if (s.eight == false) {
										eightSolved++;
										if (eightSolved == 8) {
												foreach (Square s1 in a) {
														if (s1.eight == true) {
																s1.change (8);
														}
												}
										}
								}
								if (s.nine == false) {
										nineSolved++;
										if (nineSolved == 8) {
												foreach (Square s1 in a) {
														if (s1.nine == true) {
																s1.change (9);
														}
												}
										}
								}
						}
				}

		}

		public void verticalSet2 (int column, int squareNumber)
		{
				int onesUnsolved = 0;
				int twosUnsolved = 0;
				int threesUnsolved = 0;
				int foursUnsolved = 0;
				int fivesUnsolved = 0;
				int sixsUnsolved = 0;
				int sevensUnsolved = 0;
				int eightsUnsolved = 0;
				int ninesUnsolved = 0;
				if (squareNumber == 1) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [column, i].GetComponent<Square> ();
								if (temp.one == false) {
										onesUnsolved++;
								}
						}
						if (onesUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [column, i].GetComponent<Square> ();
										if (temp.one == true) {
												temp.change (1);
										}
								}
				
						}
				}
				if (squareNumber == 2) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [column, i].GetComponent<Square> ();
								if (temp.two == false) {
										twosUnsolved++;
								}
						}
						if (twosUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [column, i].GetComponent<Square> ();
										if (temp.two == true) {
												temp.change (2);
										}
								}
				
						}
				}
				if (squareNumber == 3) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [column, i].GetComponent<Square> ();
								if (temp.three == false) {
										threesUnsolved++;
								}
						}
			
			
						if (threesUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [column, i].GetComponent<Square> ();
										if (temp.three == true) {
												temp.change (3);
										}
								}
				
						}
				}
				if (squareNumber == 4) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [column, i].GetComponent<Square> ();
								if (temp.four == false) {
										foursUnsolved++;
								}
						}
			
			
						if (foursUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [column, i].GetComponent<Square> ();
										if (temp.four == true) {
												temp.change (4);
										}
								}
				
						}
				}
				if (squareNumber == 5) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [column, i].GetComponent<Square> ();
								if (temp.five == false) {
										fivesUnsolved++;
								}
						}
						if (fivesUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [column, i].GetComponent<Square> ();
										if (temp.five == true) {
												temp.change (5);
										}
								}
				
						}
				}
				if (squareNumber == 6) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [column, i].GetComponent<Square> ();
								if (temp.six == false) {
										sixsUnsolved++;
								}
						}
			
		
						if (sixsUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [column, i].GetComponent<Square> ();
										if (temp.six == true) {
												temp.change (6);
										}
								}
				
						}
				}
				if (squareNumber == 7) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [column, i].GetComponent<Square> ();
								if (temp.seven == false) {
										sevensUnsolved++;
								}
						}
			
		
						if (sevensUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [column, i].GetComponent<Square> ();
										if (temp.seven == true) {
												temp.change (7);
										}
								}
				
						}
				}
				if (squareNumber == 8) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [column, i].GetComponent<Square> ();
								if (temp.eight == false) {
										eightsUnsolved++;
								}
						}
			

						if (eightsUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [column, i].GetComponent<Square> ();
										if (temp.eight == true) {
												temp.change (8);
										}
								}
				
						}
				}
				if (squareNumber == 9) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [column, i].GetComponent<Square> ();
								if (temp.nine == false) {
										ninesUnsolved++;
								}
						}
			
		
						if (ninesUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [column, i].GetComponent<Square> ();
										if (temp.nine == true) {
												temp.change (9);
										}
								}
				
						}
				}
		}

		public void horizontalSet2 (int row, int squareNumber)
		{
				int onesUnsolved = 0;
				int twosUnsolved = 0;
				int threesUnsolved = 0;
				int foursUnsolved = 0;
				int fivesUnsolved = 0;
				int sixsUnsolved = 0;
				int sevensUnsolved = 0;
				int eightsUnsolved = 0;
				int ninesUnsolved = 0;
				if (squareNumber == 1) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [i, row].GetComponent<Square> ();
								if (temp.one == false) {
										onesUnsolved++;
								}
						}
						if (onesUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [i, row].GetComponent<Square> ();
										if (temp.one == true) {
												temp.change (1);
										}
								}
				
						}
				}
				if (squareNumber == 2) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [i, row].GetComponent<Square> ();
								if (temp.two == false) {
										twosUnsolved++;
								}
						}
						if (twosUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [i, row].GetComponent<Square> ();
										if (temp.two == true) {
												temp.change (2);
										}
								}
				
						}
				}
				if (squareNumber == 3) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [i, row].GetComponent<Square> ();
								if (temp.three == false) {
										threesUnsolved++;
								}
						}
			

						if (threesUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [i, row].GetComponent<Square> ();
										if (temp.three == true) {
												temp.change (3);
										}
								}
				
						}
				}
				if (squareNumber == 4) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [i, row].GetComponent<Square> ();
								if (temp.four == false) {
										foursUnsolved++;
								}
						}
			

						if (foursUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [i, row].GetComponent<Square> ();
										if (temp.four == true) {
												temp.change (4);
										}
								}
				
						}
				}
				if (squareNumber == 5) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [i, row].GetComponent<Square> ();
								if (temp.five == false) {
										fivesUnsolved++;
								}
						}
						if (fivesUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [i, row].GetComponent<Square> ();
										if (temp.five == true) {
												temp.change (5);
										}
								}

						}
				}
				if (squareNumber == 6) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [i, row].GetComponent<Square> ();
								if (temp.six == false) {
										sixsUnsolved++;
								}
						}
			
						
						if (sixsUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [i, row].GetComponent<Square> ();
										if (temp.six == true) {
												temp.change (6);
										}
								}
				
						}
				}
				if (squareNumber == 7) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [i, row].GetComponent<Square> ();
								if (temp.seven == false) {
										sevensUnsolved++;
								}
						}
			
						
						if (sevensUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [i, row].GetComponent<Square> ();
										if (temp.seven == true) {
												temp.change (7);
										}
								}
				
						}
				}
				if (squareNumber == 8) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [i, row].GetComponent<Square> ();
								if (temp.eight == false) {
										eightsUnsolved++;
								}
						}
			
						
						if (eightsUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [i, row].GetComponent<Square> ();
										if (temp.eight == true) {
												temp.change (8);
										}
								}
				
						}
				}
				if (squareNumber == 9) {
						for (int i = 0; i <= 8; i++) {
								Square temp = squareList [i, row].GetComponent<Square> ();
								if (temp.nine == false) {
										ninesUnsolved++;
								}
						}
			
					
						if (ninesUnsolved == 8) {
								for (int i = 0; i<= 8; i++) {
										Square temp = squareList [i, row].GetComponent<Square> ();
										if (temp.nine == true) {
												temp.change (9);
										}
								}
				
						}
				}
		}

		public	void horizontalSet (int location, int squareNumber)
		//This looks at the row to see if any option can be eliminated
		{

				for (int i = 0; i <= 8; i++) {
						Square temp = squareList [i, location].GetComponent<Square> ();
						if (temp.solved == false) {
								temp.set (squareNumber);
						}
				}
		}

		public	void verticalSet (int location, int squareNumber)
		//This looks at the column to see if any options can be eliminated
		{
				for (int i = 0; i <= 8; i++) {
						Square temp = squareList [location, i].GetComponent<Square> ();
						if (temp.solved == false) {
								temp.set (squareNumber);
						}
				}
		}

		public void Set ()
		//This calls all of the methods that eliminate options for the columns, rows and zones
		{
				for (int i = 0; i <= 8; i++) {
						for (int j = 0; j <= 8; j++) {
								Square temp = squareList [j, i].GetComponent<Square> ();
								//if (temp.solved) 
								{
										horizontalSet (i, temp.value);
										verticalSet (j, temp.value);
										zoneSet (temp.zone, temp.value);
										horizontalSet2 (8, temp.value);
										verticalSet2 (8, temp.value);
										
								}
						}
			
				}
		}


}
