namespace PJ {
    class Player {
        private int x, y;
        private int compX, compY;
        private int pos=1, compPos;
        private int[][] stage;
        private int pivotX, pivotY, limitX, limitY;
        

        public Player(int x, int y) {
            this.x = x;
            this.y = y;
            compX = x;
            compY = y;
        }

        public void Print() {
            if (x != compX || y != compY || pos != compPos) {
                Console.SetCursorPosition(compX,compY);
                Console.WriteLine("     ");
                Console.SetCursorPosition(compX,compY+1);
                Console.WriteLine("     ");
                Console.SetCursorPosition(compX,compY+2);
                Console.WriteLine("     ");
                
                compX = x;
                compY = y;
                compPos = pos;
            }

            if (pos == 1) {
                Console.SetCursorPosition(x,y);
                Console.WriteLine(" _^_ ");
                Console.SetCursorPosition(x,y+1);
                Console.WriteLine("|___|");
                Console.SetCursorPosition(x,y+2);
                Console.WriteLine("[OOO]");
            } else if (pos == 2) {
                Console.SetCursorPosition(x,y);
                Console.WriteLine(" ___ ");
                Console.SetCursorPosition(x,y+1);
                Console.WriteLine("|_O_|");
                Console.SetCursorPosition(x,y+2);
                Console.WriteLine("[OOO]");
            } else if (pos == 3) {
                Console.SetCursorPosition(x,y);
                Console.WriteLine(" __  ");
                Console.SetCursorPosition(x,y+1);
                Console.WriteLine("|__|=");
                Console.SetCursorPosition(x,y+2);
                Console.WriteLine("[OOO]");
            } else {
                Console.SetCursorPosition(x,y);
                Console.WriteLine("  __ ");
                Console.SetCursorPosition(x,y+1);
                Console.WriteLine("=|__|");
                Console.SetCursorPosition(x,y+2);
                Console.WriteLine("[OOO]");
            }
        }

        public void GunUp() {
            pos=1;
        }

        public void GunDwn() {
            pos=2;
        }

        public void GunRgt() {
            pos=3;
        }

        public void GunLft() {
            pos=4;
        }

        public void MoveUp() {
            if (stage[y-pivotY-1][x-pivotX] == 0) y--;
        }

        public void MoveDwn() {
            if (stage[y-pivotY+3][x-pivotX] == 0) y++;
        }

        public void MoveRgt() {
            if (stage[y-pivotY][x-pivotX+3] == 0) x++;
        }

        public void MoveLft() {
            if (stage[y-pivotY][x-pivotX-1] == 0) x--;
        }

        public void SetLimits(int[][] stage, int pivotX, int pivotY, int limitX, int limitY) {
            this.stage = stage;
            this.pivotX = pivotX;
            this.pivotY = pivotY;
            this.limitX = limitX;
            this.limitY = limitY;
        }
    }

    class Tank {
        private int x, y;
        private int compX, compY;
        private int pos=1, compPos;
        private int[][] stage;
        private int cameraX, cameraY; 
        private int life=20;
        public bool dead=false;

        public bool isShooting=false;
        private bool alreadyShot=false;
        private int shotPos;
        private int bulletX, bulletY, compBX, compBY;

        public Tank(int x, int y) {
            this.x = x;
            this.y = y;
            compX = x;
            compY = y;
        }

        public int getX { get=>x; }

        public int getY { get=>y; }

        public int getBulletX { get=>bulletX; }

        public int getBulletY { get=>bulletY; }

