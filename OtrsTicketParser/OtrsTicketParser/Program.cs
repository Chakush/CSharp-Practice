using OtrsTicketParser;
using System.Text;

string pathFile = "tickets.txt";

if (!File.Exists(pathFile))
{
    Console.WriteLine($"Файл {pathFile} не найден");
    return;
}

string[] tickets = File.ReadAllLines("tickets.txt");

Dictionary<char, string> translitMap = new Dictionary<char, string>
{
    {'а', "a"}, {'б', "b"}, {'в', "v"}, {'г', "g"}, {'д', "d"},
    {'е', "e"}, {'ё', "e"}, {'ж', "zh"}, {'з', "z"}, {'и', "i"},
    {'й', "y"}, {'к', "k"}, {'л', "l"}, {'м', "m"}, {'н', "n"},
    {'о', "o"}, {'п', "p"}, {'р', "r"}, {'с', "s"}, {'т', "t"},
    {'у', "u"}, {'ф', "f"}, {'х', "kh"}, {'ц', "ts"}, {'ч', "ch"},
    {'ш', "sh"}, {'щ', "shch"}, {'ъ', ""}, {'ы', "y"}, {'ь', ""},
    {'э', "e"}, {'ю', "yu"}, {'я', "ya"}, {'.', "."}
};

List<Ticket> parsedTicket = new List<Ticket>();

foreach (var ticket in tickets)
{
    string[] ticketText = ticket.Split(';');

    string[] fullname = ticketText[1].Split(' ');
    string clayLogin = fullname[1][0] + "." + fullname[0];
    var sb = new StringBuilder();

    foreach (char c in clayLogin.ToLower())//из русс в англ
    {
        if (translitMap.ContainsKey(c))
        {
            sb.Append(translitMap[c]);
        }
        else
        {
            sb.Append(c);
        }
    }
    clayLogin = sb.ToString();

    Ticket newTicket = new Ticket
    {
        Id = ticketText[0],
        Fullname = ticketText[1],
        Position = ticketText[2],
        Store = ticketText[3],
        Login = clayLogin
    };

    parsedTicket.Add(newTicket);
}

List<string> outputLines = new List<string>();

foreach (var outputTicket in parsedTicket)
{
    outputLines.Add($"{outputTicket.Id} | {outputTicket.Fullname} | {outputTicket.Position} | {outputTicket.Store} | Логин: {outputTicket.Login}");
}
File.WriteAllLines("ready_accounts.txt", outputLines);
Console.WriteLine("Готово\nДанные сохранены в ready_accounts.txt");