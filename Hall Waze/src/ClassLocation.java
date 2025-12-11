import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;
import java.util.PriorityQueue;
import java.util.Comparator;

public class ClassLocation {
    
    //constants
    final static int TRIED = 2;
    final static int PATH = 3;
    
    //test grid
    private static int[][] locationsDownstairs = new int[100][200];
    private static int locationsUpstairs[][] = new int[50][102];
	private static int roomUpstairs;

    //main method
    public static void main(String args[]) {
        for (int i = 30; i < 32; i++) {
for (int j = 65; j < 190; j++) {
locationsDownstairs[i][j] = 1;
}
}
//2nd street
for (int i = 42; i < 44; i++) {
for (int j = 10; j < 160; j++) {
locationsDownstairs[i][j] = 1;
}
}
//1st street vertical
for (int i = 30; i < 50; i++) {
for (int j = 60; j < 62; j++) {
locationsDownstairs[i][j] = 1;
}
}
//1st street curve
int jp = 60;
for (int i = 50; i < 59; i++) {
for (int j = jp; j < jp+2; j++) {
locationsDownstairs[i][j] = 1;
}
jp += 2;
}
//1st street horizontal
for (int i = 57; i < 59; i++) {
for (int j = jp; j < 160; j++) {
locationsDownstairs[i][j] = 1;
}
}
//Antioch Street
for (int i = 30; i < 59; i++) {
for (int j = 100; j < 102; j++) {
locationsDownstairs[i][j] = 1;
}
}
//Bristow Street
for (int i = 42; i < 59; i++) {
for (int j = 119; j < 121; j++) {
locationsDownstairs[i][j] = 1;
}
}
//Catharpin Street
for (int i = 42; i < 59; i++) {
for (int j = 139; j < 141; j++) {
locationsDownstairs[i][j] += 1;
}
}
//Dominion Valley
for (int i = 30; i < 59; i++) {
for (int j = 158; j < 160; j++) {
locationsDownstairs[i][j] += 1;
}
}
//Sidewalk Outside
for (int i = 50; i < 61; i++) {
for (int j = 60; j < 62; j++) {
locationsDownstairs[i][j] = 1;
}
}
for (int i = 61; i < 63; i++) {
for (int j = 60; j < 150; j++) {
locationsDownstairs[i][j] = 1;
}
}
for (int i = 62; i > 25; i--) {
for (int j = 20; j < 22; j++) {
locationsDownstairs[i][j] = 1;
}
}
for (int i = 25; i < 27; i++) {
for (int j = 20; j < 165; j++) {
locationsDownstairs[i][j] = 1;
}
}
for (int i = 61; i < 63; i++) {
for (int j = 22; j < 60; j++) {
locationsDownstairs[i][j] = 1;
}
}
//Trailer 15
for (int i = 51; i < 54; i++) {
for (int j = 162; j < 164; j++) {
locationsDownstairs[i][j] = 15;
}
}
//Trailer 7
for (int i = 48; i < 51; i++) {
for (int j = 164; j < 166; j++) {
locationsDownstairs[i][j] = 7;
}
}
//Trailer 6
for (int i = 44; i < 47; i++) {
for (int j = 164; j < 166; j++) {
locationsDownstairs[i][j] = 6;
}
}
//Trailer 14
for (int i = 64; i < 66; i++) {
for (int j = 150; j < 153; j++) {
locationsDownstairs[i][j] = 14;
}
}
//Trailer 13
for (int i = 61; i < 63; i++) {
for (int j = 150; j < 153; j++) {
locationsDownstairs[i][j] = 13;
}
}
//Trailer 12
for (int i = 58; i < 60; i++) {
for (int j = 150; j < 153; j++) {
locationsDownstairs[i][j] = 12;
}
}
//Trailer 11
for (int i = 55; i < 57; i++) {
for (int j = 150; j < 153; j++) {
locationsDownstairs[i][j] = 11;
}
}
//Trailer 10
for (int i = 24; i < 26; i++) {
for (int j = 12; j < 15; j++) {
locationsDownstairs[i][j] = 10;
}
}
//Trailer 9
for (int i = 28; i < 31; i++) {
for (int j = 24; j < 26; j++) {
locationsDownstairs[i][j] = 9;
}
}
//Trailer 8
for (int i = 29; i < 32; i++) {
for (int j = 28; j < 30; j++) {
locationsDownstairs[i][j] = 8;
}
}
//Trailer 5
for (int i = 20; i < 23; i++) {
for (int j = 163; j < 165; j++) {
locationsDownstairs[i][j] = 5;
}
}
//Trailer 4
for (int i = 18; i < 21; i++) {
for (int j = 160; j < 162; j++) {
locationsDownstairs[i][j] = 4;
}
}
//Trailer 3
for (int i = 18; i < 21; i++) {
for (int j = 157; j < 159; j++) {
locationsDownstairs[i][j] = 3;
}
}
//Trailer 1
for (int i = 19; i < 22; i++) {
for (int j = 154; j < 156; j++) {
locationsDownstairs[i][j] = 1;
}
}
//Trailer 2
for (int i = 15; i < 18; i++) {
for (int j = 154; j < 156; j++) {
locationsDownstairs[i][j] = 2;
}
}
//Modular Classes
for (int i = 32; i < 36; i++) {
for (int j = 5; j < 11; j++) {
locationsDownstairs[i][j] = 16;
}
}
//Classrooms
//on first street
locationsDownstairs[58][102] = 1109;
locationsDownstairs[58][119] = 1110;
locationsDownstairs[58][140] = 1126;
locationsDownstairs[58][150] = 1127;
locationsDownstairs[58][100] = 1000;
//first street stairwell near 1000
locationsDownstairs[58][101] = 3000; //staircases 3000-3002 bathrooms 4000-
//on antioch
locationsDownstairs[43][100] = 1101;
locationsDownstairs[44][100] = 1102;
locationsDownstairs[45][100] = 1103;
locationsDownstairs[46][100] = 1104;
locationsDownstairs[42][100] = 1149;
locationsDownstairs[41][100] = 1150;
locationsDownstairs[40][100] = 1151;
locationsDownstairs[38][100] = 1153;
locationsDownstairs[43][102] = 1105;
locationsDownstairs[44][102] = 1106;
locationsDownstairs[45][102] = 1107;
locationsDownstairs[46][102] = 1108;
locationsDownstairs[40][102] = 1152;
locationsDownstairs[39][102] = 1154;
locationsDownstairs[38][102] = 1155;
locationsDownstairs[37][102] = 1156;
//on bristow
locationsDownstairs[43][119] = 1113;
locationsDownstairs[44][119] = 1112;
locationsDownstairs[45][119] = 1111;
locationsDownstairs[43][121] = 1114;
locationsDownstairs[44][121] = 1115;
locationsDownstairs[45][121] = 1116;
locationsDownstairs[46][121] = 1117;
//bathroom
locationsDownstairs[46][119] = 3001;
//on catharpin
locationsDownstairs[43][139] = 1121;
locationsDownstairs[44][139] = 1120;
locationsDownstairs[45][139] = 1119;
locationsDownstairs[46][139] = 1118;
locationsDownstairs[43][141] = 1122;
locationsDownstairs[44][141] = 1123;
locationsDownstairs[45][141] = 1124;
locationsDownstairs[46][141] = 1125;
//on dv
locationsDownstairs[43][158] = 1131;
locationsDownstairs[44][158] = 1130;
locationsDownstairs[45][158] = 1129;
locationsDownstairs[46][158] = 1128;
locationsDownstairs[45][160] = 1132;
locationsDownstairs[42][160] = 1134;
//secret stairwell
locationsDownstairs[41][160] = 3001;
locationsDownstairs[40][160] = 1135;
//satellite office
locationsDownstairs[39][160] = 1136;
locationsDownstairs[40][158] = 1140;
//teacher bathroom
locationsDownstairs[39][158] = 3002;
//on second street
locationsDownstairs[42][119] = 1147;
locationsDownstairs[42][121] = 1146;
locationsDownstairs[39][120] = 1145;
locationsDownstairs[40][135] = 1144;
locationsDownstairs[42][139] = 1143;
locationsDownstairs[42][149] = 1142;
locationsDownstairs[42][158] = 1141;
//main stairwell
locationsDownstairs[42][135] = 3002;
//senior courtyard
locationsDownstairs[46][98] = 3004;
locationsDownstairs[43][98] = 3004;
//library
locationsDownstairs[46][98] = 3005;
locationsDownstairs[43][98] = 3005;

//on third street
locationsDownstairs[30][160] = 1161;
locationsDownstairs[30][159] = 1162;
locationsDownstairs[30][158] = 1163;
locationsDownstairs[30][157] = 1164;
locationsDownstairs[32][159] = 1158;
//bathroom
locationsDownstairs[32][158] = 3001;
//enclosed cafeteria
locationsDownstairs[32][157] = 3003;
//kitchen
locationsDownstairs[32][150] = 1200;
//commons
locationsDownstairs[32][145] = 3006;
locationsDownstairs[42][145] = 3006;
//gym classes
locationsDownstairs[30][150] = 1303;
locationsDownstairs[30][148] = 1302;
locationsDownstairs[30][144] = 1301;
//auditorium
locationsDownstairs[32][146] = 1400;
//music hallway
locationsDownstairs[42][144] = 1404;
locationsDownstairs[42][143] = 1406;
locationsDownstairs[42][140] = 1405;
//corner stairwell
locationsDownstairs[58][160] = 3003;


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
        
        ClassLocation test = new ClassLocation(locationsDownstairs, 1109, locationsDownstairs, 1147);

        test.solve();
        System.out.println(test.toString());
      
    }
    
