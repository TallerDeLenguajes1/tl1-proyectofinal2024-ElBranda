using System.Security.Cryptography.X509Certificates;

namespace Stage {
    class Table {
        private int[][] space;
        private int m, n, x, y;
        private int pivotX=3, pivotY=3;

        public Table(int[][] space, int m, int n, int x, int y) {
            this.space = space;
            this.m = m;
            this.n = n;
            this.x = x;
            this.y = y;
        }

        public int PivotX { get => x; }

        public int PivotY { get => y; }

        public int LimitX { get => x+m; }

        public int LimitY { get => y+n; }

        public void Print() {
            for (int i = pivotX; i < pivotX+20 && i < space.Length && pivotX>=0; i++) {
                for (int j = pivotY; j < pivotY+20&& j < space[0].Length&& pivotY>=0; j++) {
                    Console.SetCursorPosition(j+x,i+y);
                    
                    if (space[i][j] == 1) {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("█");
                    } else if (space[i][j] == 2) {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("█");
                    } else if (space[i][j] == 3) {
                        Console.Write("C");
                    }
                }

            }
        }

        public void MoveUp() {
            for (int i = pivotX; i < pivotX+20 ; i++) {
                for (int j = pivotY; j < pivotY+20 ; j++) {
                    Console.SetCursorPosition(j+x,i+y);
                    
                    Console.Write(" ");
                }

            }

            if (pivotX>0) pivotX--;
        }

        public void MoveDwn() {
            for (int i = pivotX; i < pivotX+20; i++) {
                for (int j = pivotY; j < pivotY+20; j++) {
                    Console.SetCursorPosition(j+x,i+y);
                    
                    Console.Write(" ");
                }

            }

            if (pivotX < space.Length-1) pivotX++;
        }

        
        public void MoveLft() {
            for (int i = pivotX; i < pivotX+20; i++) {
                for (int j = pivotY; j < pivotY+20; j++) {
                    Console.SetCursorPosition(j+x,i+y);
                    
                    Console.Write(" ");
                }

            }
            if (pivotY > 0) pivotY--;
        }

        public void MoveRgt() {
            for (int i = pivotX; i < pivotX+20; i++) {
                for (int j = pivotY; j < pivotY+20; j++) {
                    Console.SetCursorPosition(j+x,i+y);
                    
                    Console.Write(" ");
                }

            }
            if (pivotY < space[0].Length-1) pivotY++;
        }
    }
}