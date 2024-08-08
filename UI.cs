using PJ;

namespace UI {
    class GameUI {

        public void GameTitle(int x, int y) {
            Console.SetCursorPosition(x,y);
            Console.WriteLine("________________    _______   ____  __.    ___  ____ ________  ______ _______    ___             ____ ");
            Console.SetCursorPosition(x,y+1);
            Console.WriteLine("\\__    ___/  _  \\   \\      \\ |    |/ _|   /  / /_   /   __   \\/  __  \\\\   _  \\   \\  \\           /_   |");
            Console.SetCursorPosition(x,y+2);
            Console.WriteLine("  |    | /  /_\\  \\  /   |   \\|      <    /  /   |   \\____    />      </  /_\\  \\   \\  \\    ______ |   |");
            Console.SetCursorPosition(x,y+3);
            Console.WriteLine("  |    |/    |    \\/    |    \\    |  \\  (  (    |   |  /    //   --   \\  \\_/   \\   )  )  /_____/ |   |");
            Console.SetCursorPosition(x,y+4);
            Console.WriteLine("  |____|\\____|__  /\\____|__  /____|__ \\  \\  \\   |___| /____/ \\______  /\\_____  /  /  /           |___|");
            Console.SetCursorPosition(x,y+5);
            Console.WriteLine("                \\/         \\/        \\/   \\__\\                      \\/       \\/  /__/");
        }

        public void WinTitle(int x, int y) {
            Console.SetCursorPosition(x,y);
            Console.Write("_______  _____  __   _  ______  ______ _______ _______ _     _        _______ _______ _____  _____  __   _ _______   /   /   /");
            Console.SetCursorPosition(x,y+1);
            Console.Write("|       |     | | \\  | |  ____ |_____/ |_____|    |    |     | |      |_____|    |      |   |     | | \\  | |______  /   /   / ");
            Console.SetCursorPosition(x,y+2);
            Console.Write("|_____  |_____| |  \\_| |_____| |    \\_ |     |    |    |_____| |_____ |     |    |    __|__ |_____| |  \\_| ______| .   .   .  ");
        }

        public void GameOverTitle(int x, int y) {
            Console.SetCursorPosition(x,y);
            Console.Write("  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  ");
            Console.SetCursorPosition(x,y+1);
            Console.Write(" ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒");
            Console.SetCursorPosition(x,y+2);
            Console.Write("▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒");
            Console.SetCursorPosition(x,y+3);
            Console.Write("░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  ");
            Console.SetCursorPosition(x,y+4);
            Console.Write("░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒");
            Console.SetCursorPosition(x,y+5);
            Console.Write("░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░");
            Console.SetCursorPosition(x,y+6);
            Console.Write(" ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░");
            Console.SetCursorPosition(x,y+7);
            Console.Write("░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ ");
            Console.SetCursorPosition(x,y+8);
            Console.Write("     ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     ");
            Console.SetCursorPosition(x,y+9);
            Console.Write("                                                     ░                   ");
        }

        public void Square(int x, int y, int tx, int ty) {
            Console.SetCursorPosition(x,y);
            Console.Write("╔");
            Console.SetCursorPosition(x+tx,y);
            Console.Write("╗");
            Console.SetCursorPosition(x,y+ty);
            Console.Write("╚");
            Console.SetCursorPosition(x+tx,y+ty);
            Console.Write("╝");

            for (int i = 1; i < tx; i++) {
                Console.SetCursorPosition(x+i, y);
                Console.WriteLine("═");
                Console.SetCursorPosition(x+i, y+ty);
                Console.WriteLine("═");
            }

            for (int i = 1; i < ty; i++) {
                Console.SetCursorPosition(x, y+i);
                Console.WriteLine("║");
                Console.SetCursorPosition(x+tx, y+i);
                Console.WriteLine("║");
            }
        }

        public void TankLife(string n, int life, int x, int y) {
            string hearts="";

            if (life <= 0) hearts = "RIP";
            else {
                for (int i = 0; i < life; i+=10) {
                    hearts+="♥";
                }
            }

            Console.SetCursorPosition(x, y);
            Console.Write(n+":           ");
            Console.SetCursorPosition(x, y);
            Console.Write(n+": "+hearts);
        }

    }
}