using System;
using Project.DB;


namespace Project.DB
{
    public class StickyNote
    {
        [Obsolete("Only needed for serialization and materialization", true)]
        public StickyNote() { }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public StickyNote(string title, string context)
        {
            this.Title = title;
            this.Content = context;
        }

        public override string ToString() => $"{this.Title}";
    }
}
