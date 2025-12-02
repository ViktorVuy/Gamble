namespace GambleBusiness.Games;

public class Roulette
{
    Random rnd = new Random();
    int Number { get; set; }    //The winning number
    string Roulettenum { get; set; } //Number in a string
    string Color { get; set; }  //The color corresponding to the number (RED/BLACK/NONE)
    string Guess { get; set; }
    int[] Red = new int[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
    int[] Black = new int[] { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
    bool Even {  get; set; }
    int Credits { get; set; }
    public Roulette(int credits)
    {
        Credits = credits;
        Number = -1;
        Roulettenum = "";
        Color = "none";
        Guess = "none";
    }
    public string SetNumber()
    {
        Number = rnd.Next(0, 37);
        if(Number == 37)
            Roulettenum = "00";
        else
            Roulettenum = Number.ToString();
        if (Red.Contains(Number))
            Color = "red";
        else if (Black.Contains(Number))
            Color = "black";
        if (Number % 2 == 0 && Number != 0)
            Even = true;
        else if (Number % 2 != 0 && Number != 37)
            Even = false;
        return Roulettenum;
    }
    public void Bet()   //number, even/odd, black/red, 1-12/13-24/25-26
    {

    }
}