    //fields
    private int[][] startGrid;
    private int startHeight;
    private int startWidth;
    private int[][] startMap;
    private int startLocation;
    
    int[][] endGrid;
    private int endHeight;
    private int endWidth;
    private int[][] endMap;
    private int endLocation;
    
    private List<Node> paths;
    
    //constructor
    public ClassLocation (int[][] startGrid, int startLocation, int[][] endGrid, int endLocation) {
        this.startGrid = startGrid;
        this.startHeight = startGrid.length;
        this.startWidth = startGrid[0].length;
        this.startMap = new int[startHeight][startWidth];
        this.startLocation = startLocation;
        
        this.endGrid = endGrid;
        this.endHeight = endGrid.length;
        this.endWidth = endGrid[0].length;
        this.endMap = new int[endHeight][endWidth];
        this.endLocation = endLocation;
        
        paths = new ArrayList<Node>();
    }
    
    //methods
    public void solve() {
        int[] startCoordinates = findCoordinates(startGrid, startLocation);
        Node start = new Node(startCoordinates[0], startCoordinates[1], 0, null);
        Queue<Node> queue = new PriorityQueue<>();
        queue.add(start);
        if (startGrid != endGrid) {
            int e = endLocation;
            endLocation = closestStaircase(startGrid, startLocation);
            traverse(startMap, startGrid, queue);
            Node n = paths.get(paths.size() - 1);
            while (n != null) {
            	startMap[n.y][n.x] = PATH;
            	n = n.parent;
            }
            
            paths = new ArrayList<Node>();
            queue = new PriorityQueue<>();
            startLocation = endLocation;
            startCoordinates = findCoordinates(endGrid, startLocation);
            start = new Node(startCoordinates[0], startCoordinates[1], 0, null);
            queue.add(start);
            endLocation = e;
        }
        traverse(endMap, endGrid, queue);
        Node n = paths.get(paths.size() - 1);
        while (n != null) {
        	endMap[n.y][n.x] = PATH;
        	n = n.parent;
        }
    }
    private int[] findCoordinates(int[][] grid, int room) {
    	int[] coordinates = new int[2];
        for (int row = 0; row < grid.length; row++) {
            for (int column = 0; column < grid[0].length; column++) {
                if (grid[row][column] == room) {
                    coordinates[0] = column;
                    coordinates[1] = row;
                    return coordinates;
                }
            }
        }
        return coordinates;
    }
    private int closestStaircase(int[][] grid, int location) {
        int[] coordinates = findCoordinates(grid, location);
        int[] one = findCoordinates(grid, 3000);
        int[] stair1 = {one[0], one[1], 3000};
        int[] two = findCoordinates(grid, 3001);
        int[] stair2 = {two[0], two[1], 3001};
        int[] three = findCoordinates(grid, 3002);
        int[] stair3 = {three[0], three[1], 3002};
        int[] four = findCoordinates(grid, 3003);
        int[] stair4 = {four[0], four[1], 3003};
        ArrayList<int[]> stairs = new ArrayList<>();
        stairs.add(stair1);
        stairs.add(stair2);
        stairs.add(stair3);
        stairs.add(stair4);
        int[] min = stair1;
        for (int i = 0; i < 4; i++) {
            if (distance(coordinates[0], coordinates[1], stairs.get(i)[0], stairs.get(i)[1]) < distance(coordinates[0], coordinates[1], min[0], min[1])) {
                min = stairs.get(i);
            }
        }
        return min[2];
    }
    private double distance(int x1, int y1, int x2, int y2) {
    	return Math.sqrt(Math.pow((x2 - x1), 2) + Math.pow((y2 - y1), 2));
    }
    private boolean traverse(int[][] map, int[][] grid, Queue<Node> q) {
        if (q.isEmpty()) {
            return false;
        }
        Node polled = q.poll();
        paths.add(polled);
        if (isEnd(polled)) {
            map[polled.y][polled.x] = PATH;
            return true;
        }
        else {
        	map[polled.y][polled.x] = TRIED;
            List<Node> neighbors = addNeighbors(map, grid, polled);
            q.addAll(neighbors);
            return traverse(map, grid, q);
            /*
            boolean r;
            if (r = traverse(map, grid, q, print))
            	map[polled.y][polled.x] = PATH;
            return r;
            */
            //print[polled.y][polled.x] = TRIED;
        }
        /*while (!q.isEmpty()) {
            Node polled = q.poll();
            if (isEnd(polled)) {
                map[polled.y][polled.x] = PATH;
                return true;
            }
            else {
                map[polled.y][polled.x] = TRIED;
                List<Node> neighbors = addNeighbors(polled);
                q.addAll(neighbors);
            }
        }
        return false;*/
    }
    
