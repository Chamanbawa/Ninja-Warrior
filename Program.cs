using OOP_Final_assessment;
try
{
    Game game = new Game();
    game.Start();
}catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

