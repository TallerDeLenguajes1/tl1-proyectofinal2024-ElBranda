namespace PJ {
    class Tank {
        private int x, y;
        private string name;
        private int compX, compY;
        private int pos=1, compPos;
        private int[][] stage;
        private int cameraX, cameraY; 
        private int life=20;
        private int damage=3;
        public bool dead=false;

        public bool isShooting=false,isHit=false,alreadyDamaged=false;
        private bool alreadyShot=false;
        private int shotPos;
        private int bulletX, bulletY, compBX, compBY;
        private int kills=0;

        public Tank(int x, int y, string name) {
            this.x = x;
            this.y = y;
            this.name = name;
            compX = x;
            compY = y;
        }

        public int getX { get=>x; }

        public int getY { get=>y; }

        public int BulletX { get=>bulletX;set=>bulletX=value; }

        public int BulletY { get=>bulletY;set=>bulletY=value; }

        public string Name { get=>name; set=>name=value; }
        public int Damage { get=>damage;set=>damage=value; }

        public void Print() {
            if (x != compX || y != compY || pos != compPos) {
                Clear();
                
                compX = x;
                compY = y;
                compPos = pos;
            }

            //Console.SetCursorPosition(x+2-name.Length/2,y-1);
            //Console.WriteLine(name);

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

            if (isHit) {
                isHit = false;
                alreadyShot=false;
                isShooting=false;
                Console.SetCursorPosition(compBX, compBY);
                Console.Write(" ");
                Console.SetCursorPosition(bulletX, bulletY);
                Console.Write(" ");
                bulletX=0; bulletY=0;
            }

            if (stage[compBY-cameraY][compBX-cameraX]!=0) {
                alreadyShot=false;
                isShooting=false;
                Console.SetCursorPosition(compBX, compBY);
                Console.Write(" ");
                Console.SetCursorPosition(bulletX, bulletY);
                Console.Write(" ");
                bulletX=0; bulletY=0;
            }
        }

        public int Life { get {return life;} set{life=value;} }
        public int Kills { get {return kills;} set{kills=value;} }
        
        // private async Task HitLife() {
        //     // Aplicar daño
        //     life -= damage;

        //     // Verificar si la vida es menor o igual a cero
        //     if (life <= 0) {
        //         dead = true;
        //     } else {
        //         // Esperar 2 segundos antes de permitir otro golpe
        //         await Task.Delay(2000);
        //     }
        // }

        // public async void Hit() {
        //     await HitLife();
        // }


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