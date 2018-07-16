using Project.DB;
using System.Windows;
using Repository;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for StickyNoteForm.xaml
    /// </summary>
    public partial class StickyNoteForm : Window
    {

        public StickyNoteForm()
        {
            InitializeComponent();
        }

        public StickyNote NewStickyNote
        {
            get
            {
                return new StickyNote(
                    this.Title.Text,
                    this.Context.Text
                    );
            }
            set
            {
                var ctxt = new Context();
                Title.Text = value.Title;
                Context.Text = value.Content;
                value.Id= ctxt.StickyNotes.Where(
                    x => x.Title == Title.Text
                    && x.Content == Context.Text).SingleOrDefault().Id;


            }
        }

        public int Id { get; set; }
        

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }


        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

    }
}