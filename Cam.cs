using PJ;

namespace Cam {
    class Camera {
        private int[][] map;
        private Tank player;
        private Tank[] enemies;
        private int m, n, x, y;
        private int takerX, takerY;
        private const int range = 10;

        public Camera(int[][] map, Tank player, Tank[] enemies, int x, int y) {
            this.map = map;
            this.player = player;
            this.enemies = enemies;
            this.x = x;
            this.y = y;
        }

        public void Show() {
            Clear();
            for (int i = Math.Max(0, player.getY - y - range); i < Math.Min(map.Length, player.getY - y + range + 5); i++) {
                for (int j = Math.Max(0, player.getX - x - range); j < Math.Min(map[0].Length, player.getX - x + range + 5); j++) {
                    Console.SetCursorPosition(0, 0);
                    //Console.WriteLine("                                                                  \n                                                                        \n                                                 ");
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("X: "+map.Length+" Y: "+map[0].Length+"\nPlayerX: "+player.getX+" PlayerY: "+player.getY+"\ni: "+i+" j: "+j);

                    Console.SetCursorPosition(10,0);
                    Console.WriteLine();

                    Console.SetCursorPosition(j+x,i+y);
                    if (map[i][j] == 1) {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("█");
                    } else if (map[i][j] == 2) {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("█");
                    } else if (map[i][j] == 3) {
                        Console.Write("C");
                    }

                    for (int k = 0; k < enemies.Length; k++) {
                        if (enemies[k].getX == j && enemies[k].getY == i && !enemies[k].dead) {
                            enemies[k].Print();
                        }
                    }
                }

            }

            takerX = player.getX;
            takerY = player.getY;
        }

        public void Clear() {
            if (takerX == player.getX && takerY == player.getY) return;
            // for (int i = Math.Max(0, takerY - y - range); i < Math.Min(map.Length, takerY - y + range + 5); i++) {
            //     for (int j = Math.Max(0, takerX - x - range); j < Math.Min(map[0].Length, takerX - x + range + 5); j++) {
            //         //if (j!=player.getX-x&&j!=player.getX+1-x&&j!=player.getX+2-x&&j!=player.getX+3-x&&i!=player.getY-y&&i!=player.getY+1-y&&i!=player.getY+2-y&&i!=player.getY+3-y) {
            //             Console.SetCursorPosition(j+x,i+y);
            //             Console.Write(" ");
            //         //}
            //         for (int k = 0; k < enemies.Length; k++) {
            //             enemies[k].Clear();
            //         }
            //     }
            // }
            if (player.getX > takerX) {
                for (int i = 0; i < range*4+5 && takerY-y-range+i < map.Length+8; i++) {
                    Console.SetCursorPosition(Math.Max(0,takerX-x-range+5), Math.Max(0,takerY-y-range)+i);
                    Console.Write(" ");
                }
            } else if (player.getX < takerX) {
                for (int i = 0; i < range*4+5 && takerY-y-range+i < map.Length+8; i++) {
                    Console.SetCursorPosition(takerX-x+range+9, Math.Max(0,takerY-y-range)+i);
                    Console.Write(" ");
                }
            }

            if (player.getY < takerY) {
                for (int i = 0; i < range*4+5 && takerY-y+range*4+5+i < map[0].Length; i++) {
                    Console.SetCursorPosition(Math.Max(0,takerX-x-range)+i, takerY-y+range+9);
                    Console.Write(" ");
                }
            } else if (player.getY > takerY) {
                for (int i = 0; i < range*4+5 && takerY-y+range*4+5+i < map[0].Length+8; i++) {
                    Console.SetCursorPosition(Math.Max(0,takerX-x-range)+i, Math.Max(0,player.getY-y-range+4));
                    Console.Write(" ");
                }
            }

            for (int k = 0; k < enemies.Length; k++) {
                enemies[k].Clear();
            }
        }

        public void Update(int[][] map, Tank player, Tank[] enemies, int x, int y) {
            this.map = map;
            this.player = player;
            this.enemies = enemies;
            this.x = x;
            this.y = y;
        }
    }
}