string[] tickets = {
    "TICKET-101;Иванов Иван;Кассир;Магазин 15",
    "TICKET-102;Смирнова Анна;Администратор;Магазин 42",
    "TICKET-103;Петров Алексей;Кладовщик;Магазин 08"
};

foreach (var ticket in tickets)
{
    string[] ticketText = ticket.Split(';');

    string[] fullname = ticketText[1].Split(' ');
    string clayLogin= fullname[1][0] + "." + fullname[0];

    Console.WriteLine($"Заявка:{ticketText[0]}\nЗаявитель:{ ticketText[1]} \nДолжность: {ticketText[2]} \nМагазин: {ticketText[3]}\nЛогин: {clayLogin.ToLower()}\n");
}
