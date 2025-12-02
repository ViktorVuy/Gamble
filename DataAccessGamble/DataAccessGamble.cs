namespace DataAccessGamble;

public class DataAccessGamble
{
    public string _connString { get; set; }
    /// <summary>
    /// Stelt connString in 
    /// </summary>
    public DataAccessGamble(string bestandsnaam)
    {
        _connString = bestandsnaam;
    }
    /// <summary>
    /// controlleer als bestand al bestaat
    /// </summary>
    /// <returns></returns>
    public bool ControleerBestandsnaam()
    {
        return File.Exists(_connString);
    }

    /// <summary>
    /// Een tekst wegsschrijven naar het bestand met bestandsNaam.
    /// </summary>
    public void OverWriteTekst(string tekst)
    {
        StreamWriter writer = new StreamWriter(_connString);
        writer.WriteLine(tekst);
        writer.Close();
    }
    public void OverWriteTekst(List<string> tekst)
    {
        StreamWriter writer = new StreamWriter(_connString);
        foreach (string tekstitem in tekst)
            writer.WriteLine(tekstitem);
        writer.Close();
    }
    /// <summary>
    /// Tekst toevoegen aan het bestaande bestand
    /// </summary>
    /// <param name="tekst"></param>
    public void AddTekst(string tekst)
    {
        StreamWriter writer = new StreamWriter(_connString, true);
        writer.WriteLine(tekst);
        writer.Close();
    }
    public void AddTekst(List<string> tekst)
    {
        StreamWriter writer = new StreamWriter(_connString, true);
        foreach (string tekstitem in tekst)
            writer.WriteLine(tekst);
        writer.Close();
    }
    /// <summary>
    /// leest alle inhoud van een bestand in als string
    /// </summary>
    public string ReadAllTekstToString()
    {
        string tekst = "";
        if (File.Exists(_connString))
        {
            StreamReader reader = new StreamReader(_connString);
            tekst = reader.ReadToEnd();
            reader.Close();
        }
        return tekst;
    }
    /// <summary>
    /// leest inhoud van bestand lijn per lijn in List zonder ledige lijnen
    /// </summary>
    public List<string> ReadAllTekstToList()
    {
        List<string> tekst = new List<string>();
        if (File.Exists(_connString))
        {
            StreamReader reader = new StreamReader(_connString);
            do
            {
                string line = reader.ReadLine();
                if (!string.IsNullOrEmpty(line)) tekst.Add(line);
            } while (!reader.EndOfStream);
            reader.Close();

        }
        return tekst;
    }
}
