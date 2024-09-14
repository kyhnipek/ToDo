namespace ToDo
{
    class BoardActions
    {
        public Dictionary<int, string> teamMembers = new Dictionary<int, string>();
        public List<Board> cards = new List<Board>();

        public BoardActions()
        {
            teamMembers.Add(0, "Murat Yılmaz");
            teamMembers.Add(1, "Bora Gencer");
            teamMembers.Add(2, "Arda Tosun");
            teamMembers.Add(3, "Aylin Toprak");
            cards.Add(new Board("Job", "todo", 1, Size.XS, Progress.todo));
            cards.Add(new Board("JobTwo", "todo", 2, Size.XS, Progress.inProgress));
            cards.Add(new Board("JobThree", "todo", 3, Size.XS, Progress.done));
        }
        public void ShowAllCards()
        {
            Console.WriteLine("TODO Line\n************************");
            GetcardsByProgress(Progress.todo);
            Console.WriteLine();
            Console.WriteLine("IN PROGRESS Line\n************************");
            GetcardsByProgress(Progress.inProgress);
            Console.WriteLine();
            Console.WriteLine("DONE Line\n************************");
            GetcardsByProgress(Progress.done);
            Menu.Show();
        }
        public void GetcardsByProgress(Progress progress)
        {
            foreach (var card in cards)
            {
                if (card.Progress == progress)
                    Console.WriteLine("Başlık      : {0}\nİçerik      : {1}\nAtanan Kişi : {2}\nBüyüklük    : {3}\n-", card.Header, card.Content, teamMembers[card.TeamMember], card.Size);
            }
        }
        public void AddBoard()
        {
            Console.Write("Başlık Giriniz                                  :");
            string header = Console.ReadLine();
            Console.Write("İçerik Giriniz                                  :");
            string content = Console.ReadLine();
            Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :");
            string size = Console.ReadLine();
            foreach (var member in teamMembers)
            {
                Console.WriteLine("({0}) {1}", member.Key, member.Value);
            }
            Console.Write("Kişi Seçiniz                                    :");
            int team = int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen eklemek istediğiniz Line'ı seçiniz   :\n(1) TODO \n(2) IN PROGRESS \n(3) DONE");
            string boardId = Console.ReadLine();
            cards.Add(new Board(header, content, team, (Size)Enum.Parse(typeof(Size), size, true), (Progress)Enum.Parse(typeof(Progress), boardId, true)));
            Menu.Show();
        }
        public string GetMemberByKey(int key)
        {
            teamMembers.TryGetValue(key, out string value);
            return value;

        }
        public void DeleteCard()
        {
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.Write("Lütfen kart başlığını yazınız: ");
            string query = Console.ReadLine().ToLower();
            foreach (var card in cards)
            {
                if (card.Header.ToLower() == query)
                {
                    cards.Remove(card);
                    break;
                }
                else
                {
                    Console.WriteLine(" Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* Silmeyi sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
                    int answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:
                            Menu.Show();
                            break;
                        case 2:
                            DeleteCard();
                            break;
                        default:
                            Menu.Show();
                            break;
                    }
                }
            }
        }
        public void MoveCard()
        {
            Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
            Console.Write("Lütfen kart başlığını yazınız: ");
            string query = Console.ReadLine().ToLower();
            foreach (var card in cards)
            {
                if (card.Header.ToLower() == query)
                {
                    Console.WriteLine("Bulunan Kart Bilgileri:\n**************************************\nBaşlık : {0}\nİçerik : {1}\nAtanan Kişi : {2}\nBüyüklük : {3}\nLine : {4}\nLütfen taşımak istediğiniz Line'ı seçiniz: \n(1) TODO \n(2) IN PROGRESS \n(3) DONE", card.Header, card.Content, teamMembers[card.TeamMember], card.Size, card.Progress);
                    string boardId = Console.ReadLine();
                    card.Progress = (Progress)Enum.Parse(typeof(Progress), boardId, true);
                }
                else
                {
                    Console.WriteLine(" Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* Taşımayı sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
                    int answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:
                            Menu.Show();
                            break;
                        case 2:
                            MoveCard();
                            break;
                        default:
                            Menu.Show();
                            break;
                    }
                }
            }
            Menu.Show();
        }

    }

}