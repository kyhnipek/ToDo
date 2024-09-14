namespace ToDo
{
    public class Board
    {
        private string? header;
        private string? content;
        private int teamMember;
        private Size size;
        private Progress progress;

        public Board(string header, string content, int teamMember, Size size, Progress progress)
        {
            this.Header = header;
            this.Content = content;
            this.TeamMember = teamMember;
            this.Size = size;
            this.progress = progress;
        }

        public string Header { get => header; set => header = value; }
        public string Content { get => content; set => content = value; }
        public int TeamMember { get => teamMember; set => teamMember = value; }
        public Size Size { get => size; set => size = value; }
        public Progress Progress { get => progress; set => progress = value; }
    }
}