        public void Print() {
            if (x != compX || y != compY || pos != compPos) {
                Clear();
                
                compX = x;
                compY = y;
                compPos = pos;
            }

            if (pos == 1) {
                Console.SetCursorPosition(x,y);
                Console.WriteLine(" _^_ ");
                Console.SetCursorPosition(x,y+1);
                Console.WriteLine("|___|");
                Console.SetCursorPosition(x,y+2);
                Console.WriteLine("[OOO]");
            } else if (pos == 2) {
                Console.SetCursorPosition(x,y);
                Console.WriteLine(" ___ ");
                Console.SetCursorPosition(x,y+1);
                Console.WriteLine("|_O_|");
                Console.SetCursorPosition(x,y+2);
                Console.WriteLine("[OOO]");
            } else if (pos == 3) {
                Console.SetCursorPosition(x,y);
                Console.WriteLine(" __  ");
                Console.SetCursorPosition(x,y+1);
                Console.WriteLine("|__|=");
                Console.SetCursorPosition(x,y+2);
                Console.WriteLine("[OOO]");
            } else {
                Console.SetCursorPosition(x,y);
                Console.WriteLine("  __ ");
                Console.SetCursorPosition(x,y+1);
                Console.WriteLine("=|__|");
                Console.SetCursorPosition(x,y+2);
                Console.WriteLine("[OOO]");
            }
        }

        public void Clear() {
            Console.SetCursorPosition(compX,compY);
            Console.WriteLine("     ");
            Console.SetCursorPosition(compX,compY+1);
            Console.WriteLine("     ");
            Console.SetCursorPosition(compX,compY+2);
            Console.WriteLine("     ");
        }

        public void Shot() {
            if (!alreadyShot) {
                bulletX = x;
                bulletY = y;
                shotPos = pos;
                if (shotPos==1) {
                    bulletX+=2;
                } else if (shotPos==2) {
                    bulletX+=2;
                    bulletY+=1;
                } else if (shotPos==3) {
                    bulletX+=3;
                    bulletY+=1;
                } else {
                    bulletX+=2;
                    bulletY+=1;
                }
                alreadyShot = true;
            }

            Console.SetCursorPosition(compBX, compBY);
            Console.Write(" ");
            Console.SetCursorPosition(bulletX, bulletY);
            Console.Write("O");

            compBX=bulletX;
            compBY=bulletY;

            if (shotPos==1) bulletY--;
            else if (shotPos==2) bulletY++;
            else if (shotPos==3) bulletX++;
            else bulletX--;

            if (stage[bulletY-cameraY][bulletX-cameraX]!=0) {
                alreadyShot=false;
                isShooting=false;
                Console.SetCursorPosition(compBX, compBY);
                Console.Write(" ");
            }
        }

        public int setLife { set{value=life;} }

        public void Hit() {
            life-=3;

            if (life <= 0) dead=true;
        }


        public void GunUp() {
            pos=1;
        }

        public void GunDwn() {
            pos=2;
        }

        public void GunRgt() {
            pos=3;
        }

        public void GunLft() {
            pos=4;
        }

        public void MoveUp() {
            if (stage[y-cameraY-1][x-cameraX] == 0 &&
                stage[y-cameraY-1][x-cameraX+1] == 0 &&
                stage[y-cameraY-1][x-cameraX+2] == 0 &&
                stage[y-cameraY-1][x-cameraX+3] == 0 &&
                stage[y-cameraY-1][x-cameraX+4] == 0) y--;
        }

        public void MoveDwn() {
            if (stage[y-cameraY+3][x-cameraX] == 0 &&
                stage[y-cameraY+3][x-cameraX+1] == 0 &&
                stage[y-cameraY+3][x-cameraX+2] == 0 &&
                stage[y-cameraY+3][x-cameraX+3] == 0 &&
                stage[y-cameraY+3][x-cameraX+4] == 0) y++;
        }

        public void MoveRgt() {
            if (stage[y-cameraY][x-cameraX+5] == 0 &&
                stage[y-cameraY+1][x-cameraX+5] == 0 &&
                stage[y-cameraY+2][x-cameraX+5] == 0) x++;
        }

        public void MoveLft() {
            if (stage[y-cameraY][x-cameraX-1] == 0 &&
                stage[y-cameraY+1][x-cameraX-1] == 0 &&
                stage[y-cameraY+2][x-cameraX-1] == 0) x--;
        }



        public void SetLimits(int[][] stage, int cameraX, int cameraY) {
            this.stage = stage;
            this.cameraX = cameraX;
            this.cameraY = cameraY;
        }
    }
}