    private List<Node> addNeighbors(int[][] map, int[][] grid, Node n) {
        List<Node> neighbors = new LinkedList<>();
        Node up = new Node(n.x, n.y - 1, n.dis + 1, n);
        Node down = new Node(n.x, n.y + 1, n.dis + 1, n);
        Node left = new Node(n.x - 1, n.y, n.dis + 1, n);
        Node right = new Node(n.x + 1, n.y, n.dis + 1, n);
        if (isValid(map, grid, up) || isEnd(up)) {
            neighbors.add(up);
        }
        if (isValid(map, grid, down) || isEnd(down)) {
            neighbors.add(down);
        }
        if (isValid(map, grid, left) || isEnd(left)) {
            neighbors.add(left);
        }
        if (isValid(map, grid, right) || isEnd(right)) {
            neighbors.add(right);
        }
        return neighbors;
    }
    
    private boolean isEnd(Node n) {
        int[] endCoordinates = findCoordinates(endGrid, endLocation);
        return n.y == endCoordinates[1] && n.x == endCoordinates[0];
    }
    private boolean isValid(int[][] map, int[][] grid, Node n) {
        return (inRange(grid, n) && isOpen(grid, n) && !isTried(map, n));
    }
    private boolean inRange(int[][] grid, Node n) {
        return inHeight(grid, n.y) && inWidth(grid, n.x);
    }
    private boolean inHeight(int[][] grid, int y) {
        return y >= 0 && y < grid.length;
    }
    private boolean inWidth(int[][] grid, int x) {
        return x >= 0 && x < grid[0].length;
    }
    private boolean isOpen(int[][] grid, Node n) {
        return grid[n.y][n.x] == 1;
    }
    private boolean isTried(int[][] map, Node n) {
        return map[n.y][n.x] == TRIED;
    }
    public String toString() {
        String s = "";
        for (int [] row : startMap) {
            for (int num : row) {
                s += num;
            }
            s += "\n";
        }
        if (startMap != endMap) {
            for (int [] row : endMap) {
                for (int num : row) {
                    s += num;
                }
                s += "\n";
            }
        }
        return s;
    }
    
    class Node implements Comparable<Node> {
        int x;
        int y;
        int dis;
        Node parent;
        
        Node(int x, int y, int dis, Node parent) {
            this.x = x;
            this.y = y;
            this.dis = dis;
            this.parent = parent;
        }
        
        public int compareTo(Node n) {
            return this.dis - n.dis;
        }
        
    }
}


/* notes
-clarify map to startMap and endMap
*/