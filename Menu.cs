namespace ToDo
{
    public static class Menu
    {
        static BoardActions BoardActions = new BoardActions();
        public static void Show()
        {

            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz\n*******************************************\n(1) Board Listelemek\n(2) Board'a Kart Eklemek\n(3) Board'dan Kart Silmek\n(4) Kart Taşımak");
            bool check = false;
            int selection = 0;
            while (!check || selection < 1 || selection > 5)
            {
                Console.Write("işlem numarasınız giriniz: ");
                check = int.TryParse(Console.ReadLine(), out selection);
                if (!check || selection < 1 || selection > 4)
                {
                    Console.WriteLine("Geçersiz giriş!");
                    check = false;
                }
            }
            switch (selection)
            {
                case 1:
                    BoardActions.ShowAllCards();
                    break;
                case 2:
                    BoardActions.AddBoard();
                    break;
                case 3:
                    BoardActions.DeleteCard();
                    break;
                case 4:
                    BoardActions.MoveCard();
                    break;
            }
        }
    }
}