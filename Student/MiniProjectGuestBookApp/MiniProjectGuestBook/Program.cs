using MiniProjectGuestBook;

GuestBook.GreetUser();

bool isDone = false;

while (!isDone)
{
    string name = GuestBook.GetPartyName();
    if (name.ToLower() == "done")
    {
        break;
    }
    int size = GuestBook.GetPartySize();
    GuestBook.AddPartyToBook(name, size);
}

GuestBook.PrintGuestBook();