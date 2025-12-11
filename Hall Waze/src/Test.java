
public class Test {
	public static void main(String args[]) {
		int[][] locationsUpstairs = new int[50][102];
		locationsUpstairs[2][0] = 2122;
		locationsUpstairs[2][3] = 2121;
		locationsUpstairs[2][29] = 2119;
		locationsUpstairs[2][34] = 2118;
		locationsUpstairs[2][47] = 2130;
		locationsUpstairs[2][51] = 2117;
		locationsUpstairs[2][78] = 2114;
		locationsUpstairs[2][83] = 2113;
		
		//Left Column
		locationsUpstairs[4][0] = 2133;
		locationsUpstairs[8][0] = 2123;
		locationsUpstairs[13][0] = 2124;
		locationsUpstairs[18][0] = 2134;
		locationsUpstairs[25][1] = 2135;
		locationsUpstairs[32][0] = 2125;
		locationsUpstairs[39][0] = 2126;
		locationsUpstairs[45][0] = 2127;
		locationsUpstairs[49][0] = 2128;
		
		//Bottom Row
		locationsUpstairs[4][0] = 2100;
		locationsUpstairs[8][0] = 2101;
		locationsUpstairs[13][0] = 2102;
		locationsUpstairs[18][0] = 2103;
		locationsUpstairs[25][1] = 2104;
		locationsUpstairs[32][0] = 2105;
		locationsUpstairs[39][0] = 2106;
		locationsUpstairs[45][0] = 2107;
		
		//Right Column
		locationsUpstairs[5][98] = 2112;
		locationsUpstairs[24][98] = 2111;
		locationsUpstairs[32][98] = 2110;
		locationsUpstairs[37][98] = 2109;
		locationsUpstairs[43][98] = 2108;
		locationsUpstairs[49][98] = 2129;
		
		//Middle Left
		locationsUpstairs[13][6] = 2226;
		locationsUpstairs[13][8] = 2225;
		locationsUpstairs[16][6] = 2200;
		locationsUpstairs[46][6] = 2201;
		locationsUpstairs[46][34] = 2202;
		locationsUpstairs[38][34] = 2213;
		locationsUpstairs[13][34] = 2203;
		
		//Middle
		locationsUpstairs[18][40] = 2204;
		locationsUpstairs[36][40] = 2214;
		locationsUpstairs[38][40] = 2205;
		locationsUpstairs[46][40] = 2218;
		locationsUpstairs[46][40] = 2220;
		locationsUpstairs[46][40] = 2219;
		locationsUpstairs[38][64] = 2206;
		locationsUpstairs[36][64] = 2215;
		locationsUpstairs[18][64] = 2207;
		
		//Middle Right
		locationsUpstairs[13][70] = 2224;
		locationsUpstairs[13][22] = 2223;
		locationsUpstairs[13][20] = 2222;
		locationsUpstairs[13][94] = 2221;
		locationsUpstairs[36][70] = 2208;
		locationsUpstairs[38][94] = 2211;
		locationsUpstairs[38][70] = 2217;
		locationsUpstairs[38][94] = 2216;
		locationsUpstairs[46][70] = 2209;
		locationsUpstairs[46][94] = 2210;
				
        //Main Staircase
		locationsUpstairs[11][50] = 3002;
		
		//Secret Staircase
		locationsUpstairs[5][83] = 3001;
		
		//Bottom Right Staircase
		locationsUpstairs[46][83] = 3003;
		
		//Bottom Left Staircase
		locationsUpstairs[46][3] = 3000;

		//5th Street
		for (int i = 12; i < 14; i++) 
		{ 
			for (int j = 2; j < 98; j++) 
			{
				locationsUpstairs[i][j] = 1;
			} 
		}
		  
		//4th Street 
		for (int i = 48; i < 50; i++)
		{ 
			for (int j = 2; j < 98; j++)
			{
				locationsUpstairs[i][j] = 1;
			}
		}
		  
		//Evergreen 
		for (int i = 2; i < 48; i++) 
		{ 
			for (int j = 2; j < 4; j++) 
			{ 
				locationsUpstairs[i][j] = 1;
			}
		}

		//Freedom 
		for (int i = 0; i < 48; i++)
		{
			for (int j = 36; j < 38; j++)
			{
				locationsUpstairs[i][j] = 1;
			}
		}
		  
		//Gainesville
		for (int i = 0; i < 48; i++)
		{
			for (int j = 66; j < 68; j++)
			{
				locationsUpstairs[i][j] = 1;
			}
		}
		  
		//Haymarket
		for (int i = 0; i < 48; i++)
		{
			for (int j = 96; j < 98; j++)
			{
				locationsUpstairs[i][j] = 1;
			}
		}
		  
		//CASIIT Hallway
		for (int i = 0 ; i < 2; i++)
		{
			for (int j = 36; j < 68; j++)
			{
				locationsUpstairs[i][j] = 1;
			}
		}
		
		for (int i = 0; i < locationsUpstairs.length; i++) {
			for (int j = 0; j < locationsUpstairs[0].length; j++) {
				System.out.print(locationsUpstairs[i][j] + "\t");
			}
			System.out.println();
		}
	}

}
