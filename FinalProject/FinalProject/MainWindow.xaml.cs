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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            StickyNoteForm StickyNote = new StickyNoteForm();
            if ((bool)StickyNote.ShowDialog())
            {
                this.StickyNoteListBox.Items.Add(StickyNote.NewStickyNote);

                //Adding to Database
                var ctxt = new Context();
                ctxt.StickyNotes.Add(StickyNote.NewStickyNote);
                ctxt.SaveChanges();
                
            }
        }

        private void StickyNoteListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            /* OpenFileDialog openFileDialog = new OpenFileDialog();
                 string loadFileName = openFileDialog.FileName;
                 Load loadfile = new Load(File.ReadAllText(openFileDialog.FileName));
                 loadfile.ShowDialog();
             */
            if (this.StickyNoteListBox.SelectedItems != null)
            {
                {
                    var txt = new Context();
                    StickyNote SavedNote = StickyNoteListBox.SelectedItem as StickyNote;
                    StickyNoteForm StickyForm = new StickyNoteForm();

                    var note = txt.StickyNotes.Where(x => (x.Title == SavedNote.Title && x.Content == SavedNote.Content)).SingleOrDefault();

                    StickyForm.NewStickyNote = SavedNote;

                    if ((bool)StickyForm.ShowDialog())
                    {
                        StickyNoteListBox.Items.Remove(SavedNote);
                        using (var ctxt = new Context())
                        {
                            ctxt.Entry(note).State = System.Data.Entity.EntityState.Modified;
                            ctxt.SaveChanges();

                        }
                        StickyNoteListBox.Items.Add(StickyForm.NewStickyNote);
                    }

                    else
                    {
                        this.StickyNoteListBox.Items.Remove(SavedNote);

                        //Updating DataBase
                        using (var ctxt = new Context())
                        {
                            ctxt.Entry(note).State = System.Data.Entity.EntityState.Deleted;
                            ctxt.SaveChanges();
                        }
                    }
                }
            }
        }

            private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StickyNoteListBox.SelectedItem != null)
                StickyNoteListBox.Items.Remove(StickyNoteListBox.SelectedItem);
            else
                System.Windows.Forms.MessageBox.Show($"There is NO Note to be deleted !");
        }
    }
}
