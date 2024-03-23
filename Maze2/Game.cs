namespace Maze2
{
    /// <summary>
    /// Formuläret som vårt spel kommer att köras i
    /// </summary>
    public partial class Game : Form
    {
        /// <summary>
        /// Den första labyrinten som vår Pacman ska kämpa i.
        /// Siffrorna står för:
        /// 0 = Tomrum
        /// 1 = vägg
        /// 2 = prick
        /// 3 = Pacman
        /// 4 = spöke
        /// </summary>
        int[,] mazeOriginal1 =
        {
            { 1,1,1,1,1,1,1,1,1,1,1}, // 1
            { 1,5,2,2,2,4,2,2,2,5,1}, // 2
            { 1,2,1,1,1,2,1,1,1,2,1}, // 3
            { 1,2,1,2,2,2,2,2,1,2,1}, // 4
            { 1,2,2,2,1,1,1,2,2,2,1},
            { 1,2,1,2,2,2,2,2,1,2,1}, // 4
            { 1,2,1,1,1,3,1,1,1,2,1}, // 3
            { 1,5,2,2,2,2,2,2,2,5,1}, // 2
            { 1,1,1,1,1,1,1,1,1,1,1}  // 1
        };

        int[,] mazeOriginal2 =
{
            { 1,1,1,1,1,1,1,1,1,1,1}, // 1
            { 1,2,2,2,2,4,2,2,2,2,1}, // 2
            { 1,2,1,1,1,2,1,1,1,2,1}, // 3
            { 1,2,1,1,1,3,1,1,1,2,1}, // 3
            { 1,2,2,2,2,2,2,2,2,2,1}, // 2
            { 1,1,1,1,1,1,1,1,1,1,1}  // 1
        };

        /// <summary>
        /// Det här är en kopia av nuvarande labyrint och allt som körs
        /// kommer att ändra i denna. Inget av ändringarna kommer att
        /// påverka våra "original"-labyrinter.
        /// </summary>
        int[,] maze;

        /// <summary>
        /// En lista som ska innehålla alla labyrinter som vi skapat
        /// </summary>
        List<int[,]> mazes = new List<int[,]>();

        /// <summary>
        /// Vilken labyrint är aktiv just nu?
        /// </summary>
        int currentMaze = 0;

        /// <summary>
        /// Hur många prickar finns i nuvarande labyrint?
        /// </summary>
        int numDots = 0;

        /// <summary>
        /// Storleken på de grafikblock vi ritar ut
        /// OBS: const betyder alltså att det är en konstant och därmed
        /// inte kan ändras under tiden spelet körs.
        /// Varje block ska alltså vara 32 x 32 pixlar stort.
        /// </summary>
        const int _blockSize = 32;

        /// <summary>
        /// Konstanter som talar om vad siffrorna i labyrinten
        /// står för
        /// </summary>
        const int _empty = 0;
        const int _wall = 1;
        const int _dot = 2;
        const int _pacman = 3;
        const int _ghost = 4;
        const int _powerpellet = 5;
        /// <summary>
        /// Dessa konstanter används för att hålla koll på vilken riktning
        /// som spöken och Pacman ska röra sig.
        /// </summary>
        const int _noMotion = -1;
        const int _right = 0;
        const int _down = 1;
        const int _left = 2;
        const int _up = 3;


        int _elapsedPowerUpTime = 0;
        const int _maximumPowerUpTime = 20;
        bool _poweredUp = false;
        /// <summary>
        /// Pacmans X-position
        /// </summary>
        int pacmanX;

        /// <summary>
        /// Pacmans Y-position
        /// </summary>
        int pacmanY;

        /// <summary>
        /// Den riktning som Pacman färdas i
        /// </summary>
        int pacmanDirection = _noMotion;

        /// <summary>
        /// Lever Pacman?
        /// </summary>
        bool _alive = true;

        /// <summary>
        /// En lista som kommer att innehålla alla spöken
        /// som hittas i labyrinten
        /// </summary>
        List<Ghost> ghosts = new List<Ghost>();

        /// <summary>
        /// Spelarens poäng
        /// </summary>
        int score = 0;

        /// <summary>
        /// Grundformuläret som vårt spel körs i
        /// </summary>
        /// 
        
        public Game()
        {
            // Starta upp formuläret/fönstret
            InitializeComponent();

            // Lägg till de labyrinter vi har i en lista
            mazes.Add(mazeOriginal1);
            mazes.Add(mazeOriginal2);

            // Kopiera över nuvarande oringallabyrint till den som 
            // ska användas i spelkoden
            InitMaze();
        }

        /// <summary>
        /// Gör allt grundläggande för att skapa en labyrint
        /// som spelet kan köras i
        /// </summary>
        void InitMaze()
        {
            // Skapa en kopia av nuvarande labyrint. I den kommer
            // spelet att ändra och på så vis "förstöra" den.
            // För att få en ny/korrekt labyrint så överför vi allt
            // från originallabyrinten till denna.
            maze = new int[
                mazes[currentMaze].GetLength(0),
                mazes[currentMaze].GetLength(1)];

            // Rensa bort eventuella spöken som är aktiva från föregående
            // bana
            ghosts.Clear();

            // Gå igenom hela labyrinten:
            // Kopiera allt från originallabyrinten
            // Leta fram spöken och lägg till dem i deras lista
            // Leta fram Pacman och lägg data i hans variabler
            // Räkna antalet prickar i labyrinten
            for (int i = 0; i < maze.GetLength(1); i++)
            {
                for (int j = 0; j < maze.GetLength(0); j++)
                {
                    maze[j, i] = mazes[currentMaze][j, i];

                    // Är det ett spöke?
                    if (maze[j, i] == _ghost)
                    {
                        // Lägg till spöket i listan
                        AddGhost(i, j, 0, 2);

                        // Spöken lämnar alltid efter sig en prick när de
                        // startar så vi ökar antalet prickar i labyrinten
                        // för att kompensera för det
                        numDots++;
                    }

                    // Är det en Pacman? (Man kan bara ha en)
                    // Skulle det råka finnas två, så kommer det att
                    // bli den "sista" Pacmanen som blir den aktiva
                    // och eventuella som fanns före kommer bara
                    // att stå still i labyrinten. MEN om ett spöke
                    // går på en av kopiorna så kommer den aktiva
                    // Pacmannen att dö!
                    if (maze[j, i] == _pacman)
                    {
                        // Spara undan koordinaterna för Pacman
                        pacmanX = i;
                        pacmanY = j;
                    }

                    // Är det en prick?
                    if (maze[j, i] == _dot || maze[j, i] == _powerpellet)
                    {
                        // Öka på antalet prickar i labyrinten
                        numDots++;
                    }
                }
            }

            // Gå vidare till nästa labyrint. Det gör att nästa gång vi
            // kör InitMaze så kommer den att använda den nya labyrinten
            currentMaze++;

            // Har vi kommit över maxantalet labyrinter? I så fall
            // wrappar vi runt till 0. Finns det nåt bättre än modulo?
            currentMaze %= mazes.Count;
        }

        /// <summary>
        /// Ritar ut all vår grafik på skärmen. När vi kommer hit
        /// så är hela formuläret rensat, dvs det finns ingen grafik utritad
        /// Det gör att vi aldrig behöver rita ut nåt "tomrum" eftersom
        /// allt redan är tomt
        /// </summary>
        /// <param name="e">Här finns info om formuläret/fönstret</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Färgerna som vi ska använda oss av när vi ritar ut 
            // varje grej. SolidBrush är till för att göra helfyllda
            // saker.
            SolidBrush wall = new SolidBrush(Color.Blue);
            SolidBrush dot = new SolidBrush(Color.White);
            SolidBrush pacman = new SolidBrush(Color.Yellow);
            SolidBrush ghost = new SolidBrush(Color.Red);

            // Här tar vi ut data om vilket fönster vi ska
            // rita i. Den här metoden skulle kunna anropas av olika
            // fönster och då behöver man kunna hantera vilket fönster
            // som ska användas. I vårt spel kommer det aldrig att hända
            Graphics g = e.Graphics;
            
            // Vi gör loopar som går igenom hela labyrinten. Vi går igenom
            // rad för rad och på varje rad går vi genom alla kolumner
            // som finns på raden
            // Eftersom vår maze är tvådimensionell måste vi köra med
            // GetLength(vilken dimension vi vill ha). Det går alltså
            // inte att använda .length
            for (int i = 0; i < maze.GetLength(1); i++)
            {
                for (int j = 0; j < maze.GetLength(0); j++)
                {
                    // Är det en vägg?
                    if (maze[j, i] == _wall)
                    {
                        // Rita ut en rektangel i rätt färg.
                        g.FillRectangle(
                            wall,               // Färg
                            i * _blockSize,     // X-position till blockets vänstra kant
                                                // Varje block är _blocksize brett
                                                // och därför måste vi multiplicera
                                                // med den storleken för att komma
                                                // till nästa block.
                            j * _blockSize,     // Y-position till blockets översta kant
                            _blockSize,         // Bred
                            _blockSize          // Höjd
                            );
                    }

                    // Är det en prick?
                    if (maze[j, i] == _dot)
                    {
                        g.FillEllipse(
                            dot,
                            // Prickarna är hälften så stora som ett block.
                            // Vi räknar ut blocket precis som ovan
                            // sen lägger vi till ett fjärdedels block på
                            // positionen (det ska vara en fjärdedel på alla sidor
                            // eftersom vi ska rita ut en prick som är ett halft block)
                            i * _blockSize + (3 * _blockSize) / 8 ,
                            j * _blockSize + (3 * _blockSize) / 8,
                            // Fyll halva blockets storlek
                            _blockSize / 4,
                            _blockSize / 4
                            );
                    }
                    if (maze[j, i] == _powerpellet)
                    {
                        g.FillEllipse(
                            dot,
                            i * _blockSize + _blockSize / 4,
                            j * _blockSize + _blockSize / 4,
                            // Fyll halva blockets storlek
                            _blockSize / 2,
                            _blockSize / 2
                            );
                    }

                    // Är det Pacman?
                    if (maze[j, i] == _pacman)
                    {
                        // Rita en elips/cirkel som funkar precis som
                        // en vägg, förutom att den är rund
                        g.FillEllipse(
                            pacman,
                            i * _blockSize,
                            j * _blockSize,
                            _blockSize,
                            _blockSize
                            );
                    }

                    // Är det ett spöke?
                    if (maze[j, i] == _ghost)
                    {
                        // Rita först en cirkel som täcker hela blockstorleken
                        g.FillEllipse(
                            ghost,
                            i * _blockSize,
                            j * _blockSize,
                            _blockSize,
                            _blockSize
                            );

                        // Rita sedan en rektangel på nedre halvan av blocket
                        // Då blir det att påminna om ett spöke
                        g.FillRectangle(
                            ghost,
                            i * _blockSize,
                            j * _blockSize + _blockSize / 2,
                            _blockSize,
                            _blockSize / 2
                            );
                    }
                }
            }
        }

        /// <summary>
        /// Denna körs när en tangent tryckts ned.
        /// </summary>
        /// <param name="sender">Vad skapade den här händelsen? (Form1)</param>
        /// <param name="e">Data om händelsen (t.ex. vilken tangent som trycktes ned)</param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Om Pacman inte lever så skippar vi styrningen.
            if (!_alive)
            {
                return;
            }

            // Vi utgår från att Pacman står stilla
            // Om ingen av de korrekta tangenttesterna triggas,
            // så gäller detta och Pacman står stilla. Om någon
            // av testerna triggas skrivs _noMotion över
            // riktnignen
            pacmanDirection = _noMotion;

            // Vi kör WASD-styrning. 
            // Är A nedtryckt?
            if (e.KeyCode == Keys.A)
            {
                // I så fall ska vi åka åt vänster
                pacmanDirection = _left;
            }

            if (e.KeyCode == Keys.D)
            {
                pacmanDirection = _right;
            }

            if (e.KeyCode == Keys.W)
            {
                pacmanDirection = _up;
            }

            if (e.KeyCode == Keys.S)
            {
                pacmanDirection = _down;
            }
        }

        /// <summary>
        /// Denna körs med jämna mellanrum så att allt i spelet
        /// uppdateras samtidigt och med samma intervall
        /// Det är timer-komponenten i vårt formulär som gör att koden
        /// körs varje gång den räknat 100 ms
        /// </summary>
        /// <param name="sender">Vad orsakade händelsen? (Timer1)</param>
        /// <param name="e">Data om händelsen (inget vi bryr oss i)</param>
        /// 
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Först hanterar vi Pacman

            // Spara undan Pacmans nuvarande positione, innan vi kör
            // koden för rörelsen. Det som är nuvarande position blir
            // föregående position när Pacman väl flyttar på sig. Det är
            // alltså därför det heter oldX/oldY.
            // Om något stoppar Pacman från att röra sig, såsom en vägg,
            // kommer vi att flytta tillbaka Pacman tillbaka Pacman till
            // denna position. För vi vet ju att den föregående positionen
            // var OK och inte blockerad på någotvis.
            int oldX = pacmanX;
            int oldY = pacmanY;

            // Om Pacman lever så kör vi igenom koden som sköter honom
            // annars skippar vi koden och gå vidare med spökena
            if (_alive)
            {
                if (_poweredUp && _elapsedPowerUpTime < _maximumPowerUpTime)
                {
                    _elapsedPowerUpTime++;
                }

                if (_elapsedPowerUpTime == _maximumPowerUpTime)
                {
                    _poweredUp = false;
                    _elapsedPowerUpTime = 0;
                }

                // Vilken riktning har vi fått från keydown?
                if (pacmanDirection == _left)
                {
                    // För att gå vänster minskar vi på X-positionen
                    pacmanX--;
                }

                if (pacmanDirection == _right)
                {
                    // För att gå vänster ökar vi på X-positionen
                    pacmanX++;
                }

                if (pacmanDirection == _up)
                {
                    // För att gå upp minskar vi på Y-positionen
                    pacmanY--;
                }

                if (pacmanDirection == _down)
                {
                    // För att gå ned ökar vi på Y-positionen
                    pacmanY++;
                }

                // Krockade vi just med en vägg?
                // Vi kollar det genom att titta i arrayen på den
                // positionen vi just räknat ut i föregående rörelsekod
                if (maze[pacmanY, pacmanX] == _wall)
                {
                    // Vi krockade med en vägg, då ska Pacman
                    // gå tillbaka tills sin föregående position
                    pacmanX = oldX;
                    pacmanY = oldY;
                }

                // Ligger det en prick dit Pacman rör sig?
                if (maze[pacmanY, pacmanX] == _dot)
                {
                    // En prick!
                    // Öka poängen
                    score += 10;

                    // Minska hur många prickar det finns i labyrinten
                    numDots--;
                }
                if (maze[pacmanY, pacmanX] == _powerpellet)
                {
                    _poweredUp = true;
                    score += 50;
                    numDots--;
                }

                // Sätt ut ett tomrum där Pacman stod förut
                // Om Pacman flyttats tillbaka till oldX, oldY
                // så kommer det att läggas ut ett tomrum som 
                // direkt, i raden efter denna, läggs över med
                // en Pacman. För då är ju oldY/oldX lika med
                // pacmanX/pacmanY
                maze[oldY, oldX] = _empty;
                // Sätt ut Pacman på den nya positionen
                // eventuellt är detta samma som den position han
                // kom från om han flyttades tillbaka pga att
                // han krockade med en vägg.
                maze[pacmanY, pacmanX] = _pacman;

                // Visa den nya poängen
                this.Text = $"Score: {score}";

                // Om antalet prickar blivit noll, så är det dags
                // för nästa labyrint
                if (numDots == 0)
                {
                    // Vi skapar/läser/osv en ny labyrint
                    InitMaze();

                    // Eftersom det är en helt ny labyrint så skippar vi
                    // att köra spökena denna gång.
                    return;
                }
            }

            // Koden för att hantera spökena
            // Vi går igeom alla spökena i listan ett efter ett
            // och gör allt som ska göras för varje spöke innan
            // vi går vidare till nästa
            if (ghosts.Count != 0)
            {
                for (int i = ghosts.Count - 1; i >= 0; i--)
                {
                    // Spara undan nuvarande position. Precis som i fallet
                    // med Pacman så vill vi kunna flytta tillbaka spöket
                    // om det kolliderar med något
                    oldX = ghosts[i].x;
                    oldY = ghosts[i].y;

                    // Åt vilket håll är spöket på väg?

                    // Ska det åt höger?
                    if (ghosts[i].direction == _right)
                    {
                        // Höger betyder att vi ökar X-positionen
                        ghosts[i].x++;
                    }

                    if (ghosts[i].direction == _down)
                    {
                        ghosts[i].y++;
                    }

                    if (ghosts[i].direction == _left)
                    {
                        ghosts[i].x--;
                    }

                    if (ghosts[i].direction == _up)
                    {
                        ghosts[i].y--;
                    }

                    // Körde vi in i en Pacman?
                    if (maze[ghosts[i].y, ghosts[i].x] == _pacman && !_poweredUp)
                    {
                        // Döda Pacman
                        _alive = false;

                        // Ta bort Pacman från labyrinten
                        maze[pacmanY, pacmanX] = _empty;
                    }
                    else if (maze[ghosts[i].y, ghosts[i].x] == _pacman && _poweredUp)
                    {
                        maze[ghosts[i].y, ghosts[i].x] = _empty;
                        ghosts.RemoveAt(i);
                        continue;
                    }

                    // Har vi krockat med en vägg eller ett annat spöke?
                    if (maze[ghosts[i].y, ghosts[i].x] == _wall ||
                        maze[ghosts[i].y, ghosts[i].x] == _ghost)
                    {
                        // Flytta tillbaka spöket till den tidigare
                        // positionen
                        ghosts[i].x = oldX;
                        ghosts[i].y = oldY;

                        // Öka i vilken riktning spöket ska gå.
                        // Spöket kan röra sig i rikningarna som vi angav
                        // som konstanter i början av koden. Dvs, _right = 0,
                        // osv. Om spöket var på väg åt höger så ökar vi riktningen
                        // då blir den 1, vilket betyder att den ska gå neråt
                        // Osv...
                        ghosts[i].direction++;

                        // Vi har fyra möjliga riktningar. Om direction är över
                        // 3 (dvs, uppåt), så kommer vår kära modulo att göra så att den
                        // går över till 0.
                        ghosts[i].direction %= 4;
                    }

                    // Först av allt måste vi lägga tillbaka det som låg
                    // på spökets förra position. Annars skulle det "äta"
                    // upp saker som prickarna. leaveBehind sätt till att
                    // det är en prick när spöket skapas. Så första gången
                    // kommer spöket alltid att lämnan en prick efter sig.
                    maze[oldY, oldX] = ghosts[i].leaveBehind;

                    // Spara undan det som ligger på spökets nya position
                    // så vi inte äter/skriver över det.
                    ghosts[i].leaveBehind = maze[ghosts[i].y, ghosts[i].x];

                    // Sätt ut spöket på sin nya position
                    maze[ghosts[i].y, ghosts[i].x] = _ghost;
                }


                for (int i = ghosts.Count - 1; i >= 0; i--)
                {
                    // Spara undan nuvarande position. Precis som i fallet
                    // med Pacman så vill vi kunna flytta tillbaka spöket
                    // om det kolliderar med något
                    oldX = ghosts[i].x;
                    oldY = ghosts[i].y;

                    // Åt vilket håll är spöket på väg?

                    // Ska det åt höger?
                    if (ghosts[i].direction == _right)
                    {
                        // Höger betyder att vi ökar X-positionen
                        ghosts[i].x++;
                    }

                    if (ghosts[i].direction == _down)
                    {
                        ghosts[i].y++;
                    }

                    if (ghosts[i].direction == _left)
                    {
                        ghosts[i].x--;
                    }

                    if (ghosts[i].direction == _up)
                    {
                        ghosts[i].y--;
                    }

                    // Körde vi in i en Pacman?
                    if (maze[ghosts[i].y, ghosts[i].x] == _pacman && !_poweredUp)
                    {
                        // Döda Pacman
                        _alive = false;

                        // Ta bort Pacman från labyrinten
                        maze[pacmanY, pacmanX] = _empty;
                    }
                    else if (maze[ghosts[i].y, ghosts[i].x] == _pacman && _poweredUp)
                    {
                        maze[oldY, oldX] = _empty;
                        ghosts.RemoveAt(i);
                        continue;
                       
                    }

                    // Har vi krockat med en vägg eller ett annat spöke?
                    if (maze[ghosts[i].y, ghosts[i].x] == _wall ||
                        maze[ghosts[i].y, ghosts[i].x] == _ghost)
                    {
                        // Flytta tillbaka spöket till den tidigare
                        // positionen
                        ghosts[i].x = oldX;
                        ghosts[i].y = oldY;

                        // Öka i vilken riktning spöket ska gå.
                        // Spöket kan röra sig i rikningarna som vi angav
                        // som konstanter i början av koden. Dvs, _right = 0,
                        // osv. Om spöket var på väg åt höger så ökar vi riktningen
                        // då blir den 1, vilket betyder att den ska gå neråt
                        // Osv...
                        ghosts[i].direction++;

                        // Vi har fyra möjliga riktningar. Om direction är över
                        // 3 (dvs, uppåt), så kommer vår kära modulo att göra så att den
                        // går över till 0.
                        ghosts[i].direction %= 4;
                    }

                    // Först av allt måste vi lägga tillbaka det som låg
                    // på spökets förra position. Annars skulle det "äta"
                    // upp saker som prickarna. leaveBehind sätt till att
                    // det är en prick när spöket skapas. Så första gången
                    // kommer spöket alltid att lämnan en prick efter sig.
                    maze[oldY, oldX] = ghosts[i].leaveBehind;

                    // Spara undan det som ligger på spökets nya position
                    // så vi inte äter/skriver över det.
                    ghosts[i].leaveBehind = maze[ghosts[i].y, ghosts[i].x];

                    // Sätt ut spöket på sin nya position
                    maze[ghosts[i].y, ghosts[i].x] = _ghost;
                }
            }
            // Här tvingar vi Windows att rita om formuläret.
            // Då körs vår OnPaint-metod som ritar ut hela labyrinten 
            Invalidate();
        }

        /// <summary>
        /// Lägger in ett nytt spöke i spöklistan
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y postion</param>
        /// <param name="direction">Starting direction</param>
        /// <param name="leaveBehind">What to leave behind</param>
        void AddGhost(int x, int y, int direction, int leaveBehind)
        {
            // Vi skapar först ett nytt objekt från vår klass (Ghost)
            // Det kommer att bli satt till de defaultvärden vi har i
            // vår klass-fil.
            // Sen läggs det till i spöklistan direkt.
            ghosts.Add(new Ghost());

            // Vilket är det sista (och därmed senaste) spöket i listan?
            int lastGhost = ghosts.Count - 1;

            // Gör inställningar för spöket. De tar alltså från
            // de metodargumenten som skickas in till den här metoden
            ghosts[lastGhost].x = x;
            ghosts[lastGhost].y = y;
            ghosts[lastGhost].leaveBehind = leaveBehind;
            ghosts[lastGhost].direction = direction;
        }

        // När vi släpper upp en tangent ska Pacman sluta röra sig
        // Det här skulle nog kunna göras bättre, men...
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pacmanDirection = _noMotion;
        }
    }
}
